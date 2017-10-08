using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WabiLogic.PersistPro.Model;
using WabiLogic.Foundation.Tools;
using System.IO;

namespace WabiLogic.PersistPro.WcfProxy {
    [ServiceContract(Namespace = "http://www.wabilogic.com/persistpro")]
    public interface IPersistProWcfProxy {
        //Save Routines
        [OperationContract]
        void SavePlanManager();
        [OperationContract]
        void SaveHistoryManager();
        [OperationContract]
        void SaveConfiguration();

        //Special Config Options
        [OperationContract]
        void ConfigurationSaveEncryptionPassword(string password);
        [OperationContract]
        void ConfigurationRegister(string name, string key);
        [OperationContract]
        bool ConfigurationIsRegistered();
        [OperationContract]
        bool ConfigurationGetRunSetup();
        [OperationContract]
        void ConfigurationSetRunSetup(bool setup);

        //configuration
        [OperationContract]
        void ConfigurationSetValue(string key, string value);
        [OperationContract]
        string ConfigurationGetValue(string key);
        [OperationContract]
        IEnumerable<string> ConfigurationGetKeys();
        [OperationContract]
        void ConfigurationAddKey(string key, string value);
        [OperationContract]
        void ConfigurationRemoveKey(string key);


        //history manager
        [OperationContract]
        IEnumerable<Guid> HistoryManagerGetHistoryIds();

        [OperationContract]
        Guid HistoryManagerCreateHistory(Guid planId, HistoryStatus status, DateTime scheduleDate, string note);
        [OperationContract]
        void HistoryManagerDeleteHistory(Guid historyId);

        [OperationContract]
        Guid HistoryManagerLoadLatestHistory(Guid planId);
        [OperationContract]
        IEnumerable<Guid> HistoryManagerPlanHistoryIds(Guid planId);

        //history
        [OperationContract]
        HistoryStatus HistoryGetStatus(Guid historyId);
        [OperationContract]
        DateTime HistoryGetScheduleDate(Guid historyId);
        [OperationContract]
        DateTime HistoryGetExecuteDate(Guid historyId);
        [OperationContract]
        DateTime HistoryGetBeginBackupDate(Guid historyId);
        [OperationContract]
        DateTime HistoryGetFinishBackupDate(Guid historyId);
        [OperationContract]
        string HistoryGetErrorNote(Guid historyId);
        [OperationContract]
        string HistoryGetNote(Guid historyId);

        [OperationContract]
        void HistorySetStatus(Guid historyId, HistoryStatus historyStatus);
        [OperationContract]
        void HistorySetScheduleDate(Guid historyId, DateTime scheduleDate);
        [OperationContract]
        void HistorySetExecuteDate(Guid historyId, DateTime executeDate);
        [OperationContract]
        void HistorySetBeginBackupDate(Guid historyId, DateTime beginBackupDate);
        [OperationContract]
        void HistorySetFinishBackupDate(Guid historyId, DateTime finishBackupDate);
        [OperationContract]
        void HistorySetErrorNote(Guid historyId, string errorNote);
        [OperationContract]
        void HistorySetNote(Guid historyId, string note);

        //plan management
        [OperationContract]
        IEnumerable<Guid> PlanManagerGetRootIds();
        [OperationContract]
        IEnumerable<Guid> PlanManagerGetMountIds();
        [OperationContract]
        IEnumerable<Guid> PlanManagerGetScheduleIds();
        [OperationContract]
        IEnumerable<Guid> PlanManagerGetPlanIds();

