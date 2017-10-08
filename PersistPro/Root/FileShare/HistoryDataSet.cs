using OnlineBackupUtility.Backup;
using System;
using System.IO;
namespace OnlineBackupUtility.Root.FileShare {
    public partial class HistoryDataSet {
        public static HistoryDataSet Load(Stream inputStream) {
            HistoryDataSet set = null;

            try {
                //BinaryFormatter bf = new BinaryFormatter();
                //set = bf.Deserialize(inputStream) as BasicDataSet;
                set = new HistoryDataSet();

                BinaryReader br = new BinaryReader(inputStream, System.Text.Encoding.UTF8);

                //Load History
                set.History.BeginLoadData();
                int historyCount = br.ReadInt32();
                for (int i = 0; i < historyCount; i++) {
                    int historyId = br.ReadInt32();
                    int scheduleId = br.ReadInt32();
                    HistoryStatus historyStatus = (HistoryStatus)Enum.Parse(typeof(HistoryStatus), br.ReadString(), true);
                    DateTime scheduleDate = new DateTime(br.ReadInt64());
                    DateTime promptAgainAt = new DateTime(br.ReadInt64());
                    DateTime startBackupDate = new DateTime(br.ReadInt64());
                    DateTime beginBackupDate = new DateTime(br.ReadInt64());
                    set.History.Rows.Add(historyId, scheduleId, historyStatus, scheduleDate, promptAgainAt, startBackupDate, beginBackupDate);
                }
                set.History.EndLoadData();

            }
            catch {
                set = null;
            }
            return set;
        }

        public static void Save(Stream outputStream, HistoryDataSet set) {
            BinaryWriter bw = new BinaryWriter(outputStream, System.Text.Encoding.UTF8);
 
            //Write History
            bw.Write(set.History.Count);
            foreach (HistoryRow hr in set.History) {
                bw.Write(hr.HistoryId);
                bw.Write(hr.ScheduleId);
                bw.Write(hr.Status.ToString());
                bw.Write(hr.ScheduleDate.Ticks);
                bw.Write(hr.PromptAgainAt.Ticks);
                bw.Write(hr.BeginBackupDate.Ticks);
                bw.Write(hr.FinishBackupDate.Ticks);
            }

            bw.Flush();
        }
    }
}
