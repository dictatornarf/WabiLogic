namespace PersistProClient
{
    partial class RestoreProgress
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bgwkrRestore = new System.ComponentModel.BackgroundWorker();
            this.prgbarStatus = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblItemsRemaining = new System.Windows.Forms.Label();
            this.lblRestoreProgress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFromVal = new System.Windows.Forms.Label();
            this.lblRemItemsVal = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwkrRestore
            // 
            this.bgwkrRestore.WorkerReportsProgress = true;
            this.bgwkrRestore.WorkerSupportsCancellation = true;
            this.bgwkrRestore.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwkrRestore_DoWork);
            this.bgwkrRestore.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwkrRestore_RunWorkerCompleted);
            this.bgwkrRestore.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwkrRestore_ProgressChanged);
            // 
            // prgbarStatus
            // 
            this.prgbarStatus.Location = new System.Drawing.Point(33, 49);
            this.prgbarStatus.Name = "prgbarStatus";
            this.prgbarStatus.Size = new System.Drawing.Size(350, 14);
            this.prgbarStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgbarStatus.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(308, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(74, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Current Status";
            // 
            // lblItemsRemaining
            // 
            this.lblItemsRemaining.AutoSize = true;
            this.lblItemsRemaining.Location = new System.Drawing.Point(33, 27);
            this.lblItemsRemaining.Name = "lblItemsRemaining";
            this.lblItemsRemaining.Size = new System.Drawing.Size(88, 13);
            this.lblItemsRemaining.TabIndex = 2;
            this.lblItemsRemaining.Text = "Items Remaining:";
            // 
            // lblRestoreProgress
            // 
            this.lblRestoreProgress.AutoSize = true;
            this.lblRestoreProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(75)))), ((int)(((byte)(116)))));
            this.lblRestoreProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestoreProgress.ForeColor = System.Drawing.Color.White;
            this.lblRestoreProgress.Location = new System.Drawing.Point(33, 14);
            this.lblRestoreProgress.Name = "lblRestoreProgress";
            this.lblRestoreProgress.Size = new System.Drawing.Size(224, 20);
            this.lblRestoreProgress.TabIndex = 0;
            this.lblRestoreProgress.Text = "Restoring 122 items (23.4 MB)";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(75)))), ((int)(((byte)(116)))));
            this.panel1.Controls.Add(this.lblRestoreProgress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 47);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblFromVal);
            this.panel2.Controls.Add(this.lblRemItemsVal);
            this.panel2.Controls.Add(this.lblFrom);
            this.panel2.Controls.Add(this.lblItemsRemaining);
            this.panel2.Controls.Add(this.prgbarStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 112);
            this.panel2.TabIndex = 1;
            // 
            // lblFromVal
            // 
            this.lblFromVal.AutoSize = true;
            this.lblFromVal.Location = new System.Drawing.Point(123, 9);
            this.lblFromVal.Name = "lblFromVal";
            this.lblFromVal.Size = new System.Drawing.Size(53, 13);
            this.lblFromVal.TabIndex = 1;
            this.lblFromVal.Text = "My Folder";
            // 
            // lblRemItemsVal
            // 
            this.lblRemItemsVal.AutoSize = true;
            this.lblRemItemsVal.Location = new System.Drawing.Point(120, 27);
            this.lblRemItemsVal.Name = "lblRemItemsVal";
            this.lblRemItemsVal.Size = new System.Drawing.Size(74, 13);
            this.lblRemItemsVal.TabIndex = 3;
            this.lblRemItemsVal.Text = "100 (18.7 MB)";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(33, 9);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(403, 38);
            this.panel3.TabIndex = 2;
            // 
            // RestoreProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(403, 159);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RestoreProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Restoring Data";
            this.TransparencyKey = System.Drawing.Color.DeepPink;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgwkrRestore;
        private System.Windows.Forms.ProgressBar prgbarStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblItemsRemaining;
        private System.Windows.Forms.Label lblRestoreProgress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblFromVal;
        private System.Windows.Forms.Label lblRemItemsVal;
    }
}