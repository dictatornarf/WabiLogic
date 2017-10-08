using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Security.AccessControl;


namespace PersistProServer {
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer {
        public ProjectInstaller() {
            InitializeComponent();
        }

        protected override void OnCommitted(IDictionary savedState) {
            base.OnCommitted(savedState);

            string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //Move database to common ground
            string databaseName = "PersistPro.sdf";
            string databaseAppFile = Path.Combine(appDirectory, databaseName);
            string databaseFinalDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Persist Pro");
            string databaseFinalFile = Path.Combine(databaseFinalDir, databaseName);

            if (!Directory.Exists(databaseFinalDir))
                Directory.CreateDirectory(databaseFinalDir);

            if (!File.Exists(databaseFinalFile))
                File.Move(databaseAppFile, databaseFinalFile);
            else
            {
                //for now we are not going to delete the existing db
                //we will just rename it by appending the current DateTime
                //we might want to revisit later...
                File.Move(databaseFinalFile,Path.Combine(databaseFinalDir, string.Format("{0}_{1}", databaseName, DateTime.Now.ToFileTime().ToString())));
                File.Move(databaseAppFile, databaseFinalFile);
            }

            //HACK: This is nasty but it works.... I am now starting to hate Visa :)
            //Set the database directory to read are write for everyone
            //try {
            //    DirectoryInfo di = new DirectoryInfo(databaseFinalDir);
            //    DirectorySecurity ds = di.GetAccessControl();
            //    ds.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            //    di.SetAccessControl(ds);
            //}
            //catch { /* ignore */ }

            //Set the database to be read and write by everyone
            //try {
            //    FileInfo fi = new FileInfo(databaseFinalFile);
            //    FileSecurity fs = fi.GetAccessControl();
            //    fs.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            //    fi.SetAccessControl(fs);
            //}
            //catch { /* ignore */ }

            //TODO -- IMPORTANT
            //In the future this is a good spot to put upgrade code for the databases.

            //Start Server
            ServiceController service = new ServiceController("Persist Pro");
            if (service.Status == ServiceControllerStatus.Stopped) {
                service.Start();
            }

            //Start Client
            /*try {
                Process.Start(Path.Combine(appDirectory, "PersistProClient.exe"));
            }
            catch {
                // Do nothing... 
            }*/
        }
    }
}
