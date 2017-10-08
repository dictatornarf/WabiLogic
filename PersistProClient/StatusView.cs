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
using WabiLogic.PersistPro.Controller;

namespace PersistProClient {
    public partial class StatusView : PersistProControlBase {
        private ListViewItem CurrentSelectedItem { get; set; }

        private IFactory Factory { get; set; }
        private IPlanManager PlanManager { get; set; }
        private IHistoryManager HistoryManager { get; set; }

        public StatusView() : this(null, null) { }

        public StatusView(IFactory factory, IPlanManager planManager) {
            InitializeComponent();

            this.Factory = factory;
            this.PlanManager = planManager;
            this.HistoryManager = this.Factory.LoadHistoryManager();

            this.Help = Resources.StatusViewHelp;
        }

        public override NavigationControl NavigationControlType() {
            return NavigationControl.Back;
        }

        //Adapted from http://msdn.microsoft.com/en-us/library/w56d4y5z.aspx Retrieved: 2009-01-13
        private static int CompareListViewItemByScheduleDate(ListViewItem x, ListViewItem y) {
            if (x == null) {
                if (y == null)
                    return 0; // If x is null and y is null, they're equal
                else
                    return -1; // If x is null and y is not null, y is greater. 
            }
            else { // If x is not null...
                if (y == null)
                    return 1; // ...and y is null, x is greater.
                else //The negative is for desc
                    return -Convert.ToDateTime(x.SubItems[3].Text).CompareTo(Convert.ToDateTime(y.SubItems[3].Text)); // ...and y is not null, compare the lengths of the two strings.
            }
        }


        private void UpdateList() {
            List<ListViewItem> items = new List<ListViewItem>();

            lstViewStatus.Items.Clear();
            foreach (IPlan plan in this.PlanManager.Plans) {
                IEnumerable<IHistory> histories = null;
                if (chkBoxViewHistory.Checked)
                    histories = this.HistoryManager.PlanHistories(plan);
                else
                    histories = new List<IHistory>() { this.HistoryManager.LoadLatestHistory(plan) };

                foreach (IHistory history in histories) {
                    if (history != null) {
                        ListViewItem item = new ListViewItem(new string[] { plan.Root.Name, plan.Mount.Name, history.ScheduleDate.ToString(), history.ExecuteDate.ToString(), history.Status.ToString(), history.ErrorNote });
                        item.Tag = history;
                        items.Add(item);
                    }
                }
            }

            items.Sort(CompareListViewItemByScheduleDate);
            lstViewStatus.Items.AddRange(items.ToArray());

            if (lstViewStatus.Items.Count > 0) {
                lstViewStatus.Items[0].Selected = true;
                lstViewStatus.SelectedIndices.Add(0);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            UpdateList();
        }

        private void StatusView_Load(object sender, EventArgs e) {
            btnBackupNow.Enabled = false;
            btnAbort.Enabled = false;
            UpdateList();
        }

        private void btnBackupNow_Click(object sender, EventArgs e) {
            IHistory history = (IHistory)this.CurrentSelectedItem.Tag;
            DateTime now = DateTime.Now;

            this.CurrentSelectedItem.SubItems[3].Text = now.ToString();
            history.ExecuteDate = now;
            this.Factory.SaveHistoryManager();
        }

        private void lstViewStatus_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (e.IsSelected) {
                this.CurrentSelectedItem = e.Item;

                IHistory history = e.Item.Tag as IHistory;
                if (history.Status == HistoryStatus.Aborted || history.Status == HistoryStatus.Complete || history.Status == HistoryStatus.InProgress) {
                    btnBackupNow.Enabled = false;
                }
                else {
                    btnBackupNow.Enabled = true;
                }

                if (history.Status == HistoryStatus.InError) {
                    btnAbort.Enabled = true;
                }
                else {
                    btnAbort.Enabled = false;
                }
            }
        }

        private void chkBoxViewHistory_CheckedChanged(object sender, EventArgs e) {
            UpdateList();
        }

        private void btnAbort_Click(object sender, EventArgs e) {
            IHistory history = (IHistory)this.CurrentSelectedItem.Tag;
            DateTime now = DateTime.Now;

            this.CurrentSelectedItem.SubItems[4].Text = HistoryStatus.Aborted.ToString();
            history.Status = HistoryStatus.Aborted;
            this.Factory.SaveHistoryManager();
        }
    }
}
