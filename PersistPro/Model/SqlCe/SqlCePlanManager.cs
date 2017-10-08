using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Encryption;
using WabiLogic.Foundation.Tools;
using System.Data;

namespace WabiLogic.PersistPro.Model.SqlCe
{
    public class SqlCePlanManager : IPlanManager
    {
        private PersistProDataSet DataSet { get; set; }

        public SqlCePlanManager(PersistProDataSet dataSet)
        {
            this.DataSet = dataSet;
        }

        #region IPlanManager Members

        public IEnumerable<IRoot> Roots
        {
            get
            {
                foreach (PersistProDataSet.RootRow subRow in this.DataSet.Root.Where(x => x.RowState != DataRowState.Deleted))
                    yield return new SqlCeRoot(subRow.Id, this.DataSet);
            }
        }
        public IEnumerable<IMount> Mounts
        {
            get
            {
                foreach (PersistProDataSet.MountRow subRow in this.DataSet.Mount.Where(x => x.RowState != DataRowState.Deleted))
                    yield return SqlCePlanManager.LoadMount(subRow.Id, this.DataSet);
            }
        }
        public IEnumerable<ISchedule> Schedules
        {
            get
            {
                foreach (PersistProDataSet.ScheduleRow subRow in this.DataSet.Schedule.Where(x => x.RowState != DataRowState.Deleted))
                    yield return new SqlCeSchedule(subRow.Id, this.DataSet);
            }
        }
        public IEnumerable<IPlan> Plans
        {
            get
            {
                foreach (PersistProDataSet.PlanRow subRow in this.DataSet.Plan.Where(x => x.RowState != DataRowState.Deleted))
                    yield return new SqlCePlan(subRow.Id, this.DataSet);
            }
        }

        public IRoot ImportRoot(Guid id, string name, string folder, bool sub, bool keepHistory, string note)
        {
            IRoot root = new SqlCeRoot(this.DataSet.Root.AddRootRow(id, name, folder, sub, keepHistory, note).Id, this.DataSet);
            return root;
        }

        public IRootAttributeFilter ImportRootAttributeFilter(Guid id, IRoot root, System.IO.FileAttributes filter, FilterType filterType, string note)
        {
            return new SqlCeRootAttributeFilter(this.DataSet.RootAttributeFilter.AddRootAttributeFilterRow(id, this.DataSet.Root.FindById(root.Id), filter.ToString(), filterType.ToString(), note).Id, this.DataSet);
        }

        public IRootNameFilter ImportRootNameFilter(Guid id, IRoot root, string filter, FilterType filterType, string note)
        {
            return new SqlCeRootNameFilter(this.DataSet.RootNameFilter.AddRootNameFilterRow(id, this.DataSet.Root.FindById(root.Id), filter, filterType.ToString(), note).Id, this.DataSet);
        }

        public IPlan ImportPlan(Guid id, IRoot root, IMount mount, ISchedule schedule)
        {
            return new SqlCePlan(this.DataSet.Plan.AddPlanRow(
                id,
                this.DataSet.Root.FindById(root.Id),
                this.DataSet.Mount.FindById(mount.Id),
                this.DataSet.Schedule.FindById(schedule.Id)
            ).Id, this.DataSet);
        }

        public IFileMount ImportFileMount(Guid id, string name, string note, string folder)
        {
            PersistProDataSet.MountRow mountRow = this.DataSet.Mount.AddMountRow(id, name, note);
            return new SqlCeFileMount(this.DataSet.FileMount.AddFileMountRow(Guid.NewGuid(), mountRow, folder).Id, this.DataSet);
        }

        public IExternalDriveMount ImportExternalDriveMount(Guid id, string name, string note, string folder, string label)
        {
            PersistProDataSet.MountRow mountRow = this.DataSet.Mount.AddMountRow(id, name, note);
            return new SqlCeExternalDriveMount(this.DataSet.ExternalDriveMount.AddExternalDriveMountRow(Guid.NewGuid(), mountRow, folder, label).Id, this.DataSet);
        }

