using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage;
using WabiLogic.PersistPro.Model;

namespace WabiLogic.PersistPro.Controller {
    class RootTimeSpanPurgeRules : PurgeRules {
        public IRoot Root { get; set; }
        public TimeSpan Span { get; set; }

        public RootTimeSpanPurgeRules(IRoot root, TimeSpan span) {
            this.Root = root;
            this.Span = span;
        }

        public override bool PurgeFolderInstance(IFolderInstance folderInstance) {
            if (IsFolderInstanceInRoot(folderInstance))
                return (DateTime.Now - folderInstance.EndDate) > this.Span;
            else
                return false;
        }

        public override bool PurgeFileInstance(IFileInstance fileInstance) {
            if (IsFileInstanceInRoot(fileInstance))
                return (DateTime.Now - fileInstance.EndDate) > this.Span;
            else
                return false;
        }

        private bool IsFolderInstanceInRoot(IFolderInstance fi) {
            string rootFoldername = BackupManager.RootFolderName(this.Root);
            
            IFolderInstance ptr = fi;
            do {
                if (ptr.Name == rootFoldername)
                    return true;
                else
                    ptr = ptr.Parent.GetFolderInstance(DateTime.Now);
            } while (!ptr.Folder.IsRoot);

            return false;
        }

        private bool IsFileInstanceInRoot(IFileInstance fi) {
            return IsFolderInstanceInRoot(fi.Folder.GetFolderInstance(DateTime.Now));
        }
    }
}
