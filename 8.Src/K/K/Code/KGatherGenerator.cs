using System;
using Xdgk.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using KDB;
using NLog;

namespace K
{
    internal class KGatherGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        private KGatherGenerator()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupResults"></param>
        static internal PersonGatherCollection Generator(GroupResultCollection groupResults)
        {
            PersonGatherCollection r = new PersonGatherCollection();

            foreach (GroupResult gr in groupResults)
            {
                PersonGatherCollection pgs = Generator(gr);
                r.Add(pgs);
            }
            return r;
        }

        static private PersonGatherCollection Generator(GroupResult groupResult)
        {
            PersonGatherCollection r = new PersonGatherCollection();
            foreach (PersonResult pr in groupResult.PersonResults)
            {
                PersonGather pg = Generator(pr);
                r.Add(pg);
            }
            return r;
        }

        static private PersonGather Generator(PersonResult pr)
        {
            PersonGather pg = new PersonGather(pr.TblPerson);

            foreach (TimeResult tr in pr.TimeResults)
            {
                DateTime day = tr.TimeStandard.Begin.Date;
                Gather gather = new Gather(day, tr.StartWorkResult, tr.StopWorkResult, tr.LeaveEnum);
                pg.Gathers.AddorMerge(gather);
            }
            return pg;
        }
    }

    internal class PersonGather
    {
        /// <summary>
        /// 
        /// </summary>
        internal PersonGather(tblPerson person)
        {
            this.TblPerson = person;
        }
        #region TblPerson
        /// <summary>
        /// 
        /// </summary>
        public tblPerson TblPerson
        {
            get
            {
                return _tblPerson;
            }
            set
            {
                if ( value == null )
                {
                    throw new ArgumentNullException("TblPerson");
            }
                _tblPerson = value;
            }
        } private tblPerson _tblPerson;
        #endregion //TblPerson

        #region Gathers
        /// <summary>
        /// 
        /// </summary>
        public GatherCollection Gathers
        {
            get
            {
                if (_gathers == null)
                {
                    _gathers = new GatherCollection();
                }
                return _gathers;
            }
            set
            {
                _gathers = value;
            }
        } private GatherCollection _gathers;
        #endregion //Gathers


    }

    internal class PersonGatherCollection : Collection<PersonGather>
    {
        internal void Add(PersonGatherCollection personGathers)
        {
            foreach (PersonGather pg in personGathers)
            {
                this.Add(pg);
            }
        }
    }

    internal class Gather
    {
        //internal Gather(DateTime day, KResultEnum gatherResult, LeaveEnum leaveEnum)
        internal Gather(DateTime day, KResultEnum start, KResultEnum stop, LeaveEnum leaveEnum)
        {
            Debug.Assert(day.TimeOfDay == TimeSpan.Zero);

            this._day = day;
            //this._kResultEnum = gatherResult;
            this.AddKResultEnumPair(start, stop);
            this._leaveEnum = leaveEnum;
        }

        #region Day
        /// <summary>
        /// 
        /// </summary>
        public DateTime Day
        {
            get
            {
                return _day;
            }
        } private DateTime _day;
        #endregion //Day

        //#region KResultEnum
        ///// <summary>
        ///// 
        ///// </summary>
        //public KResultEnum KResultEnum
        //{
        //    get
        //    {
        //        return _kResultEnum;
        //    }
        //    //set
        //    //{
        //    //    _kResultEnum = value;
        //    //}
        //} private KResultEnum _kResultEnum;
        //#endregion //KResultEnum

        #region LeaveEnum
        /// <summary>
        /// 
        /// </summary>
        public LeaveEnum LeaveEnum
        {
            get { return _leaveEnum; }
            set { _leaveEnum = value; }
        } private LeaveEnum _leaveEnum;
        #endregion //LeaveEnum

        /// <summary>
        /// 
        /// </summary>
        public List<KResultEnum> KResultEnumList
        {
            get { return _listKResultEnumList; }
        } private List<KResultEnum> _listKResultEnumList = new List<KResultEnum>();

        public void AddKResultEnumPair(KResultEnum start, KResultEnum stop)
        {
            _listKResultEnumList.Add(start);
            _listKResultEnumList.Add(stop);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetGatherString()
        {
            string s = string.Empty;
            foreach (KResultEnum item in KResultEnumList)
            {
                if (item == KResultEnum.Leave)
                {
                    s += GetLeaveEnumName(this.LeaveEnum);
                }
                else
                {
                    s += GetKResultEnumName(item);
                }
            }
            return s;
        }

        static private string GetKResultEnumName(KResultEnum kResultEnum)
        {
            for (int i = 0; i < _kResultEnumNameMap.Length; i += 2)
            {
                KResultEnum k = (KResultEnum)_kResultEnumNameMap[i];
                if (k == kResultEnum)
                {
                    return (string)_kResultEnumNameMap[i + 1];
                }
            }
            return kResultEnum.ToString();
        }

        static private string GetLeaveEnumName(LeaveEnum leaveEnum)
        {
            for (int i = 0; i < _leaveEnumNameMap.Length; i += 2)
            {
                LeaveEnum l = (LeaveEnum)_leaveEnumNameMap[i];
                if (l == leaveEnum)
                {
                    return (string)_leaveEnumNameMap[i + 1];
                }
            }

            return leaveEnum.ToString();
        }

        static private object[] _kResultEnumNameMap = new object[]{
                KResultEnum.Normal,"¡Ì",
                KResultEnum.Later,"³Ù",
                KResultEnum.Early,"ÍË",

                KResultEnum.LaterEarly,"³Ùµ½ÔçÍË",
                KResultEnum.Lose,"¡ð",
                KResultEnum.Leave,"Çë¼Ù",

                KResultEnum.Out,"³ö²î",
                KResultEnum.Rest,"¡Ñ",
                KResultEnum.None,"¡ð",
            };

        static private object[] _leaveEnumNameMap = new object[] {
                LeaveEnum.Private , "x",
                LeaveEnum.Sick , "S",
                LeaveEnum.Vacation , "¡÷",
        };
    }

    internal class GatherCollection : Collection<Gather>
    {
        new internal void Add(Gather gather)
        {
            throw new NotSupportedException();
        }

        internal void AddorMerge(Gather gather)
        {
            if (gather == null)
            {
                throw new ArgumentNullException("gather");
            }

            Gather exist= Find(gather.Day);
            if (exist== null)
            {
                //this.Add(gather);
                base.Add(gather);
            }
            else
            {
                //exist.KResultEnum = KResultEnumMerger.Merge(
                //   exist.KResultEnum, gather.KResultEnum);

                exist.KResultEnumList.AddRange(gather.KResultEnumList);
            }
        }

        internal string GetSumString()
        {
            int normal = 0, le = 0;
            foreach (Gather g in this)
            {
                bool added = false;
                foreach (KResultEnum item in g.KResultEnumList)
                {
                    if (item == KResultEnum.Normal)
                    {
                        if (!added)
                        {
                            normal++;
                            added = true;
                        }
                    }
                    else if (item == KResultEnum.Later ||
                        item == KResultEnum.Early ||
                        item == KResultEnum.LaterEarly)
                    {
                        le++;
                        if (!added)
                        {
                            normal++;
                            added = true;
                        }
                    }
                }
            }

            return string.Format("³öÇÚ: {0}, ³ÙÍË: {1}",normal, le );
        }

        private Gather Find(DateTime day )
        {
            foreach (Gather item in this)
            {
                if (item.Day == day)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        internal Gather FindByDay(int day)
        {
            foreach (Gather g in this)
            {
                if (g.Day.Day == day)
                {
                    return g;
                }
            }

            if (day > 28)
            {
                return null;
            }

            throw new ArgumentException("not find by day: " + day);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class KResultEnumMerger
    {
        private KResultEnumMerger()
        {
        }

        static KResultEnum[] _priority = new KResultEnum[]
        {
            KResultEnum.Rest,
            KResultEnum.Leave,
            KResultEnum.Out,
            KResultEnum.LaterEarly,
            KResultEnum.Later,
            KResultEnum.Early,
            KResultEnum.Lose,
            KResultEnum.None,
            KResultEnum.Normal,
        };

        static public KResultEnum Merge(KResultEnum k1, KResultEnum k2)
        {
            int i1 = GetIndex(k1);
            int i2 = GetIndex(k2);
            if (i1 < i2)
            {
                return k1;
            }
            else
            {
                return k2;
            }
        }

        private static int GetIndex(KResultEnum resultEnum)
        {
            for (int i = 0; i < _priority.Length; i++)
            {
                if (_priority[i] == resultEnum)
                {
                    return i;
                }
            }

            throw new ArgumentException(
                string.Format("not find kresultEnum '{0}' at priority", 
                resultEnum));
        }
    }
}
