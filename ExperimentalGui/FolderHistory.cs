using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WabiLogic.Foundation.Storage;

namespace WabiLogic.PersistPro {
    public partial class FolderHistory : Form {
        private IEnumerable<IFolderInstance> history;

        public FolderHistory() {
            InitializeComponent();
        }

        public void SetFolderHistory(IEnumerable<IFolderInstance> history) {
            this.history = history;

            listViewFolderHistory.BeginUpdate();
            listViewFolderHistory.Items.Clear();

            foreach (IFolderInstance folder in history) {
                ListViewItem lvi = new ListViewItem(folder.Name);
                lvi.SubItems.Add(folder.StartDate.ToString());
                lvi.SubItems.Add(folder.Parent.GetFolderInstance(folder.StartDate).Name);
                listViewFolderHistory.Items.Add(lvi);
            }
            listViewFolderHistory.EndUpdate();
        }
    }
}
