namespace GenyoInstaller
{
    partial class UC_Installer
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
            btnDiscord = new Button();
            btnWebsite = new Button();
            btnChangelogs = new Button();
            btnGitHub = new Button();
            label3 = new Label();
            label2 = new Label();
            btnInstall = new Button();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnDiscord
            // 
            btnDiscord.Location = new Point(492, 99);
            btnDiscord.Name = "btnDiscord";
            btnDiscord.Size = new Size(75, 28);
            btnDiscord.TabIndex = 15;
            btnDiscord.Text = "Discord";
            btnDiscord.UseVisualStyleBackColor = true;
            btnDiscord.Click += btnDiscord_Click;
            // 
            // btnWebsite
            // 
            btnWebsite.Location = new Point(492, 65);
            btnWebsite.Name = "btnWebsite";
            btnWebsite.Size = new Size(75, 28);
            btnWebsite.TabIndex = 16;
            btnWebsite.Text = "Website";
            btnWebsite.UseVisualStyleBackColor = true;
            btnWebsite.Click += btnWebsite_Click;
            // 
            // btnChangelogs
            // 
            btnChangelogs.Location = new Point(17, 174);
            btnChangelogs.Name = "btnChangelogs";
            btnChangelogs.Size = new Size(108, 28);
            btnChangelogs.TabIndex = 17;
            btnChangelogs.Text = "View Changelogs";
            btnChangelogs.UseVisualStyleBackColor = true;
            btnChangelogs.Click += btnChangelogs_Click;
            // 
            // btnGitHub
            // 
            btnGitHub.Location = new Point(492, 31);
            btnGitHub.Name = "btnGitHub";
            btnGitHub.Size = new Size(75, 28);
            btnGitHub.TabIndex = 18;
            btnGitHub.Text = "GitHub";
            btnGitHub.UseVisualStyleBackColor = true;
            btnGitHub.Click += btnGitHub_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(17, 146);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 14;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 127);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 13;
            label2.Text = "Latest version:";
            // 
            // btnInstall
            // 
            btnInstall.Font = new Font("Segoe UI", 12F);
            btnInstall.Location = new Point(377, 229);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new Size(190, 48);
            btnInstall.TabIndex = 12;
            btnInstall.Text = "Install Genyo";
            btnInstall.UseVisualStyleBackColor = true;
            btnInstall.Click += btnInstall_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.genyo512;
            pictureBox1.Location = new Point(17, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(94, 91);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 22F);
            label4.Location = new Point(127, 43);
            label4.Name = "label4";
            label4.Size = new Size(203, 41);
            label4.TabIndex = 10;
            label4.Text = "Genyo Addon";
            // 
            // UC_Installer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(btnDiscord);
            Controls.Add(btnWebsite);
            Controls.Add(btnChangelogs);
            Controls.Add(btnGitHub);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnInstall);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Name = "UC_Installer";
            Size = new Size(587, 306);
            Load += UC_Installer_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnDiscord;
        private Button btnWebsite;
        private Button btnChangelogs;
        private Button btnGitHub;
        private Label label3;
        private Label label2;
        private Button btnInstall;
        private PictureBox pictureBox1;
        private Label label4;
    }
}
