using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WabiLogic.PersistPro.Model;
using System.IO;
using PersistProClient.Properties;

namespace PersistProClient {
    public partial class RootAttributeFilterEdit : PersistProControlBase {
        private IPlanManager PlanManager { get; set; }
        private IRoot Root { get; set; }
        private ListViewItem CurrentSelectedItem { get; set; }
        private IList<IRootAttributeFilter> DeleteMeOnSave { get; set; }
        private IList<IRootAttributeFilter> RemoveMeOnCancel { get; set; }

        public RootAttributeFilterEdit() : this(null, null) { }

        public RootAttributeFilterEdit(IPlanManager planManager, IRoot root) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.Root = root;
            this.Help = Resources.RootAttributeFilterHelp;
            this.DeleteMeOnSave = new List<IRootAttributeFilter>();
            this.RemoveMeOnCancel = new List<IRootAttributeFilter>();
        }

        public override bool SaveChanges() {
            foreach (IRootNameFilter filter in this.DeleteMeOnSave) {
                this.PlanManager.DeleteRootNameFilter(filter);
            }

            foreach (ListViewItem item in lstViewAttributeFilters.Items) {
                IRootAttributeFilter filter = item.Tag as IRootAttributeFilter;
                filter.Filter = (FileAttributes)Enum.Parse(typeof(FileAttributes), item.SubItems[0].Text, true);
                filter.FilterType = (FilterType)Enum.Parse(typeof(FilterType), item.SubItems[1].Text, true);
            }

            return true;
        }

        public override void Cancel() {
            foreach (IRootNameFilter filter in this.RemoveMeOnCancel) {
                this.PlanManager.DeleteRootNameFilter(filter);
            }
        }

        private void RootAttributeFilterEdit_Load(object sender, EventArgs e) {
            if (this.Root != null) {
                lblRootName.Text = this.Root.Name;

                lstViewAttributeFilters.Items.Clear();
                foreach (IRootAttributeFilter filter in this.Root.AttributeFilters) {
                    ListViewItem lvi = lstViewAttributeFilters.Items.Add(new ListViewItem(new string[] { filter.Filter.ToString(), filter.FilterType.ToString() }));
                    lvi.Tag = filter;
                }

                if (lstViewAttributeFilters.Items.Count > 0) {
                    lstViewAttributeFilters.Items[0].Selected = true;
                }
            }

            ShowRemoveButton();
        }

        private void ShowRemoveButton() {
            btnRemove.Enabled = (lstViewAttributeFilters.Items.Count > 1);
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if (this.PlanManager != null) {
                IRootAttributeFilter filter = this.PlanManager.CreateRootAttributeFilter(this.Root, FileAttributes.Archive, FilterType.Include, "");
                ListViewItem lvi = lstViewAttributeFilters.Items.Add(new ListViewItem(new string[] { filter.Filter.ToString(), filter.FilterType.ToString() }));
                lvi.Tag = filter;
                this.RemoveMeOnCancel.Add(filter);
            }

            ShowRemoveButton();
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            if (lstViewAttributeFilters.Items.Count <= 1) {
                MessageBox.Show("At least one filter is required.", "Cannot remove last filter.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.CurrentSelectedItem != null) {
                IRootAttributeFilter filter = this.CurrentSelectedItem.Tag as IRootAttributeFilter;
                if (filter != null) {
                    this.DeleteMeOnSave.Add((IRootAttributeFilter)this.CurrentSelectedItem.Tag);
                    lstViewAttributeFilters.Items.Remove(this.CurrentSelectedItem);

                    lstViewAttributeFilters.Items[0].Selected = true;
                }
            }

            ShowRemoveButton();
        }

        private void lstViewAttributeFilters_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (e.IsSelected) {
                this.CurrentSelectedItem = e.Item;
                cmbBoxAttributeFilter.Text = this.CurrentSelectedItem.SubItems[0].Text;
                cmbBoxFilterAction.Text = this.CurrentSelectedItem.SubItems[1].Text;
            }
        }

        private void cmbBoxFilterAction_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.CurrentSelectedItem != null) {
                this.CurrentSelectedItem.SubItems[1].Text = cmbBoxFilterAction.Text;
            }
        }

        private void cmbBoxAttributeFilter_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.CurrentSelectedItem != null) {
                this.CurrentSelectedItem.SubItems[0].Text = cmbBoxAttributeFilter.Text;
            }
        }
    }
}
