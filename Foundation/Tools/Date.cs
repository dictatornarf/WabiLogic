using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.Foundation.Tools {
    public enum WeekOfMonth {
        First,
        Second,
        Third,
        Fourth,
        Last
    }

    public static class Date {
        public static DateTime FindDate(int year, int month, WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek) {
            //Start with the first
            DateTime toReturn = new DateTime(year, month, 1);

            if (weekOfMonth == WeekOfMonth.Last) {
                //Start with next month - 1 day (Last day of month)
                toReturn = toReturn.AddMonths(1).AddDays(-1.0);

                //Decrement backward and find first use of DayOfWeek
                while (toReturn.DayOfWeek != dayOfWeek)
                    toReturn = toReturn.AddDays(-1.0);
            }
            else {
                //Increment forward and find first use of DayOfWeek
                while (toReturn.DayOfWeek != dayOfWeek)
                    toReturn = toReturn.AddDays(1.0);

                switch (weekOfMonth) {
                    case WeekOfMonth.Second:
                        toReturn = toReturn.AddDays(7.0);
                        break;
                    case WeekOfMonth.Third:
                        toReturn = toReturn.AddDays(14.0);
                        break;
                    case WeekOfMonth.Fourth:
                        toReturn = toReturn.AddDays(21.0);
                        break;
                }
            }

            return toReturn;

        }
    }
}
