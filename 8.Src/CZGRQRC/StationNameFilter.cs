using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace CZGRQRC
{
    ///// <summary>
    ///// 
    ///// </summary>
    //public class StationNameFilter
    //{
    //    static public StationNameFilter Default = new StationNameFilter();

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="tbl"></param>
    //    public void Process(DataTable tbl)
    //    {
    //        this.InitRemoveReplaceNames();
    //        this.RemoveRows(tbl);
    //        this.ReplaceDisplayNames(tbl);
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    private string[] _removedNames;

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    private Hashtable _replaceNames;

    //    #region InitRemoveReplaceNames
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public void InitRemoveReplaceNames()
    //    {
    //        //this._removedNames = CZGRQRCApp.Default.DBI.ReadCalcHeatRemovedNames();
    //        //this._replaceNames = CZGRQRCApp.Default.DBI.ReadCalcHeatReplaceNames();
    //    }
    //    #endregion //InitRemoveReplaceNames

    //    #region RemoveRows
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="tbl"></param>
    //    public void RemoveRows(DataTable tbl)
    //    {
    //        if (this._removedNames.Length > 0)
    //        {
    //            string s = string.Empty;
    //            int i = 0;
    //            for (; i < this._removedNames.Length - 1; i++)
    //            {
    //                s += string.Format("'{0}',", this._removedNames[i]);
    //            }
    //            s += string.Format("'{0}'", this._removedNames[i]);

    //            s = string.Format("{0} IN ({1})", DataColumnNames.StationName, s);
    //            DataRow[] rows = tbl.Select(s);

    //            foreach (DataRow r in rows)
    //                tbl.Rows.Remove(r);
    //        }
    //    }
    //    #endregion //RemoveRows

    //    #region ReplaceDisplayNames
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="tbl"></param>
    //    public void ReplaceDisplayNames(DataTable tbl)
    //    {
    //        foreach (DataRow row in tbl.Rows)
    //        {
    //            string displayName = row[DataColumnNames.StationName].ToString();
    //            object newNameObj = this._replaceNames[displayName];
    //            if (newNameObj != null)
    //            {
    //                string newName = newNameObj.ToString();
    //                row[DataColumnNames.StationName] = newName;
    //            }
    //        }
    //    }
    //    #endregion //ReplaceDisplayNames

    //}
}
