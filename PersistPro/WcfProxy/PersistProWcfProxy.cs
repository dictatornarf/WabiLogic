using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.Controller;
using WabiLogic.PersistPro.Model;
using System.ServiceModel;

namespace WabiLogic.PersistPro.WcfProxy {
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public class PersistProWcfProxy : IPersistProWcfProxy {
        protected IFactory Factory { get; set; }
        protected IPlanManager PlanManager { get; set; }
        protected IHistoryManager HistoryManager { get; set; }
        protected IConfiguration Configuration { get; set; }

        public PersistProWcfProxy(IFactory factory) {
            this.Factory = factory;
            this.PlanManager = this.Factory.LoadPlanManager();
            this.HistoryManager = this.Factory.LoadHistoryManager();
            this.Configuration = this.Factory.LoadConfiguration();
        }

        #region IPersistProWcfProxy Members

        public void SavePlanManager() {
            this.Factory.SavePlanManager();
        }

        public void SaveHistoryManager() {
            this.Factory.SaveHistoryManager();
        }

        public void SaveConfiguration() {
            this.Factory.SaveConfiguration();
        }

        public void ConfigurationSaveEncryptionPassword(string password) {
            this.Factory.SaveEncryptionPassword(password);
        }

        public void ConfigurationRegister(string name, string key) {
            this.Factory.Register(name, key);
        }

        public bool ConfigurationIsRegistered() {
            return this.Factory.IsRegistered;
        }

        public bool ConfigurationGetRunSetup() {
            return this.Factory.RunSetup;
        }

        public void ConfigurationSetRunSetup(bool setup) {
            this.Factory.RunSetup = setup;
        }

        public void ConfigurationSetValue(string key, string value) {
            this.Configuration[key] = value;
        }

        public string ConfigurationGetValue(string key) {
            return this.Configuration[key];
        }

        public IEnumerable<string> ConfigurationGetKeys() {
            return this.Configuration.Keys;
        }

        public void ConfigurationAddKey(string key, string value) {
            this.Configuration.Add(key, value);
        }

        public void ConfigurationRemoveKey(string key) {
            this.Configuration.Remove(key);
        }

        public IEnumerable<Guid> HistoryManagerGetHistoryIds() {
            foreach (IHistory history in this.HistoryManager.Histories) {
                yield return history.Id;
            }
        }

        public Guid HistoryManagerCreateHistory(Guid planId, WabiLogic.PersistPro.Model.HistoryStatus status, DateTime scheduleDate, string note) {
            return (this.HistoryManager.CreateHistory(this.PlanManager.LoadPlan(planId), status, scheduleDate, note)).Id;
        }

        public void HistoryManagerDeleteHistory(Guid historyId) {
            this.HistoryManager.DeleteHistory(this.HistoryManager.LoadHistory(historyId));
        }

        public Guid HistoryManagerLoadLatestHistory(Guid planId) {
            return this.HistoryManager.LoadLatestHistory(this.PlanManager.LoadPlan(planId)).Id;
        }

        public IEnumerable<Guid> HistoryManagerPlanHistoryIds(Guid planId) {
            foreach (IHistory history in this.HistoryManager.PlanHistories(this.PlanManager.LoadPlan(planId))) {
                yield return history.Id;
            }
        }

        public WabiLogic.PersistPro.Model.HistoryStatus HistoryGetStatus(Guid historyId) {
            return this.HistoryManager.LoadHistory(historyId).Status;
        }

        public DateTime HistoryGetScheduleDate(Guid historyId) {
            return this.HistoryManager.LoadHistory(historyId).ScheduleDate;
        }

        public DateTime HistoryGetExecuteDate(Guid historyId) {
            return this.HistoryManager.LoadHistory(historyId).ExecuteDate;
        }

        public DateTime HistoryGetBeginBackupDate(Guid historyId) {
            return this.HistoryManager.LoadHistory(historyId).BeginBackupDate;
        }

        public DateTime HistoryGetFinishBackupDate(Guid historyId) {
            return this.HistoryManager.LoadHistory(historyId).FinishBackupDate;
        }

        public string HistoryGetErrorNote(Guid historyId) {
            return this.HistoryManager.LoadHistory(historyId).ErrorNote;
        }

        public string HistoryGetNote(Guid historyId) {
            return this.HistoryManager.LoadHistory(historyId).Note;
        }

        public void HistorySetStatus(Guid historyId, WabiLogic.PersistPro.Model.HistoryStatus historyStatus) {
            this.HistoryManager.LoadHistory(historyId).Status = historyStatus;
        }

        public void HistorySetScheduleDate(Guid historyId, DateTime scheduleDate) {
            this.HistoryManager.LoadHistory(historyId).ScheduleDate = scheduleDate;
        }

        public void HistorySetExecuteDate(Guid historyId, DateTime executeDate) {
            this.HistoryManager.LoadHistory(historyId).ExecuteDate = executeDate;
        }

        public void HistorySetBeginBackupDate(Guid historyId, DateTime beginBackupDate) {
            this.HistoryManager.LoadHistory(historyId).BeginBackupDate = beginBackupDate;
        }

        public void HistorySetFinishBackupDate(Guid historyId, DateTime finishBackupDate) {
            this.HistoryManager.LoadHistory(historyId).FinishBackupDate = finishBackupDate;
        }

        public void HistorySetErrorNote(Guid historyId, string errorNote) {
            this.HistoryManager.LoadHistory(historyId).ErrorNote = errorNote;
        }

        public void HistorySetNote(Guid historyId, string note) {
            this.HistoryManager.LoadHistory(historyId).Note = note;
        }

        public IEnumerable<Guid> PlanManagerGetRootIds() {
            foreach (IRoot root in this.PlanManager.Roots) {
                yield return root.Id;
            }
        }

        public IEnumerable<Guid> PlanManagerGetMountIds() {
            foreach (IMount mount in this.PlanManager.Mounts) {
                yield return mount.Id;
            }
        }

        public IEnumerable<Guid> PlanManagerGetScheduleIds() {
            foreach (ISchedule schedule in this.PlanManager.Schedules) {
                yield return schedule.Id;
            }
        }

        public IEnumerable<Guid> PlanManagerGetPlanIds() {
            foreach (IPlan plan in this.PlanManager.Plans) {
                yield return plan.Id;
            }
        }

        public Guid PlanManagerImportRoot(Guid id, string name, string path, bool sub, bool keepHistory, string note) {
            return this.PlanManager.ImportRoot(id, name, path, sub, keepHistory, note).Id;
        }

        public Guid PlanManagerImportRootAttributeFilter(Guid id, Guid rootId, System.IO.FileAttributes filter, WabiLogic.PersistPro.Model.FilterType filterType, string note) {
            return this.PlanManager.ImportRootAttributeFilter(id, this.PlanManager.LoadRoot(rootId), filter, filterType, note).Id;
        }

        public Guid PlanManagerImportRootNameFilter(Guid id, Guid rootId, string filter, WabiLogic.PersistPro.Model.FilterType filterType, string note) {
            return this.PlanManager.ImportRootNameFilter(id, this.PlanManager.LoadRoot(rootId), filter, filterType, note).Id;
        }

        public Guid PlanManagerImportPlan(Guid id, Guid rootId, Guid mountId, Guid scheduleId) {
            return this.PlanManager.ImportPlan(id, this.PlanManager.LoadRoot(rootId), this.PlanManager.LoadMount(mountId), this.PlanManager.LoadSchedule(scheduleId)).Id;
        }

        public Guid PlanManagerImportFileMount(Guid id, string name, string note, string folder) {
            return this.PlanManager.ImportFileMount(id, name, note, folder).Id;
        }

        public Guid PlanManagerImportExternalDriveMount(Guid id, string name, string note, string folder, string label) {
            return this.PlanManager.ImportExternalDriveMount(id, name, note, folder, label).Id;
        }

        public Guid PlanManagerImportFtpMount(Guid id, string name, string note, string server, int port, string username, string password, string folder) {
            return this.PlanManager.ImportFtpMount(id, name, note, server, port, username, password, folder).Id;
        }

        public Guid PlanManagerImportSchedule(Guid id, string name, TimeSpan time, WabiLogic.PersistPro.Model.ScheduleType scheduleType, DayOfWeek dayOfWeek, WabiLogic.Foundation.Tools.WeekOfMonth weekOfMonth) {
            return this.PlanManager.ImportSchedule(id, name, time, scheduleType, dayOfWeek, weekOfMonth).Id;
        }

        public Guid PlanManagerCreateRoot(string name, string path, bool sub, bool keepHistory, string note) {
            return this.PlanManager.CreateRoot(name, path, sub, keepHistory, note).Id;
        }

        public Guid PlanManagerCreateRootAttributeFilter(Guid rootId, System.IO.FileAttributes filter, WabiLogic.PersistPro.Model.FilterType filterType, string note) {
            return this.PlanManager.CreateRootAttributeFilter(this.PlanManager.LoadRoot(rootId), filter, filterType, note).Id;
        }

        public Guid PlanManagerCreateRootNameFilter(Guid rootId, string filter, WabiLogic.PersistPro.Model.FilterType filterType, string note) {
            return this.PlanManager.CreateRootNameFilter(this.PlanManager.LoadRoot(rootId), filter, filterType, note).Id;
        }

        public Guid PlanManagerCreatePlan(Guid rootId, Guid mountId, Guid scheduleId) {
            return this.PlanManager.CreatePlan(this.PlanManager.LoadRoot(rootId), this.PlanManager.LoadMount(mountId), this.PlanManager.LoadSchedule(scheduleId)).Id;
        }

        public Guid PlanManagerCreateFileMount(string name, string note, string folder) {
            return this.PlanManager.CreateFileMount(name, note, folder).Id;
        }

        public Guid PlanManagerCreateExternalDriveMount(string name, string note, string folder, string label) {
            return this.PlanManager.CreateExternalDriveMount(name, note, folder, label).Id;
        }

        public Guid PlanManagerCreateFtpMount(string name, string note, string server, int port, string username, string password, string folder) {
            return this.PlanManager.CreateFtpMount(name, note, server, port, username, password, folder).Id;
        }

        public Guid PlanManagerCreateSchedule(string name, TimeSpan time, WabiLogic.PersistPro.Model.ScheduleType scheduleType, DayOfWeek dayOfWeek, WabiLogic.Foundation.Tools.WeekOfMonth weekOfMonth) {
            return this.PlanManager.CreateSchedule(name, time, scheduleType, dayOfWeek, weekOfMonth).Id;
        }

        public void PlanManagerDeleteRoot(Guid rootId) {
            this.PlanManager.DeleteRoot(this.PlanManager.LoadRoot(rootId));
        }

        public void PlanManagerDeleteRootAttributeFilter(Guid rootAttributeFilterId) {
            this.PlanManager.DeleteRootAttributeFilter(this.PlanManager.LoadRootAttributeFilter(rootAttributeFilterId));
        }

        public void PlanManagerDeleteRootNameFilter(Guid rootNameFilterId) {
            this.PlanManager.DeleteRootNameFilter(this.PlanManager.LoadRootNameFilter(rootNameFilterId));
        }

        public void PlanManagerDeletePlan(Guid planId) {
            this.PlanManager.DeletePlan(this.PlanManager.LoadPlan(planId));
        }

        public void PlanManagerDeleteMount(Guid mountId) {
            this.PlanManager.DeleteMount(this.PlanManager.LoadMount(mountId));
        }

        public void PlanManagerDeleteSchedule(Guid scheduleId) {
            this.PlanManager.DeleteSchedule(this.PlanManager.LoadSchedule(scheduleId));
        }

        public Guid PlanGetRootId(Guid planId) {
            return this.PlanManager.LoadPlan(planId).Root.Id;
        }

        public Guid PlanGetMountId(Guid planId) {
            return this.PlanManager.LoadPlan(planId).Mount.Id;
        }

        public Guid PlanGetScheduleId(Guid planId) {
            return this.PlanManager.LoadPlan(planId).Schedule.Id;
        }

        public void PlanSetRootId(Guid planId, Guid rootId) {
            this.PlanManager.LoadPlan(planId).Root = this.PlanManager.LoadRoot(rootId);
        }

        public void PlanSetMountId(Guid planId, Guid mountId) {
            this.PlanManager.LoadPlan(planId).Mount = this.PlanManager.LoadMount(mountId);
        }

        public void PlanSetScheduleId(Guid planId, Guid scheduleId) {
            this.PlanManager.LoadPlan(planId).Schedule = this.PlanManager.LoadSchedule(scheduleId);
        }

        public string RootGetName(Guid rootId) {
            return this.PlanManager.LoadRoot(rootId).Name;
        }

        public string RootGetFolder(Guid rootId) {
            return this.PlanManager.LoadRoot(rootId).Folder;
        }

        public bool RootGetSub(Guid rootId) {
            return this.PlanManager.LoadRoot(rootId).Sub;
        }

        public bool RootGetKeepHistory(Guid rootId) {
            return this.PlanManager.LoadRoot(rootId).KeepHistory;
        }

        public string RootGetNote(Guid rootId) {
            return this.PlanManager.LoadRoot(rootId).Note;
        }

        public IEnumerable<Guid> RootGetNameFilterIds(Guid rootId) {
            foreach (IRootNameFilter rootNameFilter in this.PlanManager.LoadRoot(rootId).NameFilters) {
                yield return rootNameFilter.Id;
            }
        }

        public IEnumerable<Guid> RootGetAttributeFilterIds(Guid rootId) {
            foreach (IRootAttributeFilter rootAttributeFilter in this.PlanManager.LoadRoot(rootId).AttributeFilters) {
                yield return rootAttributeFilter.Id;
            }
        }

        public void RootSetName(Guid rootId, string name) {
            this.PlanManager.LoadRoot(rootId).Name = name;
        }

        public void RootSetFolder(Guid rootId, string folder) {
            this.PlanManager.LoadRoot(rootId).Folder = folder;
        }

        public void RootSetSub(Guid rootId, bool sub) {
            this.PlanManager.LoadRoot(rootId).Sub = sub;
        }

        public void RootSetKeepHistory(Guid rootId, bool keepHistory) {
            this.PlanManager.LoadRoot(rootId).KeepHistory = keepHistory;
        }

        public void RootSetNote(Guid rootId, string note) {
            this.PlanManager.LoadRoot(rootId).Note = note;
        }

        public string RootNameFilterGetFilter(Guid rootNameFilterId) {
            return this.PlanManager.LoadRootNameFilter(rootNameFilterId).Filter;
        }

        public WabiLogic.PersistPro.Model.FilterType RootNameFilterGetFilterType(Guid rootNameFilterId) {
            return this.PlanManager.LoadRootNameFilter(rootNameFilterId).FilterType;
        }

        public string RootNameFilterGetNote(Guid rootNameFilterId) {
            return this.PlanManager.LoadRootNameFilter(rootNameFilterId).Note;
        }

        public void RootNameFilterSetFilter(Guid rootNameFilterId, string filter) {
            this.PlanManager.LoadRootNameFilter(rootNameFilterId).Filter = filter;
        }

        public void RootNameFilterSetFilterType(Guid rootNameFilterId, WabiLogic.PersistPro.Model.FilterType filterType) {
            this.PlanManager.LoadRootNameFilter(rootNameFilterId).FilterType = filterType;
        }

        public void RootNameFilterSetNote(Guid rootNameFilterId, string note) {
            this.PlanManager.LoadRootNameFilter(rootNameFilterId).Note = note;
        }

        public System.IO.FileAttributes RootAttributeFilterGetFilter(Guid rootAttributeFilterId) {
            return this.PlanManager.LoadRootAttributeFilter(rootAttributeFilterId).Filter;
        }

        public WabiLogic.PersistPro.Model.FilterType RootAttributeFilterGetFilterType(Guid rootAttributeFilterId) {
            return this.PlanManager.LoadRootAttributeFilter(rootAttributeFilterId).FilterType;
        }

        public string RootAttributeFilterGetNote(Guid rootAttributeFilterId) {
            return this.PlanManager.LoadRootAttributeFilter(rootAttributeFilterId).Note;
        }

        public void RootAttributeFilterSetFilter(Guid rootAttributeFilterId, System.IO.FileAttributes filter) {
            this.PlanManager.LoadRootAttributeFilter(rootAttributeFilterId).Filter = filter;
        }

        public void RootAttributeFilterSetFilterType(Guid rootAttributeFilterId, WabiLogic.PersistPro.Model.FilterType filterType) {
            this.PlanManager.LoadRootAttributeFilter(rootAttributeFilterId).FilterType = filterType;
        }

        public void RootAttributeFilterSetNote(Guid rootAttributeFilterId, string note) {
            this.PlanManager.LoadRootAttributeFilter(rootAttributeFilterId).Note = note;
        }

        public string MountGetName(Guid mountId) {
            return this.PlanManager.LoadMount(mountId).Name;
        }

        public string MountGetNote(Guid mountId) {
            return this.PlanManager.LoadMount(mountId).Note;
        }

        public string MountGetTypeDisplayName(Guid mountId) {
            return this.PlanManager.LoadMount(mountId).TypeDisplayName;
        }

        public string MountGetInterfaceType(Guid mountId) {
            return this.PlanManager.LoadMount(mountId).GetType().FullName;
        }

        public void MountSetName(Guid mountId, string name) {
            this.PlanManager.LoadMount(mountId).Name = name;
        }

        public void MountSetNote(Guid mountId, string note) {
            this.PlanManager.LoadMount(mountId).Note = note;
        }

        public string FileMountGetFolder(Guid mountId) {
            IFileMount fileMount = this.PlanManager.LoadMount(mountId) as IFileMount;
            return (fileMount != null) ? fileMount.Folder : null;
        }

        public void FileMountSetFolder(Guid mountId, string folder) {
            IFileMount fileMount = this.PlanManager.LoadMount(mountId) as IFileMount;
            if (fileMount != null) fileMount.Folder = folder;
        }

        public string ExternalDriveMountGetFolder(Guid mountId) {
            IExternalDriveMount externalDriveMount = this.PlanManager.LoadMount(mountId) as IExternalDriveMount;
            return (externalDriveMount != null) ? externalDriveMount.Folder : null;
        }

        public string ExternalDriveMountGetLabel(Guid mountId) {
            IExternalDriveMount externalDriveMount = this.PlanManager.LoadMount(mountId) as IExternalDriveMount;
            return (externalDriveMount != null) ? externalDriveMount.Label : null;
        }

        public void ExternalDriveMountSetFolder(Guid mountId, string folder) {
            IExternalDriveMount externalDriveMount = this.PlanManager.LoadMount(mountId) as IExternalDriveMount;
            if (externalDriveMount != null) externalDriveMount.Folder = folder;
        }

        public void ExternalDriveMountSetLabel(Guid mountId, string label) {
            IExternalDriveMount externalDriveMount = this.PlanManager.LoadMount(mountId) as IExternalDriveMount;
            if (externalDriveMount != null) externalDriveMount.Label = label;
        }

        public string FtpMountGetServer(Guid mountId) {
            IFtpMount ftpMount = this.PlanManager.LoadMount(mountId) as IFtpMount;
            return (ftpMount != null) ? ftpMount.Server : null;
        }

        public int FtpMountGetPort(Guid mountId) {
            IFtpMount ftpMount = this.PlanManager.LoadMount(mountId) as IFtpMount;
            return (ftpMount != null) ? ftpMount.Port : -1;
        }

        public string FtpMountGetUsername(Guid mountId) {
            IFtpMount ftpMount = this.PlanManager.LoadMount(mountId) as IFtpMount;
            return (ftpMount != null) ? ftpMount.Username : null;
        }

        public string FtpMountGetPassword(Guid mountId) {
            IFtpMount ftpMount = this.PlanManager.LoadMount(mountId) as IFtpMount;
            return (ftpMount != null) ? ftpMount.Password : null;
        }

        public string FtpMountGetFolder(Guid mountId) {
            IFtpMount ftpMount = this.PlanManager.LoadMount(mountId) as IFtpMount;
            return (ftpMount != null) ? ftpMount.Folder : null;
        }

        public void FtpMountSetServer(Guid mountId, string server) {
            IFtpMount ftpMount = this.PlanManager.LoadMount(mountId) as IFtpMount;
            if (ftpMount != null) ftpMount.Server = server;
        }

        public void FtpMountSetPort(Guid mountId, int port) {
            IFtpMount ftpMount = this.PlanManager.LoadMount(mountId) as IFtpMount;
            if (ftpMount != null) ftpMount.Port = port;
        }

        public void FtpMountSetUsername(Guid mountId, string username) {
            IFtpMount ftpMount = this.PlanManager.LoadMount(mountId) as IFtpMount;
            if (ftpMount != null) ftpMount.Username = username;
        }

        public void FtpMountSetPassword(Guid mountId, string password) {
            IFtpMount ftpMount = this.PlanManager.LoadMount(mountId) as IFtpMount;
            if (ftpMount != null) ftpMount.Password = password;
        }

        public void FtpMountSetFolder(Guid mountId, string folder) {
            IFtpMount ftpMount = this.PlanManager.LoadMount(mountId) as IFtpMount;
            if (ftpMount != null) ftpMount.Folder = folder;
        }

        public string ScheduleGetName(Guid scheduleId) {
            return this.PlanManager.LoadSchedule(scheduleId).Name;
        }

        public TimeSpan ScheduleGetTime(Guid scheduleId) {
            return this.PlanManager.LoadSchedule(scheduleId).Time;
        }

        public WabiLogic.PersistPro.Model.ScheduleType ScheduleGetScheduleType(Guid scheduleId) {
            return this.PlanManager.LoadSchedule(scheduleId).ScheduleType;
        }

        public DayOfWeek ScheduleGetDayOfWeek(Guid scheduleId) {
            return this.PlanManager.LoadSchedule(scheduleId).DayOfWeek;
        }

        public WabiLogic.Foundation.Tools.WeekOfMonth ScheduleGetWeekOfMonth(Guid scheduleId) {
            return this.PlanManager.LoadSchedule(scheduleId).WeekOfMonth;
        }

        public void ScheduleSetName(Guid scheduleId, string name) {
            this.PlanManager.LoadSchedule(scheduleId).Name = name;
        }

        public void ScheduleSetTime(Guid scheduleId, TimeSpan time) {
            this.PlanManager.LoadSchedule(scheduleId).Time = time;
        }

        public void ScheduleSetScheduleType(Guid scheduleId, WabiLogic.PersistPro.Model.ScheduleType scheduleType) {
            this.PlanManager.LoadSchedule(scheduleId).ScheduleType = scheduleType;
        }

        public void ScheduleSetDayOfWeek(Guid scheduleId, DayOfWeek dayOfWeek) {
            this.PlanManager.LoadSchedule(scheduleId).DayOfWeek = dayOfWeek;
        }

        public void ScheduleSetWeekOfMonth(Guid scheduleId, WabiLogic.Foundation.Tools.WeekOfMonth weekOfMonth) {
            this.PlanManager.LoadSchedule(scheduleId).WeekOfMonth = weekOfMonth;
        }

        #endregion
    }
}
