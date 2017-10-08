using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WabiLogic.Foundation.Storage {
    public interface IFile {
        Guid Id { get; }
        void MoveTo(IFolder destination);
        void Rename(string name);
        void Delete();

        IFileInstance GetFileInstance(DateTime snapshot);
        IEnumerable<IFileInstance> GetFileInstances();

        void UpdateFile(Stream inputStream, long size, string md5, string note);
    }
}
