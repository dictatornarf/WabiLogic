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
    public partial class RootNameFilterEdit : PersistProControlBase {
        private IPlanManager PlanManager { get; set; }
        private IRoot Root { get; set; }
        private ListViewItem CurrentSelectedItem { get; set; }
        private IList<IRootNameFilter> DeleteMeOnSave { get; set; }
        private IList<IRootNameFilter> RemoveMeOnCancel { get; set; }

        public RootNameFilterEdit() : this(null, null) { }

        public RootNameFilterEdit(IPlanManager planManager, IRoot root) {
            InitializeComponent();

            this.PlanManager = planManager;
            this.Root = root;
            this.Help = Resources.RootNameFilterHelp;
            this.DeleteMeOnSave = new List<IRootNameFilter>();
            this.RemoveMeOnCancel = new List<IRootNameFilter>();
        }

        public override bool SaveChanges() {
            foreach (IRootNameFilter filter in this.DeleteMeOnSave) {
                this.PlanManager.DeleteRootNameFilter(filter);
            }

            foreach (ListViewItem item in lstViewNameFilters.Items) {
                IRootNameFilter filter = item.Tag as IRootNameFilter;
                filter.Filter = item.SubItems[0].Text;
                filter.FilterType = (FilterType)Enum.Parse(typeof(FilterType), item.SubItems[1].Text, true);
            }

            return true;
        }

        public override void Cancel() {
            foreach (IRootNameFilter filter in this.RemoveMeOnCancel) {
                this.PlanManager.DeleteRootNameFilter(filter);
            }            
        }

        private void RootNameFilterEdit_Load(object sender, EventArgs e) {
            if (this.Root != null) {
                lblRootName.Text = this.Root.Name;

                lstViewNameFilters.Items.Clear();
                foreach (IRootNameFilter filter in this.Root.NameFilters) {
                    ListViewItem lvi = lstViewNameFilters.Items.Add(new ListViewItem(new string[] { filter.Filter, filter.FilterType.ToString() }));
                    lvi.Tag = filter;
                }

                if (lstViewNameFilters.Items.Count > 0) {
                    lstViewNameFilters.Items[0].Selected = true;
                }
            }

            ShowRemoveButton();
        }

        private void ShowRemoveButton() {
            btnRemove.Enabled = (lstViewNameFilters.Items.Count > 1);
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if (this.PlanManager != null) {
                IRootNameFilter filter = this.PlanManager.CreateRootNameFilter(this.Root, "*.*", FilterType.Include, "");
                ListViewItem lvi = lstViewNameFilters.Items.Add(new ListViewItem(new string[] { filter.Filter, filter.FilterType.ToString() }));
                lvi.Tag = filter;
                this.RemoveMeOnCancel.Add(filter);
            }

            ShowRemoveButton();
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            if (lstViewNameFilters.Items.Count <= 1) {
                MessageBox.Show("At least one filter is required.", "Cannot remove last filter.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.CurrentSelectedItem != null) {
                IRootNameFilter filter = this.CurrentSelectedItem.Tag as IRootNameFilter;
                if (filter != null) {
                    this.DeleteMeOnSave.Add((IRootNameFilter)this.CurrentSelectedItem.Tag);
                    lstViewNameFilters.Items.Remove(this.CurrentSelectedItem);

                    lstViewNameFilters.Items[0].Selected = true;
                }
            }

            ShowRemoveButton();
        }

        private void lstViewNameFilters_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (e.IsSelected) {
                this.CurrentSelectedItem = e.Item;
                txtBoxNameFilter.Text = this.CurrentSelectedItem.SubItems[0].Text;
                cmbBoxFilterAction.Text = this.CurrentSelectedItem.SubItems[1].Text;
            }
        }

        private void cmbBoxFilterAction_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.CurrentSelectedItem != null) {
                this.CurrentSelectedItem.SubItems[1].Text = cmbBoxFilterAction.Text;
            }
        }

        private void txtBoxNameFilter_TextChanged(object sender, EventArgs e) {
            if (this.CurrentSelectedItem != null) {
                //TODO: In the future confirm this is valid format
                this.CurrentSelectedItem.SubItems[0].Text = txtBoxNameFilter.Text;
            }
        }
    }
}
