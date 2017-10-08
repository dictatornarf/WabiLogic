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
using WabiLogic.PersistPro.Controller;
using System.Threading;

namespace PersistProClient {
    public partial class PersistProManager : PersistProControlBase {
        private IFactory Factory { get; set; }
        private IPlanManager PlanManager { get; set; }
        private Mutex SystemEditLock { get; set; }
        private int SystemEditLockCount { get; set; }

        public PersistProManager() : this(null, null) { }

        public PersistProManager(IFactory factory, IPlanManager planManager) {
            InitializeComponent();

            this.Factory = factory;
            this.PlanManager = planManager;
            this.Help = Resources.PersistProManagerHelp;

            this.SystemEditLock = new Mutex(false, "PersistProSystemEdit");
            this.SystemEditLockCount = 0;
        }

        private void lnkLblBackupPlan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (TrySystemEditLock()) {
                ViewState viewState = this.Parent.Tag as ViewState;
                viewState.MoveForward(new PlanManagerEdit(this.PlanManager));
            }
        }

        private void lnkLblWhat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (TrySystemEditLock()) {
                ViewState viewState = this.Parent.Tag as ViewState;
                viewState.MoveForward(new RootManagerEdit(this.PlanManager));
            }
        }

        private void lnkLblWhere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (TrySystemEditLock()) {
                ViewState viewState = this.Parent.Tag as ViewState;
                viewState.MoveForward(new MountManagerEdit(this.PlanManager));
            }
        }

        private void lnkLblWhen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (TrySystemEditLock()) {
                ViewState viewState = this.Parent.Tag as ViewState;
                viewState.MoveForward(new ScheduleManagerEdit(this.PlanManager));
            }
        }

        private void lnkLblRestoreFromBackup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new RestoreSelector(this.Factory, this.PlanManager));
        }

        private void lnkLblStatus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ViewState viewState = this.Parent.Tag as ViewState;
            viewState.MoveForward(new StatusView(this.Factory, this.PlanManager));
        }

        private void PersistProManager_Load(object sender, EventArgs e) {
            if (this.Factory.RunSetup) {
                ViewState viewState = this.Parent.Tag as ViewState;
                viewState.MoveForward(new Configure(this.Factory, this.PlanManager));
            }
        }

        private bool TrySystemEditLock() {
            bool allow = false;

            try {
                allow = this.SystemEditLock.WaitOne(0, false);
            }
            catch (AbandonedMutexException) {
                allow = true;
            }
            
            if (allow) {
                this.SystemEditLockCount++;
            }
            else {
                //Block Access
                MessageBox.Show("The system is currently be edited by another user. They must complete their changes before you can access this functionality.", "Edit in process, please wait.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            return allow;
        }

        private void PersistProManager_ParentChanged(object sender, EventArgs e) {
            if (this.Parent != null && this.SystemEditLockCount > 0) {
                this.SystemEditLock.ReleaseMutex();
                this.SystemEditLockCount--;
            }
        }
    }
}
