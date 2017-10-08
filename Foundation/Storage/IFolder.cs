using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WabiLogic.Foundation.Storage {
    public interface IFolder {
        Guid Id { get; }
        void MoveTo(IFolder destination);
        void Rename(string name);
        void Delete();
        void Delete(bool recursive);
        bool IsRoot { get; }

        IEnumerable<IFolderInstance> GetAllSubFolderInstances();
        IEnumerable<IFolderInstance> GetSubFolderInstances(DateTime snapshot);
        IEnumerable<IFolder> GetSubFolders(DateTime snapshot);
        IFolder CreateSubFolder(string name);

        IEnumerable<IFileInstance> GetAllFileInstances();
        IEnumerable<IFileInstance> GetFileInstances(DateTime snapshot);
        IEnumerable<IFile> GetAllFiles();
        IEnumerable<IFile> GetFiles(DateTime snapshot);
        IFile CreateFile(Stream inputStream, string name, long size, string md5, string note);

        IFolderInstance GetFolderInstance(DateTime snapshot);
        IEnumerable<IFolderInstance> GetFolderInstances();
    }
}
