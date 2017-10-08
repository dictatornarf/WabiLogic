using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WabiLogic.Foundation.Storage.BasicBase;

namespace UnitTests.Storage.BasicBase.Mock {
    class BasicMockManager : BasicManager {
        public override BasicFolder GetFolder(BasicDataSet.FolderRow folderRow) {
            return new BasicMockFolder(this, folderRow);
        }

        public override BasicFolderInstance GetFolderInstance(BasicDataSet.FolderInstanceRow folderInstanceRow) {
            return new BasicMockFolderInstance(this, folderInstanceRow);
        }

        public override BasicFile GetFile(BasicDataSet.FileRow fileRow) {
            return new BasicMockFile(this, fileRow);
        }

        public override BasicFileInstance GetFileInstance(BasicDataSet.FileInstanceRow fileInstanceRow) {
            return new BasicMockFileInstance(this, fileInstanceRow);
        }

        public override System.IO.Stream LoadStream(Guid streamId) {
            throw new NotImplementedException();
        }

        public override System.IO.Stream SaveStream(Guid streamId) {
            throw new NotImplementedException();
        }

        public override void DeleteStream(Guid streamId) {
            throw new NotImplementedException();
        }

        public override IEnumerable<Guid> LoadStreamIds() {
            throw new NotImplementedException();
        }

        public override void CacheDatabase(string cacheFile) {
            throw new NotImplementedException();
        }

        public override void Open() {
            throw new NotImplementedException();
        }

        public override void Close() {
            throw new NotImplementedException();
        }

        public override void Save() {
            throw new NotImplementedException();
        }
    }
}
