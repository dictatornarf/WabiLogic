namespace WabiLogic.PersistPro {
    partial class FileHistory {
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
            this.listViewFileHistory = new System.Windows.Forms.ListView();
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderSize = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderCreateDate = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderParent = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderNote = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listViewFileHistory
            // 
            this.listViewFileHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderSize,
            this.columnHeaderCreateDate,
            this.columnHeaderParent,
            this.columnHeaderNote});
            this.listViewFileHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFileHistory.LabelEdit = true;
            this.listViewFileHistory.Location = new System.Drawing.Point(0, 0);
            this.listViewFileHistory.Name = "listViewFileHistory";
            this.listViewFileHistory.Size = new System.Drawing.Size(654, 286);
            this.listViewFileHistory.TabIndex = 0;
            this.listViewFileHistory.UseCompatibleStateImageBehavior = false;
            this.listViewFileHistory.View = System.Windows.Forms.View.Details;
            this.listViewFileHistory.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewFileHistory_ItemDrag);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 154;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "Size";
            this.columnHeaderSize.Width = 69;
            // 
            // columnHeaderCreateDate
            // 
            this.columnHeaderCreateDate.Text = "Create Date";
            this.columnHeaderCreateDate.Width = 99;
            // 
            // columnHeaderParent
            // 
            this.columnHeaderParent.Text = "Parent";
            this.columnHeaderParent.Width = 100;
            // 
            // columnHeaderNote
            // 
            this.columnHeaderNote.Text = "Note";
            this.columnHeaderNote.Width = 208;
            // 
            // FileHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 286);
            this.Controls.Add(this.listViewFileHistory);
            this.Name = "FileHistory";
            this.Text = "FileHistory";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFileHistory;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ColumnHeader columnHeaderCreateDate;
        private System.Windows.Forms.ColumnHeader columnHeaderParent;
        private System.Windows.Forms.ColumnHeader columnHeaderNote;
    }
}