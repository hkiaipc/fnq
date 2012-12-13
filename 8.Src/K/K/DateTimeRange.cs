
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using KDB;
using Xdgk.Common;


namespace K
{
    public class DateTimeRange
    {
        public DateTimeRange(DateTime begin, DateTime end)
        {
            if (begin > end)
            {
                throw new ArgumentException("begin must <= end");
            }
            this._begin = begin;
            this._end = end;
        }

#region Begin
        /// <summary>
        /// 
        /// </summary>
        public DateTime Begin
        {
            get
            {
                return _begin;
            }
            //set
            //{
            //    _begin = value;
            //}
        } private DateTime _begin;
#endregion //Begin

#region End
        /// <summary>
        /// 
        /// </summary>
        public DateTime End
        {
            get
            {
                return _end;
            }
            //set
            //{
            //    _end = value;
            //}
        } private DateTime _end;
#endregion //End

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool IsInRange(DateTime dt)
        {
            return dt >= Begin && dt <= End;
        }


        private bool IsInRange(IEnumerable<DateTime> enumerable)
        {
            DateTime outvalue;
            return IsInRange(enumerable, out outvalue);
        }

        public bool IsInRange(IEnumerable<DateTime> enumerable, out DateTime dtInRange)
        {
            bool r = false;
            dtInRange = DateTime.MinValue;

            foreach (DateTime dt in enumerable)
            {
                if (IsInRange(dt))
                {
                    r = true;
                    dtInRange = dt;
                    break;
                }
            }
            return r;
        }
    }

}