        [OperationContract]
        Guid PlanManagerImportRoot(Guid id, string name, string path, bool sub, bool keepHistory, string note);
        [OperationContract]
        Guid PlanManagerImportRootAttributeFilter(Guid id, Guid rootId, System.IO.FileAttributes filter, FilterType filterType, string note);
        [OperationContract]
        Guid PlanManagerImportRootNameFilter(Guid id, Guid rootId, string filter, FilterType filterType, string note);
        [OperationContract]
        Guid PlanManagerImportPlan(Guid id, Guid rootId, Guid mountId, Guid scheduleId);
        [OperationContract]
        Guid PlanManagerImportFileMount(Guid id, string name, string note, string folder);
        [OperationContract]
        Guid PlanManagerImportExternalDriveMount(Guid id, string name, string note, string folder, string label);
        [OperationContract]
        Guid PlanManagerImportFtpMount(Guid id, string name, string note, string server, int port, string username, string password, string folder);
        [OperationContract]
        Guid PlanManagerImportSchedule(Guid id, string name, TimeSpan time, ScheduleType scheduleType, DayOfWeek dayOfWeek, WeekOfMonth weekOfMonth);


        [OperationContract]
        Guid PlanManagerCreateRoot(string name, string path, bool sub, bool keepHistory, string note);
        [OperationContract]
        Guid PlanManagerCreateRootAttributeFilter(Guid rootId, System.IO.FileAttributes filter, FilterType filterType, string note);
        [OperationContract]
        Guid PlanManagerCreateRootNameFilter(Guid rootId, string filter, FilterType filterType, string note);
        [OperationContract]
        Guid PlanManagerCreatePlan(Guid rootId, Guid mountId, Guid scheduleId);
        [OperationContract]
        Guid PlanManagerCreateFileMount(string name, string note, string folder);
        [OperationContract]
        Guid PlanManagerCreateExternalDriveMount(string name, string note, string folder, string label);
        [OperationContract]
        Guid PlanManagerCreateFtpMount(string name, string note, string server, int port, string username, string password, string folder);
        [OperationContract]
        Guid PlanManagerCreateSchedule(string name, TimeSpan time, ScheduleType scheduleType, DayOfWeek dayOfWeek, WeekOfMonth weekOfMonth);

        [OperationContract]
        void PlanManagerDeleteRoot(Guid rootId);
        [OperationContract]
        void PlanManagerDeleteRootAttributeFilter(Guid rootAttributeFilterId);
        [OperationContract]
        void PlanManagerDeleteRootNameFilter(Guid rootNameFilterId);
        [OperationContract]
        void PlanManagerDeletePlan(Guid planId);
        [OperationContract]
        void PlanManagerDeleteMount(Guid mountId);
        [OperationContract]
        void PlanManagerDeleteSchedule(Guid scheduleId);

        //plan
        [OperationContract]
        Guid PlanGetRootId(Guid planId);
        [OperationContract]
        Guid PlanGetMountId(Guid planId);
        [OperationContract]
        Guid PlanGetScheduleId(Guid planId);

        [OperationContract]
        void PlanSetRootId(Guid planId, Guid rootId);
        [OperationContract]
        void PlanSetMountId(Guid planId, Guid mountId);
        [OperationContract]
        void PlanSetScheduleId(Guid planId, Guid scheduleId);

        //root
        [OperationContract]
        string RootGetName(Guid rootId);
        [OperationContract]
        string RootGetFolder(Guid rootId);
        [OperationContract]
        bool RootGetSub(Guid rootId);
        [OperationContract]
        bool RootGetKeepHistory(Guid rootId);
        [OperationContract]
        string RootGetNote(Guid rootId);
        [OperationContract]
        IEnumerable<Guid> RootGetNameFilterIds(Guid rootId);
        [OperationContract]
        IEnumerable<Guid> RootGetAttributeFilterIds(Guid rootId);

        [OperationContract]
        void RootSetName(Guid rootId, string name);
        [OperationContract]
        void RootSetFolder(Guid rootId, string folder);
        [OperationContract]
        void RootSetSub(Guid rootId, bool sub);
        [OperationContract]
        void RootSetKeepHistory(Guid rootId, bool keepHistory);
        [OperationContract]
        void RootSetNote(Guid rootId, string note);

        //RootNameFilter
        [OperationContract]
        string RootNameFilterGetFilter(Guid rootNameFilterId);
        [OperationContract]
        FilterType RootNameFilterGetFilterType(Guid rootNameFilterId);
        [OperationContract]
        string RootNameFilterGetNote(Guid rootNameFilterId);

