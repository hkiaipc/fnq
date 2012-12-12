﻿#define ENABLE_TEST

#if ENABLE_TEST
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace K.Test
{
    [TestFixture ]
    public class Test
    {
        [Test]
        public void TestTimeDefineIsOverlapped()
        {
            WeekTimeDefineTest();
            UserTimeDefineTest();
        }

        private void UserTimeDefineTest()
        {
            UserTimeDefine d1 = TimeDefine.CreateUserTimeDefine(5,
                0, TimeSpan.Parse("00:00:00"),
                0, TimeSpan.Parse("12:00:00"));

            UserTimeDefine d2 = TimeDefine.CreateUserTimeDefine(5,
                4, TimeSpan.Parse("12:00:00"),
                0, TimeSpan.Parse("08:00:00"));

            bool b = TimeDefineCollection.IsOverlapped(d1, d2);
            Assert.IsTrue(b);
        }

        private void WeekTimeDefineTest()
        {
            WeekTimeDefine d1 = TimeDefine.CreateWeekTimeDefine(
                DayOfWeek.Sunday, TimeSpan.Parse("00:00:00"),
                DayOfWeek.Monday, TimeSpan.Parse("00:00:00"));

            WeekTimeDefine d2 = TimeDefine.CreateWeekTimeDefine(
                DayOfWeek.Saturday, TimeSpan.Parse("12:00:00"),
                DayOfWeek.Sunday, TimeSpan.Parse("12:00:00"));


            WeekTimeDefine d3 = TimeDefine.CreateWeekTimeDefine (
                DayOfWeek.Monday , TimeSpan.Parse ("8:00:00"),
                DayOfWeek.Monday , TimeSpan.Parse ("20:00:00"));
            bool b = TimeDefineCollection.IsOverlapped(d1, d2);
            Assert.IsTrue(b);

            b = TimeDefineCollection.IsOverlapped(d1, d3);
            Assert.IsFalse(b);
        }
    }
}
#endif