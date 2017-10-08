using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Tools;

namespace WabiLogic.PersistPro.Model {
    public interface ISchedule {
        Guid Id { get; }
        string Name { get; set; }
        TimeSpan Time { get; set; }
        ScheduleType ScheduleType { get; set; }
        DayOfWeek DayOfWeek { get; set; }
        WeekOfMonth WeekOfMonth { get; set; }
    }
}
