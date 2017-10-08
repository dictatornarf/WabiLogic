using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using WabiLogic.PersistPro.Restore;
using WabiLogic.Foundation.Storage;

namespace PersistProClient
{
    public partial class RestoreProgress : Form
    {
        public RestoreManager RestoreManager { get; set; }
        public string MountName { get; set; }

        public RestoreProgress(RestoreManager restoremanager, string mountName)
        {
            this.RestoreManager = restoremanager;
            this.MountName = mountName;
            InitializeComponent();
            PerformRestore();
        }

        private void PerformRestore()
        {
            btnClose.Enabled = false;

            //kick off the restore
            bgwkrRestore.RunWorkerAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgwkrRestore_DoWork(object sender, DoWorkEventArgs e)
        {
            RestoreManager.RestoreBegin += (o, ex) => { bgwkrRestore.ReportProgress(0, ex.RestoreInfo); };
            RestoreManager.FileRestoreComplete += (o, ex) => { bgwkrRestore.ReportProgress(1, ex.RestoreInfo); };
            RestoreManager.Restore();
        }

        private void bgwkrRestore_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            RestoreInfo rInfo = (e.UserState as RestoreInfo);
            if (rInfo == null) return;

            string totalFileSize = ConvertLongFileSizeToString(rInfo.TotalFileSize);

            lblFromVal.Text = MountName;
            lblRestoreProgress.Text = string.Format(CultureInfo.InvariantCulture,
                                                "{0} {1:#,#} {2} ({3})",
                                                (rInfo.RestoredFileCount == rInfo.TotalFileCount) ? 
                                               
                                                "Restored" : "Restoring",
                                                rInfo.TotalFileCount,
                                                (rInfo.TotalFileCount == 1) ? "item" : "items",
                                                totalFileSize);

            lblStatus.Text = string.Format("Restored file {0} of {1}", rInfo.RestoredFileCount, rInfo.TotalFileCount);

            string restoredFileSize = (rInfo.TotalFileCount == rInfo.RestoredFileCount) ? " " : string.Format("({0})", ConvertLongFileSizeToString(rInfo.TotalFileSize - rInfo.RestoredFileSize));
            lblRemItemsVal.Text = string.Format("{0} {1}", rInfo.TotalFileCount - rInfo.RestoredFileCount, restoredFileSize);

            long totalSize = (rInfo.TotalFileSize == 0) ? 1 : rInfo.TotalFileSize;
            long restoredSize = (rInfo.RestoredFileSize == 0) ? 1 : rInfo.RestoredFileSize;

            prgbarStatus.Value = (int)((double)prgbarStatus.Maximum * restoredSize / totalSize);
        }

        private void bgwkrRestore_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnClose.Enabled = true;
            this.Text = "Restore Data Complete";
            this.lblStatus.Text = "Restore Complete";
        }

        private string ConvertLongFileSizeToString(long fileSize)
        {
            List<string> suffix = new List<string>() { "Bytes", "KB", "MB", "GB", "TB", "PB" };
            int counter = 0;
            while (fileSize >= 1024)
            {
                counter++;
                fileSize /= 1024;
            }
            return string.Format("{0} {1}", fileSize, (counter < suffix.Count) ? suffix[counter] : "");

        }

        ~RestoreProgress()
        {
            if (bgwkrRestore != null)
                bgwkrRestore.Dispose();
            if (RestoreManager != null)
                RestoreManager = null;
        }
    }
}
