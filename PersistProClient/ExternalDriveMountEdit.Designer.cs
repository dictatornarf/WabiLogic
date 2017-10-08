namespace PersistProClient {
    partial class ExternalDriveMountEdit {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblName = new System.Windows.Forms.Label();
            this.txtBoxFolderName = new System.Windows.Forms.TextBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblLabels = new System.Windows.Forms.Label();
            this.cmbBoxLabels = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(289, 24);
            this.lblHeader.Text = "Define Where (External Drive)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 47);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // txtBoxFolderName
            // 
            this.txtBoxFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxFolderName.Location = new System.Drawing.Point(16, 160);
            this.txtBoxFolderName.Name = "txtBoxFolderName";
            this.txtBoxFolderName.Size = new System.Drawing.Size(328, 20);
            this.txtBoxFolderName.TabIndex = 7;
            // 
            // txtBoxName
            // 
            this.txtBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxName.Location = new System.Drawing.Point(16, 63);
            this.txtBoxName.MaxLength = 60;
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(328, 20);
            this.txtBoxName.TabIndex = 2;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(13, 144);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(67, 13);
            this.lblPath.TabIndex = 6;
            this.lblPath.Text = "Folder Name";
            // 
            // lblLabels
            // 
            this.lblLabels.AutoSize = true;
            this.lblLabels.Location = new System.Drawing.Point(13, 95);
            this.lblLabels.Name = "lblLabels";
            this.lblLabels.Size = new System.Drawing.Size(102, 13);
            this.lblLabels.TabIndex = 3;
            this.lblLabels.Text = "External Drive Label";
            // 
            // cmbBoxLabels
            // 
            this.cmbBoxLabels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxLabels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxLabels.FormattingEnabled = true;
            this.cmbBoxLabels.Location = new System.Drawing.Point(16, 111);
            this.cmbBoxLabels.Name = "cmbBoxLabels";
            this.cmbBoxLabels.Size = new System.Drawing.Size(328, 21);
            this.cmbBoxLabels.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(350, 111);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ExternalDriveMountEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbBoxLabels);
            this.Controls.Add(this.lblLabels);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtBoxFolderName);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.lblPath);
            this.Name = "ExternalDriveMountEdit";
            this.Size = new System.Drawing.Size(434, 199);
            this.Load += new System.EventHandler(this.ExternalDriveMountEdit_Load);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.lblPath, 0);
            this.Controls.SetChildIndex(this.txtBoxName, 0);
            this.Controls.SetChildIndex(this.txtBoxFolderName, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblLabels, 0);
            this.Controls.SetChildIndex(this.cmbBoxLabels, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtBoxFolderName;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblLabels;
        private System.Windows.Forms.ComboBox cmbBoxLabels;
        private System.Windows.Forms.Button btnRefresh;
    }
}
