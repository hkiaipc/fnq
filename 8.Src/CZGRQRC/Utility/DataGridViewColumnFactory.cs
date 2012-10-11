using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms ;

namespace FNGRQRC.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class DataGridViewColumnFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="dgvConfigs"></param>
        static public void Create( DataGridView dgv , Xdgk.Common.DGVColumnConfigCollection dgvConfigs )
        {
            foreach (Xdgk.Common.DGVColumnConfig cc in dgvConfigs)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = cc.Text;
                column.DataPropertyName = cc.DataPropertyName;
                column.DefaultCellStyle.Format = cc.Format;
                //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns.Add(column);
            }
        }
    }
}
