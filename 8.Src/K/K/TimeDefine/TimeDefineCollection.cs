using System;
using System.Diagnostics;
using Xdgk.Common;

namespace K
{
    [Serializable]
    public class TimeDefineCollection : Collection<TimeDefine>
    {
        protected override void InsertItem(int index, TimeDefine item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                TimeDefine td = this[i];
                if (td.GetType() != item.GetType())
                {
                    throw new ArgumentException("time define collectino can not contains different type");
                }
                if (IsOverlapped(td, item))
                {
                    string msg = string.Format(
                            "{0} {1} is overlapped",
                            td, item);
                    throw new KConfigException(msg);
                }
            }
            base.InsertItem(index, item);
        }

        static private bool IsOverlapped(WeekTimeDefine td1, WeekTimeDefine td2)
        {
            int offset = (int)td1.BeginWeek;
            if (td1.EndWeek < td1.BeginWeek)
            {
                offset = offset - 7;
            }

            TimeSpan td1Begin = td1.Begin + TimeSpan.FromDays(offset);
            TimeSpan td1End = td1.End + TimeSpan.FromDays((int)td1.EndWeek);

            offset = (int)td2.BeginWeek;
            if (td2.EndWeek < td2.BeginWeek)
            {
                offset = offset - 7;
            }
            TimeSpan td2Begin = td2.Begin + TimeSpan.FromDays(offset);
            TimeSpan td2End = td2.End + TimeSpan.FromDays((int)td2.EndWeek);

            if ((td2Begin >= td1Begin && td2Begin <= td1End) ||
                (td2End >= td1Begin && td2End <= td1End))
            {
                return true;
            }
            return false;
        }

        static private bool IsOverlapped(UserTimeDefine td1, UserTimeDefine td2)
        {
            int offset = td1.BeginDayOffset;
            if (td1.EndDayOffset < td1.BeginDayOffset)
            {
                offset = offset - td1.DayOfCycle;
            }

            TimeSpan td1Begin = td1.Begin + TimeSpan.FromDays(offset);
            TimeSpan td1End = td1.End + TimeSpan.FromDays(td1.EndDayOffset);

            offset = td2.BeginDayOffset;
            if (td2.EndDayOffset < td2.BeginDayOffset)
            {
                offset = offset - td2.DayOfCycle;
            }
            TimeSpan td2Begin = td2.Begin + TimeSpan.FromDays(offset);
            TimeSpan td2End = td2.End + TimeSpan.FromDays(td2.EndDayOffset);

            if ((td2Begin >= td1Begin && td2Begin <= td1End) ||
                (td2End >= td1Begin && td2End <= td1End))
            {
                return true;
            }
            return false;
        }

        static public bool IsOverlapped(TimeDefine td1, TimeDefine td2)
        {
            Debug.Assert(td1.GetType() == td2.GetType());

            if (td1 is UserTimeDefine)
            {
                return IsOverlapped((UserTimeDefine)td1, (UserTimeDefine)td2);
            }
            if ( td1 is WeekTimeDefine )
            {
                return IsOverlapped ((WeekTimeDefine )td1,(WeekTimeDefine )td2 );
            }

            throw new NotImplementedException("IsOverlapped for " + td1.GetType().Name);
        }
    }

}
