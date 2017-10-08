namespace PersistProClient {
    partial class PlanManagerEdit {
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
            "USB Drive",
            "Daily at 5:00pm"}, -1);
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lstViewPlans = new System.Windows.Forms.ListView();
            this.columnHeaderWhat = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderWhere = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderWhen = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(142, 24);
            this.lblHeader.Text = "Manage Plans";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(207, 193);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(78, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(111, 193);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(14, 193);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(78, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lstViewPlans
            // 
            this.lstViewPlans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewPlans.BackColor = System.Drawing.Color.White;
            this.lstViewPlans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderWhat,
            this.columnHeaderWhere,
            this.columnHeaderWhen});
            this.lstViewPlans.ForeColor = System.Drawing.Color.Black;
            this.lstViewPlans.FullRowSelect = true;
            this.lstViewPlans.HideSelection = false;
            this.lstViewPlans.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstViewPlans.Location = new System.Drawing.Point(14, 47);
            this.lstViewPlans.MultiSelect = false;
            this.lstViewPlans.Name = "lstViewPlans";
            this.lstViewPlans.ShowGroups = false;
            this.lstViewPlans.Size = new System.Drawing.Size(364, 131);
            this.lstViewPlans.TabIndex = 1;
            this.lstViewPlans.UseCompatibleStateImageBehavior = false;
            this.lstViewPlans.View = System.Windows.Forms.View.Details;
            this.lstViewPlans.DoubleClick += new System.EventHandler(this.btnEdit_Click);
            this.lstViewPlans.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstViewPlans_ItemSelectionChanged);
            // 
            // columnHeaderWhat
            // 
            this.columnHeaderWhat.Text = "What";
            this.columnHeaderWhat.Width = 110;
            // 
            // columnHeaderWhere
            // 
            this.columnHeaderWhere.Text = "Where";
            this.columnHeaderWhere.Width = 110;
            // 
            // columnHeaderWhen
            // 
            this.columnHeaderWhen.Text = "When";
            this.columnHeaderWhen.Width = 139;
            // 
            // PlanManagerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lstViewPlans);
            this.Name = "PlanManagerEdit";
            this.Size = new System.Drawing.Size(391, 255);
            this.Load += new System.EventHandler(this.PlanManagerEdit_Load);
            this.ParentChanged += new System.EventHandler(this.PlanManagerEdit_ParentChanged);
            this.Controls.SetChildIndex(this.lstViewPlans, 0);
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
        private System.Windows.Forms.ListView lstViewPlans;
        private System.Windows.Forms.ColumnHeader columnHeaderWhat;
        private System.Windows.Forms.ColumnHeader columnHeaderWhere;
        private System.Windows.Forms.ColumnHeader columnHeaderWhen;
    }
}
