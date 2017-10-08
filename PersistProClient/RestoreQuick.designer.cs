namespace PersistProClient {
    partial class RestoreQuick
    {
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
            this.lblChooseRoot = new System.Windows.Forms.Label();
            this.lblRestoreLocation = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRestore = new System.Windows.Forms.Button();
            this.cmbSelectRoot = new System.Windows.Forms.ComboBox();
            this.bgwkrRestore = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(142, 24);
            this.lblHeader.Text = "Quick Restore";
            // 
            // lblChooseRoot
            // 
            this.lblChooseRoot.AutoSize = true;
            this.lblChooseRoot.Location = new System.Drawing.Point(10, 44);
            this.lblChooseRoot.Name = "lblChooseRoot";
            this.lblChooseRoot.Size = new System.Drawing.Size(186, 13);
            this.lblChooseRoot.TabIndex = 1;
            this.lblChooseRoot.Text = "Choose the folder you want to restore.";
            // 
            // lblRestoreLocation
            // 
            this.lblRestoreLocation.AutoSize = true;
            this.lblRestoreLocation.Location = new System.Drawing.Point(10, 88);
            this.lblRestoreLocation.Name = "lblRestoreLocation";
            this.lblRestoreLocation.Size = new System.Drawing.Size(209, 13);
            this.lblRestoreLocation.TabIndex = 3;
            this.lblRestoreLocation.Text = "Restore My Files to the Following Location:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(299, 101);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxPath.Location = new System.Drawing.Point(13, 104);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.Size = new System.Drawing.Size(280, 20);
            this.txtBoxPath.TabIndex = 4;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(13, 131);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(109, 23);
            this.btnRestore.TabIndex = 6;
            this.btnRestore.Text = "Restore My Data";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // cmbSelectRoot
            // 
            this.cmbSelectRoot.DisplayMember = "Name";
            this.cmbSelectRoot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectRoot.FormattingEnabled = true;
            this.cmbSelectRoot.Location = new System.Drawing.Point(13, 60);
            this.cmbSelectRoot.Name = "cmbSelectRoot";
            this.cmbSelectRoot.Size = new System.Drawing.Size(280, 21);
            this.cmbSelectRoot.TabIndex = 2;
            // 
            // RestoreQuick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.cmbSelectRoot);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtBoxPath);
            this.Controls.Add(this.lblRestoreLocation);
            this.Controls.Add(this.lblChooseRoot);
            this.Name = "RestoreQuick";
            this.Size = new System.Drawing.Size(380, 330);
            this.Load += new System.EventHandler(this.RestoreQuick_Load);
            this.ParentChanged += new System.EventHandler(this.RestoreQuick_ParentChanged);
            this.Controls.SetChildIndex(this.lblChooseRoot, 0);
            this.Controls.SetChildIndex(this.lblRestoreLocation, 0);
            this.Controls.SetChildIndex(this.txtBoxPath, 0);
            this.Controls.SetChildIndex(this.btnBrowse, 0);
            this.Controls.SetChildIndex(this.btnRestore, 0);
            this.Controls.SetChildIndex(this.cmbSelectRoot, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChooseRoot;
        private System.Windows.Forms.Label lblRestoreLocation;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBoxPath;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ComboBox cmbSelectRoot;
        private System.ComponentModel.BackgroundWorker bgwkrRestore;
    }
}
