using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OnlineBackupUtility {
    public interface IStorage {
        string CreateFileId(BackupDatabase.RootsRow root, string fileFullName);
        string CreateFullName(BackupDatabase.RootsRow root, string fileId);
        Stream Store(string fileId);
        Stream Retrieve(string fileId);
        BackupDatabase LoadDatabase();
        void SaveDatabase(BackupDatabase backupDatabase);
    }
}
