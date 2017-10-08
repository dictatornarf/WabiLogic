using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage;

namespace WabiLogic.Foundation.Storage.BasicBase {
    public abstract class BasicFolderInstance : IFolderInstance {
        public BasicFolderInstance(BasicManager manager, BasicDataSet.FolderInstanceRow folderInstanceRow) {
            this.Manager = manager;
            this.FolderInstanceRow = folderInstanceRow;
        }

        public BasicManager Manager { get; private set; }
        public BasicDataSet.FolderInstanceRow FolderInstanceRow { get; private set; }

        #region IFolderInstance Members

        public Guid Id {
            get { return this.FolderInstanceRow.FolderInstanceId; }
        }

        public string Name {
            get { return this.FolderInstanceRow.Name; }
        }

        public DateTime StartDate {
            get { return this.FolderInstanceRow.StartDate; }
        }

        public DateTime EndDate {
            get { return this.FolderInstanceRow.EndDate; }
            set { this.FolderInstanceRow.EndDate = value; }
        }

        public IFolder Folder {
            get {
                BasicDataSet.FolderRow folderRow = (from f in this.Manager.Set.Folder
                                                    where f.FolderId == this.FolderInstanceRow.FolderId
                                                    select f).Single();

                return this.Manager.GetFolder(folderRow); 
            }
        }

        public IFolder Parent {
            get {
                BasicDataSet.FolderRow folderRow = (from f in this.Manager.Set.Folder
                                                    where f.FolderId == this.FolderInstanceRow.ParentFolderId
                                                    select f).Single();

                return this.Manager.GetFolder(folderRow);
            }
        }
        #endregion
    }
}
