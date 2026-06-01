using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.Json;
using System.Net.Http;

namespace GenyoInstaller
{
    internal class InstallerScript
    {
        private UC_Installer uc;
        UC_Options options;

        public InstallerScript(UC_Installer parentUC)
        {
            uc = parentUC;
        }

        public async void StartInstalling()
        {
            uc.installing = true;

            string dir = "";

            PathSearcher pathSearcher = new();

            if (uc.parent.explicitLauncher
                && uc.parent.selectedExplicitLauncher == UC_Options.LauncherTypes.PrismLauncher)
                dir = pathSearcher.SearchPrism();
            else
                dir = pathSearcher.SearchMC();

            if (dir == string.Empty)
            {
                CloseWithError("Couldn't find Minecraft nor PrismLauncher folder.");
                return;
            }

            if (pathSearcher.usingPrism)
                await InstallPrism(dir);
            else
                await InstallMC(dir);
        }

        private async Task InstallPrism(string PrismDir)
        {
            string InstancesDir = Path.Combine(PrismDir, "instances");

            if (!Directory.Exists(InstancesDir))
            {
                CloseWithError("Couldn't find 'instances' folder in Prism.");
                // handle manual select
                return;
            }

            List<string> InstancesList = new List<string>();

            foreach (string current in Directory.GetDirectories(InstancesDir))
            {
                string ModsDir = Path.Combine(current, "minecraft", "mods");

                if (!Directory.Exists(ModsDir))
                {
                    continue;
                }
                else
                {
                    if (!new PathSearcher().CheckForFabricMeteor(ModsDir) && !uc.parent.ignoreFabricMeteor) continue;
                    InstancesList.Add(Path.GetFileName(current));
                }
            }

            if (InstancesList.Count == 0)
            {
                CloseWithError("You don't have any Prism instances with modding enabled. Create an instance where you enable Fabric modding and install Meteor Client first!");
                return;
            }

            // we have instances
            Form_PrismInstanceSelector selector = new();
            selector.InputInstances = InstancesList;

            if (selector.ShowDialog() != DialogResult.OK)
            {
                CloseWithError("No instances were selected.");
                return;
            }

            List<string> SelectedInstances = selector.OutputInstances;

            if (SelectedInstances.Count == 0)
            {
                CloseWithError("No instances were selected.");
                return;
            }

            // Check for duplicates or older versions
            foreach (string Instance in SelectedInstances.ToList())
            {
                var files = Directory.EnumerateFiles(Path.Combine(InstancesDir, Instance, "minecraft", "mods"), $"genyo-addon-{uc.latestVersion}*", SearchOption.TopDirectoryOnly);
                if (files.Any())
                {
                    if (MessageBox.Show($"You already have the latest Genyo version installed in the '{Instance}' instance.\n\nDo you still want to proceed?", 
                        "Confirmation needed", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        SelectedInstances.Remove(Instance);
                    }
                }
            }

            // If we abort all of them
            if (SelectedInstances.Count == 0)
            {
                CloseWithError("No instances were selected.");
                return;
            }

            // download to a temp file
            Form_Progress form_Progress = new();
            form_Progress.Show();

            var progress = new Progress<(int percent, long bytesRead, long totalBytes)>(report => {
                form_Progress.SetProgress(report.percent, report.bytesRead, report.totalBytes);
            });

            string tempFile = await DownloadJarToTemp(progress);

            if (tempFile == null)
                return;

            // install to the instances
            foreach (string instance in SelectedInstances)
            {
                string instanceModsPath = Path.Combine(InstancesDir, instance, "minecraft", "mods");
                string destination = Path.Combine(instanceModsPath, Path.GetFileName(tempFile));
                File.Copy(tempFile, destination, overwrite: true);
            }

            // clean up the temp file
            File.Delete(tempFile);

            if (!form_Progress.IsDisposed)
                form_Progress.Close();

            MessageBox.Show("Genyo Addon installed successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            uc.installing = false;
            uc.Reload();
        }

        private async Task InstallMC(string mcDir)
        {
            string modsDir = Path.Combine(mcDir, "mods");
            if (!Directory.Exists(modsDir))
            {
                CloseWithError("Couldn't find 'mods' folder.");
                return;
            }

            if (!new PathSearcher().CheckForFabricMeteor(modsDir) && !uc.parent.ignoreFabricMeteor)
            {
                CloseWithError("You don't have Fabric or Meteor installed in your 'mods' folder. Please install them first!");
                return;
            }

            // check for duplicates
            var latestFiles = Directory.EnumerateFiles(modsDir, $"genyo-addon-{uc.latestVersion}*", SearchOption.TopDirectoryOnly);
            if (latestFiles.Any())
            {
                if (MessageBox.Show($"You already have the latest Genyo version installed. (Minecraft Launcher) \n\nDo you still want to proceed?",
                    "Confirmation needed",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    CloseWithError("Aborted.");
                    return;
                }
            }

            Form_Progress form_Progress = new();
            form_Progress.Show();

            var progress = new Progress<(int percent, long bytesRead, long totalBytes)>(report => {
                form_Progress.SetProgress(report.percent, report.bytesRead, report.totalBytes);
            });

            string tempFile = await DownloadJarToTemp(progress);

            if (tempFile == null)
                return;

            // install to mods folder
            string destination = Path.Combine(modsDir, Path.GetFileName(tempFile));
            File.Copy(tempFile, destination, overwrite: true);

            // clean up the temp file
            File.Delete(tempFile);

            if (!form_Progress.IsDisposed)
                form_Progress.Close();

            MessageBox.Show("Genyo Addon installed successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            uc.installing = false;
            uc.Reload();
        }

        private async Task<string> DownloadJarToTemp(IProgress<(int percent, long bytesRead, long totalBytes)> progress = null)
        {
            try
            {
                string currentVer = new Form1().CurrentVersion; // to avoid multiple form1 instances

                // Separate clients because of compression
                using HttpClient apiClient = new HttpClient();
                apiClient.DefaultRequestHeaders.UserAgent.Add(
                    new System.Net.Http.Headers.ProductInfoHeaderValue("GenyoInstaller", currentVer));

                using HttpClient downloadClient = new HttpClient(new HttpClientHandler
                {
                    AutomaticDecompression = System.Net.DecompressionMethods.None
                });
                downloadClient.DefaultRequestHeaders.UserAgent.Add(
                    new System.Net.Http.Headers.ProductInfoHeaderValue("GenyoInstaller", currentVer));

                // now the download
                string apiUrl = "https://api.github.com/repos/wuritz/genyo-addon/releases/latest";

                HttpResponseMessage response = await apiClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(json);
                JsonElement root = doc.RootElement;

                string jarDownloadUrl = null;
                string jarFileName = null;

                foreach (JsonElement asset in root.GetProperty("assets").EnumerateArray())
                {
                    string assetName = asset.GetProperty("name").GetString();
                    if (assetName.EndsWith(".jar", StringComparison.OrdinalIgnoreCase))
                    {
                        jarDownloadUrl = asset.GetProperty("browser_download_url").GetString();
                        jarFileName = assetName;
                        break;
                    }
                }

                if (jarDownloadUrl == null)
                {
                    CloseWithError("No JAR file found in the latest GitHub release.");
                    return null;
                }

                using HttpResponseMessage jarResponse = await downloadClient.GetAsync(jarDownloadUrl, HttpCompletionOption.ResponseHeadersRead);
                jarResponse.EnsureSuccessStatusCode();

                long? totalBytes = jarResponse.Content.Headers.ContentLength;
                string tempPath = Path.Combine(Path.GetTempPath(), jarFileName);

                using Stream contentStream = await jarResponse.Content.ReadAsStreamAsync();
                using FileStream fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None);

                byte[] buffer = new byte[8192];
                long bytesRead = 0;
                int read;

                while ((read = await contentStream.ReadAsync(buffer)) > 0)
                {
                    await fileStream.WriteAsync(buffer.AsMemory(0, read));
                    bytesRead += read;

                    if (totalBytes.HasValue)
                    {
                        int percent = (int)((double)bytesRead / totalBytes.Value * 100);
                        progress?.Report((percent, bytesRead, totalBytes.Value));
                    }
                }

                return tempPath;
            }
            catch (HttpRequestException ex)
            {
                CloseWithError($"Network error while downloading: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                CloseWithError($"Unexpected error: {ex.Message}");
                return null;
            }
        }

        private void CloseWithError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            uc.installing = false;
        }
    }
}
