using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;
using WabiLogic.PersistPro.Model;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Tools;

namespace WabiLogic.PersistPro.Controller {
    public class ServerExecutor : ExecutorBase {
        public ServerExecutor(IFactory factory) : this (factory, 20000.0) { }

        public ServerExecutor(IFactory factory, double pulseRate) : base(factory, pulseRate) { }

        public override void Pulse() {
            ExecuteScheduledPlans();
        }

        private bool ProceedWithBackup(IPlan plan, IHistory history) {
            return history.ExecuteDate < DateTime.Now;
        }

        public void ExecuteScheduledPlans() {
            foreach (IPlan plan in this.PlanManager.Plans) {
                IHistory history = ScheduleNextRun(plan);
                
                if (ProceedWithBackup(plan, history)) {
                    try {
                        history.BeginBackupDate = DateTime.Now;
                        history.Status = HistoryStatus.InProgress;
                        this.Factory.SaveHistoryManager();

                        BackupManager backupManager = new BackupManager(plan, StorageLoader.Load(plan.Mount, this.Factory.LoadEncryption()));
                        backupManager.Backup();

                        history.FinishBackupDate = DateTime.Now;
                        history.Status = HistoryStatus.Complete;
                        history.ErrorNote = ""; //reset potential errors
                        this.Factory.SaveHistoryManager();
                    }
                    catch (Exception e) {
                        StringBuilder errorMessage = new StringBuilder();
                        if (e is System.Threading.ThreadAbortException) {
                            errorMessage.Append("Service was stopped. This was probably caused by rebooting your computer.");
                            System.Threading.Thread.ResetAbort();
                        }
                        else {
                            Exception error = e;
                            while (error != null) {
                                errorMessage.Append(error.Message);
                                errorMessage.Append(" ");
                                error = error.InnerException;
                            }
                        }

                        history.Status = HistoryStatus.InError;
                        history.ExecuteDate = DateTime.Now.AddHours(1.0);
                        history.ErrorNote = errorMessage.ToString();
                        this.Factory.SaveHistoryManager();
                    }
                }
            }
        }

        public IHistory ScheduleNextRun(IPlan plan) {
            DateTime projectedNextRunDate = CalculateNextRunDate(plan);

            IHistory toReturn = this.HistoryManager.LoadLatestHistory(plan);

            if (toReturn == null || toReturn.Status == HistoryStatus.Complete || toReturn.Status == HistoryStatus.Aborted) {
                toReturn = this.HistoryManager.CreateHistory(plan, HistoryStatus.NotStarted, CalculateNextRunDate(plan), "");
                this.Factory.SaveHistoryManager();
            }
            else if (toReturn.ScheduleDate > DateTime.Now && toReturn.ScheduleDate != projectedNextRunDate) {
                //This should handle when the user changes the schedule of a plan and the system had already planned the next occurance. 
                //If the ScheduleDate is in the future and the projectedNextRunDate is different then the ScheduleDate then change the
                //ScheduleDate to the projectedNextRunDate && update ExecutionDate to the new ScheduleDate
                toReturn.ScheduleDate = projectedNextRunDate;
                toReturn.ExecuteDate = projectedNextRunDate;
                this.Factory.SaveHistoryManager();
            }

            return toReturn;
        }

        private DateTime CalculateNextRunDate(IPlan plan) {
            //Handle daily
            DateTime toReturn = new DateTime(DateTime.Today.Ticks + plan.Schedule.Time.Ticks);

            if (toReturn < DateTime.Now)
                toReturn = toReturn.AddDays(1.0);

            //Handle Weekly
            if (plan.Schedule.ScheduleType == ScheduleType.Weekly) {
                while (plan.Schedule.DayOfWeek != toReturn.DayOfWeek)
                    toReturn = toReturn.AddDays(1.0);
            }

            //Handle Monthly
            if (plan.Schedule.ScheduleType == ScheduleType.Monthly) {
                toReturn = Date.FindDate(toReturn.Year, toReturn.Month, plan.Schedule.WeekOfMonth, plan.Schedule.DayOfWeek);

                if (toReturn < DateTime.Now) {
                    toReturn = toReturn.AddMonths(1);
                    toReturn = Date.FindDate(toReturn.Year, toReturn.Month, plan.Schedule.WeekOfMonth, plan.Schedule.DayOfWeek);
                }
            }

            return toReturn;
        }
    }
}
