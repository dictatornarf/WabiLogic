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
    public partial class RootManagerEdit : PersistProControlBase {
        private ListViewItem CurrentSelectedItem { get; set; }
        private IPlanManager PlanManager { get; set; }

        public RootManagerEdit() : this(null) { }

        public RootManagerEdit(IPlanManager planManager) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.Help = Resources.RootManagerHelp;
        }

        public override NavigationControl NavigationControlType() {
            return NavigationControl.Back;
        }

        private void btnNew_Click(object sender, EventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new RootEdit(this.PlanManager, this.PlanManager.CreateRoot("", "", true, true, "")));
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (this.PlanManager.Plans.Where(x => x.Root.Equals(this.CurrentSelectedItem.Tag)).Count() > 0) {
                MessageBox.Show(this, "This is currently in use by a backup plan. You cannot remove it.", "Cannot remove.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (DialogResult.Yes == MessageBox.Show(this, "Are you sure you want to remove this Backup Plan?", "Remove Backup Plan?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) {
                IRoot root = (IRoot)this.CurrentSelectedItem.Tag;
                this.PlanManager.DeleteRoot(root);
                UpdateList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new RootEdit(this.PlanManager, (IRoot)this.CurrentSelectedItem.Tag));
        }

        private void RootManagerEdit_Load(object sender, EventArgs e) {
            UpdateList();
        }

        private void UpdateList() {
            lstViewRoots.Items.Clear();
            foreach (IRoot root in this.PlanManager.Roots) {
                ListViewItem lvi = lstViewRoots.Items.Add(new ListViewItem(new string[] { root.Name, root.Folder }));
                lvi.Tag = root;
            }

            if (lstViewRoots.Items.Count > 0)
                lstViewRoots.Items[0].Selected = true;

            ShowButtons();
        }

        private void ShowButtons() {
            btnEdit.Enabled = (lstViewRoots.Items.Count > 0);
            btnDelete.Enabled = (lstViewRoots.Items.Count > 0);
        }

        private void lstViewRoots_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (e.IsSelected)
                this.CurrentSelectedItem = e.Item;
        }

        private void RootManagerEdit_ParentChanged(object sender, EventArgs e) {
            if (this.Parent != null)
                UpdateList();
        }
    }
}
