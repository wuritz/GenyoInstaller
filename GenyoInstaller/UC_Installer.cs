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
        private Form1 parent;

        public UC_Installer(Form1 parentForm)
        {
            parent = parentForm;
            InitializeComponent();
        }

        private async void UC_Installer_Load(object sender, EventArgs e)
        {
            // Installed Version
            PathSearcher searcher = new();
            string dir = "";
            List<string> versions = new();

            dir = searcher.SearchMC();
            if (dir == string.Empty) dir = searcher.SearchPrism();
            if (dir == string.Empty)
            {
                lbInstalled.Text = "None";
            } else
            {
                if (Directory.Exists(dir))
                {
                    var files = Directory.EnumerateFiles(dir, "genyo-addon-*", SearchOption.AllDirectories);
                    if (files.Any())
                    {
                        foreach (var file in files)
                        {
                            string version = Path.GetFileName(file).Split("-")[2].Replace(".jar", "");
                            versions.Add(version);
                        }

                        Dictionary<string, int> versionsDict = new();

                        foreach (var version in versions)
                        {
                            if (versionsDict.ContainsKey(version))
                            {
                                versionsDict[version] += 1;
                            } else
                            {
                                versionsDict[version] = 1;
                            }
                        }

                        if (versionsDict.Count > 2)
                        {
                            lbInstalled.Text = "Multiple found.";
                        }
                        else
                        {
                            if (versionsDict.Count == 1)
                            {
                                lbInstalled.Text = $"{versionsDict.ElementAt(0).Key} ({versionsDict.ElementAt(0).Value})";
                            }
                            else lbInstalled.Text = $"{versionsDict.ElementAt(0).Key} ({versionsDict.ElementAt(0).Value}), ${versionsDict.ElementAt(1).Key} ({versionsDict.ElementAt(1).Value})";
                        }
                    }
                }
            }

            // Latest Version
            label3.Text = "Fetching...";

            string latestVersion = await GetLatestVersion();
            label3.Text = latestVersion;

            // lb Status
            if (versions.Contains(latestVersion))
                lbGenyoStatus.Text = "Genyo is up to date!";
            else if (versions.Count != 0)
                lbGenyoStatus.Text = "New Genyo is available!";
            else
                lbGenyoStatus.Text = "";
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

        public void Reload()
        {
            UC_Installer newInstaller = new UC_Installer(parent);
            parent.ReloadUCInstaller(newInstaller);
        }
    }
}
