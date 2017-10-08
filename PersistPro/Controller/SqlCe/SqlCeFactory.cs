using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersistProAdapters = WabiLogic.PersistPro.PersistProDataSetTableAdapters;
using HistoryAdapaters = WabiLogic.PersistPro.HistoryDataSetTableAdapters;
using ConfigurationAdapters = WabiLogic.PersistPro.ConfigurationDataSetTableAdapters;
using WabiLogic.PersistPro.Model;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Encryption;
using WabiLogic.PersistPro.Model.SqlCe;
using WabiLogic.Foundation.Encryption.Rijndael;
using System.IO;
using WabiLogic.Foundation.ProductKey;

namespace WabiLogic.PersistPro.Controller.SqlCe {
    public class SqlCeFactory : IFactory {
        private PersistProAdapters.TableAdapterManager PersistProDbManager { get; set; }
        private PersistProDataSet PersistProDataSet { get; set; }

        private HistoryAdapaters.TableAdapterManager HistoryDbManager { get; set; }
        private HistoryDataSet HistoryDataSet { get; set; }

        private ConfigurationAdapters.TableAdapterManager ConfigurationDbManager { get; set; }
        private ConfigurationDataSet ConfigurationDataSet { get; set; }

        public SqlCeFactory() {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Persist Pro"));

            this.PersistProDataSet = new PersistProDataSet();
            this.HistoryDataSet = new HistoryDataSet();
            this.ConfigurationDataSet = new ConfigurationDataSet();

            this.PersistProDbManager = new PersistProAdapters.TableAdapterManager();
            this.HistoryDbManager = new HistoryAdapaters.TableAdapterManager();
            this.ConfigurationDbManager = new ConfigurationAdapters.TableAdapterManager();

            this.PersistProDbManager.RootTableAdapter = new PersistProAdapters.RootTableAdapter();
            this.PersistProDbManager.RootNameFilterTableAdapter = new PersistProAdapters.RootNameFilterTableAdapter();
            this.PersistProDbManager.RootAttributeFilterTableAdapter = new PersistProAdapters.RootAttributeFilterTableAdapter();
            this.PersistProDbManager.ScheduleTableAdapter = new PersistProAdapters.ScheduleTableAdapter();
            this.PersistProDbManager.MountTableAdapter = new PersistProAdapters.MountTableAdapter();
            this.PersistProDbManager.FileMountTableAdapter = new PersistProAdapters.FileMountTableAdapter();
            this.PersistProDbManager.ExternalDriveMountTableAdapter = new PersistProAdapters.ExternalDriveMountTableAdapter();
            this.PersistProDbManager.FtpMountTableAdapter = new PersistProAdapters.FtpMountTableAdapter();
            this.PersistProDbManager.PlanTableAdapter = new PersistProAdapters.PlanTableAdapter();
            this.HistoryDbManager.HistoryTableAdapter = new HistoryAdapaters.HistoryTableAdapter();
            this.ConfigurationDbManager.ConfigurationTableAdapter = new ConfigurationAdapters.ConfigurationTableAdapter();

            this.PersistProDbManager.RootTableAdapter.ClearBeforeFill = true;
            this.PersistProDbManager.RootNameFilterTableAdapter.ClearBeforeFill = true;
            this.PersistProDbManager.RootAttributeFilterTableAdapter.ClearBeforeFill = true;
            this.PersistProDbManager.ScheduleTableAdapter.ClearBeforeFill = true;
            this.PersistProDbManager.MountTableAdapter.ClearBeforeFill = true;
            this.PersistProDbManager.FileMountTableAdapter.ClearBeforeFill = true;
            this.PersistProDbManager.ExternalDriveMountTableAdapter.ClearBeforeFill = true;
            this.PersistProDbManager.FtpMountTableAdapter.ClearBeforeFill = true;
            this.PersistProDbManager.PlanTableAdapter.ClearBeforeFill = true;
            this.HistoryDbManager.HistoryTableAdapter.ClearBeforeFill = true;
            this.ConfigurationDbManager.ConfigurationTableAdapter.ClearBeforeFill = true;

            this.PersistProDbManager.RootTableAdapter.Fill(this.PersistProDataSet.Root);
            this.PersistProDbManager.RootNameFilterTableAdapter.Fill(this.PersistProDataSet.RootNameFilter);
            this.PersistProDbManager.RootAttributeFilterTableAdapter.Fill(this.PersistProDataSet.RootAttributeFilter);
            this.PersistProDbManager.ScheduleTableAdapter.Fill(this.PersistProDataSet.Schedule);
            this.PersistProDbManager.MountTableAdapter.Fill(this.PersistProDataSet.Mount);
            this.PersistProDbManager.FileMountTableAdapter.Fill(this.PersistProDataSet.FileMount);
            this.PersistProDbManager.ExternalDriveMountTableAdapter.Fill(this.PersistProDataSet.ExternalDriveMount);
            this.PersistProDbManager.FtpMountTableAdapter.Fill(this.PersistProDataSet.FtpMount);
            this.PersistProDbManager.PlanTableAdapter.Fill(this.PersistProDataSet.Plan);
            this.HistoryDbManager.HistoryTableAdapter.Fill(this.HistoryDataSet.History);
            this.ConfigurationDbManager.ConfigurationTableAdapter.Fill(this.ConfigurationDataSet.Configuration);

        }

        #region IFactory Members

        public IPlanManager LoadPlanManager() {
            return new SqlCePlanManager(this.PersistProDataSet);
        }

        public void SavePlanManager() {
            this.PersistProDbManager.UpdateAll(this.PersistProDataSet);
        }

        public IHistoryManager LoadHistoryManager() {
            return new SqlCeHistoryManager(this.HistoryDataSet);
        }

        public void SaveHistoryManager() {
            this.HistoryDbManager.UpdateAll(this.HistoryDataSet);
        }

        public IConfiguration LoadConfiguration() {
            return new SqlCeConfiguration(this.ConfigurationDataSet);
        }

        public void SaveConfiguration() {
            this.ConfigurationDbManager.UpdateAll(this.ConfigurationDataSet);
        }

        public IEncryption LoadEncryption() {
            string password = LoadConfiguration()["password"];
            if (password == null) throw new Exception("Password needed. Please run setup.");
            return new RijndaelEncryption(password);
        }

        public void SaveEncryptionPassword(string password) {
            LoadConfiguration()["password"] = password;
        }

        public void Register(string name, string key) {
            if (KeyManager.ConfirmKey(name, key)) {
                IConfiguration config = LoadConfiguration();
                config["registername"] = name;
                config["registerkey"] = key;
            }
            else {
                throw new ApplicationException("Invalid product key.");
            }
        }

        public bool IsRegistered {
            get {
                string registername = LoadConfiguration()["registername"];
                string registerkey = LoadConfiguration()["registerkey"];
                if (registername == null && registerkey == null) return false;
                return KeyManager.ConfirmKey(registername, registerkey);
            }
        }

        public bool RunSetup { 
            get {
                string runSetup = LoadConfiguration()["runsetup"];
                if (runSetup == null) return true;
                else if (runSetup == Boolean.TrueString) return true;
                else return false;
            } 
            set {
                LoadConfiguration()["runsetup"] = value ? Boolean.TrueString : Boolean.FalseString;
            } 
        }

        #endregion
    }
}
