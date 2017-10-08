using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;

namespace WabiLogic.Foundation.Storage.BasicBase {
    public abstract class BasicFolder : IFolder {
        public BasicFolder(BasicManager manager, BasicDataSet.FolderRow folderRow) {
            this.Manager = manager;
            this.FolderRow = folderRow;
        }

        public BasicManager Manager { get; private set; }
        public BasicDataSet.FolderRow FolderRow { get; private set; }

        #region IFolder Members

        public Guid Id {
            get { return this.FolderRow.FolderId; }
        }

        public void MoveTo(IFolder destination) {
            //Cannot Move Root
            if (this.FolderRow.FolderId == BasicManager.RootId)
                throw new IOException("Cannot move root folder.");

            //Cannot Move a deleted folder
            int existCount = this.Manager.Set.FolderInstance.Count(
                fi => fi.FolderId == this.FolderRow.FolderId
                && fi.StartDate <= DateTime.Now
                && fi.EndDate > DateTime.Now
            );

            if (existCount < 1)
                throw new IOException("Cannot move a deleted folder.");

            //Cannot Move parent folder to child folder
            IFolder parent = destination;
            while (parent != null && !parent.IsRoot) {
                IFolderInstance instance = parent.GetFolderInstance(DateTime.Now);

                if (instance == null) {
                    throw new IOException("Cannot move to a deleted folder.");
                }
                else {
                    if (((BasicFolder)parent).FolderRow.FolderId == this.FolderRow.FolderId)
                        throw new IOException("Cannot move parent folder to child folder.");
                }

                parent = instance.Parent;
            }

            int count = this.Manager.Set.FolderInstance.Count(
                fi => fi.ParentFolderId == ((BasicFolder)destination).FolderRow.FolderId
                && fi.StartDate <= DateTime.Now
                && fi.EndDate > DateTime.Now
                && fi.Name == this.GetFolderInstance(DateTime.Now).Name
            );

            if (count > 0)
                throw new IOException("Folder name already exists at destination.");

            try {
                //Move folder
                DateTime updateDateTime = DateTime.Now;

                //End date Folder Instance
                BasicFolderInstance fi = (BasicFolderInstance)this.GetFolderInstance(updateDateTime);
                fi.EndDate = updateDateTime;

                //Create new Folder Instance
                this.Manager.Set.FolderInstance.AddFolderInstanceRow(Guid.NewGuid(), this.FolderRow, fi.Name, ((BasicFolder)destination).FolderRow, updateDateTime, DateTime.MaxValue);
                this.Manager.Set.AcceptChanges();
            }
            catch (Exception e) {
                this.Manager.Set.RejectChanges();
                throw e;
            }
        }

        public void Rename(string name) {
            if (name == null)
                throw new NullReferenceException("Folder name cannot be null.");

            if (name.Length == 0)
                throw new Exception("Folder name cannot be empty.");

            int count = this.Manager.Set.FolderInstance.Count(
                fi => fi.ParentFolderId == ((BasicFolder)this.GetFolderInstance(DateTime.Now).Parent).FolderRow.FolderId
                && fi.StartDate <= DateTime.Now
                && fi.EndDate > DateTime.Now
                && fi.Name == name
            );

            if (count > 0)
                throw new IOException("Folder name already exists.");

            try {
                DateTime updateDateTime = DateTime.Now;

                //End date Folder Instance
                BasicFolderInstance fi = (BasicFolderInstance)this.GetFolderInstance(updateDateTime);
                fi.EndDate = updateDateTime;

                //Create new Folder Instance
                this.Manager.Set.FolderInstance.AddFolderInstanceRow(Guid.NewGuid(), this.FolderRow, name, ((BasicFolder)fi.Parent).FolderRow, updateDateTime, DateTime.MaxValue);
                this.Manager.Set.AcceptChanges();
            }
            catch (Exception e) {
                this.Manager.Set.RejectChanges();
                throw e;
            }           
        }

