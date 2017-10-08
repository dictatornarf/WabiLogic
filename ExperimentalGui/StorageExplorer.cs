using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Storage.FileShare;
using WabiLogic.Foundation.Storage.Ftp;
using WabiLogic.Foundation.Encryption.Rijndael;
using System.IO;

namespace WabiLogic.PersistPro
{
    public partial class StorageExplorer : Form
    {
        IManager manager; 

        public StorageExplorer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object senderLoad, EventArgs e) {
            //manager = new FtpManager("ftp.becstudios.com", 21, "carden", "<password>", "/backup/ben", new RijndaelEncryption("password"));
            //manager = new FileShareManager(@"C:\Users\carden\Desktop\test", new RijndaelEncryption("password"));
            manager = new FileShareManager(@"C:\Users\carden\Desktop\BackupTestSpot", new RijndaelEncryption("password"));

            manager.TransferBegin += delegate(object sender, TransferBeginEventArgs args) {
                this.Text = string.Format("Transfer Starting '{0}'", args.Identifier);
                Application.DoEvents();
            };

            manager.TransferUpdate += delegate(object sender, TransferUpdateEventArgs args) {
                this.Text = string.Format("Transfer {0:000.0}% '{1}' ", ((double)args.CurrentPosition / (double)args.Length) * 100.0, args.Identifier);
                Application.DoEvents();
            };

            manager.TransferEnd += delegate(object sender, TransferEndEventArgs args) {
                this.Text = string.Format("Transfer Ending '{0}'", args.Identifier);
                Application.DoEvents();
            };

            manager.Open();
            //manager.Recycle(new PurgeRules.TimeSpanPurgeRules(new TimeSpan(0, 0, 0, 10)));

            treeViewFolders.Nodes.Add(LoadNode(manager.GetRootFolder()));
            treeViewFolders.SelectedNode = treeViewFolders.Nodes[0];

            listViewFiles.ContextMenuStrip = LoadListViewFilesContextStripMenu();
        }

        private TreeNode LoadNode(IFolder folder) {
            TreeNode node = new TreeNode();
            node.Tag = folder;
            node.ContextMenuStrip = LoadTreeNodeContextMenuStrip(node);
            node.Text = folder.GetFolderInstance(System.DateTime.Now).Name;
            if (folder.GetSubFolderInstances(DateTime.Now).Count() > 0)
                node.Nodes.Add("holder");

            return node;
        }

        private ContextMenuStrip LoadTreeNodeContextMenuStrip(TreeNode node) {
            ContextMenuStrip strip = new ContextMenuStrip();

            ToolStripTextBox newFolderTextBox = new ToolStripTextBox();
            newFolderTextBox.AcceptsReturn = false;
            newFolderTextBox.Text = "[Folder Name]";
            newFolderTextBox.ForeColor = SystemColors.GrayText;
            newFolderTextBox.GotFocus += new EventHandler(delegate(object sender, EventArgs e) {
                newFolderTextBox.ForeColor = SystemColors.ControlText;
                newFolderTextBox.Text = "";
            });
            //newFolderTextBox.Click += new EventHandler(delegate(object sender, EventArgs e) {
            //    IFolder folder = node.Tag as IFolder;
            //    if (folder != null) {
            //        IFolder subFolder = folder.CreateSubFolder(newFolderTextBox.Text);
            //        node.Nodes.Add(LoadNode(subFolder));
            //    }
            //});
            newFolderTextBox.KeyUp += new KeyEventHandler(delegate(object sender, KeyEventArgs e) {
                if (e.KeyCode == Keys.Enter) {
                    IFolder folder = node.Tag as IFolder;
                    if (folder != null) {
                        IFolder subFolder = folder.CreateSubFolder(newFolderTextBox.Text);
                        node.Nodes.Add(LoadNode(subFolder));
                    }

                    e.SuppressKeyPress = true;
                    strip.Close();
                    newFolderTextBox.Text = "[Folder Name]";
                    newFolderTextBox.ForeColor = SystemColors.GrayText;
                }
            });

            ToolStripMenuItem newFolder = new ToolStripMenuItem();
            newFolder.Text = "New Folder";
            newFolder.DropDownItems.Add(newFolderTextBox);

            ToolStripItem rename = new ToolStripMenuItem();
            rename.Text = "Rename";
            rename.Click += new EventHandler(delegate(object sender, EventArgs e) {
                node.BeginEdit();
            });

            ToolStripItem delete = new ToolStripMenuItem();
            delete.Text = "Delete";
            delete.Click += new EventHandler(delegate(object sender, EventArgs e) {
                if (DialogResult.Yes == MessageBox.Show(this, "Delete selected folder?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
                    IFolder folder = node.Tag as IFolder;
                    if (folder != null) {
                        try {
                            folder.Delete();
                            node.Parent.Nodes.Remove(node);
                        }
                        catch (IOException ioe) {
                            ShowError(ioe.Message);
                        }
                    }
                }
            });

            ToolStripItem history = new ToolStripMenuItem();
            history.Text = "History";
            history.Click += new EventHandler(delegate(object sender, EventArgs e) {
                IFolder folder = node.Tag as IFolder;
                if (folder != null) {
                    try {
                        FolderHistory fh = new FolderHistory();
                        fh.SetFolderHistory(folder.GetFolderInstances());
                        fh.Show();
                    }
                    catch (IOException ioe) {
                        ShowError(ioe.Message);
                    }
                }
            });

            ToolStripItem seperator = new ToolStripSeparator();

            strip.Items.Add(newFolder);
            strip.Items.Add(rename);
            strip.Items.Add(delete);
            strip.Items.Add(seperator);
            strip.Items.Add(history);

            return strip;
        }

        private void treeViewFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            if (e.Action == TreeViewAction.Expand) {
                IFolder folder = e.Node.Tag as IFolder;

                if (folder != null) {
                    treeViewFolders.BeginUpdate();
                    e.Node.Nodes.Clear();

                    foreach (IFolder child in folder.GetSubFolders(DateTime.Now)) {
                        e.Node.Nodes.Add(LoadNode(child));
                    }
                    treeViewFolders.EndUpdate();
                }
            }
        }

