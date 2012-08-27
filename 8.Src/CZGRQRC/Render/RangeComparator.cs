//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CZGRQRC
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class RangeComparator : Comparator
//    {

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="rangeValues"></param>
//        public RangeComparator(RangeValues rangeValues)
//            : base(rangeValues)
//        {
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public RangeValues RangeComparaValues
//        {
//            get { return this.CompareValues as RangeValues; }
//            set
//            {
//                if (value == null)
//                    throw new ArgumentNullException("RangeCompareValues");
//                this.CompareValues = value;
//            }
//        } 


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public override CompareResult Compare(object value)
//        {
//            float f = (float)value;
//            if (f >= this.RangeComparaValues.Min && f <= this.RangeComparaValues.Max)
//            {
//                return new CompareResult(true);
//            }
//            else
//            {
//                return new CompareResult(false);
//            }
//        }
//    }
//}
