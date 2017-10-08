using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PersistProClient.Properties;
using WabiLogic.PersistPro.Model;

namespace PersistProClient {
    public partial class PlanEdit : PersistProControlBase {
        private IPlanManager PlanManager { get; set; }
        private IPlan Plan { get; set; }

        public PlanEdit() : this(null, null) { }

        public PlanEdit(IPlanManager planManager, IPlan plan) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.Plan = plan;
            this.Help = Resources.PlanHelp;
        }

        public override bool SaveChanges() {
            if (cmbBoxRoot.SelectedItem == null) {
                MessageBox.Show("You must specify what you want to backup.", "Specify what to backup.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBoxRoot.Focus();
                return false;
            }

            if (cmbBoxMount.SelectedItem == null) {
                MessageBox.Show("You must specify where you want to backup.", "Specify where to backup.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBoxMount.Focus();
                return false;
            }

            if (cmbBoxSchedule.SelectedItem == null) {
                MessageBox.Show("You must specify when you want to backup.", "Specify when to backup.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBoxSchedule.Focus();
                return false;
            }

            if (this.Plan == null) {
                this.Plan = this.PlanManager.CreatePlan(
                    cmbBoxRoot.SelectedItem as IRoot,
                    cmbBoxMount.SelectedItem as IMount,
                    cmbBoxSchedule.SelectedItem as ISchedule
                );
            }
            else {
                this.Plan.Root = cmbBoxRoot.SelectedItem as IRoot;
                this.Plan.Mount = cmbBoxMount.SelectedItem as IMount;
                this.Plan.Schedule = cmbBoxSchedule.SelectedItem as ISchedule;
            }

            return true;
        }

        public override void Cancel() { }

        private void lnkLblRoot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new RootManagerEdit(this.PlanManager));
        }

        private void lnkLblWhen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new ScheduleManagerEdit(this.PlanManager));
        }

        private void PlanEdit_Load(object sender, EventArgs e) {
            UpdateList();
        }

        private void lnkLblMount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new MountManagerEdit(this.PlanManager));
        }

        private void PlanEdit_ParentChanged(object sender, EventArgs e) {
            //object root = cmbBoxRoot.SelectedItem;
            //object mount = cmbBoxMount.SelectedItem;
            //object schedule = cmbBoxSchedule.SelectedItem;

            UpdateList();

            //cmbBoxRoot.SelectedItem = root;
            //cmbBoxMount.SelectedItem = mount;
            //cmbBoxSchedule.SelectedItem = schedule;
        }

        private void UpdateList() {
            //Find if any items were preselected
            object rootItem = cmbBoxRoot.SelectedItem;
            object mountItem = cmbBoxMount.SelectedItem;
            object scheduleItem = cmbBoxSchedule.SelectedItem;

            //Reload boxes
            cmbBoxRoot.Items.Clear();
            foreach (IRoot root in this.PlanManager.Roots) {
                cmbBoxRoot.Items.Add(root);
            }

            cmbBoxMount.Items.Clear();
            foreach (IMount mount in this.PlanManager.Mounts) {
                cmbBoxMount.Items.Add(mount);
            }

            cmbBoxSchedule.Items.Clear();
            foreach (ISchedule schedule in this.PlanManager.Schedules) {
                cmbBoxSchedule.Items.Add(schedule);
            }

            //Select best match for boxes
            if (rootItem != null && cmbBoxRoot.Items.Contains(rootItem))
                cmbBoxRoot.SelectedItem = rootItem;
            else if (this.Plan != null)
                cmbBoxRoot.SelectedItem = this.Plan.Root;
            else if (this.PlanManager.Roots.Count() > 0)
                cmbBoxRoot.SelectedItem = this.PlanManager.Roots.First();

            if (mountItem != null && cmbBoxMount.Items.Contains(mountItem))
                cmbBoxMount.SelectedItem = mountItem;
            else if (this.Plan != null)
                cmbBoxMount.SelectedItem = this.Plan.Mount;
            else if (this.PlanManager.Mounts.Count() > 0)
                cmbBoxMount.SelectedItem = this.PlanManager.Mounts.First();

            if (scheduleItem != null && cmbBoxSchedule.Items.Contains(scheduleItem))
                cmbBoxSchedule.SelectedItem = scheduleItem;
            else if (this.Plan != null)
                cmbBoxSchedule.SelectedItem = this.Plan.Schedule;
            else if (this.PlanManager.Schedules.Count() > 0)
                cmbBoxSchedule.SelectedItem = this.PlanManager.Schedules.First();
        }
    }
}
