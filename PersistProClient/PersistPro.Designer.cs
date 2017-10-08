namespace PersistProClient {
    partial class PersistPro {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersistPro));
            this.spltContainer = new System.Windows.Forms.SplitContainer();
            this.richTxtBoxHelp = new System.Windows.Forms.RichTextBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picWabiLogo = new System.Windows.Forms.PictureBox();
            this.lnklblHelp = new System.Windows.Forms.LinkLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openPersistProToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spltContainer.Panel1.SuspendLayout();
            this.spltContainer.Panel2.SuspendLayout();
            this.spltContainer.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWabiLogo)).BeginInit();
            this.contextMenuStripNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // spltContainer
            // 
            this.spltContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spltContainer.Location = new System.Drawing.Point(0, 93);
            this.spltContainer.Name = "spltContainer";
            // 
            // spltContainer.Panel1
            // 
            this.spltContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.spltContainer.Panel1.Controls.Add(this.richTxtBoxHelp);
            // 
            // spltContainer.Panel2
            // 
            this.spltContainer.Panel2.AutoScroll = true;
            this.spltContainer.Panel2.Controls.Add(this.pnlContent);
            this.spltContainer.Panel2.Controls.Add(this.pnlOptions);
            this.spltContainer.Size = new System.Drawing.Size(744, 451);
            this.spltContainer.SplitterDistance = 260;
            this.spltContainer.TabIndex = 1;
            this.spltContainer.TabStop = false;
            // 
            // richTxtBoxHelp
            // 
            this.richTxtBoxHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtBoxHelp.BackColor = System.Drawing.Color.White;
            this.richTxtBoxHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTxtBoxHelp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.richTxtBoxHelp.Location = new System.Drawing.Point(12, 7);
            this.richTxtBoxHelp.Name = "richTxtBoxHelp";
            this.richTxtBoxHelp.ReadOnly = true;
            this.richTxtBoxHelp.Size = new System.Drawing.Size(236, 432);
            this.richTxtBoxHelp.TabIndex = 0;
            this.richTxtBoxHelp.TabStop = false;
            this.richTxtBoxHelp.Text = "test\ntest\ntest";
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.AutoSize = true;
            this.pnlContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(480, 408);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.btnCancel);
            this.pnlOptions.Controls.Add(this.btnSaveChanges);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOptions.Location = new System.Drawing.Point(0, 408);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(480, 43);
            this.pnlOptions.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(121, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(13, 8);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(92, 23);
            this.btnSaveChanges.TabIndex = 0;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // pnlBanner
            // 
            this.pnlBanner.AutoSize = true;
            this.pnlBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlBanner.Controls.Add(this.pictureBox2);
            this.pnlBanner.Controls.Add(this.picWabiLogo);
            this.pnlBanner.Controls.Add(this.lnklblHelp);
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlBanner.MaximumSize = new System.Drawing.Size(0, 94);
            this.pnlBanner.MinimumSize = new System.Drawing.Size(0, 94);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(744, 94);
            this.pnlBanner.TabIndex = 2;
            this.pnlBanner.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBanner_Paint);
            this.pnlBanner.Resize += new System.EventHandler(this.pnlBanner_Resize);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::PersistProClient.Properties.Resources.pp_conceptwithicon_new2;
            this.pictureBox2.Location = new System.Drawing.Point(13, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 35);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // picWabiLogo
            // 
            this.picWabiLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picWabiLogo.BackColor = System.Drawing.Color.Transparent;
            this.picWabiLogo.Image = global::PersistProClient.Properties.Resources.WabiLogo_no_background;
            this.picWabiLogo.Location = new System.Drawing.Point(4904, 37);
            this.picWabiLogo.Name = "picWabiLogo";
            this.picWabiLogo.Size = new System.Drawing.Size(105, 45);
            this.picWabiLogo.TabIndex = 1;
            this.picWabiLogo.TabStop = false;
            // 
            // lnklblHelp
            // 
            this.lnklblHelp.AutoSize = true;
            this.lnklblHelp.BackColor = System.Drawing.Color.Transparent;
            this.lnklblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblHelp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(142)))), ((int)(((byte)(52)))));
            this.lnklblHelp.Location = new System.Drawing.Point(9, 76);
            this.lnklblHelp.Name = "lnklblHelp";
            this.lnklblHelp.Size = new System.Drawing.Size(68, 13);
            this.lnklblHelp.TabIndex = 0;
            this.lnklblHelp.TabStop = true;
            this.lnklblHelp.Text = "Show Help";
            this.lnklblHelp.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(142)))), ((int)(((byte)(52)))));
            this.lnklblHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblHelp_LinkClicked);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStripNotifyIcon;
            this.notifyIcon.Text = "PersistPro - because it is Your data";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStripNotifyIcon
            // 
            this.contextMenuStripNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPersistProToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.contextMenuStripNotifyIcon.Name = "contextMenuStripNotifyIcon";
            this.contextMenuStripNotifyIcon.Size = new System.Drawing.Size(164, 54);
            // 
            // openPersistProToolStripMenuItem
            // 
            this.openPersistProToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openPersistProToolStripMenuItem.Name = "openPersistProToolStripMenuItem";
            this.openPersistProToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openPersistProToolStripMenuItem.Text = "Open PersistPro";
            this.openPersistProToolStripMenuItem.Click += new System.EventHandler(this.openPersistProToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // PersistPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(744, 544);
            this.Controls.Add(this.pnlBanner);
            this.Controls.Add(this.spltContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PersistPro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PersistPro - because it is Your data [v1.0]";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.Load += new System.EventHandler(this.PersistPro_Load);
            this.Shown += new System.EventHandler(this.PersistPro_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PersistPro_FormClosing);
            this.spltContainer.Panel1.ResumeLayout(false);
            this.spltContainer.Panel2.ResumeLayout(false);
            this.spltContainer.Panel2.PerformLayout();
            this.spltContainer.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.pnlBanner.ResumeLayout(false);
            this.pnlBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWabiLogo)).EndInit();
            this.contextMenuStripNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer spltContainer;
        private System.Windows.Forms.RichTextBox richTxtBoxHelp;
        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.LinkLabel lnklblHelp;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem openPersistProToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox picWabiLogo;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

