using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace K
{
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


        static public WorkDefine Create(CycleTypeEnum cycleType)
        {
            WorkDefine r = null;
            switch (cycleType)
            {
                case CycleTypeEnum.Week :
                    r = new WeekWorkDefine();
                    break;

                case CycleTypeEnum.UserDefine :
                    r = new UserWorkDefine();
                    break;

                default:
                    throw new ArgumentException(cycleType.ToString());
            }
            return r;
        }
        //#region CycleType
        ///// <summary>
        ///// 
        ///// </summary>
        //public CycleTypeEnum CycleType
        //{
        //    get
        //    {
        //        return _cycleType;
        //    }
        //    set
        //    {
        //        _cycleType = value;
        //    }
        //} private CycleTypeEnum _cycleType = CycleTypeEnum.Week;
        //#endregion //CycleType
    }

    /// <summary>
    /// 
    /// </summary>
    public class WeekWorkDefine : WorkDefine
    {

    }

    public class UserWorkDefine : WorkDefine
    {
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

    }

}
