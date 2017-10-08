namespace PersistProClient {
    partial class PlanEdit {
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
            this.lblRoot = new System.Windows.Forms.Label();
            this.lblMount = new System.Windows.Forms.Label();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.cmbBoxRoot = new System.Windows.Forms.ComboBox();
            this.cmbBoxMount = new System.Windows.Forms.ComboBox();
            this.cmbBoxSchedule = new System.Windows.Forms.ComboBox();
            this.lnkLblRoot = new System.Windows.Forms.LinkLabel();
            this.lnkLblMount = new System.Windows.Forms.LinkLabel();
            this.lnkLblWhen = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(117, 24);
            this.lblHeader.Text = "Define Plan";
            // 
            // lblRoot
            // 
            this.lblRoot.AutoSize = true;
            this.lblRoot.Location = new System.Drawing.Point(13, 43);
            this.lblRoot.Name = "lblRoot";
            this.lblRoot.Size = new System.Drawing.Size(175, 13);
            this.lblRoot.TabIndex = 1;
            this.lblRoot.Text = "What data do you want to backup?";
            // 
            // lblMount
            // 
            this.lblMount.AutoSize = true;
            this.lblMount.Location = new System.Drawing.Point(13, 93);
            this.lblMount.Name = "lblMount";
            this.lblMount.Size = new System.Drawing.Size(204, 13);
            this.lblMount.TabIndex = 4;
            this.lblMount.Text = "Where do you want to backup your data?";
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Location = new System.Drawing.Point(13, 142);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(201, 13);
            this.lblSchedule.TabIndex = 7;
            this.lblSchedule.Text = "When do you want to backup your data?";
            // 
            // cmbBoxRoot
            // 
            this.cmbBoxRoot.DisplayMember = "Name";
            this.cmbBoxRoot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxRoot.FormattingEnabled = true;
            this.cmbBoxRoot.Location = new System.Drawing.Point(16, 59);
            this.cmbBoxRoot.Name = "cmbBoxRoot";
            this.cmbBoxRoot.Size = new System.Drawing.Size(274, 21);
            this.cmbBoxRoot.TabIndex = 2;
            // 
            // cmbBoxMount
            // 
            this.cmbBoxMount.DisplayMember = "Name";
            this.cmbBoxMount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxMount.FormattingEnabled = true;
            this.cmbBoxMount.Location = new System.Drawing.Point(16, 109);
            this.cmbBoxMount.Name = "cmbBoxMount";
            this.cmbBoxMount.Size = new System.Drawing.Size(274, 21);
            this.cmbBoxMount.TabIndex = 5;
            // 
            // cmbBoxSchedule
            // 
            this.cmbBoxSchedule.DisplayMember = "Name";
            this.cmbBoxSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxSchedule.FormattingEnabled = true;
            this.cmbBoxSchedule.Location = new System.Drawing.Point(16, 158);
            this.cmbBoxSchedule.Name = "cmbBoxSchedule";
            this.cmbBoxSchedule.Size = new System.Drawing.Size(274, 21);
            this.cmbBoxSchedule.TabIndex = 8;
            // 
            // lnkLblRoot
            // 
            this.lnkLblRoot.AutoSize = true;
            this.lnkLblRoot.Location = new System.Drawing.Point(296, 62);
            this.lnkLblRoot.Name = "lnkLblRoot";
            this.lnkLblRoot.Size = new System.Drawing.Size(75, 13);
            this.lnkLblRoot.TabIndex = 3;
            this.lnkLblRoot.TabStop = true;
            this.lnkLblRoot.Text = "Manage What";
            this.lnkLblRoot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblRoot_LinkClicked);
            // 
            // lnkLblMount
            // 
            this.lnkLblMount.AutoSize = true;
            this.lnkLblMount.Location = new System.Drawing.Point(296, 112);
            this.lnkLblMount.Name = "lnkLblMount";
            this.lnkLblMount.Size = new System.Drawing.Size(81, 13);
            this.lnkLblMount.TabIndex = 6;
            this.lnkLblMount.TabStop = true;
            this.lnkLblMount.Text = "Manage Where";
            this.lnkLblMount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblMount_LinkClicked);
            // 
            // lnkLblWhen
            // 
            this.lnkLblWhen.AutoSize = true;
            this.lnkLblWhen.Location = new System.Drawing.Point(296, 161);
            this.lnkLblWhen.Name = "lnkLblWhen";
            this.lnkLblWhen.Size = new System.Drawing.Size(78, 13);
            this.lnkLblWhen.TabIndex = 9;
            this.lnkLblWhen.TabStop = true;
            this.lnkLblWhen.Text = "Manage When";
            this.lnkLblWhen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblWhen_LinkClicked);
            // 
            // PlanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRoot);
            this.Controls.Add(this.lnkLblWhen);
            this.Controls.Add(this.lnkLblMount);
            this.Controls.Add(this.lnkLblRoot);
            this.Controls.Add(this.cmbBoxSchedule);
            this.Controls.Add(this.cmbBoxMount);
            this.Controls.Add(this.cmbBoxRoot);
            this.Controls.Add(this.lblSchedule);
            this.Controls.Add(this.lblMount);
            this.Name = "PlanEdit";
            this.Size = new System.Drawing.Size(402, 212);
            this.Load += new System.EventHandler(this.PlanEdit_Load);
            this.ParentChanged += new System.EventHandler(this.PlanEdit_ParentChanged);
            this.Controls.SetChildIndex(this.lblMount, 0);
            this.Controls.SetChildIndex(this.lblSchedule, 0);
            this.Controls.SetChildIndex(this.cmbBoxRoot, 0);
            this.Controls.SetChildIndex(this.cmbBoxMount, 0);
            this.Controls.SetChildIndex(this.cmbBoxSchedule, 0);
            this.Controls.SetChildIndex(this.lnkLblRoot, 0);
            this.Controls.SetChildIndex(this.lnkLblMount, 0);
            this.Controls.SetChildIndex(this.lnkLblWhen, 0);
            this.Controls.SetChildIndex(this.lblRoot, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRoot;
        private System.Windows.Forms.Label lblMount;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.ComboBox cmbBoxRoot;
        private System.Windows.Forms.ComboBox cmbBoxMount;
        private System.Windows.Forms.ComboBox cmbBoxSchedule;
        private System.Windows.Forms.LinkLabel lnkLblRoot;
        private System.Windows.Forms.LinkLabel lnkLblMount;
        private System.Windows.Forms.LinkLabel lnkLblWhen;
    }
}
