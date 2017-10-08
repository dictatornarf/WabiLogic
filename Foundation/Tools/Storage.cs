using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;

namespace WabiLogic.PersistPro.Tools {
    public static class Storage {
        public static string[] PrepFileInTempDirForTransfer(IList<IFileInstance> fileInstances) {
            List<string> tempFileLocations = new List<string>();

            string tempFolder = Path.Combine(Path.GetTempPath(), "OnlineBackupUtilityTemp");
            if (!Directory.Exists(tempFolder))
                Directory.CreateDirectory(tempFolder);

            foreach (IFileInstance fi in fileInstances) {
                string fileFolder = Path.Combine(tempFolder, fi.StartDate.Ticks.ToString());
                if (!Directory.Exists(fileFolder))
                    Directory.CreateDirectory(fileFolder);

                string fileName = Path.Combine(fileFolder, fi.Name);

                if (!File.Exists(fileName)) {
                    using (Stream inputStream = fi.CreateStream())
                    using (Stream outputStream = File.OpenWrite(fileName)) {
                        WabiLogic.Foundation.Tools.IO.WriteStream(inputStream, outputStream);
                    }
                }

                tempFileLocations.Add(fileName);
            }

            return tempFileLocations.ToArray();
        }

        public static bool RestoreFileInstance(IFileInstance fileInstance, string restoreFolder) {
            bool success = true;

            if (!Directory.Exists(restoreFolder))
                Directory.CreateDirectory(restoreFolder);

            string fileName = Path.Combine(restoreFolder, fileInstance.Name);

            if (!File.Exists(fileName)) {
                using (Stream inputStream = fileInstance.CreateStream())
                using (Stream outputStream = File.OpenWrite(fileName)) {
                    WabiLogic.Foundation.Tools.IO.WriteStream(inputStream, outputStream);
                }
            }

            return success;
        }
    }
}
