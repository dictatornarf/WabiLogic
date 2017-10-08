using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using WabiLogic.PersistPro.Model;
using WabiLogic.Foundation.Storage;
using WabiLogic.PersistPro.Tools;
using WabiLogic.Foundation.Tools.Extensions;
using WabiLogic.PersistPro.Controller;
using WabiLogic.PersistPro.Restore;
using PersistProClient.Properties;

namespace PersistProClient
{
    public partial class RestoreQuick : PersistProControlBase {
        private IFactory Factory { get; set; }
        private IPlanManager PlanManager { get; set; }
        private DateTime Snapshot { get; set; }
        private IMount RestoreMount { get; set; }

        private IManager StorageManager { get; set; }
        private IFolder PlanRootFolder { get; set; }

        private class FolderDisplay
        {
            public string DisplayName { get; set; }
            public IFolderInstance FolderInstance { get; set; }
        }

        public RestoreQuick() : this(null, null,null, DateTime.MinValue) { }
        public RestoreQuick(IFactory factory, IPlanManager planManager, IMount selectedMount, DateTime snapshot)
        {
            InitializeComponent();
            
            this.Factory = factory;
            this.PlanManager = planManager;
            this.Snapshot = snapshot;
            this.RestoreMount = selectedMount;
            this.Help = Resources.QuickRestoreHelp;
        }

        public override NavigationControl NavigationControlType() {
            return NavigationControl.Back;
        }

        private void RestoreQuick_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == fbdBrowse.ShowDialog())
            {
                txtBoxPath.Text = fbdBrowse.SelectedPath;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            //TODO: Validate that the restore path is valid and not empty
            if (cmbSelectRoot.SelectedItem == null)
            {
                MessageBox.Show("You must specify which folder you want to restore.", "Specify what to restore.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSelectRoot.Focus();
                return;
            }

            //TODO: we should have it check to see if the path is valid
            //if the path is valid and the folder does not exist we should ask the user
            //if they want us to create the specified folder.
            if (!Directory.Exists(txtBoxPath.Text))
            {
                MessageBox.Show("You must specify where you want to restore.", "Specify where to restore.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxPath.Focus();
                return;
            }

            RestoreData();
        }

        private void UpdateList()
        {
            IManager storageManager = StorageLoader.Load(RestoreMount, this.Factory.LoadEncryption());
            storageManager.Open(); //TODO: Remember to close this....

            //This is the main level for the plan root.
            cmbSelectRoot.Items.Clear();
            cmbSelectRoot.DisplayMember = "DisplayName";
            foreach (IFolderInstance root in storageManager.GetRootFolder().GetSubFolderInstances(this.Snapshot))
            {
                //need to talk with Ben about how to remove the guid from the end of the folder name
                //we might have to add an additional property to the IFolderInstance that contains
                //the name minus the guid
                FolderDisplay display = new FolderDisplay()
                {
                    DisplayName = root.GetCleanFileName(),
                    FolderInstance = root
                };

                cmbSelectRoot.Items.Add(display);
            }

            //If there are no roots then we need to alert the user and error gracefully
            if (cmbSelectRoot.Items.Count == 0)
            {
                throw new Exception("Could not find root folder.");
            }

            cmbSelectRoot.SelectedIndex = 0;

            storageManager.Close();
        }

        private void RestoreQuick_ParentChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void RestoreData()
        {
            IRestorer restorer = RestoreFactory.RestoreFolder((cmbSelectRoot.SelectedItem as FolderDisplay).FolderInstance,
                                                                            txtBoxPath.Text,
                                                                            true,
                                                                            false,
                                                                            DateTime.Now);

            RestoreManager restoreManager = new RestoreManager(this.Factory, restorer);

            RestoreProgress restoreProgress = new RestoreProgress(restoreManager,RestoreMount.Name);
            restoreProgress.ShowDialog();

            restoreProgress.Dispose();
        }
    }
}
