//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CZGRQRC
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    abstract public class Comparator
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="name"></param>
//        public Comparator(CompareValues compareValues)
//        {
//            //this.Name = name;
//            this.CompareValues = compareValues;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public CompareValues CompareValues
//        {
//            get { return _compareValues; }
//            set
//            {
//                if (value == null)
//                    throw new ArgumentNullException("CompareValues");
//                _compareValues = value;
//            }
//        } private CompareValues _compareValues;


//        ///// <summary>
//        ///// 
//        ///// </summary>
//        //public string Name
//        //{
//        //    get { return _name; }
//        //    set 
//        //    {
//        //        if (value == null || value.Trim().Length == 0)
//        //            throw new ArgumentException("name null or empty");
//        //        _name = value; 
//        //    }
//        //} private string _name;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public abstract CompareResult Compare(object value);
//    }
//}