        public void Delete() {
            //Cannot Delete Root
            if (this.FolderRow.FolderId == BasicManager.RootId)
                throw new IOException("Cannot delete root folder.");

            //Cannot Delete non-empty folder. Use Recursive Delete.
            if (this.GetSubFolderInstances(DateTime.Now).Count() > 0 || this.GetFileInstances(DateTime.Now).Count() > 0)
                throw new IOException("Cannot delete non-empty folder.");

            try {
                DateTime updateDateTime = DateTime.Now;

                //End date Folder Instance
                BasicFolderInstance fi = (BasicFolderInstance)this.GetFolderInstance(updateDateTime);
                fi.EndDate = updateDateTime;
                this.Manager.Set.AcceptChanges();
            }
            catch (Exception e) {
                this.Manager.Set.RejectChanges();
                throw e;
            }
        }

        public void Delete(bool recursive) {
            if (!recursive) {
                Delete();
            }
            else {
                DeleteRecursive(this);
            }
        }

        private void DeleteRecursive(IFolder folder) {
            foreach (IFolder subFolder in folder.GetSubFolders(DateTime.Now)) {
                DeleteRecursive(subFolder);
            }

            foreach (IFile file in folder.GetFiles(DateTime.Now)) {
                file.Delete();
            }

            folder.Delete();
        }

        public bool IsRoot {
            get { return (this.FolderRow.FolderId == BasicManager.RootId); }
        }

        public IEnumerable<IFolderInstance> GetAllSubFolderInstances() {
            var results = from fi in this.Manager.Set.FolderInstance
                          where fi.ParentFolderId == this.FolderRow.FolderId
                          && fi.ParentFolderId != fi.FolderId // Handle Root
                          orderby fi.Name
                          select fi;

            foreach (BasicDataSet.FolderInstanceRow fir in results) {
                yield return this.Manager.GetFolderInstance(fir);
            }
        }

        public IEnumerable<IFolderInstance> GetSubFolderInstances(DateTime snapshot) {
            var results = from fi in this.Manager.Set.FolderInstance
                          where fi.ParentFolderId == this.FolderRow.FolderId
                          && fi.StartDate <= snapshot
                          && fi.EndDate > snapshot
                          && fi.ParentFolderId != fi.FolderId // Handle Root
                          orderby fi.Name
                          select fi;

            foreach (BasicDataSet.FolderInstanceRow fir in results) {
                yield return this.Manager.GetFolderInstance(fir);
            }
        }

        public IEnumerable<IFolder> GetSubFolders(DateTime snapshot) {
            var results = from fi in this.Manager.Set.FolderInstance join 
                                          f in this.Manager.Set.Folder on fi.FolderId equals f.FolderId 
                          where fi.ParentFolderId == this.FolderRow.FolderId
                          && fi.StartDate <= snapshot
                          && fi.EndDate > snapshot
                          && fi.ParentFolderId != fi.FolderId // Handle Root
                          orderby fi.Name
                          select f;

            foreach (BasicDataSet.FolderRow fr in results) {
                yield return this.Manager.GetFolder(fr);
            }
        }

        public IFolder CreateSubFolder(string name) {
            if (name == null)
                throw new NullReferenceException("Folder name cannot be null.");

            if (name.Length == 0)
                throw new Exception("Folder name cannot be empty.");

            int count = this.Manager.Set.FolderInstance.Count(
                fi => fi.ParentFolderId == this.FolderRow.FolderId
                && fi.StartDate <= DateTime.Now
                && fi.EndDate > DateTime.Now
                && fi.Name == name
            );

            if (count > 0)
                throw new IOException("Folder name already exists.");
            
            try {
                BasicDataSet.FolderRow fr = this.Manager.Set.Folder.AddFolderRow(Guid.NewGuid());
                this.Manager.Set.FolderInstance.AddFolderInstanceRow(Guid.NewGuid(), fr, name, this.FolderRow, DateTime.Now, DateTime.MaxValue);
                this.Manager.Set.AcceptChanges();
                return this.Manager.GetFolder(fr);
            }
            catch (Exception e) {
                this.Manager.Set.RejectChanges();
                throw e;
            }
        }

