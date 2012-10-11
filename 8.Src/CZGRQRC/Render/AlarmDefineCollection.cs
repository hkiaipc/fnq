using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Xdgk.Common;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [XmlInclude(typeof(RangeAlarmDefine))]
    public class AlarmDefineCollection : Collection<AlarmDefine>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AlarmDefine GetAlarmDefine(string name)
        {
            foreach (AlarmDefine c in this)
            {
                if (StringHelper.Equal(c.Name, name)) 
                    return c;
            }
            return null;
        }
    }
}
