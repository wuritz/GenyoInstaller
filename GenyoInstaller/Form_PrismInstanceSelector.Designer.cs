namespace GenyoInstaller
{
    partial class Form_PrismInstanceSelector
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            checkedListBox1 = new CheckedListBox();
            label2 = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            btnSelectAll = new Button();
            btnDeselectAll = new Button();
            lbFabricMeteor = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 10);
            label1.Name = "label1";
            label1.Size = new Size(226, 15);
            label1.TabIndex = 0;
            label1.Text = "Select which instances to install Genyo in:";
            // 
            // checkedListBox1
            // 
            checkedListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(8, 28);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(444, 220);
            checkedListBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(12, 303);
            label2.Name = "label2";
            label2.Size = new Size(297, 15);
            label2.TabIndex = 2;
            label2.Text = "Remember Genyo's MC version and select accordingly.";
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(377, 339);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 3;
            btnOK.Text = "&OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(296, 339);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSelectAll.Location = new Point(9, 258);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(90, 23);
            btnSelectAll.TabIndex = 5;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = true;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // btnDeselectAll
            // 
            btnDeselectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeselectAll.Location = new Point(105, 258);
            btnDeselectAll.Name = "btnDeselectAll";
            btnDeselectAll.Size = new Size(85, 23);
            btnDeselectAll.TabIndex = 5;
            btnDeselectAll.Text = "Deselect All";
            btnDeselectAll.UseVisualStyleBackColor = true;
            btnDeselectAll.Click += btnDeselectAll_Click;
            // 
            // lbFabricMeteor
            // 
            lbFabricMeteor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbFabricMeteor.AutoSize = true;
            lbFabricMeteor.BackColor = Color.LightCoral;
            lbFabricMeteor.Location = new Point(12, 284);
            lbFabricMeteor.Name = "lbFabricMeteor";
            lbFabricMeteor.Size = new Size(366, 15);
            lbFabricMeteor.TabIndex = 6;
            lbFabricMeteor.Text = "You won't see instances which don't have Fabric or Meteor installed.";
            // 
            // Form_PrismInstanceSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 374);
            Controls.Add(lbFabricMeteor);
            Controls.Add(btnDeselectAll);
            Controls.Add(btnSelectAll);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(label2);
            Controls.Add(checkedListBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form_PrismInstanceSelector";
            Text = "Select a Prism Instance";
            Load += Form_PrismInstanceSelector_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckedListBox checkedListBox1;
        private Label label2;
        private Button btnOK;
        private Button btnCancel;
        private Button btnSelectAll;
        private Button btnDeselectAll;
        private Label lbFabricMeteor;
    }
}