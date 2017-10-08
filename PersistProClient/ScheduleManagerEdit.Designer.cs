namespace PersistProClient {
    partial class ScheduleManagerEdit {
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Daily on Tuesday for some Hamburger");
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lstViewSchedules = new System.Windows.Forms.ListView();
            this.columnHeaderDescription = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(146, 24);
            this.lblHeader.Text = "Manage When";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(205, 193);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(78, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(109, 193);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(12, 193);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(78, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // lstViewSchedules
            // 
            this.lstViewSchedules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewSchedules.BackColor = System.Drawing.Color.White;
            this.lstViewSchedules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDescription});
            this.lstViewSchedules.ForeColor = System.Drawing.Color.Black;
            this.lstViewSchedules.FullRowSelect = true;
            this.lstViewSchedules.HideSelection = false;
            this.lstViewSchedules.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstViewSchedules.Location = new System.Drawing.Point(12, 47);
            this.lstViewSchedules.MultiSelect = false;
            this.lstViewSchedules.Name = "lstViewSchedules";
            this.lstViewSchedules.ShowGroups = false;
            this.lstViewSchedules.Size = new System.Drawing.Size(335, 131);
            this.lstViewSchedules.TabIndex = 1;
            this.lstViewSchedules.UseCompatibleStateImageBehavior = false;
            this.lstViewSchedules.View = System.Windows.Forms.View.Details;
            this.lstViewSchedules.DoubleClick += new System.EventHandler(this.BtnEdit_Click);
            this.lstViewSchedules.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LstViewRoots_ItemSelectionChanged);
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "Description";
            this.columnHeaderDescription.Width = 326;
            // 
            // ScheduleManagerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lstViewSchedules);
            this.Name = "ScheduleManagerEdit";
            this.Size = new System.Drawing.Size(363, 226);
            this.Load += new System.EventHandler(this.ScheduleManagerEdit_Load);
            this.ParentChanged += new System.EventHandler(this.ScheduleManagerEdit_ParentChanged);
            this.Controls.SetChildIndex(this.lstViewSchedules, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ListView lstViewSchedules;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;

    }
}
