using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PersistProClient.Properties;
using WabiLogic.PersistPro.Model;
using WabiLogic.Foundation.Tools;
using WabiLogic.PersistPro.Controller;
using WabiLogic.PersistPro.Controller.SqlCe;
using WabiLogic.PersistPro.WcfProxy;
using System.ServiceModel;
using WabiLogic.PersistPro.Controller.Wcf;
using System.IO;
using System.Drawing.Drawing2D;

namespace PersistProClient {
    public partial class PersistPro : Form {
        private bool ApplicationSuccessfullyStarted { get; set; }
        private bool CloseApplication { get; set; }
        private bool IsNotifyIconOK { get; set; } //This exists because apparently you can't check (this.notifyIcon.Icon == Resources.NotifyIconOK)
        private ClientExecutor Client { get; set; }
        private ViewState ViewState { get; set; }
        private IFactory Factory { get; set; }
        private IPlanManager PlanManager { get; set; }
        private IHistoryManager HistoryManager { get; set; }

        public PersistPro() {
            this.ApplicationSuccessfullyStarted = false;

            InitializeComponent();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        }

        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {

            Action logError = () => {
                                  string dataDir = Path.Combine(Environment.GetFolderPath(
                                                                Environment.SpecialFolder.CommonApplicationData),
                                                                "Persist Pro");
                                  string errorLog = Path.Combine(dataDir, "error.log");

                    using (StreamWriter sw = File.AppendText(errorLog)) 
                    {
                        sw.WriteLine("---------------------------");
                        sw.WriteLine("Date: {0}", DateTime.Now);

                        Exception recursiveException = e.Exception;
                        do {
                            sw.WriteLine(recursiveException.Message);
                            sw.WriteLine(recursiveException.StackTrace);
                            recursiveException = recursiveException.InnerException;
                        } while (recursiveException != null);
                    }
        };
            
            try {
                //logError();
                if (!ApplicationSuccessfullyStarted) {
                    MessageBox.Show("PersistPro cannot communicate with the PersistPro service. The service must be active for this application to start. Please start the PersistPro service and launch this application again.", "Cannot start PersistPro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Environment.Exit(-1);
                }

                if (e.Exception is CommunicationException) {
                    MessageBox.Show("PersistPro cannot communicate with the PersistPro service. The service must be active for this application to work. Please start the PersistPro service and launch this application again.", "Cannot start PersistPro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Environment.Exit(-1);
                }
                else {
                    MessageBox.Show("A potential problem occurred with the PersistPro application. The client application will be closed. Please restart the client.", "Potential problem occured.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Environment.Exit(-1);
                }
                //this.Client.Stop();
                this.CloseApplication = true;
                Application.Exit();
                //this.Close();
            }
            catch (Exception) {
                //logError();
                Environment.Exit(-1);
            }
        }

        private void PersistPro_Load(object sender, EventArgs e) {
            //Set the window to the current system font
            //More info http://www.mztools.com/articles/2007/MZ2007030.aspx accessed 2008-11-22
            //Note to make this work right I set the AutoScaleMode to DPI
            this.Font = SystemFonts.MessageBoxFont;

            //This is used to keep the current state for the user controls.
            this.ViewState = new ViewState(this.pnlContent, x => richTxtBoxHelp.Rtf = x);
            this.pnlContent.Tag = this.ViewState;
            this.ViewState.ViewStateChanged += new ViewState.ViewStateChangedEventHandler(ViewState_ViewStateChanged);

            this.spltContainer.Panel1Collapsed = true;

            //This is to cause the window to not be visible during loading
            this.Opacity = 0.0;
            this.ShowInTaskbar = false;
            this.CloseApplication = false;

            this.notifyIcon.Icon = Resources.persistpro_icon_final;// Resources.NotifyIconOK;
            this.IsNotifyIconOK = true;
            
            this.Factory = new WcfFactory();
            this.PlanManager = this.Factory.LoadPlanManager();
            this.HistoryManager = this.Factory.LoadHistoryManager();

            //this.Factory.SaveEncryptionPassword("password");
            //this.Factory.SaveConfiguration();

            //Start client for server updates
            this.Client = new ClientExecutor(this.Factory);
            this.Client.HistoryChanged += new ChangedHistoryHandler(Client_HistoryChanged);
            this.Client.ThreadException += new EventHandler<System.Threading.ThreadExceptionEventArgs>(Application_ThreadException);
            this.Client.Start();

            UpdateNotifications();

            this.ViewState.MoveForward(new PersistProManager(this.Factory, this.PlanManager));

            if (this.Factory.LoadConfiguration()["showhelp"] == "false")
                DisplayHelp(false);
            else
                DisplayHelp(true);

            this.ApplicationSuccessfullyStarted = true;
        }

        private void UpdateNotifications() {
            bool errorOccured = false;
            foreach (IPlan plan in this.PlanManager.Plans) {
                IHistory history = this.HistoryManager.LoadLatestHistory(plan);

                if (history != null && history.Status == HistoryStatus.InError) {
                    errorOccured = true;

                    string errorMessage = string.Format("{0}\nReattempt will be made at {1}.", history.ErrorNote, history.ExecuteDate);
                    DisplayError(errorMessage, "PersistPro Backup Error", false);
                    //Error detected go red.
                    //if (this.IsNotifyIconOK) {
                    //    string message = string.Format("{0}\nReattempt will be made at {1}.", history.ErrorNote, history.ExecuteDate);
                    //    this.notifyIcon.ShowBalloonTip(5, "PersistPro Backup Error", message, ToolTipIcon.Error);
                    //    notifyIcon.Icon = Resources.NotifyIconError;
                    //    this.IsNotifyIconOK = false;
                    //}
                }
            }

            //If no errors go green!
            if (!errorOccured) {
                DisplayOK();
            }
        }

        private void DisplayError(string errorMessage, string errorTitle, bool forceShow) {
            //Error detected go red.
            if (forceShow || this.IsNotifyIconOK) {
                this.notifyIcon.ShowBalloonTip(5, errorTitle, errorMessage, ToolTipIcon.Error);
                notifyIcon.Icon = Resources.NotifyIconError;
                this.IsNotifyIconOK = false;
            }
        }

        private void DisplayOK() {
            notifyIcon.Icon = Resources.persistpro_icon_final;// Resources.NotifyIconOK;
            this.IsNotifyIconOK = true;
        }

        void Client_HistoryChanged(object sender, EventArgs e) {
            UpdateNotifications();
        }

        private void ViewState_ViewStateChanged(object sender, EventArgs e) {
            pnlOptions.Visible = (this.ViewState.Count > 1);
            if (this.ViewState.CurrentControl.NavigationControlType() == NavigationControl.SaveChangesAndCancel) {
                btnSaveChanges.Text = "Save Changes";
                btnCancel.Visible = true;

                this.Factory.SavePlanManager();
            }
            else if (this.ViewState.CurrentControl.NavigationControlType() == NavigationControl.SaveChanges) {
                btnSaveChanges.Text = "Save Changes";
                btnCancel.Visible = false;

                this.Factory.SavePlanManager();
            }
            else if (this.ViewState.CurrentControl.NavigationControlType() == NavigationControl.Back) {
                btnSaveChanges.Text = "Back";
                btnCancel.Visible = false;
            }
        }
            
        private void btnSaveChanges_Click(object sender, EventArgs e) {
            if (this.ViewState.SaveCurrentControlChanges()) {
                this.ViewState.MoveBackward();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.ViewState.CancelCurrentControlChanges();
            this.ViewState.MoveBackward();
        }

        private void lnklblHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            DisplayHelp(this.spltContainer.Panel1Collapsed);
        }

        private void DisplayHelp(bool display) {
            if (display) {
                this.spltContainer.Panel1Collapsed = false;
                this.lnklblHelp.Text = "Hide Help";
                this.Factory.LoadConfiguration()["showhelp"] = "true";
            }
            else {
                this.spltContainer.Panel1Collapsed = true;
                this.lnklblHelp.Text = "Show Help";
                this.Factory.LoadConfiguration()["showhelp"] = "false";
            }

            this.Factory.SaveConfiguration();
        }

        private void openPersistProToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            if (DialogResult.Yes == MessageBox.Show("Do you want to exit PersistPro manager?", "PersistPro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) {
                this.CloseApplication = true;
                this.Close();
            }
        }

        private void PersistPro_Shown(object sender, EventArgs e) {
            //Now that the form has been drawn, hide it and set Opacity to full and allow viewing in Taskbar
            this.Hide();
            this.Opacity = 1.0;
            this.ShowInTaskbar = true;

            //Show Register Splash Screen if needed
            if (!this.Factory.IsRegistered) {

                RegisterSplash rs = new RegisterSplash(this.Factory);
                rs.ShowDialog();
            }

            //moved this so that it doesn't show until the splash screen has unloaded.

            //Run Setup so show to the user
            if (this.Factory.RunSetup)
            {
                this.Show();
                this.Activate();
            }
        }

        private void PersistPro_FormClosing(object sender, FormClosingEventArgs e) {
            if (!this.CloseApplication) {
                e.Cancel = true;
                this.Hide();
            }
            else {
                this.Client.Stop();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.Show();
            this.Activate();
        }

        private void pnlBanner_Paint(object sender, PaintEventArgs e)
        {
           Rectangle rect = new Rectangle(0,0,pnlBanner.Width,pnlBanner.Height);

           LinearGradientBrush gbrush = new LinearGradientBrush(rect,Color.Black,Color.Gray,90F);
           e.Graphics.FillRectangle(gbrush,rect);
        }

        private void pnlBanner_Resize(object sender, EventArgs e)
        {
            pnlBanner.Invalidate();
            PositionWabiLogo();
        }

        //HACK To make the wabilogo show in the right position
        //for some reason if you set the anchor to the right the image never shows...
        private void PositionWabiLogo()
        {
            picWabiLogo.Location = new Point(pnlBanner.Width - picWabiLogo.Width -5, 46);
            //picWabiLogo.Left = pnlBanner.Width - picWabiLogo.Width - 5;
        }
    }
}
