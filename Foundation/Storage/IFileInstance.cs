using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WabiLogic.Foundation.Storage {
    public interface IFileInstance {
        Guid Id { get; }
        string Name { get; }
        long Size { get; }
        string MD5 { get; }
        string Note { get; set; }
        IFolder Folder { get; }

        DateTime StartDate { get; }
        DateTime EndDate { get; }

        Stream CreateStream();
        IFile File { get; }
        void MakeCurrentInstance(); //Make current instance
    }
}
