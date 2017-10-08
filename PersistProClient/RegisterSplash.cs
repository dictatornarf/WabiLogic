using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WabiLogic.PersistPro.Controller;
using WabiLogic.Foundation.ProductKey;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace PersistProClient {
    public partial class RegisterSplash : Form {
        private IFactory Factory { get; set; }
        private int ContinueEnabledCount { get; set; }

        public RegisterSplash() : this(null) { }

        public RegisterSplash(IFactory factory) {
            InitializeComponent();
            this.Factory = factory;
        }

        private void RegisterSplash_Load(object sender, EventArgs e) {
            //Set the window to the current system font
            //More info http://www.mztools.com/articles/2007/MZ2007030.aspx accessed 2008-11-22
            //Note to make this work right I set the AutoScaleMode to DPI
            this.Font = SystemFonts.MessageBoxFont;

            timerEnable.Enabled = true;
            btnOrderLater.Enabled = false;
            this.ContinueEnabledCount = 10;
            HandleOrderLater();
        }

        private void HandleOrderLater() {
            this.ContinueEnabledCount -= 1;

            if (this.ContinueEnabledCount < 1) {
                timerEnable.Enabled = false;
                btnOrderLater.Enabled = true;
            }

            if (this.ContinueEnabledCount < 1)
                btnOrderLater.Text = "Order Later";
            else
                btnOrderLater.Text = string.Format("Order Later ({0})", this.ContinueEnabledCount);
        }

        private void timerEnable_Tick(object sender, EventArgs e) {
            HandleOrderLater();
        }

        private void btnOrder_Click(object sender, EventArgs e) {
            Process.Start("http://www.wabilogic.com/persistpro/order");
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            if (txtBoxName.Text.Trim().Length == 0) {
                MessageBox.Show("Name cannot be empty.", "Name needed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxName.Focus();
                return;
            }

            if (txtBoxKey.Text.Trim().Length == 0) {
                MessageBox.Show("Key cannot be empty.", "Key needed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxKey.Focus();
                return;
            }

            if (!KeyManager.ConfirmKey(txtBoxName.Text, txtBoxKey.Text)) {
                MessageBox.Show("Key does not match name given. Please check that both are correct.", "Invalid Name / Key pair.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxKey.Focus();
                return;
            }

            this.Factory.Register(txtBoxName.Text, txtBoxKey.Text);
            this.Factory.SaveConfiguration();
            this.Close();
        }

        private void btnOrderLater_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void pnlBanner_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pnlBanner.Width, pnlBanner.Height);

            LinearGradientBrush gbrush = new LinearGradientBrush(rect, Color.Black, Color.Gray, 90F);
            e.Graphics.FillRectangle(gbrush, rect);
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
            picWabiLogo.Location = new Point(pnlBanner.Width - picWabiLogo.Width, 60);
            //picWabiLogo.Left = pnlBanner.Width - picWabiLogo.Width - 5;
        }
    }
}
