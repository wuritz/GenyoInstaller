using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GenyoInstaller
{
    public partial class UC_Options : UserControl
    {
        private Form1 parentForm;

        public UC_Options(Form1 parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
        }

        private void UC_Options_Load(object sender, EventArgs e)
        {
            parentForm.manualInstallLocation = cbSelectManually.Checked;
            parentForm.explicitLauncher = cbOnlyLauncher.Checked;
            parentForm.ignoreFabricMeteor = cbIgnore.Checked;

            comboB_Launcher.SelectedItem = "Prism Launcher";
            //TODO: implement config | saved settings

            HandleExplicitLauncherChange();

            tt_CB1.SetToolTip(cbSelectManually, "Instead of the installer looking for folders, you decide where explicitly to install Genyo.");
            tt_OnlyInstall.SetToolTip(cbOnlyLauncher, "The installer only looks for the selected launcher's directories.");
            tt_CB3.SetToolTip(cbIgnore, "The installer blocks the download if it can't find Fabric or Meteor in your 'mods' folder. This ignores that check.");

            parentForm.uc_installer.RefreshLabels();
        }

        private void cbSelectManually_CheckedChanged(object sender, EventArgs e)
        {
            parentForm.manualInstallLocation = cbSelectManually.Checked;

            if (cbSelectManually.Checked)
            {
                if (MessageBox.Show("Note that enabling this completely skips any checks that ensure only valid install locations are used.\n\nDo you wish to proceed?",
                    "Confirmation needed",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    != DialogResult.Yes)
                {
                    parentForm.manualInstallLocation = false;
                    cbSelectManually.Checked = false;
                }
            }
        }

        private void cbIgnore_CheckedChanged(object sender, EventArgs e)
        {
            parentForm.ignoreFabricMeteor = cbIgnore.Checked;
        }

        private void cbOnlyLauncher_CheckedChanged(object sender, EventArgs e)
        {
            parentForm.explicitLauncher = cbOnlyLauncher.Checked;

            if (parentForm.explicitLauncher)
            {
                HandleExplicitLauncherChange();
            }

            parentForm.uc_installer.RefreshLabels();
        }

        private void comboB_Launcher_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleExplicitLauncherChange();
            parentForm.uc_installer.RefreshLabels();
        }

        private void HandleExplicitLauncherChange()
        {
            if (comboB_Launcher.SelectedIndex == 0)
            {
                parentForm.selectedExplicitLauncher = LauncherTypes.MinecraftLauncher;
            }
            else
            {
                parentForm.selectedExplicitLauncher = LauncherTypes.PrismLauncher;
            }
        }

        public enum LauncherTypes
        {
            MinecraftLauncher, PrismLauncher
        }
    }
}
