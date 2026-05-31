namespace GenyoInstaller
{
    partial class UC_Options
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbSelectManually = new CheckBox();
            cbPrism = new CheckBox();
            SuspendLayout();
            // 
            // cbSelectManually
            // 
            cbSelectManually.AutoSize = true;
            cbSelectManually.Location = new Point(3, 12);
            cbSelectManually.Name = "cbSelectManually";
            cbSelectManually.Size = new Size(176, 19);
            cbSelectManually.TabIndex = 0;
            cbSelectManually.Text = "Manually select install folder";
            cbSelectManually.UseVisualStyleBackColor = true;
            cbSelectManually.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // cbPrism
            // 
            cbPrism.AutoSize = true;
            cbPrism.Location = new Point(3, 37);
            cbPrism.Name = "cbPrism";
            cbPrism.Size = new Size(229, 19);
            cbPrism.TabIndex = 1;
            cbPrism.Text = "Only look for PrismLauncher instances";
            cbPrism.UseVisualStyleBackColor = true;
            cbPrism.CheckedChanged += cbPrism_CheckedChanged;
            // 
            // UC_Options
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cbPrism);
            Controls.Add(cbSelectManually);
            Name = "UC_Options";
            Size = new Size(533, 246);
            Load += UC_Options_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbSelectManually;
        private CheckBox cbPrism;
    }
}
