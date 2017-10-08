using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WabiLogic.Foundation.ProductKey;

namespace GeneratePersistProKey {
    public partial class GenerateKey : Form {
        public GenerateKey() {
            InitializeComponent();
        }

        private void RegenerateKey() {
            try {
                string name = string.Format("Name: {0}", txtBoxName.Text);
                string key = string.Format("Product Key: {0}", KeyManager.GenerateKey(txtBoxName.Text, txtBoxSpice.Text));

                txtBoxResult.Lines = new string[] { name, key };

                lblError.Visible = false;
            }
            catch (Exception e) {
                txtBoxResult.Lines = new string[0];

                lblError.Visible = true;
                lblError.Text = e.Message;
            }
        }

        private void txtBoxName_TextChanged(object sender, EventArgs e) {
            RegenerateKey();
        }

        private void txtBoxSpice_TextChanged(object sender, EventArgs e) {
            RegenerateKey();
        }
    }
}