        public IFtpMount ImportFtpMount(Guid id, string name, string note, string server, int port, string username, string password, string folder)
        {
            PersistProDataSet.MountRow mountRow = this.DataSet.Mount.AddMountRow(id, name, note);
            return new SqlCeFtpMount(this.DataSet.FtpMount.AddFtpMountRow(Guid.NewGuid(), mountRow, server, port, username, password, folder).Id, this.DataSet);
        }

        public ISchedule ImportSchedule(Guid id, string name, TimeSpan time, ScheduleType scheduleType, DayOfWeek dayOfWeek, WeekOfMonth weekOfMonth)
        {
            return new SqlCeSchedule(this.DataSet.Schedule.AddScheduleRow(
                id,
                name,
                time.Ticks,
                scheduleType.ToString(),
                dayOfWeek.ToString(),
                weekOfMonth.ToString()
            ).Id, this.DataSet);
        }

        public IRoot CreateRoot(string name, string folder, bool sub, bool keepHistory, string note)
        {
            IRoot root = new SqlCeRoot(this.DataSet.Root.AddRootRow(Guid.NewGuid(), name, folder, sub, keepHistory, note).Id, this.DataSet);
            CreateRootNameFilter(root, "*.*", FilterType.Include, "");
            CreateRootAttributeFilter(root, System.IO.FileAttributes.Archive, FilterType.Include, "");
            CreateRootAttributeFilter(root, System.IO.FileAttributes.System, FilterType.Exclude, "");
            CreateRootAttributeFilter(root, System.IO.FileAttributes.Hidden, FilterType.Exclude, "");
            CreateRootAttributeFilter(root, System.IO.FileAttributes.Temporary, FilterType.Exclude, "");
            return root;
        }

        public IRootAttributeFilter CreateRootAttributeFilter(IRoot root, System.IO.FileAttributes filter, FilterType filterType, string note)
        {
            return new SqlCeRootAttributeFilter(this.DataSet.RootAttributeFilter.AddRootAttributeFilterRow(Guid.NewGuid(), this.DataSet.Root.FindById(root.Id), filter.ToString(), filterType.ToString(), note).Id, this.DataSet);
        }

        public IRootNameFilter CreateRootNameFilter(IRoot root, string filter, FilterType filterType, string note)
        {
            return new SqlCeRootNameFilter(this.DataSet.RootNameFilter.AddRootNameFilterRow(Guid.NewGuid(), this.DataSet.Root.FindById(root.Id), filter, filterType.ToString(), note).Id, this.DataSet);
        }

        public IPlan CreatePlan(IRoot root, IMount mount, ISchedule schedule)
        {
            return new SqlCePlan(this.DataSet.Plan.AddPlanRow(
                Guid.NewGuid(),
                this.DataSet.Root.FindById(root.Id),
                this.DataSet.Mount.FindById(mount.Id),
                this.DataSet.Schedule.FindById(schedule.Id)
            ).Id, this.DataSet);
        }

        public IFileMount CreateFileMount(string name, string note, string folder)
        {
            PersistProDataSet.MountRow mountRow = this.DataSet.Mount.AddMountRow(Guid.NewGuid(), name, note);
            return new SqlCeFileMount(this.DataSet.FileMount.AddFileMountRow(Guid.NewGuid(), mountRow, folder).Id, this.DataSet);
        }

        public IExternalDriveMount CreateExternalDriveMount(string name, string note, string folder, string label)
        {
            PersistProDataSet.MountRow mountRow = this.DataSet.Mount.AddMountRow(Guid.NewGuid(), name, note);
            return new SqlCeExternalDriveMount(this.DataSet.ExternalDriveMount.AddExternalDriveMountRow(Guid.NewGuid(), mountRow, folder, label).Id, this.DataSet);
        }

        public IFtpMount CreateFtpMount(string name, string note, string server, int port, string username, string password, string folder)
        {
            PersistProDataSet.MountRow mountRow = this.DataSet.Mount.AddMountRow(Guid.NewGuid(), name, note);
            return new SqlCeFtpMount(this.DataSet.FtpMount.AddFtpMountRow(Guid.NewGuid(), mountRow, server, port, username, password, folder).Id, this.DataSet);
        }

