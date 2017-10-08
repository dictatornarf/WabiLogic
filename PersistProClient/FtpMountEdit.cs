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
    public partial class FtpMountEdit : PersistProControlBase {
        private IPlanManager PlanManager { get; set; }
        private IFtpMount FtpMount { get; set; }

        public FtpMountEdit() : this(null, null) { }

        public FtpMountEdit(IPlanManager planManager, IFtpMount ftpMount) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.FtpMount = ftpMount;
            this.Help = Resources.FtpMountHelp;
        }

        public override bool SaveChanges() {
            if (txtBoxName.Text.Trim().Length == 0) {
                MessageBox.Show("Name cannot be blank.", "Name needed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxName.Focus();
                return false;
            }

            if (txtBoxServer.Text.Trim().Length == 0) {
                MessageBox.Show("Server cannot be blank.", "Server needed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxServer.Focus();
                return false;
            }

            int port = 1;
            if (txtBoxPort.Text.Trim().Length == 0 || !int.TryParse(txtBoxPort.Text, out port) || port < 1 || port > 65535) {
                MessageBox.Show("Port must be an number between 1 and 65535.", "Port needed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxPort.Focus();
                return false;
            }

            if (txtBoxUsername.Text.Trim().Length == 0) {
                MessageBox.Show("Username cannot be blank.", "Username needed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxUsername.Focus();
                return false;
            }

            if (txtBoxFolder.Text.Trim().Length == 0) {
                MessageBox.Show("Folder cannot be blank.", "Folder needed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxFolder.Focus();
                return false;
            }

            this.FtpMount.Name = txtBoxName.Text;
            this.FtpMount.Server = txtBoxServer.Text;
            this.FtpMount.Port = port;
            this.FtpMount.Username = txtBoxUsername.Text;
            this.FtpMount.Password = txtBoxPassword.Text;
            this.FtpMount.Folder = txtBoxFolder.Text;

            return true;
        }

        public override void Cancel() {
            if (this.FtpMount.Name.Length == 0) //If the name is empty then it was just created
                this.PlanManager.DeleteMount(this.FtpMount);
        }

        private void FtpMountEdit_Load(object sender, EventArgs e) {
            txtBoxName.Text = this.FtpMount.Name;
            txtBoxServer.Text = this.FtpMount.Server;
            txtBoxPort.Text = this.FtpMount.Port.ToString();
            txtBoxUsername.Text = this.FtpMount.Username;
            txtBoxPassword.Text = this.FtpMount.Password;
            txtBoxFolder.Text = this.FtpMount.Folder;
        }
    }
}
