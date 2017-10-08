namespace PersistProClient {
    partial class RootNameFilterEdit {
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
            "Include",
            "*.jpg"}, -1);
            this.lstViewNameFilters = new System.Windows.Forms.ListView();
            this.columnHeaderFilterName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFilterAction = new System.Windows.Forms.ColumnHeader();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblNameFitler = new System.Windows.Forms.Label();
            this.cmbBoxFilterAction = new System.Windows.Forms.ComboBox();
            this.txtBoxNameFilter = new System.Windows.Forms.TextBox();
            this.grpBoxEditFilter = new System.Windows.Forms.GroupBox();
            this.lblFilterAction = new System.Windows.Forms.Label();
            this.lblRootName = new System.Windows.Forms.Label();
            this.grpBoxEditFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(165, 24);
            this.lblHeader.Text = "File Name Filter ";
            // 
            // lstViewNameFilters
            // 
            this.lstViewNameFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFilterName,
            this.columnHeaderFilterAction});
            this.lstViewNameFilters.FullRowSelect = true;
            this.lstViewNameFilters.HideSelection = false;
            this.lstViewNameFilters.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstViewNameFilters.Location = new System.Drawing.Point(16, 77);
            this.lstViewNameFilters.MultiSelect = false;
            this.lstViewNameFilters.Name = "lstViewNameFilters";
            this.lstViewNameFilters.ShowGroups = false;
            this.lstViewNameFilters.Size = new System.Drawing.Size(164, 165);
            this.lstViewNameFilters.TabIndex = 2;
            this.lstViewNameFilters.UseCompatibleStateImageBehavior = false;
            this.lstViewNameFilters.View = System.Windows.Forms.View.Details;
            this.lstViewNameFilters.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstViewNameFilters_ItemSelectionChanged);
            // 
            // columnHeaderFilterName
            // 
            this.columnHeaderFilterName.DisplayIndex = 1;
            this.columnHeaderFilterName.Text = "Name Filter";
            this.columnHeaderFilterName.Width = 90;
            // 
            // columnHeaderFilterAction
            // 
            this.columnHeaderFilterAction.DisplayIndex = 0;
            this.columnHeaderFilterAction.Text = "Filter Action";
            this.columnHeaderFilterAction.Width = 70;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(22, 258);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(108, 258);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(65, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblNameFitler
            // 
            this.lblNameFitler.AutoSize = true;
            this.lblNameFitler.Location = new System.Drawing.Point(17, 83);
            this.lblNameFitler.Name = "lblNameFitler";
            this.lblNameFitler.Size = new System.Drawing.Size(60, 13);
            this.lblNameFitler.TabIndex = 2;
            this.lblNameFitler.Text = "Name Filter";
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
            // txtBoxNameFilter
            // 
            this.txtBoxNameFilter.Location = new System.Drawing.Point(20, 99);
            this.txtBoxNameFilter.Name = "txtBoxNameFilter";
            this.txtBoxNameFilter.Size = new System.Drawing.Size(114, 20);
            this.txtBoxNameFilter.TabIndex = 3;
            this.txtBoxNameFilter.TextChanged += new System.EventHandler(this.txtBoxNameFilter_TextChanged);
            // 
            // grpBoxEditFilter
            // 
            this.grpBoxEditFilter.Controls.Add(this.lblFilterAction);
            this.grpBoxEditFilter.Controls.Add(this.txtBoxNameFilter);
            this.grpBoxEditFilter.Controls.Add(this.lblNameFitler);
            this.grpBoxEditFilter.Controls.Add(this.cmbBoxFilterAction);
            this.grpBoxEditFilter.Location = new System.Drawing.Point(202, 77);
            this.grpBoxEditFilter.Name = "grpBoxEditFilter";
            this.grpBoxEditFilter.Size = new System.Drawing.Size(148, 165);
            this.grpBoxEditFilter.TabIndex = 3;
            this.grpBoxEditFilter.TabStop = false;
            this.grpBoxEditFilter.Text = "Edit Name Filter";
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
            // lblRootName
            // 
            this.lblRootName.AutoSize = true;
            this.lblRootName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRootName.Location = new System.Drawing.Point(12, 44);
            this.lblRootName.Name = "lblRootName";
            this.lblRootName.Size = new System.Drawing.Size(109, 20);
            this.lblRootName.TabIndex = 1;
            this.lblRootName.Text = "[Root Name]";
            // 
            // RootNameFilterEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstViewNameFilters);
            this.Controls.Add(this.lblRootName);
            this.Controls.Add(this.grpBoxEditFilter);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Name = "RootNameFilterEdit";
            this.Size = new System.Drawing.Size(364, 310);
            this.Load += new System.EventHandler(this.RootNameFilterEdit_Load);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.grpBoxEditFilter, 0);
            this.Controls.SetChildIndex(this.lblRootName, 0);
            this.Controls.SetChildIndex(this.lstViewNameFilters, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.grpBoxEditFilter.ResumeLayout(false);
            this.grpBoxEditFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstViewNameFilters;
        private System.Windows.Forms.ColumnHeader columnHeaderFilterAction;
        private System.Windows.Forms.ColumnHeader columnHeaderFilterName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblNameFitler;
        private System.Windows.Forms.ComboBox cmbBoxFilterAction;
        private System.Windows.Forms.TextBox txtBoxNameFilter;
        private System.Windows.Forms.GroupBox grpBoxEditFilter;
        private System.Windows.Forms.Label lblFilterAction;
        private System.Windows.Forms.Label lblRootName;

    }
}
