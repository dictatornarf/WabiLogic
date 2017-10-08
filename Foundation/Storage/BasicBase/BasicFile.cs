using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;

namespace WabiLogic.Foundation.Storage.BasicBase {
    public abstract class BasicFile : IFile {
        public BasicFile(BasicManager manager, BasicDataSet.FileRow fileRow) {
            this.Manager = manager;
            this.FileRow = fileRow;
        }

        public BasicManager Manager { get; private set; }
        public BasicDataSet.FileRow FileRow { get; private set; }

        #region IFile Members

        public Guid Id {
            get { return this.FileRow.FileId; }
        }

        public void MoveTo(IFolder destination) {
            int count = this.Manager.Set.FileInstance.Count(
                fi => fi.FolderId == ((BasicFolder)destination).FolderRow.FolderId
                && fi.StartDate <= DateTime.Now
                && fi.EndDate > DateTime.Now
                && fi.Name == this.GetFileInstance(DateTime.Now).Name
            );

            if (count > 0)
                throw new IOException("File name already exists at destination.");

            try {
                //Move folder
                DateTime updateDateTime = DateTime.Now;

                //End date File Instance
                BasicFileInstance fi = (BasicFileInstance)this.GetFileInstance(updateDateTime);
                fi.EndDate = updateDateTime;

                //Create new File Instance
                this.Manager.Set.FileInstance.AddFileInstanceRow(Guid.NewGuid(), this.FileRow, ((BasicFolder)destination).FolderRow, fi.Name, fi.Size, fi.MD5, fi.Note, fi.StreamId, updateDateTime, DateTime.MaxValue);
                this.Manager.Set.AcceptChanges();
            }
            catch (Exception e) {
                this.Manager.Set.RejectChanges();
                throw e;
            }
        }

        public void Rename(string name) {
            if (name == null)
                throw new NullReferenceException("File name cannot be null.");

            if (name.Length == 0)
                throw new Exception("File name cannot be empty.");

            int count = this.Manager.Set.FileInstance.Count(
                fi => fi.FolderId == ((BasicFolder)this.GetFileInstance(DateTime.Now).Folder).FolderRow.FolderId
                && fi.StartDate <= DateTime.Now
                && fi.EndDate > DateTime.Now
                && fi.Name == name
            );

            if (count > 0)
                throw new IOException("File name already exists.");

            try {
                DateTime updateDateTime = DateTime.Now;

                //End date Folder Instance
                BasicFileInstance fi = (BasicFileInstance)this.GetFileInstance(updateDateTime);
                fi.EndDate = updateDateTime;

                //Create new Folder Instance
                this.Manager.Set.FileInstance.AddFileInstanceRow(Guid.NewGuid(), this.FileRow, ((BasicFolder)fi.Folder).FolderRow, fi.Name, fi.Size, fi.MD5, fi.Note, fi.StreamId, updateDateTime, DateTime.MaxValue);
                this.Manager.Set.AcceptChanges();
            }
            catch (Exception e) {
                this.Manager.Set.RejectChanges();
                throw e;
            }
        }

        public void Delete() {
            try {
                DateTime updateDateTime = DateTime.Now;

                //End date Folder Instance
                BasicFileInstance fi = (BasicFileInstance)this.GetFileInstance(updateDateTime);
                fi.EndDate = updateDateTime;
                this.Manager.Set.AcceptChanges();
            }
            catch (Exception e) {
                this.Manager.Set.RejectChanges();
                throw e;
            }
        }

        public IFileInstance GetFileInstance(DateTime snapshot) {
            BasicDataSet.FileInstanceRow fileInstanceRow = (from fi in this.Manager.Set.FileInstance
                                                                where fi.FileId == this.FileRow.FileId
                                                                && fi.StartDate <= snapshot
                                                                && fi.EndDate > snapshot
                                                                select fi).Single();

            return this.Manager.GetFileInstance(fileInstanceRow);
        }

        public IEnumerable<IFileInstance> GetFileInstances() {
            var results = from fi in this.Manager.Set.FileInstance
                          where fi.FileId == this.FileRow.FileId
                          orderby fi.StartDate
                          select fi;

            List<IFileInstance> toReturn = new List<IFileInstance>();
            foreach (BasicDataSet.FileInstanceRow fileInstanceRow in results) {
                yield return this.Manager.GetFileInstance(fileInstanceRow);
            }
        }

        public void UpdateFile(Stream inputStream, long size, string md5, string note) {
            try {
                DateTime updateDateTime = DateTime.Now;
                BasicFileInstance fi = (BasicFileInstance)this.GetFileInstance(updateDateTime);

                Guid streamId = this.Manager.FindStreamId(md5, size);
                if (streamId == Guid.Empty) {
                    streamId = Guid.NewGuid();
                    using (Stream transferStream = new TransferStream(this.Manager, inputStream, fi.Name, size)) {
                        this.Manager.SaveStream(transferStream, streamId);
                    }
                }
                else {
                    inputStream.Close();
                }

                //End date File Instance
                fi.EndDate = updateDateTime;

                this.Manager.Set.FileInstance.AddFileInstanceRow(Guid.NewGuid(), this.FileRow, ((BasicFolder)fi.Folder).FolderRow, fi.Name, size, md5, note, streamId, updateDateTime, DateTime.MaxValue);
                this.Manager.Set.AcceptChanges();
            }
            catch (Exception e) {
                this.Manager.Set.RejectChanges();
                throw e;
            }
        }

        #endregion
    }
}
