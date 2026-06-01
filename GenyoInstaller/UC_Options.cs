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
        public bool SelectManually;
        public bool OnlyPrism;
        public bool IgnoreFM;

        public UC_Options()
        {
            InitializeComponent();
        }

        private void UC_Options_Load(object sender, EventArgs e)
        {
            SelectManually = cbSelectManually.Checked;
            OnlyPrism = cbPrism.Checked;
            IgnoreFM = cbIgnore.Checked;

            tt_CB1.SetToolTip(cbSelectManually, "Instead of the installer looking for folders, you decide where explicitly to install Genyo.");
            tt_CB2.SetToolTip(cbPrism, "The installer only looks for PrismLauncher instances, ignoring the '.minecraft' default folder that Minecraft Launcher uses");
            tt_CB3.SetToolTip(cbIgnore, "The installer blocks the download if it can't find Fabric or Meteor in your 'mods' folder. This ignores that check.");
        }

        private void cbPrism_CheckedChanged(object sender, EventArgs e)
        {
            OnlyPrism = cbPrism.Checked;
        }

        private void cbSelectManually_CheckedChanged(object sender, EventArgs e)
        {
            SelectManually = cbSelectManually.Checked;
        }

        private void cbIgnore_CheckedChanged(object sender, EventArgs e)
        {
            IgnoreFM = cbIgnore.Checked;
        }
    }
}