        private void treeViewFolders_AfterSelect(object sender, TreeViewEventArgs e) {
            IFolder folder = e.Node.Tag as IFolder;
            UpdateFileList(folder);
        }

        private void UpdateFileList(IFolder folder) {
            if (folder != null) {
                listViewFiles.BeginUpdate();
                listViewFiles.Items.Clear();

                foreach (IFileInstance file in folder.GetFileInstances(DateTime.Now)) {
                    ListViewItem lvi = new ListViewItem(file.Name);
                    lvi.SubItems.Add(file.Size.ToString());
                    lvi.SubItems.Add(file.StartDate.ToString());
                    lvi.Tag = file.File;
                    listViewFiles.Items.Add(lvi);
                }
                listViewFiles.EndUpdate();
            }
        }

        private ContextMenuStrip LoadListViewFilesContextStripMenu() {
            ContextMenuStrip strip = new ContextMenuStrip();

            ToolStripItem rename = new ToolStripMenuItem();
            rename.Text = "Rename";
            rename.Click += new EventHandler(delegate(object sender, EventArgs e) {
                if (listViewFiles.SelectedItems.Count > 0)
                    listViewFiles.SelectedItems[0].BeginEdit();
            });

            ToolStripItem delete = new ToolStripMenuItem();
            delete.Text = "Delete";
            delete.Click += new EventHandler(delegate(object sender, EventArgs e) {
                if (DialogResult.Yes == MessageBox.Show(this, "Delete selected files?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
                    listViewFiles.BeginUpdate();
                    foreach (ListViewItem item in listViewFiles.SelectedItems) {
                        IFile file = item.Tag as IFile;
                        if (file != null) {
                            try {
                                file.Delete();
                                listViewFiles.Items.Remove(item);
                            }
                            catch (IOException ioe) {
                                ShowError(ioe.Message);
                            }
                        }
                    }
                    listViewFiles.EndUpdate();
                }
            });

            ToolStripItem history = new ToolStripMenuItem();
            history.Text = "History";
            history.Click += new EventHandler(delegate(object sender, EventArgs e) {
                foreach (ListViewItem item in listViewFiles.SelectedItems) {
                    IFile file = item.Tag as IFile;
                    if (file != null) {
                        try {
                            FileHistory fh = new FileHistory();
                            fh.SetFileHistory(file.GetFileInstances());
                            fh.Show();
                        }
                        catch (IOException ioe) {
                            ShowError(ioe.Message);
                        }
                    }
                }
            });

            ToolStripItem seperator = new ToolStripSeparator();

            strip.Items.Add(rename);
            strip.Items.Add(delete);
            strip.Items.Add(seperator);
            strip.Items.Add(history);

            return strip;
        }

        private void treeViewFolders_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
            IFolder folder = e.Node.Tag as IFolder;

            if (e.Label == null) {
                e.CancelEdit = true;
            }
            else if (folder != null) {
                try {
                    folder.Rename(e.Label);
                }
                catch (IOException ioe) {
                    ShowError(ioe.Message);
                    e.CancelEdit = true;
                }
            }
        }

