using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace K
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    abstract public class WorkDefine
    {

        #region Create WorkDefine
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cycleType"></param>
        /// <returns></returns>
        static public WorkDefine Create(CycleTypeEnum cycleType)
        {
            WorkDefine r = null;
            switch (cycleType)
            {
                case CycleTypeEnum.Week:
                    r = new WeekWorkDefine();
                    break;

                case CycleTypeEnum.UserDefine:
                    r = new UserWorkDefine();
                    break;

                default:
                    throw new ArgumentException(cycleType.ToString());
            }
            return r;
        }
        #endregion //

        #region Serialize
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wd"></param>
        /// <returns></returns>
        static public string Serialize(WorkDefine wd)
        {
            XmlSerializer s = new XmlSerializer(typeof(SerializableObject));
            StringWriter sw = new StringWriter();
            s.Serialize(sw, new SerializableObject(wd));
            return sw.ToString();
        }
        #endregion //Serialize

        #region Deserialize
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        static public WorkDefine Deserialize(string context)
        {
            XmlSerializer s = new XmlSerializer(typeof(SerializableObject));
            StringReader sr = new StringReader(context);
            SerializableObject serObject = s.Deserialize(sr) as SerializableObject;
            WorkDefine wd = serObject.Object as WorkDefine ;

            Debug.Assert(wd != null, "Deserialize WorkDefine error");
            return wd;

        }
        #endregion //Deserialize

        #region WorkDefine
        /// <summary>
        /// 
        /// </summary>
        protected WorkDefine()
        {
        }
        #endregion //WorkDefine

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

        #region //CycleType
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
        #endregion //CycleType

        #region CreateTimeStandards
        abstract internal TimeStandardCollection CreateTimeStandards(DateTime month);
        #endregion //CreateTimeStandards
    }
}
