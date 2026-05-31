using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GenyoInstaller
{
    public partial class Form_PrismInstanceSelector : Form
    {
        public List<string> InputInstances = new();
        public List<string> OutputInstances = new();

        public Form_PrismInstanceSelector()
        {
            InitializeComponent();
        }

        private void Form_PrismInstanceSelector_Load(object sender, EventArgs e)
        {
            foreach (string CurrentInstance in InputInstances)
            {
                checkedListBox1.Items.Add(CurrentInstance, false);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (string CurrentInstance in checkedListBox1.CheckedItems)
            {
                OutputInstances.Add(CurrentInstance);
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            
        }
    }
}
