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
using System.IO;

namespace PersistProClient {
    public partial class RootEdit : PersistProControlBase {
        private IPlanManager PlanManager { get; set; }
        private IRoot Root { get; set; }

        public RootEdit() : this(null, null) { }

        public RootEdit(IPlanManager planManager, IRoot root) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.Root = root;
            this.Help = Resources.RootHelp;
        }

        public override bool SaveChanges() {
            if (!Directory.Exists(txtBoxPath.Text)) {
                MessageBox.Show("Folder path does not exist.", "Cannot find folder.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxPath.Focus();
                return false;
            }
            
            if (txtBoxName.Text.Trim().Length == 0) {
                MessageBox.Show("Name cannot be blank.", "Name needed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxName.Focus();
                return false;
            }

            this.Root.Name = txtBoxName.Text;
            this.Root.Folder = txtBoxPath.Text;
            this.Root.Sub = chkBoxSub.Checked;
            this.Root.KeepHistory = chkBoxKeepHistory.Checked;

            return true;
        }

        public override void Cancel() {
            if (this.Root.Name.Length == 0) //If the name is empty then it was just created
                this.PlanManager.DeleteRoot(this.Root);
        }

        private void RootEdit_Load(object sender, EventArgs e) {
            txtBoxName.Text = this.Root.Name;
            txtBoxPath.Text = this.Root.Folder;
            chkBoxSub.Checked = this.Root.Sub;
            chkBoxKeepHistory.Checked = this.Root.KeepHistory;
        }

        private void lnkLblConfigureNameFilters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new RootNameFilterEdit(this.PlanManager, this.Root));
        }

        private void lnkLblConfigureAttributeFilters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new RootAttributeFilterEdit(this.PlanManager, this.Root));
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            if (DialogResult.OK == fbdBrowse.ShowDialog()) {
                txtBoxPath.Text = fbdBrowse.SelectedPath;
            }
        }
    }
}
