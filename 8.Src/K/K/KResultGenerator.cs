using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using KDB;
using Xdgk.Common;

namespace K
{
    internal class KResultGenerator
    {

        private DB _db;
        private DateTime _monthForGenerator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        internal KResultGenerator(DB db, DateTime monthForGenerator)
        {
            Debug.Assert(db != null);

            _db = db;
        }

        /// <summary>
        /// 
        /// </summary>
        internal GroupResultCollection Generate()
        {
            //_kResults = new KResultCollection();
            GroupResultCollection groupResults = new GroupResultCollection();

            foreach (tblGroup gp in _db.tblGroup.ToList())
            {
                //foreach (tblPerson p in gp.tblPerson.ToList())
                //{

                //}
                GroupResult gpResult = GenerateGroupResult(gp);
                groupResults.Add(gpResult);
            }
            return groupResults;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gp"></param>
        /// <returns></returns>
        private GroupResult GenerateGroupResult(tblGroup gp)
        {
            GroupResult gpResult = new GroupResult();
            //foreach (tblPerson person in gp.tblPerson)
            //{
                gpResult.TblGroup = gp;
                List<tblPerson> persons = gp.tblPerson.ToList();
                gpResult.PersonResults = GeneratePersonResultCollection(persons);
            //}
            return gpResult;
        }

        private PersonResultCollection GeneratePersonResultCollection(List<tblPerson> persons)
        {
            PersonResultCollection r = new PersonResultCollection();
            foreach (tblPerson person in persons)
            {
                PersonResult personResult = GeneratePersonResult(person);
                r.Add(personResult);
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        private PersonResult GeneratePersonResult(tblPerson person)
        {
            PersonResult r = new PersonResult();
            r.TblPerson = person;

            r.TimeResults = GenerateTimeResultCollection(person.tblGroup.tblWorkDefine);
            return r;
        }

        private TimeResultCollection GenerateTimeResultCollection(tblWorkDefine workDefine)
        {
            TimeResultCollection timeResults = new TimeResultCollection();
            TimeStandardCollection timeStandards = GenerateTimeStandards(workDefine, _monthForGenerator);
            foreach (TimeStandard timeStandard in timeStandards)
            {
                TimeResult timeResult = GenerateTimeResult(timeStandard);
                timeResults.Add(timeResult);
            }
            return timeResults;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeStandard"></param>
        /// <returns></returns>
        private TimeResult GenerateTimeResult(TimeStandard timeStandard)
        {
            List<tblTmData> tmDatas = null;
            List<tblLeave> leaves = null;

            TimeResult r = new TimeResult();
            r.TimeStandard = timeStandard;

        }

        private TimeStandardCollection GenerateTimeStandards(tblWorkDefine workDefine, DateTime monthForGenerator)
        {
            // TODO: get timedefines
            //
            TimeDefineCollection timeDefines = null;
            TimeStandardCollection timeStandards = new TimeStandardCollection();
            return timeStandards;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //internal KResultCollection KResults
        //{
        //    get
        //    {
        //        return _kResults;
        //    }
        //} private KResultCollection _kResults;

        private KResultEnum CheckLeave(List<tblLeave> leaves, TimeStandard timeStandard)
        {
            KResultEnum r = KResultEnum.None;
            foreach (tblLeave item in leaves)
            {
                //if ( item.
                if (item.IsInLeave(timeStandard))
                {
                    r = (KResultEnum)item.LeaveType;
                }
            }
            return r;
        }

        private KResultEnum CheckTime(List<tblTmData> tmDatas, TimeStandard timeStandard)
        {

        }
    }

    internal static class tblLeaveEx
    {
        static public bool IsInLeave(this tblLeave leave, DateTime dt)
        {
            return dt >= leave.LeaveBegin && dt <= leave.LeaveEnd;
        }

        static public bool IsInLeave(this tblLeave leave, TimeStandard timeStandard)
        {
            return (leave.IsInLeave(timeStandard.Begin) || leave.IsInLeave(timeStandard.End));
        }
    }


    internal class GroupResult
    {
        #region TblGroup
        /// <summary>
        /// 
        /// </summary>
        public tblGroup TblGroup
        {
            get
            {
                if (_tblGroup == null)
                {
                    _tblGroup = new tblGroup();
                }
                return _tblGroup;
            }
            set
            {
                _tblGroup = value;
            }
        } private tblGroup _tblGroup;
        #endregion //TblGroup

        #region PersonResults
        /// <summary>
        /// 
        /// </summary>
        public PersonResultCollection PersonResults
        {
            get
            {
                if (_personResults == null)
                {
                    _personResults = new PersonResultCollection();
                }
                return _personResults;
            }
            set
            {
                _personResults = value;
            }
        } private PersonResultCollection _personResults;
        #endregion //PersonResults
    }

    internal class GroupResultCollection : Collection<GroupResult>
    {
    }

    internal class PersonResult
    {
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
                _tblPerson = value;
            }
        } private tblPerson _tblPerson;
        #endregion //TblPerson

        #region TimeResults
        /// <summary>
        /// 
        /// </summary>
        public TimeResultCollection TimeResults
        {
            get
            {
                //if (_timeResults == null)
                //{
                //    _timeResults = new TimeResultCollection();
                //}
                return _timeResults;
            }
            set
            {
                _timeResults = value;
            }
        } private TimeResultCollection _timeResults;
        #endregion //TimeResults

    }

    internal class PersonResultCollection : Collection<PersonResult>
    {
    }


    internal class TimeStandard
    {
        #region Date
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        } private DateTime _date;
        #endregion //Date

        #region DayOfWeek
        /// <summary>
        /// 
        /// </summary>
        public DayOfWeek DayOfWeek
        {
            get
            {
                return _dayOfWeek;
            }
            set
            {
                _dayOfWeek = value;
            }
        } private DayOfWeek _dayOfWeek;
        #endregion //DayOfWeek

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
            set
            {
                _begin = value;
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
            set
            {
                _end = value;
            }
        } private DateTime _end;
        #endregion //End

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTimes"></param>
        /// <returns></returns>
        public KResultEnum Check(List<DateTime> dateTimes)
        {
            // 1. has dt in begin - 2 hour then normal
            //    not normal: has dt in begin + 2 hour then later
            //
            // 2. has dt in end + 2 hour then normal
            //    not normal: has dt in end - 2 hour then early
            // 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool IsInTime(DateTime dt)
        {
            return dt >= this.Begin && dt <= this.End;
        }
    }

    internal class TimeStandardCollection : Collection<TimeStandard>
    {

    }

    internal class TimeResult
    {
        #region TimeStandard
        /// <summary>
        /// 
        /// </summary>
        public TimeStandard TimeStandard
        {
            get
            {
                return _timeStandard;
            }
            set
            {
                _timeStandard = value;
            }
        } private TimeStandard _timeStandard;
        #endregion //TimeStandard

        #region KQResultEnum
        /// <summary>
        /// 
        /// </summary>
        public KResultEnum KResultEnum
        {
            get
            {
                return _kResultEnum;
            }
            set
            {
                _kResultEnum = value;
            }
        } private KResultEnum _kResultEnum;
        #endregion //KQResultEnum

        #region PracticeBegin
        /// <summary>
        /// 
        /// </summary>
        public DateTime PracticeBegin
        {
            get
            {
                return _practiceBegin;
            }
            set
            {
                _practiceBegin = value;
            }
        } private DateTime _practiceBegin;
        #endregion //PracticeBegin

        #region PracticeEnd
        /// <summary>
        /// 
        /// </summary>
        public DateTime PracticeEnd
        {
            get
            {
                return _practiceEnd;
            }
            set
            {
                _practiceEnd = value;
            }
        } private DateTime _practiceEnd;
        #endregion //PracticeEnd
        #region Remark
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get
            {
                if (_remark == null)
                {
                    _remark = string.Empty;
                }
                return _remark;
            }
            set
            {
                _remark = value;
            }
        } private string _remark;
        #endregion //Remark
    }

    internal class TimeResultCollection : Collection<TimeResult>
    {
    }

}
