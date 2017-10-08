using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WabiLogic.PersistPro.Model;
using System.IO;
using PersistProClient.Properties;

namespace PersistProClient {
    public partial class ExternalDriveMountEdit : PersistProControlBase {
        private IPlanManager PlanManager { get; set; }
        private IExternalDriveMount ExternalDriveMount { get; set; }

        public ExternalDriveMountEdit() : this(null, null) { }

        public ExternalDriveMountEdit(IPlanManager planManager, IExternalDriveMount externalDriveMount) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.ExternalDriveMount = externalDriveMount;
            this.Help = Resources.ExternalDriveMountHelp;

            cmbBoxLabels.ValueMember = "Label";
            cmbBoxLabels.DisplayMember = "Desc";
        }

        public override bool SaveChanges() {
            if (txtBoxName.Text.Trim().Length == 0) {
                MessageBox.Show("Name cannot be blank.", "Name needed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxName.Focus();
                return false;
            }

            if (!cmbBoxLabels.Enabled) {
                MessageBox.Show("Please insert an external drive and press Refresh.", "External Drive needed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            this.ExternalDriveMount.Name = txtBoxName.Text;
            this.ExternalDriveMount.Folder = txtBoxFolderName.Text;
            if (cmbBoxLabels.Items.Count > 0)
                this.ExternalDriveMount.Label = ((Item)cmbBoxLabels.SelectedItem).Label;

            return true;
        }

        public override void Cancel() {
            if (this.ExternalDriveMount.Name.Length == 0) //If the name is empty then it was just created
                this.PlanManager.DeleteMount(this.ExternalDriveMount);
        }

        private void ExternalDriveMountEdit_Load(object sender, EventArgs e) {
            txtBoxName.Text = this.ExternalDriveMount.Name;
            txtBoxFolderName.Text = this.ExternalDriveMount.Folder;
            LoadLabels();
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            LoadLabels();
        }

        private void LoadLabels() {
            cmbBoxLabels.Items.Clear();

            foreach (DriveInfo drive in DriveInfo.GetDrives()) {
                try {
                    if (drive.DriveType != DriveType.Removable)
                        continue;

                    string labelDesc = null;
                    if (drive.VolumeLabel.Trim().Length == 0)
                        labelDesc = string.Format("[No Label] ({0})", drive.RootDirectory);
                    else
                        labelDesc = string.Format("{0} ({1})", drive.VolumeLabel, drive.RootDirectory);

                    cmbBoxLabels.Items.Add(new Item() { Desc = labelDesc, Label = drive.VolumeLabel });
                }
                catch {
                    //Ignore
                }
            }

            bool foundCurrentDrive = false;
            if (cmbBoxLabels.Items.Count > 0) {
                //Select current Label
                for (int i = 0; i < cmbBoxLabels.Items.Count; i++) {
                    if (((Item)cmbBoxLabels.Items[i]).Label == this.ExternalDriveMount.Label) {
                        foundCurrentDrive = true;
                        cmbBoxLabels.SelectedIndex = i;
                        break;
                    }
                }
            }

            //If the formerly selected drive is not present, add it
            if (!foundCurrentDrive && this.ExternalDriveMount.Name != "") {
                string labelDesc = null;
                if (this.ExternalDriveMount.Label.Trim().Length == 0)
                    labelDesc = "[No Label] (Not Connected)";
                else
                    labelDesc = string.Format("{0} (Not Connected)", this.ExternalDriveMount.Label);

                cmbBoxLabels.Items.Insert(0, new Item() { Desc = labelDesc, Label = this.ExternalDriveMount.Label });
                cmbBoxLabels.SelectedIndex = 0;
            }

            //If no drives are present
            if (cmbBoxLabels.Items.Count == 0) {
                cmbBoxLabels.Items.Add("No External Drives Found.");
                cmbBoxLabels.Enabled = false;
            }
            else {
                cmbBoxLabels.Enabled = true;
            }
        }

        private class Item {
            public string Desc { get; set; }
            public string Label { get; set; }
        }
    }
}
