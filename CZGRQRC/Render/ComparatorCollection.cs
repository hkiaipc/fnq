//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xdgk.Common;
//namespace CZGRQRC
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class ComparatorCollection : Collection<Comparator>
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="name"></param>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public CompareResult Compare(string name, object value)
//        {
//            Comparator c = GetComparator(name);
//            if (c == null)
//            {
//                throw new InvalidOperationException(string.Format("not find compare name '{0}'", name));
//            }

//            return c.Compare(value);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="name"></param>
//        /// <returns></returns>
//        public Comparator GetComparator(string name)
//        {
//            foreach (Comparator c in this)
//            {
//                if (StringHelper.Equal(c.CompareValues.Name, name))
//                {
//                    return c;
//                }
//            }
//            return null;
//        }
//    }
//}
