using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineBackupUtility.Storage;
using OnlineBackupUtility.Mount;

namespace OnlineBackupUtility.Root {
    public interface IRootManager {
        IManager StorageManager { get; }
        IMount Mount { get; }
        IEnumerable<IRoot> Roots { get; }
        ISchedule Schedule { get; }

        void RemoveRoot(IRoot root);
        IRoot CreateRoot(string name, string path, bool sub, string note);
        void Save();
        void Backup();
    }
}
