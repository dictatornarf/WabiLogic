using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;

namespace WabiLogic.PersistPro.Model.Wcf {
    public class WcfPlanManager : IPlanManager {
        private ProxyConnectionManager Proxy { get; set; }

        public WcfPlanManager(ProxyConnectionManager proxy) {
            this.Proxy = proxy;
        }

        #region IPlanManager Members

        public IEnumerable<IRoot> Roots {
            get {
                foreach (Guid rootId in this.Proxy.Perform<IEnumerable<Guid>>(x => x.PlanManagerGetRootIds())) {
                    yield return this.LoadRoot(rootId);
                }    
            }
        }

        public IEnumerable<IMount> Mounts {
            get {
                foreach (Guid mountId in this.Proxy.Perform<IEnumerable<Guid>>(x => x.PlanManagerGetMountIds())) {
                    yield return this.LoadMount(mountId);
                }
            }
        }

        public IEnumerable<ISchedule> Schedules {
            get {
                foreach (Guid scheduleId in this.Proxy.Perform<IEnumerable<Guid>>(x => x.PlanManagerGetScheduleIds())) {
                    yield return this.LoadSchedule(scheduleId);
                }
            }
        }

        public IEnumerable<IPlan> Plans {
            get {
                foreach (Guid planId in this.Proxy.Perform<IEnumerable<Guid>>(x => x.PlanManagerGetPlanIds())) {
                    yield return this.LoadPlan(planId);
                }
            }
        }

        public IRoot ImportRoot(Guid id, string name, string path, bool sub, bool keepHistory, string note) {
            return new WcfRoot(this.Proxy.Perform<Guid>(x => x.PlanManagerImportRoot(id, name, path, sub, keepHistory, note)), this.Proxy);
        }

        public IRootAttributeFilter ImportRootAttributeFilter(Guid id, IRoot root, System.IO.FileAttributes filter, FilterType filterType, string note) {
            return new WcfRootAttributeFilter(this.Proxy.Perform<Guid>(x => x.PlanManagerImportRootAttributeFilter(id, root.Id, filter, filterType, note)), this.Proxy);
        }

        public IRootNameFilter ImportRootNameFilter(Guid id, IRoot root, string filter, FilterType filterType, string note) {
            return new WcfRootNameFilter(this.Proxy.Perform<Guid>(x => x.PlanManagerImportRootNameFilter(id, root.Id, filter, filterType, note)), this.Proxy);
        }

        public IPlan ImportPlan(Guid id, IRoot root, IMount mount, ISchedule schedule) {
            return new WcfPlan(this.Proxy.Perform<Guid>(x => x.PlanManagerImportPlan(id, root.Id, mount.Id, schedule.Id)), this.Proxy);
        }

        public IFileMount ImportFileMount(Guid id, string name, string note, string folder) {
            return new WcfFileMount(this.Proxy.Perform<Guid>(x => x.PlanManagerImportFileMount(id, name, note, folder)), this.Proxy);
        }

        public IExternalDriveMount ImportExternalDriveMount(Guid id, string name, string note, string folder, string label) {
            return new WcfExternalDriveMount(this.Proxy.Perform<Guid>(x => x.PlanManagerImportExternalDriveMount(id, name, note, folder, label)), this.Proxy);
        }

        public IFtpMount ImportFtpMount(Guid id, string name, string note, string server, int port, string username, string password, string folder) {
            return new WcfFtpMount(this.Proxy.Perform<Guid>(x => x.PlanManagerImportFtpMount(id, name, note, server, port, username, password, folder)), this.Proxy);
        }

        public ISchedule ImportSchedule(Guid id, string name, TimeSpan time, ScheduleType scheduleType, DayOfWeek dayOfWeek, WabiLogic.Foundation.Tools.WeekOfMonth weekOfMonth) {
            return new WcfSchedule(this.Proxy.Perform<Guid>(x => x.PlanManagerImportSchedule(id, name, time, scheduleType, dayOfWeek, weekOfMonth)), this.Proxy);
        }

        public IRoot CreateRoot(string name, string path, bool sub, bool keepHistory, string note) {
            return new WcfRoot(this.Proxy.Perform<Guid>(x => x.PlanManagerCreateRoot(name, path, sub, keepHistory, note)), this.Proxy);
        }

        public IRootAttributeFilter CreateRootAttributeFilter(IRoot root, System.IO.FileAttributes filter, FilterType filterType, string note) {
            return new WcfRootAttributeFilter(this.Proxy.Perform<Guid>(x => x.PlanManagerCreateRootAttributeFilter(root.Id, filter, filterType, note)), this.Proxy);
        }

