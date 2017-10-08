namespace PersistProClient {
    partial class RestoreBrowser {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreBrowser));
            this.trvBExplorer = new System.Windows.Forms.TreeView();
            this.imglstExplorer = new System.Windows.Forms.ImageList(this.components);
            this.grpbxRestoreOptions = new System.Windows.Forms.GroupBox();
            this.chkIncludeAllFileVersions = new System.Windows.Forms.CheckBox();
            this.chkIncludeSubFolders = new System.Windows.Forms.CheckBox();
            this.lnklblRestoreItem = new System.Windows.Forms.LinkLabel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.lblRestoreLocation = new System.Windows.Forms.Label();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.bgwkrRestore = new System.ComponentModel.BackgroundWorker();
            this.grpbxRestoreOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(165, 24);
            this.lblHeader.Text = "Backup Explorer";
            // 
            // trvBExplorer
            // 
            this.trvBExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvBExplorer.ImageIndex = 0;
            this.trvBExplorer.ImageList = this.imglstExplorer;
            this.trvBExplorer.Location = new System.Drawing.Point(16, 38);
            this.trvBExplorer.Name = "trvBExplorer";
            this.trvBExplorer.SelectedImageIndex = 0;
            this.trvBExplorer.Size = new System.Drawing.Size(226, 346);
            this.trvBExplorer.TabIndex = 1;
            this.trvBExplorer.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.BeforeNodexExpandOrCollape);
            this.trvBExplorer.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.BeforeNodexExpandOrCollape);
            this.trvBExplorer.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvBExplorer_BeforeSelect);
            // 
            // imglstExplorer
            // 
            this.imglstExplorer.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstExplorer.ImageStream")));
            this.imglstExplorer.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstExplorer.Images.SetKeyName(0, "ExpirationHS.png");
            this.imglstExplorer.Images.SetKeyName(1, "Folder_Closed.png");
            this.imglstExplorer.Images.SetKeyName(2, "Folder_Open.png");
            this.imglstExplorer.Images.SetKeyName(3, "Generic_Device.png");
            this.imglstExplorer.Images.SetKeyName(4, "Generic_Document.png");
            this.imglstExplorer.Images.SetKeyName(5, "CLSDFOLD.BMP");
            this.imglstExplorer.Images.SetKeyName(6, "OPENFOLD.BMP");
            // 
            // grpbxRestoreOptions
            // 
            this.grpbxRestoreOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbxRestoreOptions.Controls.Add(this.chkIncludeAllFileVersions);
            this.grpbxRestoreOptions.Controls.Add(this.chkIncludeSubFolders);
            this.grpbxRestoreOptions.Controls.Add(this.lnklblRestoreItem);
            this.grpbxRestoreOptions.Controls.Add(this.btnBrowse);
            this.grpbxRestoreOptions.Controls.Add(this.txtBoxPath);
            this.grpbxRestoreOptions.Controls.Add(this.lblRestoreLocation);
            this.grpbxRestoreOptions.Location = new System.Drawing.Point(248, 38);
            this.grpbxRestoreOptions.Name = "grpbxRestoreOptions";
            this.grpbxRestoreOptions.Size = new System.Drawing.Size(276, 124);
            this.grpbxRestoreOptions.TabIndex = 2;
            this.grpbxRestoreOptions.TabStop = false;
            this.grpbxRestoreOptions.Text = "Restore Options";
            // 
            // chkIncludeAllFileVersions
            // 
            this.chkIncludeAllFileVersions.AutoSize = true;
            this.chkIncludeAllFileVersions.Location = new System.Drawing.Point(9, 60);
            this.chkIncludeAllFileVersions.Name = "chkIncludeAllFileVersions";
            this.chkIncludeAllFileVersions.Size = new System.Drawing.Size(137, 17);
            this.chkIncludeAllFileVersions.TabIndex = 3;
            this.chkIncludeAllFileVersions.Text = "Include All File Versions";
            this.chkIncludeAllFileVersions.UseVisualStyleBackColor = true;
            // 
            // chkIncludeSubFolders
            // 
            this.chkIncludeSubFolders.AutoSize = true;
            this.chkIncludeSubFolders.Location = new System.Drawing.Point(9, 82);
            this.chkIncludeSubFolders.Name = "chkIncludeSubFolders";
            this.chkIncludeSubFolders.Size = new System.Drawing.Size(120, 17);
            this.chkIncludeSubFolders.TabIndex = 4;
            this.chkIncludeSubFolders.Text = "Include Sub-Folders";
            this.chkIncludeSubFolders.UseVisualStyleBackColor = true;
            // 
            // lnklblRestoreItem
            // 
            this.lnklblRestoreItem.AutoSize = true;
            this.lnklblRestoreItem.Location = new System.Drawing.Point(112, 104);
            this.lnklblRestoreItem.Name = "lnklblRestoreItem";
            this.lnklblRestoreItem.Size = new System.Drawing.Size(112, 13);
            this.lnklblRestoreItem.TabIndex = 5;
            this.lnklblRestoreItem.TabStop = true;
            this.lnklblRestoreItem.Text = "Restore Selected Item";
            this.lnklblRestoreItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblRestoreItem_LinkClicked);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(196, 32);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxPath.Location = new System.Drawing.Point(9, 35);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.Size = new System.Drawing.Size(181, 20);
            this.txtBoxPath.TabIndex = 1;
            // 
            // lblRestoreLocation
            // 
            this.lblRestoreLocation.AutoSize = true;
            this.lblRestoreLocation.Location = new System.Drawing.Point(6, 17);
            this.lblRestoreLocation.Name = "lblRestoreLocation";
            this.lblRestoreLocation.Size = new System.Drawing.Size(168, 13);
            this.lblRestoreLocation.TabIndex = 0;
            this.lblRestoreLocation.Text = "Restore to the Following Location:";
            // 
            // RestoreBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grpbxRestoreOptions);
            this.Controls.Add(this.trvBExplorer);
            this.Name = "RestoreBrowser";
            this.Size = new System.Drawing.Size(529, 398);
            this.Load += new System.EventHandler(this.RestoreBrowser_Load);
            this.Controls.SetChildIndex(this.trvBExplorer, 0);
            this.Controls.SetChildIndex(this.grpbxRestoreOptions, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.grpbxRestoreOptions.ResumeLayout(false);
            this.grpbxRestoreOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvBExplorer;
        private System.Windows.Forms.ImageList imglstExplorer;
        private System.Windows.Forms.GroupBox grpbxRestoreOptions;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBoxPath;
        private System.Windows.Forms.Label lblRestoreLocation;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.CheckBox chkIncludeAllFileVersions;
        private System.Windows.Forms.CheckBox chkIncludeSubFolders;
        private System.Windows.Forms.LinkLabel lnklblRestoreItem;
        private System.ComponentModel.BackgroundWorker bgwkrRestore;
    }
}
