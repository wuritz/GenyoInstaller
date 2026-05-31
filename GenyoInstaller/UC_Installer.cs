using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GenyoInstaller
{
    public partial class UC_Installer : UserControl
    {
        public bool installing = false;

        public UC_Installer()
        {
            InitializeComponent();
        }

        private async void UC_Installer_Load(object sender, EventArgs e)
        {
            // Version
            label3.Text = "Fetching...";

            string latestVersion = await GetLatestVersion();
            label3.Text = latestVersion;
        }

        private async Task<string> GetLatestVersion()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "GenyoAddon-Installer");

                    string url = $"https://api.github.com/repos/wuritz/genyo-addon/releases/latest";
                    string jsonResponse = await client.GetStringAsync(url);

                    Match match = Regex.Match(jsonResponse, @"""tag_name"":\s*""([^""]+)""");
                    if (match.Success)
                    {
                        return match.Groups[1].Value;
                    }

                    return "Unknown";
                }
            }
            catch
            {
                return "Offline";
            }
        }

        private void btnChangelogs_Click(object sender, EventArgs e)
        {
            openBrowser("https://genyo.dev/changelogs");
        }

        private void btnWebsite_Click(object sender, EventArgs e)
        {
            openBrowser("https://genyo.dev");
        }

        private void btnGitHub_Click(object sender, EventArgs e)
        {
            openBrowser("https://github.com/wuritz/genyo-addon");
        }

        private void btnDiscord_Click(object sender, EventArgs e)
        {
            openBrowser("https://genyo.dev/discord");
        }

        private void openBrowser(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show("Could not open the browser.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (installing)
            {
                MessageBox.Show("Currently installing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InstallerScript installerScript = new InstallerScript(this);
            installerScript.StartInstalling();
        }
    }
}
