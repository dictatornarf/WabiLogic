using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WabiLogic.PersistPro.Model;
using WabiLogic.Foundation.Tools;

namespace PersistProClient {
    public partial class ScheduleEdit : PersistProControlBase {
        private IPlanManager PlanManager { get; set; }
        private ISchedule Schedule { get; set; }

        public ScheduleEdit() : this(null, null) { }

        public ScheduleEdit(IPlanManager planManager, ISchedule schedule) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.Schedule = schedule;
        }

        public override bool SaveChanges() {
            this.Schedule.Name = txtBoxName.Text;
            this.Schedule.Time = new TimeSpan(dtpTime.Value.Hour, dtpTime.Value.Minute, 0);
            this.Schedule.ScheduleType = (ScheduleType)Enum.Parse(typeof(ScheduleType), cmbBoxSchedule.Text, true);
            this.Schedule.DayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), cmbBoxDayOfWeek.Text, true);
            this.Schedule.WeekOfMonth = (WeekOfMonth)Enum.Parse(typeof(WeekOfMonth), cmbBoxWeekOfMonth.Text, true);

            return true;
        }

        public override void Cancel() {
            if (this.Schedule.Name.Length == 0) //If the name is empty then it was just created
                this.PlanManager.DeleteSchedule(this.Schedule);
        }

        private void ScheduleEdit_Load(object sender, EventArgs e) {
            txtBoxName.Text = this.Schedule.Name;
            dtpTime.Value = new DateTime(DateTime.Today.Ticks + this.Schedule.Time.Ticks);
            cmbBoxSchedule.SelectedItem = this.Schedule.ScheduleType.ToString();
            cmbBoxDayOfWeek.SelectedItem = this.Schedule.DayOfWeek.ToString();
            cmbBoxWeekOfMonth.SelectedItem = this.Schedule.WeekOfMonth.ToString(); ;
        }

        private void fieldChanged(object sender, EventArgs e) {
            UpdateState();
        }

        private ScheduleType GetCurrentScheduleType() {
            ScheduleType toReturn = ScheduleType.None;

            switch (cmbBoxSchedule.SelectedIndex) {
                case 0:
                    toReturn = ScheduleType.Daily;
                    break;
                case 1:
                    toReturn = ScheduleType.Weekly;
                    break;
                case 2:
                    toReturn = ScheduleType.Monthly;
                    break;
            }

            return toReturn;
        }

        private void SetVisibleState() {
            int beginX = lblTime.Left;
            int padding = 5;

            switch (GetCurrentScheduleType()) {
                case ScheduleType.Daily:
                    dtpTime.Enabled = true;
                    cmbBoxDayOfWeek.Enabled = false;
                    cmbBoxWeekOfMonth.Enabled = false;

                    cmbBoxWeekOfMonth.Visible = false;
                    cmbBoxDayOfWeek.Visible = false;
                    lblAt.Visible = false;
                    dtpTime.Visible = true;

                    dtpTime.Left = beginX;
                    break;
                case ScheduleType.Weekly:
                    dtpTime.Enabled = true;
                    cmbBoxDayOfWeek.Enabled = true;
                    cmbBoxWeekOfMonth.Enabled = false;

                    cmbBoxWeekOfMonth.Visible = false;
                    cmbBoxDayOfWeek.Visible = true;
                    lblAt.Visible = true;
                    dtpTime.Visible = true;

                    cmbBoxDayOfWeek.Left = beginX;
                    lblAt.Left = cmbBoxDayOfWeek.Left + cmbBoxDayOfWeek.Width + padding;
                    dtpTime.Left = lblAt.Left + lblAt.Width + padding;
                    break;
                case ScheduleType.Monthly:
                    dtpTime.Enabled = true;
                    cmbBoxDayOfWeek.Enabled = true;
                    cmbBoxWeekOfMonth.Enabled = true;

                    cmbBoxWeekOfMonth.Visible = true;
                    cmbBoxDayOfWeek.Visible = true;
                    lblAt.Visible = true;
                    dtpTime.Visible = true;

                    cmbBoxWeekOfMonth.Left = beginX;
                    cmbBoxDayOfWeek.Left = cmbBoxWeekOfMonth.Left + cmbBoxWeekOfMonth.Width + padding;
                    lblAt.Left = cmbBoxDayOfWeek.Left + cmbBoxDayOfWeek.Width + padding;
                    dtpTime.Left = lblAt.Left + lblAt.Width + padding;
                    break;
            }
        }

        private void UpdateState() {
            SetVisibleState();
            txtBoxName.Text = BuildDescriptiveName();
        }

        private string BuildDescriptiveName() {
            string toReturn = null;

            switch (GetCurrentScheduleType()) {
                case ScheduleType.Daily:
                    toReturn = string.Format("Daily at {0}", dtpTime.Text);
                    break;
                case ScheduleType.Weekly:
                    toReturn = string.Format("{0} at {1}", cmbBoxDayOfWeek.Text, dtpTime.Text);
                    break;
                case ScheduleType.Monthly:
                    toReturn = string.Format("{0} {1} at {2}", cmbBoxWeekOfMonth.Text, cmbBoxDayOfWeek.Text, dtpTime.Text);
                    break;
            }

            return toReturn;
        }
    }
}
