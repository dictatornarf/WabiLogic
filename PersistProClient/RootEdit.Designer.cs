namespace PersistProClient {
    partial class RootEdit {
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkBoxSub = new System.Windows.Forms.CheckBox();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.lnkLblConfigureNameFilters = new System.Windows.Forms.LinkLabel();
            this.grpBoxAdvancedSettings = new System.Windows.Forms.GroupBox();
            this.chkBoxKeepHistory = new System.Windows.Forms.CheckBox();
            this.lnkLblConfigureAttributeFilters = new System.Windows.Forms.LinkLabel();
            this.grpBoxAdvancedSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(123, 24);
            this.lblHeader.Text = "Define What";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 43);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(13, 92);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(29, 13);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "Path";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(16, 59);
            this.txtBoxName.MaxLength = 60;
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(280, 20);
            this.txtBoxName.TabIndex = 2;
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxPath.Location = new System.Drawing.Point(16, 108);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.Size = new System.Drawing.Size(280, 20);
            this.txtBoxPath.TabIndex = 4;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(302, 105);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkBoxSub
            // 
            this.chkBoxSub.AutoSize = true;
            this.chkBoxSub.Checked = true;
            this.chkBoxSub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxSub.Location = new System.Drawing.Point(16, 134);
            this.chkBoxSub.Name = "chkBoxSub";
            this.chkBoxSub.Size = new System.Drawing.Size(196, 17);
            this.chkBoxSub.TabIndex = 6;
            this.chkBoxSub.Text = "Include all sub folders in the backup";
            this.chkBoxSub.UseVisualStyleBackColor = true;
            // 
            // lnkLblConfigureNameFilters
            // 
            this.lnkLblConfigureNameFilters.AutoSize = true;
            this.lnkLblConfigureNameFilters.Location = new System.Drawing.Point(6, 39);
            this.lnkLblConfigureNameFilters.Name = "lnkLblConfigureNameFilters";
            this.lnkLblConfigureNameFilters.Size = new System.Drawing.Size(113, 13);
            this.lnkLblConfigureNameFilters.TabIndex = 1;
            this.lnkLblConfigureNameFilters.TabStop = true;
            this.lnkLblConfigureNameFilters.Text = "Configure Name Filters";
            this.lnkLblConfigureNameFilters.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblConfigureNameFilters_LinkClicked);
            // 
            // grpBoxAdvancedSettings
            // 
            this.grpBoxAdvancedSettings.Controls.Add(this.chkBoxKeepHistory);
            this.grpBoxAdvancedSettings.Controls.Add(this.lnkLblConfigureAttributeFilters);
            this.grpBoxAdvancedSettings.Controls.Add(this.lnkLblConfigureNameFilters);
            this.grpBoxAdvancedSettings.Location = new System.Drawing.Point(16, 167);
            this.grpBoxAdvancedSettings.Name = "grpBoxAdvancedSettings";
            this.grpBoxAdvancedSettings.Size = new System.Drawing.Size(178, 84);
            this.grpBoxAdvancedSettings.TabIndex = 7;
            this.grpBoxAdvancedSettings.TabStop = false;
            this.grpBoxAdvancedSettings.Text = "Advanced Settings";
            // 
            // chkBoxKeepHistory
            // 
            this.chkBoxKeepHistory.AutoSize = true;
            this.chkBoxKeepHistory.Checked = true;
            this.chkBoxKeepHistory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxKeepHistory.Location = new System.Drawing.Point(6, 19);
            this.chkBoxKeepHistory.Name = "chkBoxKeepHistory";
            this.chkBoxKeepHistory.Size = new System.Drawing.Size(86, 17);
            this.chkBoxKeepHistory.TabIndex = 0;
            this.chkBoxKeepHistory.Text = "Keep History";
            this.chkBoxKeepHistory.UseVisualStyleBackColor = true;
            // 
            // lnkLblConfigureAttributeFilters
            // 
            this.lnkLblConfigureAttributeFilters.AutoSize = true;
            this.lnkLblConfigureAttributeFilters.Location = new System.Drawing.Point(6, 61);
            this.lnkLblConfigureAttributeFilters.Name = "lnkLblConfigureAttributeFilters";
            this.lnkLblConfigureAttributeFilters.Size = new System.Drawing.Size(124, 13);
            this.lnkLblConfigureAttributeFilters.TabIndex = 2;
            this.lnkLblConfigureAttributeFilters.TabStop = true;
            this.lnkLblConfigureAttributeFilters.Text = "Configure Attribute Filters";
            this.lnkLblConfigureAttributeFilters.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblConfigureAttributeFilters_LinkClicked);
            // 
            // RootEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.grpBoxAdvancedSettings);
            this.Controls.Add(this.chkBoxSub);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtBoxPath);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPath);
            this.Name = "RootEdit";
            this.Size = new System.Drawing.Size(390, 268);
            this.Load += new System.EventHandler(this.RootEdit_Load);
            this.Controls.SetChildIndex(this.lblPath, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txtBoxPath, 0);
            this.Controls.SetChildIndex(this.btnBrowse, 0);
            this.Controls.SetChildIndex(this.chkBoxSub, 0);
            this.Controls.SetChildIndex(this.grpBoxAdvancedSettings, 0);
            this.Controls.SetChildIndex(this.txtBoxName, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.grpBoxAdvancedSettings.ResumeLayout(false);
            this.grpBoxAdvancedSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chkBoxSub;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.LinkLabel lnkLblConfigureNameFilters;
        private System.Windows.Forms.GroupBox grpBoxAdvancedSettings;
        private System.Windows.Forms.LinkLabel lnkLblConfigureAttributeFilters;
        private System.Windows.Forms.CheckBox chkBoxKeepHistory;
    }
}
