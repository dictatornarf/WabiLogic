using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage;

namespace WabiLogic.Foundation.Tools.Extensions
{
    public static class IFolderInstanceExtensionMethods
    {
        public static string GetCleanFileName(this IFolderInstance myInterface)
        {
            if (myInterface.Parent.IsRoot)
            {
                return myInterface.Name.Remove(myInterface.Name.LastIndexOf("_"));
            }
            return myInterface.Name;
        }

    }
}
