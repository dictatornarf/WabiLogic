using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.Foundation.Storage {
    public interface IFolderInstance {
        Guid Id { get; }
        string Name { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        
        IFolder Folder { get; }
        IFolder Parent { get; }
    }
}
