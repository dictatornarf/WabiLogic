using System;
using System.IO;
using System.Text;
using OnlineBackupUtility.Root;

namespace OnlineBackupUtility.Root.FileShare {
    public partial class RootDataSet {
        partial class NameFilterDataTable {
        }
    
        public static RootDataSet Load(Stream inputStream) {
            RootDataSet set = null;

            try {
                //BinaryFormatter bf = new BinaryFormatter();
                //set = bf.Deserialize(inputStream) as BasicDataSet;
                set = new RootDataSet();

                BinaryReader br = new BinaryReader(inputStream, System.Text.Encoding.UTF8);

                //Load Roots
                set.Root.BeginLoadData();
                int rootCount = br.ReadInt32();
                for (int i = 0; i < rootCount; i++) {
                    int rootId = br.ReadInt32();
                    string name = br.ReadString();
                    string path = br.ReadString();
                    bool sub = br.ReadBoolean();
                    string note = br.ReadString();
                    set.Root.Rows.Add(rootId, name, path, sub, note);
                }
                set.Root.EndLoadData();

                //Load NameFilters
                set.NameFilter.BeginLoadData();
                int nameFilterCount = br.ReadInt32();
                for (int i = 0; i < nameFilterCount; i++) {
                    int nameFilterId = br.ReadInt32();
                    int rootId = br.ReadInt32();
                    string filter = br.ReadString();
                    FilterType filterType = (FilterType)Enum.Parse(typeof(FilterType), br.ReadString(), true);
                    string note = br.ReadString();
                    set.NameFilter.Rows.Add(nameFilterId, rootId, filter, filterType, note);
                }
                set.NameFilter.EndLoadData();

                //Load AttributeFilters
                set.AttributeFilter.BeginLoadData();
                int attributeFilterCount = br.ReadInt32();
                for (int i = 0; i < attributeFilterCount; i++) {
                    int attributeFilterId = br.ReadInt32();
                    int rootId = br.ReadInt32();
                    FileAttributes filter = DecodeFileAttributes(br.ReadString());
                    FilterType filterType = (FilterType)Enum.Parse(typeof(FilterType), br.ReadString(), true);
                    string note = br.ReadString();
                    set.AttributeFilter.Rows.Add(attributeFilterId, rootId, filter, filterType, note);
                }
                set.AttributeFilter.EndLoadData();

                //Load Schedules
                set.Schedule.BeginLoadData();
                int scheduleCount = br.ReadInt32();
                for (int i = 0; i < scheduleCount; i++) {
                    int scheduleId = br.ReadInt32();
                    DateTime time = new DateTime(br.ReadInt64());
                    Schedule schedule = (Schedule)Enum.Parse(typeof(Schedule), br.ReadString(), true);
                    DayOfWeek dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), br.ReadString(), true);
                    WeekOfMonth weekOfMonth = (WeekOfMonth)Enum.Parse(typeof(WeekOfMonth), br.ReadString(), true);
                    bool promptBeforeBackup = br.ReadBoolean();
                    TimeSpan periodToWaitBeforeAlertIfNotCompleted = new TimeSpan(br.ReadInt64());
                    set.Schedule.Rows.Add(scheduleId, time, schedule, dayOfWeek, weekOfMonth, promptBeforeBackup, periodToWaitBeforeAlertIfNotCompleted);
                }
                set.Schedule.EndLoadData();
            }
            catch {
                set = null;
            }
            return set;
        }

        public static void Save(Stream outputStream, RootDataSet set) {
            BinaryWriter bw = new BinaryWriter(outputStream, System.Text.Encoding.UTF8);

            //Write Roots
            bw.Write(set.Root.Count);
            foreach (RootRow rr in set.Root) {
                bw.Write(rr.RootId);
                bw.Write(rr.Name);
                bw.Write(rr.Path);
                bw.Write(rr.Sub);
                bw.Write(rr.Note);
            }

            //Write NameFilter
            bw.Write(set.NameFilter.Count);
            foreach (NameFilterRow nfr in set.NameFilter) {
                bw.Write(nfr.NameFilterId);
                bw.Write(nfr.RootId);
                bw.Write(nfr.Filter);
                bw.Write(nfr.FilterType.ToString());
                bw.Write(nfr.Note);
            }

            //Write AttributeFilter
            bw.Write(set.AttributeFilter.Count);
            foreach (AttributeFilterRow afr in set.AttributeFilter) {
                bw.Write(afr.AttributeFilterId);
                bw.Write(afr.RootId);
                bw.Write(EncodeFileAttributes(afr.Filter));
                bw.Write(afr.FilterType.ToString());
                bw.Write(afr.Note);
            }

            //Write Schedule
            bw.Write(set.Schedule.Count);
            foreach (ScheduleRow sr in set.Schedule) {
                bw.Write(sr.ScheduleId);
                bw.Write(sr.Time.Ticks);
                bw.Write(sr.ScheduleType.ToString());
                bw.Write(sr.DayOfWeek.ToString());
                bw.Write(sr.WeekOfMonth.ToString());
                bw.Write(sr.PromptBeforeBackup);
                bw.Write(sr.PeriodToWaitBeforeAlertIfNotCompleted.Ticks);
            }

            bw.Flush();
        }

        private static FileAttributes DecodeFileAttributes(string values) {
            FileAttributes toReturn = 0;

            foreach (string value in values.Split(',')) {
                toReturn &= (FileAttributes)Enum.Parse(typeof(FileAttributes), value, true);
            }

            return toReturn;
        }

        private static string EncodeFileAttributes(FileAttributes values) {
            StringBuilder toReturn = new StringBuilder();

            FileAttributes[] options = (FileAttributes[])Enum.GetValues(typeof(FileAttributes));

            foreach (FileAttributes option in options) {
                if (option == (option & values)) {
                    toReturn.Append(option.ToString());
                    toReturn.Append(",");
                }
            }

            return toReturn.ToString();
        }
    }
}
