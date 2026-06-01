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
            components = new System.ComponentModel.Container();
            cbSelectManually = new CheckBox();
            cbPrism = new CheckBox();
            cbIgnore = new CheckBox();
            tt_CB1 = new ToolTip(components);
            tt_CB2 = new ToolTip(components);
            tt_CB3 = new ToolTip(components);
            label1 = new Label();
            SuspendLayout();
            // 
            // cbSelectManually
            // 
            cbSelectManually.AutoSize = true;
            cbSelectManually.Location = new Point(3, 3);
            cbSelectManually.Name = "cbSelectManually";
            cbSelectManually.Size = new Size(196, 19);
            cbSelectManually.TabIndex = 0;
            cbSelectManually.Text = "Manually select the install folder";
            cbSelectManually.UseVisualStyleBackColor = true;
            cbSelectManually.CheckedChanged += cbSelectManually_CheckedChanged;
            // 
            // cbPrism
            // 
            cbPrism.AutoSize = true;
            cbPrism.Location = new Point(3, 28);
            cbPrism.Name = "cbPrism";
            cbPrism.Size = new Size(229, 19);
            cbPrism.TabIndex = 1;
            cbPrism.Text = "Only look for PrismLauncher instances";
            cbPrism.UseVisualStyleBackColor = true;
            cbPrism.CheckedChanged += cbPrism_CheckedChanged;
            // 
            // cbIgnore
            // 
            cbIgnore.AutoSize = true;
            cbIgnore.Location = new Point(3, 53);
            cbIgnore.Name = "cbIgnore";
            cbIgnore.Size = new Size(198, 19);
            cbIgnore.TabIndex = 2;
            cbIgnore.Text = "Ignore Fabric and Meteor checks";
            cbIgnore.UseVisualStyleBackColor = true;
            cbIgnore.CheckedChanged += cbIgnore_CheckedChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(396, 267);
            label1.Name = "label1";
            label1.Size = new Size(199, 15);
            label1.TabIndex = 3;
            label1.Text = "Hover on an option for more details.";
            // 
            // UC_Options
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(cbIgnore);
            Controls.Add(cbPrism);
            Controls.Add(cbSelectManually);
            Name = "UC_Options";
            Size = new Size(600, 286);
            Load += UC_Options_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbSelectManually;
        private CheckBox cbPrism;
        private CheckBox cbIgnore;
        private ToolTip tt_CB1;
        private ToolTip tt_CB2;
        private ToolTip tt_CB3;
        private Label label1;
    }
}
