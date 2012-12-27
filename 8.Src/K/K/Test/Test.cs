#define ENABLE_TEST

#if ENABLE_TEST
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using KDB;

namespace K.Test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestTimeDefineIsOverlapped()
        {
            WeekTimeDefineTest();
            UserTimeDefineTest();
        }

        TimeSpan _ts = TimeSpan.Parse("00:30:00");
        private void UserTimeDefineTest()
        {
            UserTimeDefine d1 = TimeDefine.CreateUserTimeDefine(5,
                0, TimeSpan.Parse("00:00:00"),
                0, TimeSpan.Parse("12:00:00"), _ts, _ts);

            UserTimeDefine d2 = TimeDefine.CreateUserTimeDefine(5,
                4, TimeSpan.Parse("12:00:00"),
                0, TimeSpan.Parse("08:00:00"), _ts, _ts);

            bool b = TimeDefineCollection.IsOverlapped(d1, d2);
            Assert.IsTrue(b);
        }

        private void WeekTimeDefineTest()
        {
            WeekTimeDefine d1 = TimeDefine.CreateWeekTimeDefine(
                DayOfWeek.Sunday, TimeSpan.Parse("00:00:00"),
                DayOfWeek.Monday, TimeSpan.Parse("00:00:00"),
                _ts, _ts);

            WeekTimeDefine d2 = TimeDefine.CreateWeekTimeDefine(
                DayOfWeek.Saturday, TimeSpan.Parse("12:00:00"),
                DayOfWeek.Sunday, TimeSpan.Parse("12:00:00"),
                _ts, _ts);


            WeekTimeDefine d3 = TimeDefine.CreateWeekTimeDefine(
                DayOfWeek.Monday, TimeSpan.Parse("8:00:00"),
                DayOfWeek.Monday, TimeSpan.Parse("20:00:00"),
                _ts, _ts);
            bool b = TimeDefineCollection.IsOverlapped(d1, d2);
            Assert.IsTrue(b);

            b = TimeDefineCollection.IsOverlapped(d1, d3);
            Assert.IsFalse(b);
        }
    }


    [TestFixture]
    public class TestDateTimeHelper
    {
        [Test]
        public void TestNextMonth()
        {
            DateTime month = new DateTime(2012, 11, 3);
            DateTime r = DateTimeHelper.NextMonth(month);
            Console.WriteLine(r);
            Assert.AreEqual(2012, r.Year);
            Assert.AreEqual(12, r.Month);
            Assert.AreEqual(1, r.Day);
            Assert.AreEqual(0, r.Hour);
            Assert.AreEqual(0, r.Minute);
            Assert.AreEqual(0, r.Second);


            month = new DateTime(2012, 12, 4);
            r = DateTimeHelper.NextMonth(month);
            Console.WriteLine(r);

            Assert.AreEqual(2013, r.Year);
            Assert.AreEqual(1, r.Month);
            Assert.AreEqual(1, r.Day);
            Assert.AreEqual(0, r.Hour);
            Assert.AreEqual(0, r.Minute);
            Assert.AreEqual(0, r.Second);
        }
    }

    [TestFixture]
    public class TestDateTimeRange
    {
        DateTimeRange baseRange = new DateTimeRange(
            DateTime.Parse("2000-1-15"), DateTime.Parse("2000-1-16"));

        DateTimeRange disconnectRange = new DateTimeRange(
            DateTime.Parse("2000-1-25"), DateTime.Parse("2000-1-26")
            );

        DateTimeRange crossBeginRange = new DateTimeRange(
            DateTime.Parse("2000-1-14"), DateTime.Parse("2000-1-15 12:00:00")
            );

        DateTimeRange crossEndRange = new DateTimeRange(
            DateTime.Parse("2000-1-15 12:00:00"), DateTime.Parse("2000-1-17")
            );

        DateTimeRange includeRange = new DateTimeRange(
            DateTime.Parse("2000-1-15 12:00:00"), DateTime.Parse("2000-1-15 17:00:00")
            );

        DateTimeRange beIncludeRange = new DateTimeRange(
            DateTime.Parse("2000-1-14"), DateTime.Parse("2000-1-17")
            );

        [Test]
        public void Test()
        {
            object[] objs = new object[] {
                    DateTimeRangeRelation.Disconnection , disconnectRange ,
                    DateTimeRangeRelation.CrossAtBegin, crossBeginRange ,
                    DateTimeRangeRelation.CrossAtEnd , crossEndRange ,
                    DateTimeRangeRelation.Include , includeRange ,
                    DateTimeRangeRelation.BeIncluded , beIncludeRange };

            for (int i = 0; i < objs.Length; i += 2)
            {
                DateTimeRange dtr = (DateTimeRange)objs[i + 1];
                DateTimeRangeRelation r = baseRange.DiscernRelation(dtr);
                Console.WriteLine("{0} => {1} => {2}", baseRange, dtr, r);
                Assert.AreEqual(objs[i], r);
            }
        }
    }


    [TestFixture]
    public class TestLinqObjectEqual
    {
        [Test]
        public void FromSameDB()
        {
            DB db = DBFactory.GetDB();
            tblGroup v1 = db.tblGroup.First();
            tblGroup v2 = db.tblGroup.ToList()[0];
            Console.WriteLine("{0} {1}", v1.GroupName, v1.GroupID);
            Assert.AreEqual(v1.GroupID, v2.GroupID);

            Assert.AreEqual(v1, v2);
            Assert.AreSame(v1, v2);
        }

        [Test]
        public void FromDiffDB()
        {
            DB db1 = DBFactory.GetDB();
            DB db2 = DBFactory.GetDB();

            tblGroup v1 = db1.tblGroup.First();
            tblGroup v2 = db2.tblGroup.First();
            Console.WriteLine("v1: {0} {1}", v1.GroupName, v1.GroupID);
            Console.WriteLine("v2: {0} {1}", v2.GroupName, v2.GroupID);

            Assert.AreEqual(v1.GroupID, v2.GroupID);
            //Assert.AreEqual(v1, v2);
            Assert.AreNotEqual(v1, v2);
            Assert.AreNotSame(v1, v2);
        }
    }
}
#endif