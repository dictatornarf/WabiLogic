using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Encryption;
using WabiLogic.Foundation.Tools;

namespace WabiLogic.PersistPro.Model {
    public interface IPlanManager {
        IEnumerable<IRoot> Roots { get; }
        IEnumerable<IMount> Mounts { get; }
        IEnumerable<ISchedule> Schedules { get; }

        IEnumerable<IPlan> Plans { get; }

        IRoot ImportRoot(Guid id, string name, string path, bool sub, bool keepHistory, string note);
        IRootAttributeFilter ImportRootAttributeFilter(Guid id, IRoot root, System.IO.FileAttributes filter, FilterType filterType, string note);
        IRootNameFilter ImportRootNameFilter(Guid id, IRoot root, string filter, FilterType filterType, string note);
        IPlan ImportPlan(Guid id, IRoot root, IMount mount, ISchedule schedule);
        IFileMount ImportFileMount(Guid id, string name, string note, string folder);
        IExternalDriveMount ImportExternalDriveMount(Guid id, string name, string note, string folder, string label);
        IFtpMount ImportFtpMount(Guid id, string name, string note, string server, int port, string username, string password, string folder);
        ISchedule ImportSchedule(Guid id, string name, TimeSpan time, ScheduleType scheduleType, DayOfWeek dayOfWeek, WeekOfMonth weekOfMonth);

        IRoot CreateRoot(string name, string path, bool sub, bool keepHistory, string note);
        IRootAttributeFilter CreateRootAttributeFilter(IRoot root, System.IO.FileAttributes filter, FilterType filterType, string note);
        IRootNameFilter CreateRootNameFilter(IRoot root, string filter, FilterType filterType, string note);
        IPlan CreatePlan(IRoot root, IMount mount, ISchedule schedule);
        IFileMount CreateFileMount(string name, string note, string folder);
        IExternalDriveMount CreateExternalDriveMount(string name, string note, string folder, string label);
        IFtpMount CreateFtpMount(string name, string note, string server, int port, string username, string password, string folder);
        ISchedule CreateSchedule(string name, TimeSpan time, ScheduleType scheduleType, DayOfWeek dayOfWeek, WeekOfMonth weekOfMonth);

        void DeleteRoot(IRoot root);
        void DeleteRootAttributeFilter(IRootAttributeFilter rootAttributeFilter);
        void DeleteRootNameFilter(IRootNameFilter rootNameFilter);
        void DeletePlan(IPlan plan);
        void DeleteMount(IMount mount);
        void DeleteSchedule(ISchedule schedule);

        IPlan LoadPlan(Guid planId);
        IRoot LoadRoot(Guid rootId);
        IRootNameFilter LoadRootNameFilter(Guid rootNameFilter);
        IRootAttributeFilter LoadRootAttributeFilter(Guid rootAttributeFilter);
        IMount LoadMount(Guid mountId);
        ISchedule LoadSchedule(Guid scheduleId);
    }
}
