using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WabiLogic.PersistPro.Model;
using WabiLogic.PersistPro.Controller;
using PersistProClient.Properties;

namespace PersistProClient {
    public partial class RestoreSelector : PersistProControlBase {
        private IFactory Factory { get; set; }
        private IPlanManager PlanManager { get; set; }

        public RestoreSelector() : this(null, null) { }

        public RestoreSelector(IFactory factory, IPlanManager planManager)
        {
            InitializeComponent();
            this.Help = Resources.RestoreSelectorHelp;
            this.Factory = factory;
            this.PlanManager = planManager;
        }

        public override NavigationControl NavigationControlType() {
            return NavigationControl.Back;
        }

        private void cmbBoxMount_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleBackupButtons(cmbBoxMount.SelectedIndex >= 0);
        }

        private void ToggleBackupButtons(bool setEnabled)
        {
            lnkLblBackupExplorer.Enabled = setEnabled;
            lnkLblQuickRestore.Enabled = setEnabled;
        }

        private void RestoreManager_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            //Find if any items were preselected
            object mountItem = cmbBoxMount.SelectedItem;

            cmbBoxMount.Items.Clear();
            foreach (IMount mount in this.PlanManager.Mounts)
            {
                cmbBoxMount.Items.Add(mount);
            }

            //Select best match for boxes
            if (mountItem != null && cmbBoxMount.Items.Contains(mountItem))
                cmbBoxMount.SelectedItem = mountItem;
            else if (this.PlanManager.Mounts.Count() > 0)
                cmbBoxMount.SelectedItem = this.PlanManager.Mounts.First();
        }

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewState viewState = this.Parent.Tag as ViewState;
            IMount selectedMount = this.cmbBoxMount.SelectedItem as IMount;

            while(true)
            {

            if (IsMountAvailable(selectedMount))
                break;

               DialogResult result =  MessageBox.Show("The selected location is not available. " +
                                                    "If the location is on an external drive, " +
                                                    "ensure the drive in connected and try again. " +
                                                    "If the location is on an FTP site " +
                                                    "ensure the you have an active internet connection " +
                                                    "and the FTP site is available and try again.","Restore Location Unavailable", MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                    break; //they clicked retry so keep trying until success or cancel
                else
                    return; //they cancelled so exit the routine
            }

            if (sender.Equals(lnkLblMount))
                viewState.MoveForward(new MountManagerEdit(this.PlanManager));
            else if (sender.Equals(lnkLblQuickRestore))
                viewState.MoveForward(new RestoreQuick(this.Factory, this.PlanManager, selectedMount, DateTime.Now));
            else
                viewState.MoveForward(new RestoreBrowser(this.Factory, this.PlanManager, selectedMount, DateTime.Now));
        }

        private void RestoreSelector_ParentChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private bool IsMountAvailable(IMount selectedMount)
        {
            bool isAvailable = true;
            try
            {
                StorageLoader.Load(selectedMount, this.Factory.LoadEncryption());
            }
            catch
            {
                isAvailable = false;
            }
            return isAvailable;
        }
    }
}
