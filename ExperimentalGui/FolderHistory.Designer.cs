namespace WabiLogic.PersistPro {
    partial class FolderHistory {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listViewFolderHistory = new System.Windows.Forms.ListView();
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderCreateDate = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderParent = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listViewFolderHistory
            // 
            this.listViewFolderHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderCreateDate,
            this.columnHeaderParent});
            this.listViewFolderHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFolderHistory.Location = new System.Drawing.Point(0, 0);
            this.listViewFolderHistory.Name = "listViewFolderHistory";
            this.listViewFolderHistory.Size = new System.Drawing.Size(373, 264);
            this.listViewFolderHistory.TabIndex = 0;
            this.listViewFolderHistory.UseCompatibleStateImageBehavior = false;
            this.listViewFolderHistory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 118;
            // 
            // columnHeaderCreateDate
            // 
            this.columnHeaderCreateDate.Text = "Create Date";
            this.columnHeaderCreateDate.Width = 135;
            // 
            // columnHeaderParent
            // 
            this.columnHeaderParent.Text = "Parent";
            this.columnHeaderParent.Width = 115;
            // 
            // FolderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 264);
            this.Controls.Add(this.listViewFolderHistory);
            this.Name = "FolderHistory";
            this.Text = "FolderHistory";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFolderHistory;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderCreateDate;
        private System.Windows.Forms.ColumnHeader columnHeaderParent;
    }
}