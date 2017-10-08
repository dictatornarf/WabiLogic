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
using System.IO;
using WabiLogic.Foundation.Tools;

namespace PersistProClient {
    public partial class Configure : PersistProControlBase {
        private IFactory Factory { get; set; }
        private IPlanManager PlanManager { get; set; }

        public Configure() : this(null, null) { }

        public Configure(IFactory factory, IPlanManager planManager) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.Factory = factory;
            this.Help = Resources.ConfigureHelp;
        }

        public override NavigationControl NavigationControlType() {
            return NavigationControl.SaveChanges;
        }

        public override bool SaveChanges() {
            bool upper = false;
            bool lower = false;
            bool digit = false;
            bool askWhitespace = true;

            //confirm that the passwords match
            if (!txtBoxPassword.Text.Equals(txtBoxConfirmPassword.Text))
            {
                MessageBox.Show("The passwords entered do not match. Please re-type the password and try again", "Passwords do not match.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxPassword.Focus();
                return false;
            }

            for (int i = 0; i < txtBoxPassword.Text.Length; i++) {
                if (Char.IsUpper(txtBoxPassword.Text, i))
                    upper = true;
                if (Char.IsLower(txtBoxPassword.Text, i))
                    lower = true;
                if (Char.IsDigit(txtBoxPassword.Text, i))
                    digit = true;
                if (askWhitespace && Char.IsWhiteSpace(txtBoxPassword.Text, i)) {
                    if (DialogResult.No == MessageBox.Show("Are you sure you want your password to contain whitespace?", "Do you want whitespace?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) {
                        txtBoxPassword.Focus();
                        return false;
                    }
                    else {
                        askWhitespace = false;
                    }
                }
            }

            if (!(upper && lower && digit)) {
                MessageBox.Show("Password should contain numbers, uppercase, and lowercase characters.", "Strong password needed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxPassword.Focus();
                return false;
            }

            if (txtBoxPassword.Text.Trim().Length < 8) {
                MessageBox.Show("Password should be at least 8 characters long.", "Strong password needed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxPassword.Focus();
                return false;
            }

            if (chkBoxQuickSetupOption.Checked) {
                IRoot root = this.PlanManager.CreateRoot(Environment.UserName + "'s My Documents", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), true, true, "");
                IMount mount = this.PlanManager.CreateFileMount("Local Backup", "", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "PersistProBackup"));
                ISchedule schedule = this.PlanManager.CreateSchedule("Friday at 09:00 PM", new TimeSpan(21, 0, 0), ScheduleType.Weekly, DayOfWeek.Friday, WeekOfMonth.First);
                this.PlanManager.CreatePlan(root, mount, schedule);

                this.Factory.SavePlanManager();
            }

            //TODO - we need to add transaction code in case the save encryption password fails
            try
            {
                this.Factory.SaveEncryptionPassword(txtBoxPassword.Text);
                this.Factory.RunSetup = false;
                this.Factory.SaveConfiguration();
            }
            catch //(Exception e)
            {
                MessageBox.Show("PersistPro has encountered a problem while trying to save your configuration settings. Please try again or contact PersistPro support.", "Save Configuration Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }
    }
}
