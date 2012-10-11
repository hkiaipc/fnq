using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class AlarmDefine
    {
        /// <summary>
        /// 
        /// </summary>
        public AlarmDefine()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public AlarmDefine(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        } private string _name;



        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get
            {
                string s = string.Empty;
                if (StringHelper.Equal(this.Name, "GT1"))
                {
                    s = strings.GT1;
                }
                else if (StringHelper.Equal(this.Name, "GT2"))
                {
                    s = strings.GT2;
                }
                else if (StringHelper.Equal(this.Name, "BT1"))
                {
                    s = strings.BT1;
                }
                else if (StringHelper.Equal(this.Name, "BT2"))
                {
                    s = strings.BT2;
                }
                else if (StringHelper.Equal(this.Name, "GP1"))
                {
                    s = strings.GP1;
                }
                else if (StringHelper.Equal(this.Name, "GP2"))
                {
                    s = strings.GP2;
                }
                else if (StringHelper.Equal(this.Name, "BP1"))
                {
                    s = strings.BP1;
                }
                else if (StringHelper.Equal(this.Name, "BP2"))
                {
                    s = strings.BP2;
                }
                else
                {
                    s = this.Name;
                }
                return s;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        abstract public CompareResult Compare(object value);
    }
}