        public IEnumerable<IFileInstance> GetAllFileInstances() {
            var results = from fi in this.Manager.Set.FileInstance
                          where fi.FolderId == this.FolderRow.FolderId
                          orderby fi.Name
                          select fi;

            foreach (BasicDataSet.FileInstanceRow fir in results) {
                yield return this.Manager.GetFileInstance(fir);
            }
        }

        public IEnumerable<IFileInstance> GetFileInstances(DateTime snapshot) {
            var results = from fi in this.Manager.Set.FileInstance
                          where fi.FolderId == this.FolderRow.FolderId
                          && fi.StartDate <= snapshot
                          && fi.EndDate > snapshot
                          orderby fi.Name
                          select fi;

            foreach (BasicDataSet.FileInstanceRow fir in results) {
                yield return this.Manager.GetFileInstance(fir);
            }
        }

        public IEnumerable<IFile> GetAllFiles() {
            var results = from fi in this.Manager.Set.FileInstance
                          join f in this.Manager.Set.File on fi.FileId equals f.FileId
                          where fi.FolderId == this.FolderRow.FolderId
                          orderby fi.Name
                          select f;

            foreach (BasicDataSet.FileRow fr in results) {
                yield return this.Manager.GetFile(fr);
            }
        }

        public IEnumerable<IFile> GetFiles(DateTime snapshot) {
            var results = from fi in this.Manager.Set.FileInstance
                          join f in this.Manager.Set.File on fi.FileId equals f.FileId
                          where fi.FolderId == this.FolderRow.FolderId
                          && fi.StartDate <= snapshot
                          && fi.EndDate > snapshot
                          orderby fi.Name
                          select f;

            foreach (BasicDataSet.FileRow fr in results) {
                yield return this.Manager.GetFile(fr);
            }
        }

        public IFile CreateFile(Stream inputStream, string name, long size, string md5, string note) {
            if (name == null)
                throw new NullReferenceException("File name cannot be null.");

            if (name.Length == 0)
                throw new Exception("File name cannot be empty.");

            IFile toReturn = null;

            int count = this.Manager.Set.FileInstance.Count(
                fi => fi.FolderId == this.FolderRow.FolderId
                && fi.StartDate <= DateTime.Now
                && fi.EndDate > DateTime.Now
                && fi.Name == name
            );

            if (count > 0)
                throw new IOException("File name already exists.");

            try {
                Guid streamId = this.Manager.FindStreamId(md5, size);
                if (streamId == Guid.Empty) {
                    streamId = Guid.NewGuid();
                    using (Stream transferStream = new TransferStream(this.Manager, inputStream, name, size)) {
                        this.Manager.SaveStream(transferStream, streamId);
                    }
                }
                else {
                    inputStream.Close();
                }
                BasicDataSet.FileRow fr = this.Manager.Set.File.AddFileRow(Guid.NewGuid());
                this.Manager.Set.FileInstance.AddFileInstanceRow(Guid.NewGuid(), fr, this.FolderRow, name, size, md5, note, streamId, DateTime.Now, DateTime.MaxValue);
                this.Manager.Set.AcceptChanges();

                toReturn = this.Manager.GetFile(fr);
            }
            catch (Exception e) {
                this.Manager.Set.RejectChanges();
                throw e;
            }

            return toReturn;
        }

        public IFolderInstance GetFolderInstance(DateTime snapshot) {
            var rows = (from fi in this.Manager.Set.FolderInstance
                        where fi.FolderId == this.FolderRow.FolderId
                        && fi.StartDate <= snapshot
                        && fi.EndDate > snapshot
                        select fi);

            IFolderInstance toReturn = null;
            if (rows.Count() == 1)
                toReturn = this.Manager.GetFolderInstance(rows.Single());

            return toReturn;
        }

        public IEnumerable<IFolderInstance> GetFolderInstances() {
            var results = from fi in this.Manager.Set.FolderInstance
                          where fi.FolderId == this.FolderRow.FolderId
                          orderby fi.StartDate
                          select fi;
            
            foreach (BasicDataSet.FolderInstanceRow folderInstanceRow in results) {
                yield return this.Manager.GetFolderInstance(folderInstanceRow);
            }
        }

        #endregion
    }
}
