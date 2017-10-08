using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;

namespace WabiLogic.Foundation.Storage.BasicBase {
    public abstract class BasicFileInstance : IFileInstance {
        public BasicFileInstance(BasicManager manager, BasicDataSet.FileInstanceRow fileInstanceRow) {
            this.Manager = manager;
            this.FileInstanceRow = fileInstanceRow;
        }

        public BasicManager Manager { get; private set; }
        public BasicDataSet.FileInstanceRow FileInstanceRow { get; private set; }

        public Guid StreamId {
            get { return this.FileInstanceRow.StreamId; }
        }

        #region IFileInstance Members
        public Guid Id {
            get { return this.FileInstanceRow.FileInstanceId; }
        }

        public string Name {
            get { return this.FileInstanceRow.Name; }
        }

        public long Size {
            get { return this.FileInstanceRow.Size; }
        }

        public string MD5 {
            get { return this.FileInstanceRow.MD5; }
        }

        public string Note {
            get { return this.FileInstanceRow.Note; }
            set { this.FileInstanceRow.Note = value; }
        }

        public DateTime StartDate {
            get { return this.FileInstanceRow.StartDate; }
        }

        public DateTime EndDate {
            get { return this.FileInstanceRow.EndDate; }
            set { this.FileInstanceRow.EndDate = value; }
        }

        public Stream CreateStream() {
            return new TransferStream(this.Manager, this.Manager.LoadStream(this.StreamId), this.Name, this.Size);
        }

        public IFolder Folder {
            get {
                BasicDataSet.FolderRow folderRow = (from f in this.Manager.Set.Folder
                                                    where f.FolderId == this.FileInstanceRow.FolderId
                                                    select f).Single();

                return this.Manager.GetFolder(folderRow);
            }
        }


        public IFile File {
            get {
                BasicDataSet.FileRow fileRow = (from f in this.Manager.Set.File
                                                join fi in this.Manager.Set.FileInstance
                                                on f.FileId equals fi.FileId
                                                where fi.FileInstanceId == this.FileInstanceRow.FileInstanceId
                                                select f).Single();

                return this.Manager.GetFile(fileRow);
            }
        }

        public void MakeCurrentInstance() {
            DateTime updateDateTime = DateTime.Now;

            //End date File Instance
            BasicFileInstance fi = (BasicFileInstance)this.File.GetFileInstance(updateDateTime);
            fi.EndDate = updateDateTime;

            //Add this one
            this.Manager.Set.FileInstance.AddFileInstanceRow(Guid.NewGuid(), ((BasicFile)this.File).FileRow, ((BasicFolder)fi.Folder).FolderRow, fi.Name, this.Size, this.MD5, this.Note, this.StreamId, updateDateTime, DateTime.MaxValue);
            this.Manager.Set.AcceptChanges();
        }

        #endregion
    }
}
