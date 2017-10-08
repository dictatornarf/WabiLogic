using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using WabiLogic.PersistPro.Model;
using WabiLogic.Foundation.Storage;
using WabiLogic.PersistPro.Restore;
using WabiLogic.Foundation.Tools.Extensions;
using WabiLogic.PersistPro.Controller;
using PersistProClient.Properties;

namespace PersistProClient {
    public partial class RestoreBrowser : PersistProControlBase {
        private IFactory Factory { get; set; }
        private IPlanManager PlanManager { get; set; }
        private IMount RestoreMount { get; set; }
        private DateTime Snapshot { get; set; }

        private IManager StorageManager { get; set; }
        private IFolder PlanRootFolder { get; set; }

        public RestoreBrowser() : this(null, null, null, DateTime.Now) { }

        public RestoreBrowser(IFactory factory, IPlanManager planManager, IMount selectedMount, DateTime snapshot)
        {
            InitializeComponent();

            this.Factory = factory;
            this.PlanManager = planManager;
            this.RestoreMount = selectedMount;
            this.Snapshot = snapshot;
            this.Help = Resources.BackupExplorerHelp;
        }

        public override NavigationControl NavigationControlType() {
            return NavigationControl.Back;
        }

        private void RestoreBrowser_Load(object sender, EventArgs e) {
            UpdateTreeView();
        }

        private void UpdateTreeView()
        {

            IManager storageManager = StorageLoader.Load(RestoreMount, this.Factory.LoadEncryption());
            storageManager.Open(); //TODO: Remember to close this....

            //This is the main level for the plan root.
            trvBExplorer.Nodes.Clear();

            trvBExplorer.Nodes.Add(LoadNode<IFolderInstance>(storageManager.GetRootFolder().GetFolderInstance(Snapshot),"Backup Explorer",3,
                                    new Predicate<IFolderInstance>(x => x.Folder.GetAllSubFolderInstances().Count() > 0)));

            trvBExplorer.SelectedNode = trvBExplorer.Nodes[0];

            storageManager.Close();
        }

        private void ExpandNode(TreeNode nodeToExpand)
        {
            if (nodeToExpand.Tag is IFolderInstance)
            {
                //TODO:need to check with Ben to see if we can add an overload to the IFolder.GetFiles method
                //that does require a date. This way we can get a list of files from all time without
                //having to group and sort all of the file instances.

                IEnumerable<IFileInstance> fileInstances = (nodeToExpand.Tag as IFolderInstance).Folder.GetAllFileInstances();
                if (fileInstances.Count() > 0)
                {
                    List<Guid> addedFileGuids = new List<Guid>();
                    foreach (IFileInstance file in fileInstances.OrderByDescending(x => x.EndDate))
                    {

                        //only add the unique files regardless of number of instances...
                        if (!addedFileGuids.Contains(file.File.Id))
                        {
                            nodeToExpand.Nodes.Add(LoadNode<IFileInstance>(file, file.Name, 4, new Predicate<IFileInstance>(x => x.File.GetFileInstances().Count() > 0)));
                            addedFileGuids.Add(file.File.Id);
                        }
                    }
                }
                foreach (IFolderInstance folder in (nodeToExpand.Tag as IFolderInstance).Folder.GetAllSubFolderInstances())
                {
                    //folder.GetCleanFileName()
                    //string cleanFolderName = folder.Name;
                    ////if the folder is a root then we need to strip off the guid that is appended to the name
                    //if (nodeToExpand.Level == 0 && cleanFolderName.Contains("_"))
                    //{
                    //    cleanFolderName = cleanFolderName.Remove(cleanFolderName.LastIndexOf("_"));
                    //}
                    TreeNode node = LoadNode<IFolderInstance>(folder, folder.GetCleanFileName(), 1,
                                                                new Predicate<IFolderInstance>
                                                                    (x => 
                                                                        (x.Folder.GetAllSubFolderInstances().Count() > 0) ||
                                                                        (x.Folder.GetAllFileInstances().Count() > 0)));
                    nodeToExpand.Nodes.Add(node);
                }
            }
            else if (nodeToExpand.Tag is IFileInstance)
            {
                //NOTE: we make the assumption that GetFileInstances will always return data
                //b/c this was checked when the node was added. We may need to revisit later...
                //order the files by date descending
                foreach (IFileInstance fileInstance in (nodeToExpand.Tag as IFileInstance).File.GetFileInstances().OrderByDescending(x => x.EndDate))
                {
                    nodeToExpand.Nodes.Add(LoadNode<IFileInstance>(fileInstance, fileInstance.StartDate.ToLongDateString(),0));
                }
            }
        }

