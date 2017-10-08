using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WabiLogic.PersistPro.Model;
using PersistProClient.Properties;
using WabiLogic.Foundation.Tools;

namespace PersistProClient {
    public partial class ScheduleManagerEdit : PersistProControlBase {
        private ListViewItem CurrentSelectedItem { get; set; }
        private IPlanManager PlanManager { get; set; }

        public ScheduleManagerEdit() : this(null) { }

        public ScheduleManagerEdit(IPlanManager planManager) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.Help = Resources.ScheduleManagerHelp;
        }

        public override NavigationControl NavigationControlType() {
            return NavigationControl.Back;
        }

        private void ScheduleManagerEdit_Load(object sender, EventArgs e) {
            UpdateList();
        }

        private void BtnNew_Click(object sender, EventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new ScheduleEdit(this.PlanManager, this.PlanManager.CreateSchedule("", TimeSpan.Zero, ScheduleType.Daily, DayOfWeek.Sunday, WeekOfMonth.First)));
        }

        private void BtnDelete_Click(object sender, EventArgs e) {
            if (this.PlanManager.Plans.Where(x => x.Schedule.Equals(this.CurrentSelectedItem.Tag)).Count() > 0) {
                MessageBox.Show(this, "This is currently in use by a backup plan. You cannot remove it.", "Cannot remove.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (DialogResult.Yes == MessageBox.Show(this, "Are you sure you want to remove this Backup Plan?", "Remove Backup Plan?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) {
                ISchedule schedule = (ISchedule)this.CurrentSelectedItem.Tag;
                this.PlanManager.DeleteSchedule(schedule);
                UpdateList();
            }
        }

        private void UpdateList() {
            lstViewSchedules.Items.Clear();

            try
            {
                foreach (ISchedule schedule in this.PlanManager.Schedules)
                {
                    ListViewItem lvi = lstViewSchedules.Items.Add(new ListViewItem(new string[] { schedule.Name }));
                    lvi.Tag = schedule;
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error updating List.", e);
            }
            if (lstViewSchedules.Items.Count > 0)
                lstViewSchedules.Items[0].Selected = true;

            ShowButtons();
        }

        private void ShowButtons() {
            btnEdit.Enabled = (lstViewSchedules.Items.Count > 0);
            btnDelete.Enabled = (lstViewSchedules.Items.Count > 0);
        }

        private void BtnEdit_Click(object sender, EventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new ScheduleEdit(this.PlanManager, (ISchedule)this.CurrentSelectedItem.Tag));
        }

        private void LstViewRoots_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (e.IsSelected)
                this.CurrentSelectedItem = e.Item;
        }

        private void ScheduleManagerEdit_ParentChanged(object sender, EventArgs e) {
            if (this.Parent != null)
                UpdateList();
        }
    }
}
