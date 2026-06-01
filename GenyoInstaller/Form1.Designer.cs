namespace GenyoInstaller
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label7 = new Label();
            label6 = new Label();
            tbOptions = new TabPage();
            tbInstaller = new TabPage();
            tabControl1 = new TabControl();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(95, 342);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 22;
            label7.Text = "label7";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(4, 342);
            label6.Name = "label6";
            label6.Size = new Size(92, 15);
            label6.TabIndex = 21;
            label6.Text = "Installer version:";
            // 
            // tbOptions
            // 
            tbOptions.Location = new Point(4, 24);
            tbOptions.Name = "tbOptions";
            tbOptions.Padding = new Padding(3);
            tbOptions.Size = new Size(591, 311);
            tbOptions.TabIndex = 1;
            tbOptions.Text = "Options";
            tbOptions.UseVisualStyleBackColor = true;
            // 
            // tbInstaller
            // 
            tbInstaller.Location = new Point(4, 24);
            tbInstaller.Name = "tbInstaller";
            tbInstaller.Padding = new Padding(3);
            tbInstaller.Size = new Size(591, 311);
            tbInstaller.TabIndex = 0;
            tbInstaller.Text = "Installer";
            tbInstaller.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tbInstaller);
            tabControl1.Controls.Add(tbOptions);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(599, 339);
            tabControl1.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(599, 361);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Genyo Installer";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label7;
        private Label label6;
        private TabPage tbOptions;
        private TabPage tbInstaller;
        private TabControl tabControl1;
    }
}
