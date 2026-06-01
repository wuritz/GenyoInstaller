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
            cbIgnore = new CheckBox();
            tt_CB1 = new ToolTip(components);
            tt_OnlyInstall = new ToolTip(components);
            tt_CB3 = new ToolTip(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboB_Launcher = new ComboBox();
            cbOnlyLauncher = new CheckBox();
            SuspendLayout();
            // 
            // cbSelectManually
            // 
            cbSelectManually.AutoSize = true;
            cbSelectManually.Location = new Point(6, 57);
            cbSelectManually.Name = "cbSelectManually";
            cbSelectManually.Size = new Size(196, 19);
            cbSelectManually.TabIndex = 0;
            cbSelectManually.Text = "Manually select the install folder";
            cbSelectManually.UseVisualStyleBackColor = true;
            cbSelectManually.CheckedChanged += cbSelectManually_CheckedChanged;
            // 
            // cbIgnore
            // 
            cbIgnore.AutoSize = true;
            cbIgnore.Location = new Point(6, 140);
            cbIgnore.Name = "cbIgnore";
            cbIgnore.Size = new Size(216, 19);
            cbIgnore.TabIndex = 2;
            cbIgnore.Text = "Ignore checks for Fabric and Meteor";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 9);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 4;
            label2.Text = "Install location";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 122);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 5;
            label3.Text = "Installation process";
            // 
            // comboB_Launcher
            // 
            comboB_Launcher.DropDownStyle = ComboBoxStyle.DropDownList;
            comboB_Launcher.Items.AddRange(new object[] { "Minecraft Launcher", "Prism Launcher" });
            comboB_Launcher.Location = new Point(195, 30);
            comboB_Launcher.Name = "comboB_Launcher";
            comboB_Launcher.Size = new Size(148, 23);
            comboB_Launcher.TabIndex = 6;
            comboB_Launcher.SelectedIndexChanged += comboB_Launcher_SelectedIndexChanged;
            // 
            // cbOnlyLauncher
            // 
            cbOnlyLauncher.AutoSize = true;
            cbOnlyLauncher.Checked = true;
            cbOnlyLauncher.CheckState = CheckState.Checked;
            cbOnlyLauncher.Location = new Point(6, 32);
            cbOnlyLauncher.Name = "cbOnlyLauncher";
            cbOnlyLauncher.Size = new Size(183, 19);
            cbOnlyLauncher.TabIndex = 7;
            cbOnlyLauncher.Text = "Only install into this launcher:";
            cbOnlyLauncher.UseVisualStyleBackColor = true;
            cbOnlyLauncher.CheckedChanged += cbOnlyLauncher_CheckedChanged;
            // 
            // UC_Options
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cbOnlyLauncher);
            Controls.Add(comboB_Launcher);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbIgnore);
            Controls.Add(cbSelectManually);
            Name = "UC_Options";
            Size = new Size(600, 286);
            Load += UC_Options_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbSelectManually;
        private CheckBox cbIgnore;
        private ToolTip tt_CB1;
        private ToolTip tt_OnlyInstall;
        private ToolTip tt_CB3;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboB_Launcher;
        private CheckBox cbOnlyLauncher;
    }
}
