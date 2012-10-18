using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class DataGridViewFormatters
    {
        /// <summary>
        /// 
        /// </summary>
        static public DataFormatterCollection DefaultDataFormatterCollection
        {
            get
            {
                if (_dataFormatterCollection == null)
                {
                    DataFormatterCollection s = new DataFormatterCollection();
                    s.Add(new SingleFormatter());
                    s.Add(new Int32Formatter());
                    s.Add(new DoubleFormatter());

                    //s.Add();
                    //return s;
                    _dataFormatterCollection = s;
                }
                return _dataFormatterCollection;
            }
            set { _dataFormatterCollection = value; }
        } static private DataFormatterCollection _dataFormatterCollection;
    }
}
