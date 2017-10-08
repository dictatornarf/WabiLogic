using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Storage.FileShare;
using NUnit.Framework;

namespace UnitTests {
    //[TestFixture]
    public class FileStorageTest : StorageTestBase {
        protected override IManager LoadManager() {
            return new FileShareManager(@"C:\Users\carden\Desktop\test");
        }

        public static void Main(string[] args) {
            Guid g = Guid.NewGuid();
            string n = g.ToString("N");
            string d = g.ToString("D");
            string b = g.ToString("B");
            string p = g.ToString("P");
            string a = g.ToString();

            Guid g1 = new Guid(n);

            //System.IO.File.Move(@"C:\Users\carden\Desktop\test\storage.del", @"C:\Users\carden\Desktop\test\storage.old");

            FileStorageTest test = new FileStorageTest();
            test.Init();
            test.SimulateBackupOperations();
            
        }
    }
}
