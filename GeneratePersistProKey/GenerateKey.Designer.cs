namespace GeneratePersistProKey {
    partial class GenerateKey {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateKey));
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblResultingKey = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxResult = new System.Windows.Forms.TextBox();
            this.txtBoxSpice = new System.Windows.Forms.TextBox();
            this.lblSpice = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(12, 9);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(82, 13);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblResultingKey
            // 
            this.lblResultingKey.AutoSize = true;
            this.lblResultingKey.Location = new System.Drawing.Point(12, 59);
            this.lblResultingKey.Name = "lblResultingKey";
            this.lblResultingKey.Size = new System.Drawing.Size(72, 13);
            this.lblResultingKey.TabIndex = 1;
            this.lblResultingKey.Text = "Resulting Key";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxName.Location = new System.Drawing.Point(12, 25);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(294, 20);
            this.txtBoxName.TabIndex = 2;
            this.txtBoxName.TextChanged += new System.EventHandler(this.txtBoxName_TextChanged);
            // 
            // txtBoxResult
            // 
            this.txtBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxResult.Location = new System.Drawing.Point(15, 75);
            this.txtBoxResult.Multiline = true;
            this.txtBoxResult.Name = "txtBoxResult";
            this.txtBoxResult.ReadOnly = true;
            this.txtBoxResult.Size = new System.Drawing.Size(478, 159);
            this.txtBoxResult.TabIndex = 3;
            // 
            // txtBoxSpice
            // 
            this.txtBoxSpice.Location = new System.Drawing.Point(312, 25);
            this.txtBoxSpice.Name = "txtBoxSpice";
            this.txtBoxSpice.Size = new System.Drawing.Size(89, 20);
            this.txtBoxSpice.TabIndex = 4;
            this.txtBoxSpice.TextChanged += new System.EventHandler(this.txtBoxSpice_TextChanged);
            // 
            // lblSpice
            // 
            this.lblSpice.AutoSize = true;
            this.lblSpice.Location = new System.Drawing.Point(309, 9);
            this.lblSpice.Name = "lblSpice";
            this.lblSpice.Size = new System.Drawing.Size(34, 13);
            this.lblSpice.TabIndex = 5;
            this.lblSpice.Text = "Spice";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(12, 242);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(53, 13);
            this.lblError.TabIndex = 6;
            this.lblError.Text = "Error Text";
            this.lblError.Visible = false;
            // 
            // GenerateKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 264);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblSpice);
            this.Controls.Add(this.txtBoxSpice);
            this.Controls.Add(this.txtBoxResult);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.lblResultingKey);
            this.Controls.Add(this.lblCustomerName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GenerateKey";
            this.Text = "Product Key Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblResultingKey;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxResult;
        private System.Windows.Forms.TextBox txtBoxSpice;
        private System.Windows.Forms.Label lblSpice;
        private System.Windows.Forms.Label lblError;
    }
}

