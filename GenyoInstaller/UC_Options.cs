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

        public UC_Options()
        {
            InitializeComponent();
        }

        private void UC_Options_Load(object sender, EventArgs e)
        {
            SelectManually = cbSelectManually.Checked;
            OnlyPrism = cbPrism.Checked;
        }

        private void cbPrism_CheckedChanged(object sender, EventArgs e)
        {
            SelectManually = cbSelectManually.Checked;
            OnlyPrism = cbPrism.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
