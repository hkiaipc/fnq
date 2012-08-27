using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using CZGRCommon;
using Xdgk.Common;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class CCCFactory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        static public CCC CreateGRDataCCC(DataGridView dgv)
        {
            return CreateGRDataLastCCC(dgv);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public CCC CreateGRDataLastCCC(DataGridView dgv)
        {
            if (dgv == null)
                throw new ArgumentNullException("null");

            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteExtraGRDeviceDataTable();
            CCC ccc = new CCC(tbl);
            string[] names = new string[] {"street", "name", "registeredArea", "supportArea" };
            foreach (string name in names)
            {
                string mapName = GetMapName(name);
                int idx = GetDataGridViewColumnDisplayIndex(mapName, dgv);
                if (idx != -1)
                {
                    ccc.List.Add(new III(name, idx + 1));
                }
            }
            //ccc.List.Add(new III("street", 1));
            //ccc.List.Add(new III("name", 2));
            return ccc; 
        }

        #region GetMapName
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static private string GetMapName(string name)
        {
            if (StringHelper.Equal(name, "name"))
                return "displayname";
            return name;
        }
        #endregion //GetMapName


        #region GetDataGridViewColumnDisplayIndex
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns>基于0的索引号，不存在返回-1</returns>
        static private int GetDataGridViewColumnDisplayIndex(string columnName, DataGridView dgv)
        {
            int idx = -1;
            DataGridViewColumn dgvc = dgv.Columns[columnName];
            if (dgvc != null)
            {
                idx = dgvc.DisplayIndex;
            }
            return idx;
        }
        #endregion //GetDataGridViewColumnDisplayIndex
    }
}
