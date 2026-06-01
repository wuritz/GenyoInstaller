using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GenyoInstaller
{
    public partial class Form_Progress : Form
    {
        public Form_Progress()
        {
            InitializeComponent();
        }

        public void SetProgress(int percent, long bytesRead, long totalBytes)
        {
            if (percent < progressBar1.Maximum)
            {
                progressBar1.Value = percent + 1;
                progressBar1.Value = percent;
            }
            else
            {
                progressBar1.Value = progressBar1.Maximum;
            }

            label2.Text = $"{FormatBytes(bytesRead)} / {FormatBytes(totalBytes)}";
        }

        private string FormatBytes(long bytes)
        {
            if (bytes >= 1024 * 1024)
                return $"{bytes / (1024.0 * 1024.0):F1} MB";
            else if (bytes >= 1024)
                return $"{bytes / 1024.0:F1} KB";
            else
                return $"{bytes} B";
        }
    }
}
