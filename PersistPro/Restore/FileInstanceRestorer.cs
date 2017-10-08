using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage;
using System.IO;

namespace WabiLogic.PersistPro.Restore
{
    class FileInstanceRestorer : IRestorer
    {
        public IFileInstance FileInstanceToRestore { get; set; }
        public bool IncludeDateInFileName { get; set; }
        public string RestorePath { get; set; }

        public event EventHandler<ItemRestoreCompleteEventArgs> ItemRestoreComplete;

        protected virtual void OnItemRestoreComplete(ItemRestoreCompleteEventArgs e)
        {
            if (ItemRestoreComplete != null)
            {
                ItemRestoreComplete(this, e);
            }
        }


        #region IRestorer Members


        public void RestoreItem()
        {
            if (!Directory.Exists(RestorePath))
                Directory.CreateDirectory(RestorePath);

            string fileName = GetAvailableFileName(FileInstanceToRestore.Name);

            using (Stream inputStream = FileInstanceToRestore.CreateStream())
            using (Stream outputStream = File.OpenWrite(fileName))
            {
                try
                {
                    WabiLogic.Foundation.Tools.IO.WriteStream(inputStream, outputStream);
                }
                catch (ObjectDisposedException) { /* Ignore -- Probably remote network reset */ }
            }
            OnItemRestoreComplete(new ItemRestoreCompleteEventArgs(FileInstanceToRestore, null));
        }



        public RestoreInfo GenerateRestoreInfo()
        {
            //It is possible for a file to be zero bytes. In order to make our calculations easier
            //we are going to round up to a single byte.
            return new RestoreInfo()
            {
                TotalFileCount = 1,
                TotalFileSize = FileInstanceToRestore.Size,
                TotalFolderCount = 0
            };
        }
        #endregion

        #region FileNameHelperMethods
        //returns an available filename to be used when restoring a file instance, using the following rules:
        //**If IncludeDateInFileName is true then rule 1 is skipped
        //1. Try to create the file using the filename
        //2. Try to create the file using the filename with the date included
        //3. Append an integer to the end of the filename (starts with 1 and increments by one until file doesn't exist)
        private string GetAvailableFileName(string fileName)
        {
            if (IncludeDateInFileName)
                fileName = AddDateToFileName(fileName);
            else
            {
                //check to see if the file exists, if so append the date to the file name
                fileName = Path.Combine(RestorePath, FileInstanceToRestore.Name);
                
                if (File.Exists(fileName)) fileName = AddDateToFileName(fileName);
            }

            string tempFileName = fileName;
            int counter = 0;

            while (File.Exists(tempFileName)) 
            {
                tempFileName = AppendNumberToFileName(fileName, ++counter);
            }

            return tempFileName;
        }

        private string AddDateToFileName(string fileName)
        {
            return Path.Combine(RestorePath, string.Format("{0} ({1}){2}", Path.GetFileNameWithoutExtension(fileName),
                                FileInstanceToRestore.StartDate.ToLongDateString(),
                                Path.GetExtension(fileName)));
        }

        //returns filename in format <FileName>_<Int>.<Extension>
        private string AppendNumberToFileName(string fileName, int counter)
        {
            return Path.Combine(RestorePath, string.Format("{0}_{1}{2}", Path.GetFileNameWithoutExtension(fileName),
                    counter.ToString(),
                    Path.GetExtension(fileName)));
        }

        #endregion
    }
}