        public IRootNameFilter CreateRootNameFilter(IRoot root, string filter, FilterType filterType, string note) {
            return new WcfRootNameFilter(this.Proxy.Perform<Guid>(x => x.PlanManagerCreateRootNameFilter(root.Id, filter, filterType, note)), this.Proxy);
        }

        public IPlan CreatePlan(IRoot root, IMount mount, ISchedule schedule) {
            return new WcfPlan(this.Proxy.Perform<Guid>(x => x.PlanManagerCreatePlan(root.Id, mount.Id, schedule.Id)), this.Proxy);
        }

        public IFileMount CreateFileMount(string name, string note, string folder) {
            return new WcfFileMount(this.Proxy.Perform<Guid>(x => x.PlanManagerCreateFileMount(name, note, folder)), this.Proxy);
        }

        public IExternalDriveMount CreateExternalDriveMount(string name, string note, string folder, string label) {
            return new WcfExternalDriveMount(this.Proxy.Perform<Guid>(x => x.PlanManagerCreateExternalDriveMount(name, note, folder, label)), this.Proxy);
        }

        public IFtpMount CreateFtpMount(string name, string note, string server, int port, string username, string password, string folder) {
            return new WcfFtpMount(this.Proxy.Perform<Guid>(x => x.PlanManagerCreateFtpMount(name, note, server, port, username, password, folder)), this.Proxy);
        }

        public ISchedule CreateSchedule(string name, TimeSpan time, ScheduleType scheduleType, DayOfWeek dayOfWeek, WabiLogic.Foundation.Tools.WeekOfMonth weekOfMonth) {
            return new WcfSchedule(this.Proxy.Perform<Guid>(x => x.PlanManagerCreateSchedule(name, time, scheduleType, dayOfWeek, weekOfMonth)), this.Proxy);
        }

        public void DeleteRoot(IRoot root) {
            this.Proxy.Perform(x => x.PlanManagerDeleteRoot(root.Id));
        }

        public void DeleteRootAttributeFilter(IRootAttributeFilter rootAttributeFilter) {
            this.Proxy.Perform(x => x.PlanManagerDeleteRootAttributeFilter(rootAttributeFilter.Id));
        }

        public void DeleteRootNameFilter(IRootNameFilter rootNameFilter) {
            this.Proxy.Perform(x => x.PlanManagerDeleteRootNameFilter(rootNameFilter.Id));
        }

        public void DeletePlan(IPlan plan) {
            this.Proxy.Perform(x => x.PlanManagerDeletePlan(plan.Id));
        }

        public void DeleteMount(IMount mount) {
            this.Proxy.Perform(x => x.PlanManagerDeleteMount(mount.Id));
        }

        public void DeleteSchedule(ISchedule schedule) {
            this.Proxy.Perform(x => x.PlanManagerDeleteSchedule(schedule.Id));
        }

        public IPlan LoadPlan(Guid planId) {
            return new WcfPlan(planId, this.Proxy);
        }

        public IRoot LoadRoot(Guid rootId) {
            return new WcfRoot(rootId, this.Proxy);
        }

        public IRootNameFilter LoadRootNameFilter(Guid rootNameFilter) {
            return new WcfRootNameFilter(rootNameFilter, this.Proxy);
        }

        public IRootAttributeFilter LoadRootAttributeFilter(Guid rootAttributeFilter) {
            return new WcfRootAttributeFilter(rootAttributeFilter, this.Proxy);
        }

        public IMount LoadMount(Guid mountId) {
            return WcfPlanManager.LoadMount(mountId, this.Proxy);
        }

        public ISchedule LoadSchedule(Guid scheduleId) {
            return new WcfSchedule(scheduleId, this.Proxy);
        }

        #endregion

        public static IMount LoadMount(Guid mountId, ProxyConnectionManager proxy) {
            string interfaceType = proxy.Perform<string>(x => x.MountGetInterfaceType(mountId));
            if (interfaceType.EndsWith("FileMount", StringComparison.OrdinalIgnoreCase))
                return new WcfFileMount(mountId, proxy);
            else if (interfaceType.EndsWith("ExternalDriveMount", StringComparison.OrdinalIgnoreCase))
                return new WcfExternalDriveMount(mountId, proxy);
            else if (interfaceType.EndsWith("FtpMount", StringComparison.OrdinalIgnoreCase))
                return new WcfFtpMount(mountId, proxy);

            return null;
        }
    }
}
