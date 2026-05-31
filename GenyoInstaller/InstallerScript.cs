using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace GenyoInstaller
{
    internal class InstallerScript
    {
        private UC_Installer uc;
        UC_Options options;

        private bool UsingPrism = false;

        public InstallerScript(UC_Installer parentUC)
        {
            uc = parentUC; 
            options = new UC_Options();
        }

        public void StartInstalling()
        {
            uc.installing = true;

            // Find MC folder
            // Find PrismLauncher too
            // Select between MC and Prism
            //      Select Prism profile if needed
            // Find Meteor folder
            // Make sure Fabric is installed
            // Find mods folder
            // Download .jar from GitHub
            // Install .jar
            // Show done msgbox

            string dir = "";

            if (options.OnlyPrism)
            {
                dir = SearchPrism();
            } else
            {
                dir = SearchMC();
            }

            if (dir == string.Empty)
            {
                CloseWithError("Couldn't find Minecraft nor PrismLauncher folder.");
                return;
            }

            if (UsingPrism)
            {
                InstallPrism(dir);
            } else
            {
                InstallMC();
            }
        }

        private void InstallPrism(string PrismDir)
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
                string ModsDir = Path.Combine(Path.Combine(current, "minecraft"), "mods");

                if (!Directory.Exists(ModsDir))
                {
                    continue;
                } else
                {
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

            List<string> SelectedInstances = new();
            
            if (selector.ShowDialog() == DialogResult.OK)
            {
                SelectedInstances = selector.OutputInstances;

                if (SelectedInstances.Count == 0)
                {
                    CloseWithError("No instances were selected.");
                    return;
                }

                foreach (string selected in SelectedInstances)
                {
                    MessageBox.Show(selected);
                }
            }
        }

        private void InstallMC()
        {

        }

        private string SearchMC()
        {
            string outputDir = "";
            string dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft"
            );
            
            if (!Directory.Exists(dir))
            {
                // look for prism
                string prismDir = SearchPrism();

                if (prismDir == string.Empty || prismDir == null)
                {
                    // handle manual select
                    return string.Empty;
                }

                UsingPrism = true;
                outputDir = prismDir;
            } else
            {
                outputDir = dir;
            }

            return outputDir;
        }

        private string SearchPrism()
        {
            string outputDir = "";
            string dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PrismLauncher"
            );

            if (!Directory.Exists(dir))
            {
                return string.Empty;
            } else
            {
                outputDir = dir;
            }

            return outputDir;
        }

        private void ErrorMSGBox(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CloseWithError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            uc.installing = false;
        }
    }
}
