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
    public partial class MountManagerEdit : PersistProControlBase {
        private ListViewItem CurrentSelectedItem { get; set; }
        private IPlanManager PlanManager { get; set; }

        public MountManagerEdit() : this(null) { }

        public MountManagerEdit(IPlanManager planManager) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.Help = Resources.MountManagerHelp;
        }

        public override NavigationControl NavigationControlType() {
            return NavigationControl.Back;
        }

        private void btnNew_Click(object sender, EventArgs e) {
            lblSelectType.Visible = true;
            cmbBoxMountTypes.Visible = true;
            btnCreate.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (this.PlanManager.Plans.Where(x => x.Mount.Id == ((IMount)this.CurrentSelectedItem.Tag).Id).Count() > 0)
            {
                MessageBox.Show(this, "This is currently in use by a backup plan. You cannot remove it.", "Cannot remove.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (DialogResult.Yes == MessageBox.Show(this, "Are you sure you want to remove this?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) {
                IMount mount = (IMount)this.CurrentSelectedItem.Tag;
                this.PlanManager.DeleteMount(mount);
                UpdateList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;

            if (this.CurrentSelectedItem.Tag is IFileMount)
                viewState.MoveForward(new FileMountEdit(this.PlanManager, (IFileMount)this.CurrentSelectedItem.Tag));

            if (this.CurrentSelectedItem.Tag is IExternalDriveMount)
                viewState.MoveForward(new ExternalDriveMountEdit(this.PlanManager, (IExternalDriveMount)this.CurrentSelectedItem.Tag));

            if (this.CurrentSelectedItem.Tag is IFtpMount)
                viewState.MoveForward(new FtpMountEdit(this.PlanManager, (IFtpMount)this.CurrentSelectedItem.Tag));
        }

        private void MountManagerEdit_Load(object sender, EventArgs e) {
            UpdateList();
            cmbBoxMountTypes.SelectedIndex = 0;
        }

        private void UpdateList() {
            lstViewMounts.Items.Clear();
            foreach (IMount mount in this.PlanManager.Mounts) {
                ListViewItem lvi = lstViewMounts.Items.Add(new ListViewItem(new string[] { mount.TypeDisplayName, mount.Name }));
                lvi.Tag = mount;
            }

            if (lstViewMounts.Items.Count > 0)
                lstViewMounts.Items[0].Selected = true;

            ShowButtons();
        }

        private void ShowButtons() {
            btnEdit.Enabled = (lstViewMounts.Items.Count > 0);
            btnDelete.Enabled = (lstViewMounts.Items.Count > 0);
        }

        private void lstViewMounts_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (e.IsSelected)
                this.CurrentSelectedItem = e.Item;
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;

            if (cmbBoxMountTypes.SelectedIndex == 0)
                viewState.MoveForward(new FileMountEdit(this.PlanManager, this.PlanManager.CreateFileMount("", "", "")));
            if (cmbBoxMountTypes.SelectedIndex == 1)
                viewState.MoveForward(new ExternalDriveMountEdit(this.PlanManager, this.PlanManager.CreateExternalDriveMount("", "", "", "")));
            if (cmbBoxMountTypes.SelectedIndex == 2)
                viewState.MoveForward(new FtpMountEdit(this.PlanManager, this.PlanManager.CreateFtpMount("", "", "", 21, "", "", "")));
        }

        private void MountManagerEdit_ParentChanged(object sender, EventArgs e) {
            if (this.Parent != null)
                UpdateList();
        }
    }
}