        public ISchedule CreateSchedule(string name, TimeSpan time, ScheduleType scheduleType, DayOfWeek dayOfWeek, WeekOfMonth weekOfMonth)
        {
            return new SqlCeSchedule(this.DataSet.Schedule.AddScheduleRow(
                Guid.NewGuid(),
                name,
                time.Ticks,
                scheduleType.ToString(),
                dayOfWeek.ToString(),
                weekOfMonth.ToString()
            ).Id, this.DataSet);
        }

        public void DeleteRoot(IRoot root)
        {
            this.DataSet.Root.FindById(root.Id).Delete();
        }

        public void DeleteRootAttributeFilter(IRootAttributeFilter rootAttributeFilter)
        {
            this.DataSet.RootAttributeFilter.FindById(rootAttributeFilter.Id).Delete();
        }

        public void DeleteRootNameFilter(IRootNameFilter rootNameFilter)
        {
            this.DataSet.RootNameFilter.FindById(rootNameFilter.Id).Delete();
        }

        public void DeletePlan(IPlan plan)
        {
            this.DataSet.Plan.FindById(plan.Id).Delete();
        }

        public void DeleteMount(IMount mount)
        {
            this.DataSet.Mount.FindById(mount.Id).Delete();
        }

        public void DeleteSchedule(ISchedule schedule)
        {
            this.DataSet.Schedule.FindById(schedule.Id).Delete();
        }

        public IPlan LoadPlan(Guid planId)
        {
            var plans = this.DataSet.Plan.Where(x => x.RowState != DataRowState.Deleted && x.Id == planId);
            if (plans.Count() == 1)
                return new SqlCePlan(planId, this.DataSet);
            else
                return null;
        }

        public IRoot LoadRoot(Guid rootId)
        {
            var roots = this.DataSet.Root.Where(x => x.RowState != DataRowState.Deleted && x.Id == rootId);
            if (roots.Count() == 1)
                return new SqlCeRoot(rootId, this.DataSet);
            else
                return null;
        }

        public IRootNameFilter LoadRootNameFilter(Guid rootNameFilter)
        {
            var rootNameFilters = this.DataSet.RootNameFilter.Where(x => x.RowState != DataRowState.Deleted && x.Id == rootNameFilter);
            if (rootNameFilters.Count() == 1)
                return new SqlCeRootNameFilter(rootNameFilter, this.DataSet);
            else
                return null;
        }

        public IRootAttributeFilter LoadRootAttributeFilter(Guid rootAttributeFilter)
        {
            var rootAttributeFilters = this.DataSet.RootAttributeFilter.Where(x => x.RowState != DataRowState.Deleted && x.Id == rootAttributeFilter);
            if (rootAttributeFilters.Count() == 1)
                return new SqlCeRootAttributeFilter(rootAttributeFilter, this.DataSet);
            else
                return null;
        }

        public IMount LoadMount(Guid mountId)
        {
            var mounts = this.DataSet.Mount.Where(x => x.RowState != DataRowState.Deleted && x.Id == mountId);
            if (mounts.Count() == 1)
                return SqlCePlanManager.LoadMount(mountId, this.DataSet);
            else
                return null;
        }

        public ISchedule LoadSchedule(Guid scheduleId)
        {
            var schedules = this.DataSet.Schedule.Where(x => x.RowState != DataRowState.Deleted && x.Id == scheduleId);
            if (schedules.Count() == 1)
                return new SqlCeSchedule(scheduleId, this.DataSet);
            else
                return null;
        }

        #endregion

        public static IMount LoadMount(Guid id, PersistProDataSet dataSet)
        {
            var fileMounts = dataSet.FileMount.Where(x => x.RowState != DataRowState.Deleted && x.MountId == id);
            if (fileMounts.Count() > 0)
                return new SqlCeFileMount(fileMounts.Single().Id, dataSet);

            var externalDriveMounts = dataSet.ExternalDriveMount.Where(x => x.RowState != DataRowState.Deleted && x.MountId == id);
            if (externalDriveMounts.Count() > 0)
                return new SqlCeExternalDriveMount(externalDriveMounts.Single().Id, dataSet);

            var ftpMounts = dataSet.FtpMount.Where(x => x.RowState != DataRowState.Deleted && x.MountId == id);
            if (ftpMounts.Count() > 0)
                return new SqlCeFtpMount(ftpMounts.Single().Id, dataSet);

            return null;
        }
    }
}
