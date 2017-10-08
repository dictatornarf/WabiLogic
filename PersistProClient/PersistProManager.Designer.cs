namespace PersistProClient {
    partial class PersistProManager {
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
            this.lnkLblBackupPlan = new System.Windows.Forms.LinkLabel();
            this.lnkLblWhat = new System.Windows.Forms.LinkLabel();
            this.lnkLblWhere = new System.Windows.Forms.LinkLabel();
            this.lnkLblWhen = new System.Windows.Forms.LinkLabel();
            this.lnkLblRestoreFromBackup = new System.Windows.Forms.LinkLabel();
            this.lnkLblStatus = new System.Windows.Forms.LinkLabel();
            this.lblActions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(139, 24);
            this.lblHeader.Text = "Backup Tasks";
            // 
            // lnkLblBackupPlan
            // 
            this.lnkLblBackupPlan.AutoSize = true;
            this.lnkLblBackupPlan.Location = new System.Drawing.Point(13, 141);
            this.lnkLblBackupPlan.Name = "lnkLblBackupPlan";
            this.lnkLblBackupPlan.Size = new System.Drawing.Size(115, 13);
            this.lnkLblBackupPlan.TabIndex = 4;
            this.lnkLblBackupPlan.TabStop = true;
            this.lnkLblBackupPlan.Text = "Manage Backup Plans";
            this.lnkLblBackupPlan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblBackupPlan_LinkClicked);
            // 
            // lnkLblWhat
            // 
            this.lnkLblWhat.AutoSize = true;
            this.lnkLblWhat.Location = new System.Drawing.Point(33, 163);
            this.lnkLblWhat.Name = "lnkLblWhat";
            this.lnkLblWhat.Size = new System.Drawing.Size(151, 13);
            this.lnkLblWhat.TabIndex = 5;
            this.lnkLblWhat.TabStop = true;
            this.lnkLblWhat.Text = "What do you want to backup?";
            this.lnkLblWhat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblWhat_LinkClicked);
            // 
            // lnkLblWhere
            // 
            this.lnkLblWhere.AutoSize = true;
            this.lnkLblWhere.Location = new System.Drawing.Point(33, 185);
            this.lnkLblWhere.Name = "lnkLblWhere";
            this.lnkLblWhere.Size = new System.Drawing.Size(204, 13);
            this.lnkLblWhere.TabIndex = 6;
            this.lnkLblWhere.TabStop = true;
            this.lnkLblWhere.Text = "Where do you want to backup your data?";
            this.lnkLblWhere.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblWhere_LinkClicked);
            // 
            // lnkLblWhen
            // 
            this.lnkLblWhen.AutoSize = true;
            this.lnkLblWhen.Location = new System.Drawing.Point(33, 209);
            this.lnkLblWhen.Name = "lnkLblWhen";
            this.lnkLblWhen.Size = new System.Drawing.Size(207, 13);
            this.lnkLblWhen.TabIndex = 7;
            this.lnkLblWhen.TabStop = true;
            this.lnkLblWhen.Text = "When do you want your backup to occur?";
            this.lnkLblWhen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblWhen_LinkClicked);
            // 
            // lnkLblRestoreFromBackup
            // 
            this.lnkLblRestoreFromBackup.AutoSize = true;
            this.lnkLblRestoreFromBackup.Location = new System.Drawing.Point(13, 68);
            this.lnkLblRestoreFromBackup.Name = "lnkLblRestoreFromBackup";
            this.lnkLblRestoreFromBackup.Size = new System.Drawing.Size(84, 13);
            this.lnkLblRestoreFromBackup.TabIndex = 2;
            this.lnkLblRestoreFromBackup.TabStop = true;
            this.lnkLblRestoreFromBackup.Text = "Restore Backup";
            this.lnkLblRestoreFromBackup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblRestoreFromBackup_LinkClicked);
            // 
            // lnkLblStatus
            // 
            this.lnkLblStatus.AutoSize = true;
            this.lnkLblStatus.Location = new System.Drawing.Point(13, 45);
            this.lnkLblStatus.Name = "lnkLblStatus";
            this.lnkLblStatus.Size = new System.Drawing.Size(106, 13);
            this.lnkLblStatus.TabIndex = 1;
            this.lnkLblStatus.TabStop = true;
            this.lnkLblStatus.Text = "View Status / History";
            this.lnkLblStatus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblStatus_LinkClicked);
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActions.Location = new System.Drawing.Point(12, 106);
            this.lblActions.Name = "lblActions";
            this.lblActions.Size = new System.Drawing.Size(136, 24);
            this.lblActions.TabIndex = 3;
            this.lblActions.Text = "Backup Plans";
            // 
            // PersistProManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lblActions);
            this.Controls.Add(this.lnkLblRestoreFromBackup);
            this.Controls.Add(this.lnkLblStatus);
            this.Controls.Add(this.lnkLblWhen);
            this.Controls.Add(this.lnkLblBackupPlan);
            this.Controls.Add(this.lnkLblWhere);
            this.Controls.Add(this.lnkLblWhat);
            this.Name = "PersistProManager";
            this.Size = new System.Drawing.Size(306, 257);
            this.Load += new System.EventHandler(this.PersistProManager_Load);
            this.ParentChanged += new System.EventHandler(this.PersistProManager_ParentChanged);
            this.Controls.SetChildIndex(this.lnkLblWhat, 0);
            this.Controls.SetChildIndex(this.lnkLblWhere, 0);
            this.Controls.SetChildIndex(this.lnkLblBackupPlan, 0);
            this.Controls.SetChildIndex(this.lnkLblWhen, 0);
            this.Controls.SetChildIndex(this.lnkLblStatus, 0);
            this.Controls.SetChildIndex(this.lnkLblRestoreFromBackup, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.lblActions, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkLblBackupPlan;
        private System.Windows.Forms.LinkLabel lnkLblWhat;
        private System.Windows.Forms.LinkLabel lnkLblWhere;
        private System.Windows.Forms.LinkLabel lnkLblWhen;
        private System.Windows.Forms.LinkLabel lnkLblRestoreFromBackup;
        private System.Windows.Forms.LinkLabel lnkLblStatus;
        private System.Windows.Forms.Label lblActions;
    }
}
