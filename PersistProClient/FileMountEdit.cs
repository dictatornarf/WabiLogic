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
    public partial class FileMountEdit : PersistProControlBase {
        private IPlanManager PlanManager { get; set; }
        private IFileMount FileMount { get; set; }

        public FileMountEdit() : this(null, null) { }

        public FileMountEdit(IPlanManager planManager, IFileMount fileMount) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.FileMount = fileMount;
            this.Help = Resources.FileMountHelp;
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

            this.FileMount.Name = txtBoxName.Text;
            this.FileMount.Folder = txtBoxPath.Text;

            return true;
        }

        public override void Cancel() {
            if (this.FileMount.Name.Length == 0) //If the name is empty then it was just created
                this.PlanManager.DeleteMount(this.FileMount);
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            if (DialogResult.OK == fbdBrowse.ShowDialog()) {
                txtBoxPath.Text = fbdBrowse.SelectedPath;
            }
        }

        private void FileMountEdit_Load(object sender, EventArgs e) {
            txtBoxName.Text = this.FileMount.Name;
            txtBoxPath.Text = this.FileMount.Folder;
        }
    }
}
