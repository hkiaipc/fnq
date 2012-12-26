using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace K
{
    [Serializable]
    [XmlInclude(typeof(WeekWorkDefine))]
    [XmlInclude(typeof(UserWorkDefine))]
    [XmlInclude(typeof(WeekTimeDefine))]
    [XmlInclude(typeof(UserTimeDefine))]
    public class SerializableObject
    {
        #region SerializableObject
        public SerializableObject()
        {
        }
        #endregion //SerializableObject

        #region SerializableObject
        public SerializableObject(object obj)
        {
            this.Object = obj;
        }
        #endregion //SerializableObject

        #region Object
        /// <summary>
        /// 
        /// </summary>
        public object Object
        {
            get
            {
                return _object;
            }
            set
            {
                _object = value;
            }
        } private object _object;
        #endregion //Object
    }


    class d__b5
    {
        //public int <>3__count;
        //public TResult <>3__element;
        //private int <>l__initialThreadId;
    }

}
