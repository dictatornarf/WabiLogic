using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBackupUtility.Root.FileShare {
    public class Schedule : OnlineBackupUtility.Root.ISchedule {
        public RootDataSet.ScheduleRow ScheduleRow { get; private set; }
        public RootManager RootManager { get; private set; }

        public Schedule(RootDataSet.ScheduleRow scheduleRow, RootManager rootManager) {
            this.ScheduleRow = scheduleRow;
            this.RootManager = rootManager;
        }

        #region ISchedule Members

        public int Id {
            get { return this.Id; }
        }

        public TimeSpan Time {
            get {
                return this.ScheduleRow.Time;
            }
            set {
                this.ScheduleRow.Time = value;
            }
        }

        public ScheduleType ScheduleType {
            get {
                return this.ScheduleRow.ScheduleType;
            }
            set {
                this.ScheduleRow.ScheduleType = value;
            }
        }

        public DayOfWeek DayOfWeek {
            get {
                return this.ScheduleRow.DayOfWeek;
            }
            set {
                this.ScheduleRow.DayOfWeek = value;
            }
        }

        public WeekOfMonth WeekOfMonth {
            get {
                return this.ScheduleRow.WeekOfMonth;
            }
            set {
                this.ScheduleRow.WeekOfMonth = value;
            }
        }

        public bool PromptBeforeBackup {
            get {
                return this.ScheduleRow.PromptBeforeBackup;
            }
            set {
                this.ScheduleRow.PromptBeforeBackup = value;
            }
        }

        public TimeSpan PeriodToWaitBeforeAlertIfNotCompleted {
            get {
                return this.ScheduleRow.PeriodToWaitBeforeAlertIfNotCompleted;
            }
            set {
                this.ScheduleRow.PeriodToWaitBeforeAlertIfNotCompleted = value;
            }
        }

        public bool IsTimeToBackup(IHistoryManager historyManager) {
            bool toReturn = false;
            switch (this.ScheduleType) {
                case ScheduleType.None:
                    break;
                case ScheduleType.Daily:
                    //historyManager.LoadLatestHistory
                case ScheduleType.Weekly:
                case ScheduleType.Monthly:
                    break;
            }
            
            return toReturn;
        }

        #endregion
    }
}
