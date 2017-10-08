using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using NUnit.Framework;
using WabiLogic.Foundation.Storage;

namespace UnitTests {
    public abstract class StorageTestBase {
        private IManager manager;

        protected abstract IManager LoadManager();

        //[SetUp]
        public void Init() {
            manager = LoadManager();
        }

        //[Test]
        public void SimulateBackupOperations() {
            int sleepTime = 10;

            DateTime startTime = DateTime.Now;
            Thread.Sleep(sleepTime); 

            IFolder root = manager.GetRootFolder();
            Assert.IsNotNull(root, "Cannot create folder root.");

            string testName1 = "test1";
            IFolder test1 = root.CreateSubFolder(testName1);
            Assert.IsNotNull(test1, @"Cannot create folder root\{0}.", testName1);

            string testName1_1 = "test1_1";
            IFolder test1_1 = test1.CreateSubFolder(testName1_1);
            Assert.IsNotNull(test1_1, @"Cannot create folder root\{0}\{1}.", testName1, testName1_1);

            string testName1_2 = "test1_2";
            IFolder test1_2 = test1.CreateSubFolder(testName1_2);
            Assert.IsNotNull(test1_2, @"Cannot create folder root\{0}\{1}.", testName1, testName1_2);

            string testName1_3 = "test1_3";
            IFolder test1_3 = test1.CreateSubFolder(testName1_3);
            Assert.IsNotNull(test1_3, @"Cannot create folder root\{0}\{1}.", testName1, testName1_3);

            string testName2 = "test2";
            IFolder test2 = root.CreateSubFolder(testName2);
            Assert.IsNotNull(test2, @"Cannot create folder root\{0}.", testName2);

            Thread.Sleep(sleepTime);
            DateTime foldersCreatedTime = DateTime.Now;
            Thread.Sleep(sleepTime); 

            Action<string> testFoldersAtCreateTime = delegate(string description) {
                Assert.IsTrue(root.IsRoot, "Root does not say it is root. {0}", description);
                Assert.IsFalse(test1.IsRoot, "Sub Folder 1 claims it is root. {0}", description);
                Assert.IsFalse(test1_1.IsRoot, "Sub Folder 1_1 claims it is root. {0}", description);
                Assert.IsFalse(test1_2.IsRoot, "Sub Folder 1_2 claims it is root. {0}", description);
                Assert.IsFalse(test1_3.IsRoot, "Sub Folder 1_3 claims it is root. {0}", description);
                Assert.IsFalse(test2.IsRoot, "Sub Folder 2 claims it is root. {0}", description);

                IFolder parent = test1_1;
                int levels = 0;
                while (!parent.IsRoot) {
                    parent = parent.GetFolderInstance(DateTime.Now).Parent;
                    Assert.IsNotNull(parent, "Parent folder is null. {0}", description);
                    levels++;
                }
                Assert.AreEqual(2, levels, "Folder is at an incorrect depth of {0}. {1}", levels, description);

                Assert.AreEqual(test1_1.GetFolderInstance(DateTime.Now).Name, test1_1.GetFolderInstance(DateTime.Now).Folder.GetFolderInstance(DateTime.Now).Name, "FolderInstance does not point to its own Folder. {0}", description);

                Assert.IsTrue(test1.GetSubFolders(startTime).Count() == 0, "Folders exist before created. {0}", description);
                Assert.AreEqual(3, test1.GetSubFolders(foldersCreatedTime).Count(), "Wrong number of create folders exist. {0}", description);

                List<string> folderNameGroup = new List<string>(new string[] { testName1_1, testName1_2, testName1_3 });
                foreach (IFolderInstance folderInstance in test1.GetSubFolderInstances(foldersCreatedTime)) {
                    folderNameGroup.Remove(folderInstance.Name);
                }
                Assert.IsEmpty(folderNameGroup, "Did not find all created folders. {0}", description);
            };
            testFoldersAtCreateTime("First pass after creation.");

            test1_1.MoveTo(test2);

            Thread.Sleep(sleepTime); 
            DateTime folderMoveTime = DateTime.Now;
            Thread.Sleep(sleepTime);

            Action<string> testFoldersAtMoveTime = delegate(string description) {
                testFoldersAtCreateTime(description);

                Assert.AreEqual(2, test1.GetSubFolders(folderMoveTime).Count(), "Wrong number of move folders exist [1]. {0}", description);
                Assert.AreEqual(1, test2.GetSubFolders(folderMoveTime).Count(), "Wrong number of move folders exist [2]. {0}", description);

                List<string> folderNameGroup = new List<string>(new string[] { testName1_2, testName1_3 });
                foreach (IFolderInstance folderInstance in test1.GetSubFolderInstances(folderMoveTime)) {
                    folderNameGroup.Remove(folderInstance.Name);
                }
                Assert.IsEmpty(folderNameGroup, "Did not find all moved folders [1]. {0}", description);

                Assert.AreEqual(testName1_1, test2.GetSubFolders(folderMoveTime).First().GetFolderInstance(folderMoveTime).Name, "Did not find all moved folders [2]. {0}.", description);
            };

            testFoldersAtMoveTime("Second pass after move.");

            string testName1_1New = "testName1_1New";
            test1_1.Rename(testName1_1New);

            Thread.Sleep(sleepTime); 
            DateTime folderRenameTime = DateTime.Now;
            Thread.Sleep(sleepTime); 

            Action<string> testFoldersAtRenameTime = delegate(string description) {
                testFoldersAtMoveTime(description);

                Assert.AreEqual(testName1_1New, test1_1.GetFolderInstance(folderRenameTime).Name, "Folder did not rename. {0}", description);
            };

            testFoldersAtRenameTime("Third pass after rename.");

            test1_3.Delete();

            Thread.Sleep(sleepTime); 
            DateTime folderDeleteTime = DateTime.Now;
            Thread.Sleep(sleepTime); 

            Action<string> testFoldersAtDeleteTime = delegate(string description) {
                testFoldersAtRenameTime(description);

                Assert.AreEqual(1, test1.GetSubFolders(folderDeleteTime).Count(), "Wrong number of delete folders exist. {0}", description);
                Assert.AreEqual(testName1_2, test1.GetSubFolders(folderDeleteTime).First().GetFolderInstance(folderDeleteTime).Name, "Wrong folder deleted. {0}", description);
            };

            testFoldersAtDeleteTime("Fourth pass after delete.");

            Assert.AreEqual(3, test1_1.GetFolderInstances().Count(), "Number of Folder instance is wrong.");

            //Test Error Conditions
            try {
                root.CreateSubFolder(testName1);
                Assert.That(false, "Folder created with same name.");
            }
            catch (IOException) {
                //Correct behavior
            }

            try {
                root.MoveTo(test1);
                Assert.That(false, "Was able to move root folder.");
            }
            catch (IOException) {
                //Correct behavior
            }

            try {
                test1.MoveTo(test1_2);
                Assert.That(false, "A parent folder moved underneath a child folder.");
            }
            catch (IOException) {
                //Correct behavior
            }

            try {
                test1_3.MoveTo(test1_1);
                Assert.That(false, "A deleted folder was allowed to move.");
            }
            catch (IOException) {
                //Correct behavior
            }

            IFolder test1_1MoveNameError = test1.CreateSubFolder(testName1_1New);
            try {
                test1_1MoveNameError.MoveTo(test2);
                Assert.That(false, "A folder was allowed to move with the same name.");
            }
            catch (IOException) {
                //Correct behavior
            }

            try {
                test1_1MoveNameError.Rename(testName1_2);
                Assert.That(false, "A folder was allowed to rename itself to a name that already existed.");
            }
            catch (IOException) {
                //Correct behavior
            }

            //string testFileToLoad = @"C:\Users\carden\Desktop\BackupTest\test.txt";
            //string md5 = WabiLogic.Foundation.Tools.IO.GenerateMD5(testFileToLoad);
            //using (Stream inputStream = File.OpenRead(testFileToLoad)) {
            //    test1_1.CreateFile(inputStream, "test.txt", inputStream.Length, md5, "This is my note.");
            //}
            //using (Stream inputStream = File.OpenRead(testFileToLoad)) {
            //    test1_1.CreateFile(inputStream, "test.txt", inputStream.Length, md5, "This is my note.");
            //}

            manager.Save();
        }
    }
}
