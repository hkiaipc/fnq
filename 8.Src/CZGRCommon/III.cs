using System;
using System.Collections.Generic;
using System.Text;

namespace CZGRCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class III
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="xlsColumn"></param>
        public III(string columnName, int xlsColumn)
        {
            this.ColumnName = columnName;
            this.XlsColumn = xlsColumn; ;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        } private string _columnName;

        /// <summary>
        /// 
        /// </summary>
        public int XlsColumn
        {
            get { return _xlsColumn; }
            set 
            {
                if (value < 1)
                    throw new ArgumentException("value must >= 1");
                _xlsColumn = value; 
            }
        } private int _xlsColumn;
    }
}
