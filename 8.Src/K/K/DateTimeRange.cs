using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using KDB;
using Xdgk.Common;

namespace K
{
    /// <summary>
    /// 
    /// </summary>
    public enum DateTimeRangeRelation
    {
        Disconnection,
        CrossAtBegin,
        CrossAtEnd,
        Include,
        BeIncluded,

    }

    /// <summary>
    /// 
    /// </summary>
    public class DateTimeRange
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IncludeBeginPoint
        {
            get { return _includeBeginPoint; }
            set { _includeBeginPoint = value; }
        } private bool _includeBeginPoint = true;

        /// <summary>
        /// 
        /// </summary>
        public bool IncludeEndPoint
        {
            get { return _includeEndPoint; }
            set { _includeEndPoint = value; }
        } private bool _includeEndPoint = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
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
        } private DateTime _end;
        #endregion //End

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool IsEarly(DateTime dt)
        {
            if (this.IncludeBeginPoint)
            {
                return dt < this._begin;
            }
            else
            {
                return dt <= this._begin;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool IsLater( DateTime dt )
        {
            if (this.IncludeEndPoint)
            {
                return dt > this._end;
            }
            else
            {
                return dt >= this._end;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool IsInRange(DateTime dt)
        {
            bool r = false;
            if (IncludeBeginPoint)
            {
                r = dt >= this._begin;
            }
            else
            {
                r = dt > this._begin;
            }

            if (r)
            {
                if (IncludeEndPoint)
                {
                    r = dt <= this._end;
                }
                else
                {
                    r = dt < this._end;
                }
            }
            return r;

            //return dt >= Begin && dt <= End;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        private bool HasInRange(IEnumerable<DateTime> enumerable)
        {
            DateTime outvalue;
            return HasInRange(enumerable, out outvalue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="dtInRange"></param>
        /// <returns></returns>
        public bool HasInRange(IEnumerable<DateTime> enumerable, out DateTime dtInRange)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtr"></param>
        /// <returns></returns>
        public DateTimeRangeRelation DiscernRelation(DateTimeRange dtr)
        {
            if (dtr == null)
            {
                throw new ArgumentNullException("dtr");
            }

            bool b = this.IsInRange(dtr.Begin);
            bool e = this.IsInRange(dtr.End);

            DateTimeRangeRelation[,] table = new DateTimeRangeRelation[2, 2] {
                { DateTimeRangeRelation.Disconnection, DateTimeRangeRelation.CrossAtEnd },
                { DateTimeRangeRelation.CrossAtBegin,  DateTimeRangeRelation.Include },
            };

            DateTimeRangeRelation r = table[b ? 1 : 0, e ? 1 : 0];

            if (r == DateTimeRangeRelation.Disconnection)
            {
                if ( IsEarly (dtr.Begin ) && IsLater ( dtr.End ) )
                {
                    r = DateTimeRangeRelation.BeIncluded;
                }
            }

            return r;
        }
    }

}