        //Loads a single node into the tree, if the node contains sub-nodes a place holder node is added.
        private TreeNode LoadNode<T>(T container, string nodeText, int imgIndex) { return LoadNode<T>(container, nodeText,imgIndex, null); }
        private TreeNode LoadNode<T>(T container, string nodeText,int imgIndex, Predicate<T> checkForSubNodes)
        {
            TreeNode node = new TreeNode(nodeText,imgIndex,imgIndex);
            node.Tag = container;

            if (container is IFileInstance){
                SetColor<IFileInstance>(node, new Action<IFileInstance>(x => node.ForeColor= (x.EndDate > DateTime.Now) ? Color.Green : Color.Gray));
            }
                else if (container is IFolderInstance){
                    SetColor<IFolderInstance>(node, new Action<IFolderInstance>(x => node.ForeColor = (x.EndDate > DateTime.Now) ? Color.Green : Color.Gray));
                }
            //node.ContextMenuStrip = LoadTreeNodeContextMenuStrip(node);
            if ((checkForSubNodes != null) &&(checkForSubNodes(container)))
                node.Nodes.Add("holder");
            return node;
        }

        private void SetColor<T>(TreeNode node, Action<T> setNodeColor) where T: class
        {
            T instance = (node.Tag as T);
            setNodeColor(instance);
        }

        private void BeforeNodexExpandOrCollape(object sender, TreeViewCancelEventArgs e)
        {
            trvBExplorer.BeginUpdate();
            SetNodeState(e.Node, e.Action);
            if (e.Action == TreeViewAction.Expand) { e.Node.Nodes.Clear(); ExpandNode(e.Node); }
            trvBExplorer.EndUpdate();
        }

        private void SetNodeState(TreeNode node, TreeViewAction action)
        {
            //we do not want to change the icon of root nodes (those at level o)
            if ((node.Level > 0) &&(node.Tag is IFolderInstance))
            {
              node.SelectedImageIndex =  node.ImageIndex = (action == TreeViewAction.Expand) ? 2 : 1;
            }
        }

        private void trvBExplorer_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            SetSelectedItemRestoreOptions(e.Node);
        }

        private void SetSelectedItemRestoreOptions(TreeNode node)
        {
            IFileInstance file = (node.Tag as IFileInstance);

            if (node.Tag is IFolderInstance)
            {
                //the item is a folder we should give the option to restore sub-folders
                lnklblRestoreItem.Text = "Restore Selected Folder";
                //chkIncludeSubFolders.Visible = chkIncludeSubFolders.Enabled = true;
                //chkIncludeAllFileVersions.Visible = chkIncludeAllFileVersions.Enabled = true;
                chkIncludeSubFolders.Enabled = chkIncludeAllFileVersions.Enabled = true;

            }
            else if ((node.Tag is IFileInstance) && (node.GetNodeCount(true) > 0))
            {
                //the item is a file we should give the option to restore current version or all versions
                lnklblRestoreItem.Text = "Restore Selected File";
                //chkIncludeSubFolders.Visible = chkIncludeSubFolders.Enabled = false;
                //chkIncludeAllFileVersions.Visible = chkIncludeAllFileVersions.Enabled = true;
                chkIncludeAllFileVersions.Enabled = true;
                chkIncludeSubFolders.Enabled = chkIncludeSubFolders.Checked =  false;

            }
            else
            {
                //the item is a file instance we should just give the option to the item
                lnklblRestoreItem.Text = "Restore Selected File Version";
                //chkIncludeSubFolders.Visible = chkIncludeSubFolders.Enabled = false;
                //chkIncludeAllFileVersions.Visible = chkIncludeAllFileVersions.Enabled = false;
                chkIncludeSubFolders.Enabled = chkIncludeSubFolders.Checked = false;
                chkIncludeAllFileVersions.Enabled = false;
            }
            
        }

        private void lnklblRestoreItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Validate that the restore path is valid and not empty
            if (trvBExplorer.SelectedNode == null)
            {
                MessageBox.Show("You must specify which item you want to restore.", "Specify what to restore.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                trvBExplorer.Focus();
                return;
            }

            //TODO: we should have it check to see if the path is valid
            //if the path is valid and the folder does not exist we should ask the user
            //if they want us to create the specified folder.
            if (!Directory.Exists(txtBoxPath.Text))
            {
                MessageBox.Show("You must specify where you want to restore.", "Specify where to restore.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxPath.Focus();
                return;
            }

            RestoreData();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == fbdBrowse.ShowDialog())
            {
                txtBoxPath.Text = fbdBrowse.SelectedPath;
            }
        }

        private void RestoreData()
        {
            IRestorer restorer = null;

            if (trvBExplorer.SelectedNode.Tag is IFolderInstance)
            {
                restorer = RestoreFactory.RestoreFolder((trvBExplorer.SelectedNode.Tag as IFolderInstance),
                                                                            txtBoxPath.Text,
                                                                            chkIncludeSubFolders.Checked,
                                                                            chkIncludeAllFileVersions.Checked,
                                                                            DateTime.Now);
            }
            else
            {
                restorer = RestoreFactory.RestoreFile((trvBExplorer.SelectedNode.Tag as IFileInstance).File,
                                                                    txtBoxPath.Text,
                                                                    chkIncludeAllFileVersions.Checked,
                                                                    DateTime.Now);
            }

            RestoreManager restoreManager = new RestoreManager(this.Factory, restorer);

            RestoreProgress restoreProgress = new RestoreProgress(restoreManager, RestoreMount.Name);
            restoreProgress.ShowDialog();

            restoreProgress.Dispose();
        }
    }
}
