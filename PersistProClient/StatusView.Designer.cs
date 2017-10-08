namespace PersistProClient {
    partial class StatusView {
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Pictures",
            "FTP",
            "Date",
            "Date",
            "InError",
            "Error Message"}, -1);
            this.lstViewStatus = new System.Windows.Forms.ListView();
            this.columnHeaderWhat = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderWhere = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderScheduledDate = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderBackupTime = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderStatus = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderErrorNote = new System.Windows.Forms.ColumnHeader();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBackupNow = new System.Windows.Forms.Button();
            this.chkBoxViewHistory = new System.Windows.Forms.CheckBox();
            this.btnAbort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(66, 24);
            this.lblHeader.Text = "Status";
            // 
            // lstViewStatus
            // 
            this.lstViewStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewStatus.BackColor = System.Drawing.Color.White;
            this.lstViewStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderWhat,
            this.columnHeaderWhere,
            this.columnHeaderScheduledDate,
            this.columnHeaderBackupTime,
            this.columnHeaderStatus,
            this.columnHeaderErrorNote});
            this.lstViewStatus.ForeColor = System.Drawing.Color.Black;
            this.lstViewStatus.FullRowSelect = true;
            this.lstViewStatus.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstViewStatus.Location = new System.Drawing.Point(13, 48);
            this.lstViewStatus.Name = "lstViewStatus";
            this.lstViewStatus.Size = new System.Drawing.Size(641, 127);
            this.lstViewStatus.TabIndex = 1;
            this.lstViewStatus.UseCompatibleStateImageBehavior = false;
            this.lstViewStatus.View = System.Windows.Forms.View.Details;
            this.lstViewStatus.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstViewStatus_ItemSelectionChanged);
            // 
            // columnHeaderWhat
            // 
            this.columnHeaderWhat.Text = "What";
            this.columnHeaderWhat.Width = 98;
            // 
            // columnHeaderWhere
            // 
            this.columnHeaderWhere.Text = "Where";
            this.columnHeaderWhere.Width = 95;
            // 
            // columnHeaderScheduledDate
            // 
            this.columnHeaderScheduledDate.Text = "Scheduled Date";
            this.columnHeaderScheduledDate.Width = 132;
            // 
            // columnHeaderBackupTime
            // 
            this.columnHeaderBackupTime.Text = "Backup Time";
            this.columnHeaderBackupTime.Width = 125;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            this.columnHeaderStatus.Width = 83;
            // 
            // columnHeaderErrorNote
            // 
            this.columnHeaderErrorNote.Text = "Note";
            this.columnHeaderErrorNote.Width = 191;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(16, 189);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBackupNow
            // 
            this.btnBackupNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackupNow.Location = new System.Drawing.Point(472, 189);
            this.btnBackupNow.Name = "btnBackupNow";
            this.btnBackupNow.Size = new System.Drawing.Size(89, 23);
            this.btnBackupNow.TabIndex = 4;
            this.btnBackupNow.Text = "Backup Now";
            this.btnBackupNow.UseVisualStyleBackColor = true;
            this.btnBackupNow.Click += new System.EventHandler(this.btnBackupNow_Click);
            // 
            // chkBoxViewHistory
            // 
            this.chkBoxViewHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBoxViewHistory.AutoSize = true;
            this.chkBoxViewHistory.Location = new System.Drawing.Point(114, 193);
            this.chkBoxViewHistory.Name = "chkBoxViewHistory";
            this.chkBoxViewHistory.Size = new System.Drawing.Size(84, 17);
            this.chkBoxViewHistory.TabIndex = 3;
            this.chkBoxViewHistory.Text = "View History";
            this.chkBoxViewHistory.UseVisualStyleBackColor = true;
            this.chkBoxViewHistory.CheckedChanged += new System.EventHandler(this.chkBoxViewHistory_CheckedChanged);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbort.Location = new System.Drawing.Point(579, 189);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbort.TabIndex = 5;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // StatusView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.chkBoxViewHistory);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstViewStatus);
            this.Controls.Add(this.btnBackupNow);
            this.Name = "StatusView";
            this.Size = new System.Drawing.Size(667, 222);
            this.Load += new System.EventHandler(this.StatusView_Load);
            this.Controls.SetChildIndex(this.btnBackupNow, 0);
            this.Controls.SetChildIndex(this.lstViewStatus, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.Controls.SetChildIndex(this.chkBoxViewHistory, 0);
            this.Controls.SetChildIndex(this.btnAbort, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstViewStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ColumnHeader columnHeaderWhat;
        private System.Windows.Forms.ColumnHeader columnHeaderWhere;
        private System.Windows.Forms.ColumnHeader columnHeaderScheduledDate;
        private System.Windows.Forms.ColumnHeader columnHeaderBackupTime;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderErrorNote;
        private System.Windows.Forms.Button btnBackupNow;
        private System.Windows.Forms.CheckBox chkBoxViewHistory;
        private System.Windows.Forms.Button btnAbort;
    }
}
