namespace PersistProClient {
    partial class RestoreSelector
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
            this.lnkLblBackupExplorer = new System.Windows.Forms.LinkLabel();
            this.lnkLblQuickRestore = new System.Windows.Forms.LinkLabel();
            this.lblWhereInfo = new System.Windows.Forms.Label();
            this.lnkLblMount = new System.Windows.Forms.LinkLabel();
            this.cmbBoxMount = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(153, 24);
            this.lblHeader.Text = "Restore: Step 1";
            // 
            // lnkLblBackupExplorer
            // 
            this.lnkLblBackupExplorer.AutoSize = true;
            this.lnkLblBackupExplorer.Enabled = false;
            this.lnkLblBackupExplorer.Location = new System.Drawing.Point(162, 98);
            this.lnkLblBackupExplorer.Name = "lnkLblBackupExplorer";
            this.lnkLblBackupExplorer.Size = new System.Drawing.Size(114, 13);
            this.lnkLblBackupExplorer.TabIndex = 5;
            this.lnkLblBackupExplorer.TabStop = true;
            this.lnkLblBackupExplorer.Text = "Open Backup Explorer";
            this.lnkLblBackupExplorer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // lnkLblQuickRestore
            // 
            this.lnkLblQuickRestore.AutoSize = true;
            this.lnkLblQuickRestore.Enabled = false;
            this.lnkLblQuickRestore.Location = new System.Drawing.Point(16, 98);
            this.lnkLblQuickRestore.Name = "lnkLblQuickRestore";
            this.lnkLblQuickRestore.Size = new System.Drawing.Size(123, 13);
            this.lnkLblQuickRestore.TabIndex = 4;
            this.lnkLblQuickRestore.TabStop = true;
            this.lnkLblQuickRestore.Text = "Perform a Quick Restore";
            this.lnkLblQuickRestore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // lblWhereInfo
            // 
            this.lblWhereInfo.AutoSize = true;
            this.lblWhereInfo.Location = new System.Drawing.Point(16, 34);
            this.lblWhereInfo.Name = "lblWhereInfo";
            this.lblWhereInfo.Size = new System.Drawing.Size(232, 13);
            this.lblWhereInfo.TabIndex = 1;
            this.lblWhereInfo.Text = "Where would you like to restore your data from?";
            // 
            // lnkLblMount
            // 
            this.lnkLblMount.AutoSize = true;
            this.lnkLblMount.Location = new System.Drawing.Point(299, 53);
            this.lnkLblMount.Name = "lnkLblMount";
            this.lnkLblMount.Size = new System.Drawing.Size(81, 13);
            this.lnkLblMount.TabIndex = 3;
            this.lnkLblMount.TabStop = true;
            this.lnkLblMount.Text = "Manage Where";
            this.lnkLblMount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // cmbBoxMount
            // 
            this.cmbBoxMount.DisplayMember = "Name";
            this.cmbBoxMount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxMount.FormattingEnabled = true;
            this.cmbBoxMount.Location = new System.Drawing.Point(19, 50);
            this.cmbBoxMount.Name = "cmbBoxMount";
            this.cmbBoxMount.Size = new System.Drawing.Size(274, 21);
            this.cmbBoxMount.TabIndex = 2;
            this.cmbBoxMount.SelectedIndexChanged += new System.EventHandler(this.cmbBoxMount_SelectedIndexChanged);
            // 
            // RestoreSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lnkLblMount);
            this.Controls.Add(this.cmbBoxMount);
            this.Controls.Add(this.lblWhereInfo);
            this.Controls.Add(this.lnkLblBackupExplorer);
            this.Controls.Add(this.lnkLblQuickRestore);
            this.Name = "RestoreSelector";
            this.Size = new System.Drawing.Size(382, 127);
            this.Load += new System.EventHandler(this.RestoreManager_Load);
            this.ParentChanged += new System.EventHandler(this.RestoreSelector_ParentChanged);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.lnkLblQuickRestore, 0);
            this.Controls.SetChildIndex(this.lnkLblBackupExplorer, 0);
            this.Controls.SetChildIndex(this.lblWhereInfo, 0);
            this.Controls.SetChildIndex(this.cmbBoxMount, 0);
            this.Controls.SetChildIndex(this.lnkLblMount, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkLblBackupExplorer;
        private System.Windows.Forms.LinkLabel lnkLblQuickRestore;
        private System.Windows.Forms.Label lblWhereInfo;
        private System.Windows.Forms.LinkLabel lnkLblMount;
        private System.Windows.Forms.ComboBox cmbBoxMount;

    }
}
