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
            OutputInstances.Clear();
            foreach (string CurrentInstance in checkedListBox1.CheckedItems)
            {
                OutputInstances.Add(CurrentInstance);
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OutputInstances.Clear();
            Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }
    }
}
