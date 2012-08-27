using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class T
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeout"></param>
        public T(TimeSpan timeout)
        {
            this.TimeOut = timeout;
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Last
        {
            get { return _last; }
            set { _last = value; }
        } private DateTime _last;

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan TimeOut
        {
            get { return _timeOut; }
            set 
            {
                if (value < TimeSpan.FromSeconds(1))
                    throw new ArgumentOutOfRangeException("TimeOut", value, "must >= 1s");
                _timeOut = value; 
            }
        } private TimeSpan _timeOut = TimeSpan.FromSeconds(10);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsTimeOut()
        {
            return IsTimeOut(DateTime.Now);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsTimeOut( DateTime dt)
        {
            TimeSpan ts = dt - this.Last;
            if (ts >= TimeOut || ts < TimeSpan.Zero)
                return true;
            else
                return false;
        }
    }

    #region DataGirdViewColumnHelper
    /// <summary>
    /// 
    /// </summary>
    public class DataGirdViewColumnHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="configs"></param>
        static public void InitDataGridViewColumns(DataGridView dgv, DGVColumnConfigCollection configs)
        {
            dgv.AutoGenerateColumns = false;
           foreach (DGVColumnConfig cc in configs)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = cc.DataPropertyName;
                column.HeaderText = cc.Text;
                column.DataPropertyName = cc.DataPropertyName;
                column.DefaultCellStyle.Format = cc.Format;
                //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                column.Width = cc.Width;
                dgv.Columns.Add(column);
            }
        }
    }
    #endregion //DataGirdViewColumnHelper
}
