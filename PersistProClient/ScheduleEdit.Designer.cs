namespace PersistProClient {
    partial class ScheduleEdit {
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
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.cmbBoxSchedule = new System.Windows.Forms.ComboBox();
            this.cmbBoxDayOfWeek = new System.Windows.Forms.ComboBox();
            this.cmbBoxWeekOfMonth = new System.Windows.Forms.ComboBox();
            this.lblAt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(131, 24);
            this.lblHeader.Text = "Define When";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 43);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(168, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "This is the name of your schedule.";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Enabled = false;
            this.txtBoxName.Location = new System.Drawing.Point(16, 59);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(242, 20);
            this.txtBoxName.TabIndex = 2;
            this.txtBoxName.TabStop = false;
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "hh:mm tt";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(250, 156);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(71, 20);
            this.dtpTime.TabIndex = 9;
            this.dtpTime.Value = new System.DateTime(2008, 11, 7, 9, 0, 0, 0);
            this.dtpTime.ValueChanged += new System.EventHandler(this.fieldChanged);
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Location = new System.Drawing.Point(13, 91);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(174, 13);
            this.lblSchedule.TabIndex = 3;
            this.lblSchedule.Text = "How often do you want to backup?";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(13, 140);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(207, 13);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "When do you want your backup to occur?";
            // 
            // cmbBoxSchedule
            // 
            this.cmbBoxSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxSchedule.FormattingEnabled = true;
            this.cmbBoxSchedule.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.cmbBoxSchedule.Location = new System.Drawing.Point(16, 107);
            this.cmbBoxSchedule.Name = "cmbBoxSchedule";
            this.cmbBoxSchedule.Size = new System.Drawing.Size(242, 21);
            this.cmbBoxSchedule.TabIndex = 4;
            this.cmbBoxSchedule.SelectedIndexChanged += new System.EventHandler(this.fieldChanged);
            // 
            // cmbBoxDayOfWeek
            // 
            this.cmbBoxDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxDayOfWeek.FormattingEnabled = true;
            this.cmbBoxDayOfWeek.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cmbBoxDayOfWeek.Location = new System.Drawing.Point(129, 156);
            this.cmbBoxDayOfWeek.Name = "cmbBoxDayOfWeek";
            this.cmbBoxDayOfWeek.Size = new System.Drawing.Size(93, 21);
            this.cmbBoxDayOfWeek.TabIndex = 7;
            this.cmbBoxDayOfWeek.SelectedIndexChanged += new System.EventHandler(this.fieldChanged);
            // 
            // cmbBoxWeekOfMonth
            // 
            this.cmbBoxWeekOfMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxWeekOfMonth.FormattingEnabled = true;
            this.cmbBoxWeekOfMonth.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth",
            "Last"});
            this.cmbBoxWeekOfMonth.Location = new System.Drawing.Point(16, 156);
            this.cmbBoxWeekOfMonth.Name = "cmbBoxWeekOfMonth";
            this.cmbBoxWeekOfMonth.Size = new System.Drawing.Size(99, 21);
            this.cmbBoxWeekOfMonth.TabIndex = 6;
            this.cmbBoxWeekOfMonth.SelectedIndexChanged += new System.EventHandler(this.fieldChanged);
            // 
            // lblAt
            // 
            this.lblAt.AutoSize = true;
            this.lblAt.Location = new System.Drawing.Point(228, 159);
            this.lblAt.Name = "lblAt";
            this.lblAt.Size = new System.Drawing.Size(16, 13);
            this.lblAt.TabIndex = 8;
            this.lblAt.Text = "at";
            // 
            // ScheduleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAt);
            this.Controls.Add(this.cmbBoxWeekOfMonth);
            this.Controls.Add(this.cmbBoxDayOfWeek);
            this.Controls.Add(this.cmbBoxSchedule);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblSchedule);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.txtBoxName);
            this.Name = "ScheduleEdit";
            this.Size = new System.Drawing.Size(434, 214);
            this.Load += new System.EventHandler(this.ScheduleEdit_Load);
            this.Controls.SetChildIndex(this.txtBoxName, 0);
            this.Controls.SetChildIndex(this.dtpTime, 0);
            this.Controls.SetChildIndex(this.lblSchedule, 0);
            this.Controls.SetChildIndex(this.lblTime, 0);
            this.Controls.SetChildIndex(this.cmbBoxSchedule, 0);
            this.Controls.SetChildIndex(this.cmbBoxDayOfWeek, 0);
            this.Controls.SetChildIndex(this.cmbBoxWeekOfMonth, 0);
            this.Controls.SetChildIndex(this.lblAt, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox cmbBoxSchedule;
        private System.Windows.Forms.ComboBox cmbBoxDayOfWeek;
        private System.Windows.Forms.ComboBox cmbBoxWeekOfMonth;
        private System.Windows.Forms.Label lblAt;
    }
}
