using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WabiLogic.Foundation.Tools;

namespace UnitTests {
    [TestFixture]
    public class DateTest {
        [Test]
        public void TestFindDate() {
            Assert.AreEqual(new DateTime(2008, 12, 7), Date.FindDate(2008, 12, WeekOfMonth.First, DayOfWeek.Sunday));
            Assert.AreEqual(new DateTime(2008, 12, 1), Date.FindDate(2008, 12, WeekOfMonth.First, DayOfWeek.Monday));

            Assert.AreEqual(new DateTime(2008, 8, 12), Date.FindDate(2008, 8, WeekOfMonth.Second, DayOfWeek.Tuesday));
            Assert.AreEqual(new DateTime(2008, 8, 20), Date.FindDate(2008, 8, WeekOfMonth.Third, DayOfWeek.Wednesday));

            Assert.AreEqual(new DateTime(2009, 1, 23), Date.FindDate(2009, 1, WeekOfMonth.Fourth, DayOfWeek.Friday));

            Assert.AreEqual(new DateTime(2008, 12, 29), Date.FindDate(2008, 12, WeekOfMonth.Last, DayOfWeek.Monday));
            Assert.AreEqual(new DateTime(2009, 1, 30), Date.FindDate(2009, 1, WeekOfMonth.Last, DayOfWeek.Friday));
        }
    }
}
