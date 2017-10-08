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

namespace PersistProClient {
    public partial class PlanManagerEdit : PersistProControlBase {
        private IPlanManager PlanManager { get; set; }
        private ListViewItem CurrentSelectedItem { get; set; }

        public PlanManagerEdit() : this(null) { }

        public PlanManagerEdit(IPlanManager planManager) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.Help = Resources.PlanManagerHelp;
        }

        private void PlanManagerEdit_Load(object sender, EventArgs e) {
            UpdateList();
        }

        public override NavigationControl NavigationControlType() {
            return NavigationControl.Back;
        }

        private void UpdateList() {
            lstViewPlans.Items.Clear();
            foreach (IPlan plan in this.PlanManager.Plans) {
                ListViewItem lvi = lstViewPlans.Items.Add(new ListViewItem(new string[] { plan.Root.Name, plan.Mount.Name, plan.Schedule.Name }));
                lvi.Tag = plan;
            }

            if (lstViewPlans.Items.Count > 0)
                lstViewPlans.Items[0].Selected = true;

            ShowButtons();
        }

        private void ShowButtons() {
            btnEdit.Enabled = (lstViewPlans.Items.Count > 0);
            btnDelete.Enabled = (lstViewPlans.Items.Count > 0);
        }

        private void btnNew_Click(object sender, EventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new PlanEdit(this.PlanManager, null));
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (DialogResult.Yes == MessageBox.Show(this, "Are you sure you want to remove this Backup Plan?", "Remove Backup Plan?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) {
                IPlan plan = (IPlan)this.CurrentSelectedItem.Tag;
                this.PlanManager.DeletePlan(plan);
                UpdateList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new PlanEdit(this.PlanManager, (IPlan)this.CurrentSelectedItem.Tag));
        }

        private void lstViewPlans_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
             if (e.IsSelected) 
                this.CurrentSelectedItem = e.Item;
         }

        private void PlanManagerEdit_ParentChanged(object sender, EventArgs e) {
            if (this.Parent != null)
                UpdateList();
        }
    }
}