        [OperationContract]
        void RootNameFilterSetFilter(Guid rootNameFilterId, string filter);
        [OperationContract]
        void RootNameFilterSetFilterType(Guid rootNameFilterId, FilterType filterType);
        [OperationContract]
        void RootNameFilterSetNote(Guid rootNameFilterId, string note);

        //RootAttributeFilter
        [OperationContract]
        FileAttributes RootAttributeFilterGetFilter(Guid rootAttributeFilterId);
        [OperationContract]
        FilterType RootAttributeFilterGetFilterType(Guid rootAttributeFilterId);
        [OperationContract]
        string RootAttributeFilterGetNote(Guid rootAttributeFilterId);

        [OperationContract]
        void RootAttributeFilterSetFilter(Guid rootAttributeFilterId, FileAttributes filter);
        [OperationContract]
        void RootAttributeFilterSetFilterType(Guid rootAttributeFilterId, FilterType filterType);
        [OperationContract]
        void RootAttributeFilterSetNote(Guid rootAttributeFilterId, string note);

        //Mount
        [OperationContract]
        string MountGetName(Guid mountId);
        [OperationContract]
        string MountGetNote(Guid mountId);
        [OperationContract]
        string MountGetTypeDisplayName(Guid mountId);
        [OperationContract]
        string MountGetInterfaceType(Guid mountId); //Return interface name?

        [OperationContract]
        void MountSetName(Guid mountId, string name);
        [OperationContract]
        void MountSetNote(Guid mountId, string note);

        //File Mount
        [OperationContract]
        string FileMountGetFolder(Guid mountId);

        [OperationContract]
        void FileMountSetFolder(Guid mountId, string folder);

        //External Drive Mount
        [OperationContract]
        string ExternalDriveMountGetFolder(Guid mountId);
        [OperationContract]
        string ExternalDriveMountGetLabel(Guid mountId);

        [OperationContract]
        void ExternalDriveMountSetFolder(Guid mountId, string folder);
        [OperationContract]
        void ExternalDriveMountSetLabel(Guid mountId, string label);

        //Ftp Mount
        [OperationContract]
        string FtpMountGetServer(Guid mountId);
        [OperationContract]
        int FtpMountGetPort(Guid mountId);
        [OperationContract]
        string FtpMountGetUsername(Guid mountId);
        [OperationContract]
        string FtpMountGetPassword(Guid mountId);
        [OperationContract]
        string FtpMountGetFolder(Guid mountId);

        [OperationContract]
        void FtpMountSetServer(Guid mountId, string server);
        [OperationContract]
        void FtpMountSetPort(Guid mountId, int port);
        [OperationContract]
        void FtpMountSetUsername(Guid mountId, string username);
        [OperationContract]
        void FtpMountSetPassword(Guid mountId, string password);
        [OperationContract]
        void FtpMountSetFolder(Guid mountId, string folder);

        //Schedule
        [OperationContract]
        string ScheduleGetName(Guid scheduleId);
        [OperationContract]
        TimeSpan ScheduleGetTime(Guid scheduleId);
        [OperationContract]
        ScheduleType ScheduleGetScheduleType(Guid scheduleId);
        [OperationContract]
        DayOfWeek ScheduleGetDayOfWeek(Guid scheduleId);
        [OperationContract]
        WeekOfMonth ScheduleGetWeekOfMonth(Guid scheduleId);

        [OperationContract]
        void ScheduleSetName(Guid scheduleId, string name);
        [OperationContract]
        void ScheduleSetTime(Guid scheduleId, TimeSpan time);
        [OperationContract]
        void ScheduleSetScheduleType(Guid scheduleId, ScheduleType scheduleType);
        [OperationContract]
        void ScheduleSetDayOfWeek(Guid scheduleId, DayOfWeek dayOfWeek);
        [OperationContract]
        void ScheduleSetWeekOfMonth(Guid scheduleId, WeekOfMonth weekOfMonth);
    }
}
