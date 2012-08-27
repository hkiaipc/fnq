using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CZGRCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class CCC
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        public CCC(DataTable tbl)
        {
            this.DataTable = tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        public DataTable DataTable
        {
            get { return _tbl; }
            set {
                if (value == null)
                    throw new ArgumentNullException("DataTable");
                _tbl = value;
            }
        } private DataTable _tbl;

        /// <summary>
        /// 
        /// </summary>
        public List<III> List
        {
            get { return _list; }
        } private List<III> _list = new List<III>();
    }

}
