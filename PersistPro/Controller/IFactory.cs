using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.Model;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Encryption;

namespace WabiLogic.PersistPro.Controller {
    public interface IFactory {
        IPlanManager LoadPlanManager();
        void SavePlanManager();

        IHistoryManager LoadHistoryManager();
        void SaveHistoryManager();

        IConfiguration LoadConfiguration();
        void SaveConfiguration();

        IEncryption LoadEncryption();
        void SaveEncryptionPassword(string password);

        void Register(string name, string key);
        bool IsRegistered { get; }

        bool RunSetup { get; set; }
    }
}
