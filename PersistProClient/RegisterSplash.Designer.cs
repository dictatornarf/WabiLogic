namespace PersistProClient {
    partial class RegisterSplash {
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
            this.btnOrderNow = new System.Windows.Forms.Button();
            this.btnOrderLater = new System.Windows.Forms.Button();
            this.timerEnable = new System.Windows.Forms.Timer(this.components);
            this.grpBoxRegister = new System.Windows.Forms.GroupBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtBoxKey = new System.Windows.Forms.TextBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.picPersistProLogo = new System.Windows.Forms.PictureBox();
            this.picWabiLogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpBoxRegister.SuspendLayout();
            this.pnlBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPersistProLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWabiLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOrderNow
            // 
            this.btnOrderNow.Location = new System.Drawing.Point(17, 104);
            this.btnOrderNow.Name = "btnOrderNow";
            this.btnOrderNow.Size = new System.Drawing.Size(107, 23);
            this.btnOrderNow.TabIndex = 1;
            this.btnOrderNow.Text = "Order Now";
            this.btnOrderNow.UseVisualStyleBackColor = true;
            this.btnOrderNow.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnOrderLater
            // 
            this.btnOrderLater.Location = new System.Drawing.Point(149, 104);
            this.btnOrderLater.Name = "btnOrderLater";
            this.btnOrderLater.Size = new System.Drawing.Size(104, 23);
            this.btnOrderLater.TabIndex = 2;
            this.btnOrderLater.Text = "Order Later (6)";
            this.btnOrderLater.UseVisualStyleBackColor = true;
            this.btnOrderLater.Click += new System.EventHandler(this.btnOrderLater_Click);
            // 
            // timerEnable
            // 
            this.timerEnable.Interval = 1000;
            this.timerEnable.Tick += new System.EventHandler(this.timerEnable_Tick);
            // 
            // grpBoxRegister
            // 
            this.grpBoxRegister.Controls.Add(this.btnRegister);
            this.grpBoxRegister.Controls.Add(this.txtBoxKey);
            this.grpBoxRegister.Controls.Add(this.txtBoxName);
            this.grpBoxRegister.Controls.Add(this.lblKey);
            this.grpBoxRegister.Controls.Add(this.lblName);
            this.grpBoxRegister.Location = new System.Drawing.Point(17, 147);
            this.grpBoxRegister.Name = "grpBoxRegister";
            this.grpBoxRegister.Size = new System.Drawing.Size(330, 175);
            this.grpBoxRegister.TabIndex = 3;
            this.grpBoxRegister.TabStop = false;
            this.grpBoxRegister.Text = "Register PersistPro";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(20, 129);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtBoxKey
            // 
            this.txtBoxKey.Location = new System.Drawing.Point(20, 92);
            this.txtBoxKey.Name = "txtBoxKey";
            this.txtBoxKey.Size = new System.Drawing.Size(292, 20);
            this.txtBoxKey.TabIndex = 3;
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(20, 41);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(292, 20);
            this.txtBoxName.TabIndex = 1;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(17, 76);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(65, 13);
            this.lblKey.TabIndex = 2;
            this.lblKey.Text = "Product Key";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // pnlBanner
            // 
            this.pnlBanner.AutoSize = true;
            this.pnlBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlBanner.Controls.Add(this.lblMessage);
            this.pnlBanner.Controls.Add(this.picPersistProLogo);
            this.pnlBanner.Controls.Add(this.picWabiLogo);
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlBanner.MaximumSize = new System.Drawing.Size(0, 94);
            this.pnlBanner.MinimumSize = new System.Drawing.Size(0, 94);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(473, 94);
            this.pnlBanner.TabIndex = 0;
            this.pnlBanner.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBanner_Paint);
            this.pnlBanner.Resize += new System.EventHandler(this.pnlBanner_Resize);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMessage.Location = new System.Drawing.Point(14, 72);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(227, 16);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Thank you for using PersistPro!";
            // 
            // picPersistProLogo
            // 
            this.picPersistProLogo.BackColor = System.Drawing.Color.Transparent;
            this.picPersistProLogo.Image = global::PersistProClient.Properties.Resources.pp_conceptwithicon_new2;
            this.picPersistProLogo.Location = new System.Drawing.Point(13, 13);
            this.picPersistProLogo.Name = "picPersistProLogo";
            this.picPersistProLogo.Size = new System.Drawing.Size(250, 35);
            this.picPersistProLogo.TabIndex = 2;
            this.picPersistProLogo.TabStop = false;
            // 
            // picWabiLogo
            // 
            this.picWabiLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picWabiLogo.BackColor = System.Drawing.Color.Transparent;
            this.picWabiLogo.Image = global::PersistProClient.Properties.Resources.WabiLogo_no_background;
            this.picWabiLogo.Location = new System.Drawing.Point(365, 50);
            this.picWabiLogo.Margin = new System.Windows.Forms.Padding(0);
            this.picWabiLogo.Name = "picWabiLogo";
            this.picWabiLogo.Size = new System.Drawing.Size(105, 45);
            this.picWabiLogo.TabIndex = 1;
            this.picWabiLogo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 336);
            this.panel1.TabIndex = 0;
            // 
            // RegisterSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(473, 336);
            this.ControlBox = false;
            this.Controls.Add(this.grpBoxRegister);
            this.Controls.Add(this.btnOrderLater);
            this.Controls.Add(this.btnOrderNow);
            this.Controls.Add(this.pnlBanner);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterSplash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PersistPro";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RegisterSplash_Load);
            this.grpBoxRegister.ResumeLayout(false);
            this.grpBoxRegister.PerformLayout();
            this.pnlBanner.ResumeLayout(false);
            this.pnlBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPersistProLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWabiLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOrderNow;
        private System.Windows.Forms.Button btnOrderLater;
        private System.Windows.Forms.Timer timerEnable;
        private System.Windows.Forms.GroupBox grpBoxRegister;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtBoxKey;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.PictureBox picPersistProLogo;
        private System.Windows.Forms.PictureBox picWabiLogo;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panel1;
    }
}