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
    public partial class FileHistory : Form {
        private IEnumerable<IFileInstance> history;

        public FileHistory() {
            InitializeComponent();
        }

        public void SetFileHistory(IEnumerable<IFileInstance> history) {
            this.history = history;

            listViewFileHistory.BeginUpdate();
            listViewFileHistory.Items.Clear();

            foreach (IFileInstance file in history) {
                ListViewItem lvi = new ListViewItem(file.Name);
                lvi.SubItems.Add(file.Size.ToString());
                lvi.SubItems.Add(file.StartDate.ToString());
                lvi.SubItems.Add(file.Folder.GetFolderInstance(file.StartDate).Name);
                lvi.SubItems.Add(file.Note);
                lvi.Tag = file;
                listViewFileHistory.Items.Add(lvi);
            }
            listViewFileHistory.EndUpdate();
        }

        private void listViewFileHistory_ItemDrag(object sender, ItemDragEventArgs e) {
            List<IFileInstance> fileInstances = new List<IFileInstance>();
            foreach (ListViewItem item in listViewFileHistory.SelectedItems) {
                fileInstances.Add(item.Tag as IFileInstance);
            }

            string[] files = WabiLogic.PersistPro.Tools.Storage.PrepFileInTempDirForTransfer(fileInstances);
            DataObject dataObject = new DataObject();
            dataObject.SetData(DataFormats.FileDrop, files);
            listViewFileHistory.DoDragDrop(dataObject, DragDropEffects.Move | DragDropEffects.Copy);
        }
    }
}
