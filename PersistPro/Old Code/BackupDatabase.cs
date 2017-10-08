using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace OnlineBackupUtility.BackupDatabaseTableAdapters {
}

namespace OnlineBackupUtility {
    public partial class BackupDatabase {
   
        public static void Save(BackupDatabase backupDatabase, Stream saveStream) {
            backupDatabase.RemotingFormat = SerializationFormat.Binary;
            backupDatabase.Files.RemotingFormat = SerializationFormat.Binary;
            backupDatabase.Roots.RemotingFormat = SerializationFormat.Binary;

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(saveStream, backupDatabase);
        }

        public static BackupDatabase Load(Stream loadStream) {
            BinaryFormatter bf = new BinaryFormatter();
            BackupDatabase backupDatabase = bf.Deserialize(loadStream) as BackupDatabase;

            return backupDatabase;
        }

        public partial class FilesRow {
            public bool IsFileMatch(string hash, long size) {
                return (this.Hash == hash && this.Size == size);
            }
        }

        partial class FilesDataTable {
            public FilesRow FindFileId(string fileId) {
                FilesRow[] rows = this.Select(string.Format("FileId = '{0}'", fileId)) as FilesRow[];
                return (rows.Length > 0) ? rows[0] : null;
            }        
        }

        partial class RootsDataTable {
            public RootsRow FindName(string name) {
                RootsRow[] rows = this.Select(string.Format("Name = '{0}'", name)) as RootsRow[];
                return (rows.Length > 0) ? rows[0] : null;
            }
        }
    }
}
