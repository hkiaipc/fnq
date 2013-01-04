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
    public class DateTimeRange
    {
        public enum PriorityEnum
        {
            PriorityFirst,
            PriorityLast,
        }

        #region IncludeBeginPoint
        /// <summary>
        /// 
        /// </summary>
        public bool IncludeBeginPoint
        {
            get { return _includeBeginPoint; }
            set { _includeBeginPoint = value; }
        } private bool _includeBeginPoint = true;
        #endregion //IncludeBeginPoint

        #region IncludeEndPoint
        /// <summary>
        /// 
        /// </summary>
        public bool IncludeEndPoint
        {
            get { return _includeEndPoint; }
            set { _includeEndPoint = value; }
        } private bool _includeEndPoint = false;
        #endregion //IncludeEndPoint

        #region DateTimeRange
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
        #endregion //DateTimeRange

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

        #region IsEarly
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
        #endregion //IsEarly

        #region IsLater
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
        #endregion //IsLater

        #region IsInRange
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
        #endregion //IsInRange


        #region HasInRange
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
        #endregion //HasInRange

        #region HasInRange

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="dtInRange"></param>
        /// <returns></returns>
        public bool HasInRange(IEnumerable<DateTime> enumerable, out DateTime dtInRange)
        {
            return HasInRange(enumerable, PriorityEnum.PriorityFirst, out dtInRange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="dtInRange"></param>
        /// <returns></returns>
        public bool HasInRange(IEnumerable<DateTime> enumerable, PriorityEnum priority, out DateTime dtInRange)
        {
            dtInRange = DateTime.MinValue;

            IEnumerable<DateTime> r = this.GetInRange(enumerable);
            bool has = r.Count() > 0;
            if (has)
            {
                dtInRange = priority == PriorityEnum.PriorityFirst ? r.First() : r.Last();
            }

            return has;
        }
        #endregion //HasInRange

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public IEnumerable<DateTime> GetInRange(IEnumerable<DateTime> enumerable)
        {
            List<DateTime> r = new List<DateTime>();
            foreach (DateTime dt in enumerable)
            {
                if (IsInRange(dt))
                {
                    r.Add(dt);
                }
            }
            return r; 
        }

        #region DiscernRelation
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
                // e = false                           e = true 
                { DateTimeRangeRelation.Disconnection, DateTimeRangeRelation.CrossAtBegin }, // b = false
                { DateTimeRangeRelation.CrossAtEnd,    DateTimeRangeRelation.Include },      // b = true
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
        #endregion //DiscernRelation

        #region ToString
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = string.Format("{0}{1} ~ {2}{3}",
                _includeBeginPoint ? '[' : '(', this._begin,
                this._end, _includeEndPoint ? ']' : ')'
                );
            return s;
        }
        #endregion //ToString
    }
}
