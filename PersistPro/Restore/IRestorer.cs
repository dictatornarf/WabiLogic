using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Restore
{
    public interface IRestorer
    {
        event EventHandler<ItemRestoreCompleteEventArgs> ItemRestoreComplete;

        void RestoreItem();
        RestoreInfo GenerateRestoreInfo();
    }

}