        private void ShowError(string error) {
            MessageBox.Show(error, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            manager.Save();
            manager.Close();
        }

        private TreeNode IsTreeNode(DragEventArgs args) {
            TreeNode node = null;
            if (args.Data.GetDataPresent(DataFormats.Serializable, true)) {
                node = args.Data.GetData(DataFormats.Serializable, true) as TreeNode;
            }
            return node;
        }

        private void treeViewFolders_DragOver(object sender, DragEventArgs e) {
            if (IsTreeNode(e) != null || IsOnlineBackupUtilityFileMove(e) != null)
                e.Effect = DragDropEffects.Move;
            else 
                e.Effect = DragDropEffects.None; 
        }

        private void treeViewFolders_DragDrop(object sender, DragEventArgs e) {
            TreeNode sourceNode = IsTreeNode(e);
            IList<IFile> sourceFiles = IsOnlineBackupUtilityFileMove(e);

            TreeNode destinationNode = treeViewFolders.GetNodeAt(treeViewFolders.PointToClient(new Point(e.X, e.Y)));
            IFolder destinationFolder = destinationNode.Tag as IFolder;

            try {
                if (sourceNode != null) {
                    IFolder sourceFolder = sourceNode.Tag as IFolder;
                    sourceFolder.MoveTo(destinationFolder);

                    sourceNode.Parent.Nodes.Remove(sourceNode);
                    destinationNode.Nodes.Add(sourceNode);
                }
                else if (sourceFiles != null) {
                    IFolder currentFolder = null;
                    foreach(IFile file in sourceFiles) {
                        if (currentFolder == null)
                            currentFolder = file.GetFileInstance(DateTime.Now).Folder;

                        file.MoveTo(destinationFolder);
                    }

                    if (currentFolder != null)
                        UpdateFileList(currentFolder);
                }
            }
            catch (IOException ioe) {
                ShowError(ioe.Message);
            }
        }

        private void treeViewFolders_ItemDrag(object sender, ItemDragEventArgs e) {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void listViewFiles_DragOver(object sender, DragEventArgs e) {
            if (IsFileList(e) != null) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        private void listViewFiles_DragDrop(object sender, DragEventArgs e) {
            string[] files = IsFileList(e);
            IFolder folder = treeViewFolders.SelectedNode.Tag as IFolder;
            if (files != null)
                UpdateFiles(folder, files);
        }

        private void UpdateFiles(IFolder folder, string[] files) {
            IEnumerable<IFileInstance> fis = folder.GetFileInstances(DateTime.Now);

            foreach (string file in files) {
                FileInfo fileInfo = new FileInfo(file);
                string md5 = WabiLogic.Foundation.Tools.IO.GenerateMD5(fileInfo.FullName);
                using (Stream inputStream = File.OpenRead(fileInfo.FullName)) {
                    IFileInstance fileInstance = (from fi in fis where fi.Name == fileInfo.Name select fi).DefaultIfEmpty(null).Single();

                    if (fileInstance == null)
                        folder.CreateFile(inputStream, fileInfo.Name, inputStream.Length, md5, "Created file.");
                    else if (fileInstance.MD5 != md5 || fileInstance.Size != inputStream.Length)
                        fileInstance.File.UpdateFile(inputStream, inputStream.Length, md5, "Update file.");

                    UpdateFileList(folder);
                }
            }
        }

        private string[] IsFileList(DragEventArgs args) {
            string[] files = null;
            if (args.Data.GetDataPresent(DataFormats.FileDrop, true)) {
                files = args.Data.GetData(DataFormats.FileDrop, true) as string[];
            }
            return files;
        }

        private void listViewFiles_AfterLabelEdit(object sender, LabelEditEventArgs e) {
            IFile file = listViewFiles.Items[e.Item].Tag as IFile;

            if (e.Label == null) {
                e.CancelEdit = true;
            }
            else if (file != null) {
                try {
                    file.Rename(e.Label);
                }
                catch (IOException ioe) {
                    ShowError(ioe.Message);
                    e.CancelEdit = true;
                }
            }
        }

        private void listViewFiles_ItemDrag(object sender, ItemDragEventArgs e) {
            List<IFile> files = new List<IFile>();
            List<IFileInstance> fileInstances = new List<IFileInstance>();
            foreach (ListViewItem item in listViewFiles.SelectedItems) {
                IFile file = item.Tag as IFile;
                files.Add(file);
                fileInstances.Add(file.GetFileInstance(DateTime.Now));
            }

            DataObject dataObject = new DataObject();
            dataObject.SetData(DataFormats.FileDrop, WabiLogic.PersistPro.Tools.Storage.PrepFileInTempDirForTransfer(fileInstances));
            dataObject.SetData(onlineBackupUtilityFileMove, files);
            listViewFiles.DoDragDrop(dataObject, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private string onlineBackupUtilityFileMove = "OnlineBackupUtilityFileMove";
        private IList<IFile> IsOnlineBackupUtilityFileMove(DragEventArgs args) {
            IList<IFile> files = null;
            if (args.Data.GetDataPresent(onlineBackupUtilityFileMove, true)) {
                files = args.Data.GetData(onlineBackupUtilityFileMove, true) as IList<IFile>;
            }
            return files;
        }
    }
}
