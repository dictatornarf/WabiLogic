namespace PersistProClient {
    partial class RootAttributeFilterEdit {
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
            "Archive",
            "Include"}, -1);
            this.lblRootName = new System.Windows.Forms.Label();
            this.grpBoxEditFilter = new System.Windows.Forms.GroupBox();
            this.cmbBoxAttributeFilter = new System.Windows.Forms.ComboBox();
            this.lblFilterAction = new System.Windows.Forms.Label();
            this.lblAttributeFitler = new System.Windows.Forms.Label();
            this.cmbBoxFilterAction = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstViewAttributeFilters = new System.Windows.Forms.ListView();
            this.columnHeaderFilterAttribute = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFilterAction = new System.Windows.Forms.ColumnHeader();
            this.grpBoxEditFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(181, 24);
            this.lblHeader.Text = "File Attribute Filter";
            // 
            // lblRootName
            // 
            this.lblRootName.AutoSize = true;
            this.lblRootName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRootName.Location = new System.Drawing.Point(12, 43);
            this.lblRootName.Name = "lblRootName";
            this.lblRootName.Size = new System.Drawing.Size(109, 20);
            this.lblRootName.TabIndex = 1;
            this.lblRootName.Text = "[Root Name]";
            // 
            // grpBoxEditFilter
            // 
            this.grpBoxEditFilter.Controls.Add(this.cmbBoxAttributeFilter);
            this.grpBoxEditFilter.Controls.Add(this.lblFilterAction);
            this.grpBoxEditFilter.Controls.Add(this.lblAttributeFitler);
            this.grpBoxEditFilter.Controls.Add(this.cmbBoxFilterAction);
            this.grpBoxEditFilter.Location = new System.Drawing.Point(231, 76);
            this.grpBoxEditFilter.Name = "grpBoxEditFilter";
            this.grpBoxEditFilter.Size = new System.Drawing.Size(148, 165);
            this.grpBoxEditFilter.TabIndex = 3;
            this.grpBoxEditFilter.TabStop = false;
            this.grpBoxEditFilter.Text = "Edit Name Filter";
            // 
            // cmbBoxAttributeFilter
            // 
            this.cmbBoxAttributeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxAttributeFilter.FormattingEnabled = true;
            this.cmbBoxAttributeFilter.Items.AddRange(new object[] {
            "Archive",
            "Compressed",
            "Encrypted",
            "Hidden",
            "Offline",
            "ReadOnly",
            "System",
            "Temporary"});
            this.cmbBoxAttributeFilter.Location = new System.Drawing.Point(20, 99);
            this.cmbBoxAttributeFilter.Name = "cmbBoxAttributeFilter";
            this.cmbBoxAttributeFilter.Size = new System.Drawing.Size(114, 21);
            this.cmbBoxAttributeFilter.TabIndex = 3;
            this.cmbBoxAttributeFilter.SelectedIndexChanged += new System.EventHandler(this.cmbBoxAttributeFilter_SelectedIndexChanged);
            // 
            // lblFilterAction
            // 
            this.lblFilterAction.AutoSize = true;
            this.lblFilterAction.Location = new System.Drawing.Point(17, 32);
            this.lblFilterAction.Name = "lblFilterAction";
            this.lblFilterAction.Size = new System.Drawing.Size(62, 13);
            this.lblFilterAction.TabIndex = 0;
            this.lblFilterAction.Text = "Filter Action";
            // 
            // lblAttributeFitler
            // 
            this.lblAttributeFitler.AutoSize = true;
            this.lblAttributeFitler.Location = new System.Drawing.Point(17, 83);
            this.lblAttributeFitler.Name = "lblAttributeFitler";
            this.lblAttributeFitler.Size = new System.Drawing.Size(71, 13);
            this.lblAttributeFitler.TabIndex = 2;
            this.lblAttributeFitler.Text = "Attribute Filter";
            // 
            // cmbBoxFilterAction
            // 
            this.cmbBoxFilterAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxFilterAction.FormattingEnabled = true;
            this.cmbBoxFilterAction.Items.AddRange(new object[] {
            "Include",
            "Exclude"});
            this.cmbBoxFilterAction.Location = new System.Drawing.Point(20, 48);
            this.cmbBoxFilterAction.Name = "cmbBoxFilterAction";
            this.cmbBoxFilterAction.Size = new System.Drawing.Size(114, 21);
            this.cmbBoxFilterAction.TabIndex = 1;
            this.cmbBoxFilterAction.SelectedIndexChanged += new System.EventHandler(this.cmbBoxFilterAction_SelectedIndexChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(108, 257);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(65, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(22, 257);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstViewAttributeFilters
            // 
            this.lstViewAttributeFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFilterAttribute,
            this.columnHeaderFilterAction});
            this.lstViewAttributeFilters.FullRowSelect = true;
            this.lstViewAttributeFilters.HideSelection = false;
            this.lstViewAttributeFilters.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstViewAttributeFilters.Location = new System.Drawing.Point(16, 76);
            this.lstViewAttributeFilters.MultiSelect = false;
            this.lstViewAttributeFilters.Name = "lstViewAttributeFilters";
            this.lstViewAttributeFilters.ShowGroups = false;
            this.lstViewAttributeFilters.Size = new System.Drawing.Size(196, 165);
            this.lstViewAttributeFilters.TabIndex = 2;
            this.lstViewAttributeFilters.UseCompatibleStateImageBehavior = false;
            this.lstViewAttributeFilters.View = System.Windows.Forms.View.Details;
            this.lstViewAttributeFilters.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstViewAttributeFilters_ItemSelectionChanged);
            // 
            // columnHeaderFilterAttribute
            // 
            this.columnHeaderFilterAttribute.DisplayIndex = 1;
            this.columnHeaderFilterAttribute.Text = "Attribute Filter";
            this.columnHeaderFilterAttribute.Width = 92;
            // 
            // columnHeaderFilterAction
            // 
            this.columnHeaderFilterAction.DisplayIndex = 0;
            this.columnHeaderFilterAction.Text = "Filter Action";
            this.columnHeaderFilterAction.Width = 96;
            // 
            // RootAttributeFilterEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lstViewAttributeFilters);
            this.Controls.Add(this.lblRootName);
            this.Controls.Add(this.grpBoxEditFilter);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Name = "RootAttributeFilterEdit";
            this.Size = new System.Drawing.Size(397, 303);
            this.Load += new System.EventHandler(this.RootAttributeFilterEdit_Load);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.grpBoxEditFilter, 0);
            this.Controls.SetChildIndex(this.lblRootName, 0);
            this.Controls.SetChildIndex(this.lstViewAttributeFilters, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.grpBoxEditFilter.ResumeLayout(false);
            this.grpBoxEditFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRootName;
        private System.Windows.Forms.GroupBox grpBoxEditFilter;
        private System.Windows.Forms.Label lblFilterAction;
        private System.Windows.Forms.Label lblAttributeFitler;
        private System.Windows.Forms.ComboBox cmbBoxFilterAction;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lstViewAttributeFilters;
        private System.Windows.Forms.ColumnHeader columnHeaderFilterAction;
        private System.Windows.Forms.ColumnHeader columnHeaderFilterAttribute;
        private System.Windows.Forms.ComboBox cmbBoxAttributeFilter;
    }
}
