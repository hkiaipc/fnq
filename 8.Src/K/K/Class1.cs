using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Xdgk.Common;

namespace K
{
    class KConfigException : Exception
    {
        public KConfigException(string msg)
            : base(msg)
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    class Class1
    {
    }

    abstract class IDBase
    {
        #region ID
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        } private int _id;
        #endregion //ID
    }

    [Serializable]
    public class TimeDefine
    {
        #region Begin
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public TimeSpan Begin
        {
            get
            {
                //return this.BeginTime.TimeOfDay;
                return TimeSpan.Parse(this.BeginTime);
            }
            set
            {
                this.BeginTime = value.ToString();
            }
        }
        #endregion //Begin

        #region End
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public TimeSpan End
        {
            get
            {
                return TimeSpan.Parse(this.EndTime);
            }
            set
            {
                this.EndTime = value.ToString ();
            }
        }
        #endregion //End

        #region BeginDT
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Begin")]
        public string BeginTime
        {
            get
            {
                return _beginTime;
            }
            set
            {
                _beginTime = value;
            }
        } private string _beginTime;
        #endregion //BeginDT

        #region EndDT
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("End")]
        public string EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        } private string _endTime;
        #endregion //EndDT


        #region DayOffset
        /// <summary>
        /// 
        /// </summary>
        public int DayOffset
        {
            get
            {
                return _dayOffset;
            }
            set
            {
                _dayOffset = value;
            }
        } private int _dayOffset;
        #endregion //DayOffset

        #region IsCrossDay
        /// <summary>
        /// 
        /// </summary>
        public bool IsCrossDay
        {
            get
            {
                return this.Begin >= this.End;
            }
            //set
            //{
                //_isCrossDay = value;
            //}
        } //private bool _isCrossDay;
        #endregion //IsCrossDay

        #region Hold
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan Hold
        {
            get
            {
                TimeSpan ts = this.Begin - this.End;
                if (IsCrossDay)
                {
                    ts += TimeSpan.Parse("24:00:00");
                }
                return ts;
            }
        }
        #endregion //Hold

    }

    [Serializable]
    public class TimeDefineCollection : Collection<TimeDefine>
    {
        protected override void InsertItem(int index, TimeDefine item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                TimeDefine td = this[i];
                if (TimeDefineHelper.IsOverlapped(td, item))
                {
                    string msg = string.Format(
                        "{0} {1} is overlapped", 
                        td, item);
                    throw new KConfigException(msg);
                }
            }
            base.InsertItem(index, item);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class TimeDefineHelper
    {
        static public bool IsOverlapped(TimeDefine td1, TimeDefine td2)
        {
            // TODO: check timedefine overlapped
            //
            TimeSpan td1Begin = td1.Begin + TimeSpan.FromDays(td1.DayOffset);
            TimeSpan td1End = td1.End + TimeSpan.FromDays(td1.DayOffset);
            if (td1.IsCrossDay)
            {
                td1End += TimeSpan.FromDays(1d);
            }

            TimeSpan td2Begin = td2.Begin + TimeSpan.FromDays(td2.DayOffset);
            TimeSpan td2End = td2.End + TimeSpan.FromDays(td2.DayOffset);
            if (td2.IsCrossDay)
            {
                td2End += TimeSpan.FromDays(1d);
            }

            if ((td2Begin >= td1Begin && td2Begin <= td1End) ||
                (td2End >= td1Begin && td2End <= td1End))
            {
                return true;
            }

            return false;
        }
    }

    [Serializable]
    public class WorkDefine
    {

        static public string Serialize(WorkDefine wd)
        {
            XmlSerializer s = new XmlSerializer(typeof(WorkDefine));
            StringWriter sw = new StringWriter();
            s.Serialize(sw, wd);
            return sw.ToString();
        }

        static public WorkDefine Deserialize(string context)
        {
            XmlSerializer s = new XmlSerializer(typeof(WorkDefine));
            StringReader sr = new StringReader(context);
            WorkDefine wd = s.Deserialize(sr) as WorkDefine;

            Debug.Assert(wd != null, "Deserialize WorkDefine error");
            return wd;

        }


        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name

        #region DayOfCycle
        /// <summary>
        /// 
        /// </summary>
        public int DayOfCycle
        {
            get
            {
                return _dayOfCycle;
            }
            set
            {
                Debug.Assert(_dayOfCycle >= 1);
                _dayOfCycle = value;
            }
        } private int _dayOfCycle = 7;
        #endregion //DayOfCycle

        #region StartDateTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDateTime
        {
            get
            {
                return _startDateTime;
            }
            set
            {
                _startDateTime = value;
            }
        } private DateTime _startDateTime = DateTime.Parse("2000-01-01");
        #endregion //StartDateTime

        #region TimeDefines
        /// <summary>
        /// 
        /// </summary>
        public TimeDefineCollection TimeDefines
        {
            get
            {
                if (_timeDefines == null)
                {
                    _timeDefines = new TimeDefineCollection();
                }
                return _timeDefines;
            }
            set
            {
                _timeDefines = value;
            }
        } private TimeDefineCollection _timeDefines;
        #endregion //TimeDefines

        #region CycleType
        /// <summary>
        /// 
        /// </summary>
        public CycleTypeEnum CycleType
        {
            get
            {
                return _cycleType;
            }
            set
            {
                _cycleType = value;
            }
        } private CycleTypeEnum _cycleType = CycleTypeEnum.Week;
        #endregion //CycleType
    }

    public class WorkDefineCollection : Collection<WorkDefine>
    {
    }

    class Person : IDBase
    {
        #region Tm
        /// <summary>
        /// 
        /// </summary>
        public Tm Tm
        {
            get
            {
                if (_tm == null)
                {
                    _tm = GetTmByPersonID(this.ID);
                }
                return _tm;
            }
            set
            {
                _tm = value;
            }
        } private Tm _tm;
        #endregion //Tm

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Tm GetTmByPersonID(int personID)
        {
            // TODO:
            //
            throw new NotImplementedException();
        }

        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name
    }

    class PersonCollection : Collection<Person>
    {
    }

    class Group : IDBase
    {
        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name

        #region Persons
        /// <summary>
        /// 
        /// </summary>
        public PersonCollection Persons
        {
            get
            {
                if (_persons == null)
                {
                    _persons = new PersonCollection();
                }
                return _persons;
            }
            set
            {
                _persons = value;
            }
        } private PersonCollection _persons;
        #endregion //Persons
    }

    class GroupCollection : Collection<Group>
    {
    }

    enum LeaveEnum
    {
        Private = 0,
        Sick = 1,
        Vacation = 2,
        //Out = 3,
    }

    class Leave
    {
        #region LeaveEnum
        /// <summary>
        /// 
        /// </summary>
        public LeaveEnum LeaveEnum
        {
            get
            {
                return _leaveEnum;
            }
            set
            {
                _leaveEnum = value;
            }
        } private LeaveEnum _leaveEnum;
        #endregion //LeaveEnum

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

    }

    class LeaveCollection : Collection<Leave>
    {
    }

    enum KResultEnum
    {
        Normal = 0,
        Later = 1,
        Early = 2,
        LaterEarly = 3,
        Lose = 4,
        Leave = 5,
        Out = 6,
        Rest = 7,
        None = 999,
    }

    //class KResult
    //{
    //}

    //class KResultCollection : Collection<KResult>
    //{
    //}

    class Tm : IDBase
    {
        #region SN
        /// <summary>
        /// 
        /// </summary>
        public string SN
        {
            get
            {
                if (_sN == null)
                {
                    _sN = string.Empty;
                }
                return _sN;
            }
            set
            {
                _sN = value;
            }
        } private string _sN;
        #endregion //SN

        #region TmDatas
        /// <summary>
        /// 
        /// </summary>
        public TmDataCollection TmDatas
        {
            get
            {
                if (_tmDatas == null)
                {
                    _tmDatas = new TmDataCollection();
                }
                return _tmDatas;
            }
            set
            {
                _tmDatas = value;
            }
        } private TmDataCollection _tmDatas;
        #endregion //TmDatas

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public TmDataCollection GetTmDatas(string begin, string end)
        {
            throw new NotImplementedException();
        }
    }

    class TmCollection : Collection<Tm>
    {
    }

    class TmData : IDBase
    {
        #region DT
        /// <summary>
        /// 
        /// </summary>
        public DateTime DT
        {
            get
            {
                return _dT;
            }
            set
            {
                _dT = value;
            }
        } private DateTime _dT;
        #endregion //DT
    }

    class TmDataCollection : Collection<TmData>
    {
    }

}
