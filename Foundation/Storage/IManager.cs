using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.Foundation.Storage {
    public interface IManager {
        IFolder GetRootFolder();

        event TransferBeginHandler TransferBegin;
        event TransferUpdateHandler TransferUpdate;
        event TransferEndHandler TransferEnd;

        void CacheDatabase(string cacheFile);
        void Open();
        void Save();
        void Recycle(PurgeRules purgeRules);
        void Close();
    }
}
