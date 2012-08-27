using System;
using System.Collections.Generic;
using System.Text;

namespace CZGRQRC
{


    /// <summary>
    /// 
    /// </summary>
    public class CompareResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isNormal"></param>
        public CompareResult(CompareResultEnum cre)
        {
            this.CompareResultEnum = cre;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsNormal
        {
            get { return this._compareResultEnum == CompareResultEnum.Normal; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAlarm
        {
            get
            {
                return !IsNormal;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CompareResultEnum CompareResultEnum
        {
            get { return _compareResultEnum; }
            set { _compareResultEnum = value; }
        } private CompareResultEnum _compareResultEnum;
    }
}
