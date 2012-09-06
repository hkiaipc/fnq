using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Drawing;
using Xdgk.GRCommon;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        /// <param name="calcColumnInfos"></param>
        static public void AddCalcColumn(System.Data.DataTable tbl, CalcColumnInfoCollection calcColumnInfos)
        {
            foreach (CalcColumnInfo cci in calcColumnInfos)
            {
                System.Data.DataColumn dc = new System.Data.DataColumn(cci.Name);
                dc.Expression = cci.Expression;
                dc.DataType = cci.DataType;
                //Console.WriteLine(dc.DataType);
                tbl.Columns.Add(dc);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        static public void FillSupportArea(DataTable tbl)
        {
            string sql = "select StationName, SupportArea from vStationDevice";
            DataTable areatbl = CZGRQRCApp.Default.DBI.ExecuteDataTable(sql);
            foreach( DataRow row in tbl.Rows )
            {
                //row["supportarea"] = 100F;
                string displayname = row[DataColumnNames.StationName].ToString();
                DataRow[] rows = areatbl.Select(string.Format("StationName = '{0}'", displayname));
                if (rows.Length > 0)
                {
                    row[DataColumnNames.SupportArea] = rows[0][DataColumnNames.SupportArea];
                }
                else
                {
                    row[DataColumnNames.SupportArea] = 0;
                }
            }
        }
    }

    ///// <summary>
    ///// 
    ///// </summary>
    //public class CurveHelper
    //{
    //    static private Hashtable GetTable()
    //    {
    //        if (_table == null)
    //        {
    //            _table = new Hashtable();
    //            GRDataCurveConfigCollection temp = Create(
    //                GRDataEnum.GT1,
    //                GRDataEnum.BT1,
    //                GRDataEnum.GT2,
    //                GRDataEnum.BT2
    //                );
    //            _table.Add(GRCurveTypeEnum.TemperatureCurve, temp);

    //            temp = Create(
    //                GRDataEnum.GP1,
    //                GRDataEnum.BP1,
    //                GRDataEnum.GP2,
    //                GRDataEnum.BP2
    //                );
    //            _table.Add(GRCurveTypeEnum.PressureCurve, temp);
    //        }
    //        return _table;
    //    } static Hashtable _table;


    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    static private GRDataCurveConfigCollection Create(params GRDataEnum[] dataEnums )
    //    {
    //        GRDataCurveConfigCollection t = new GRDataCurveConfigCollection();
    //        foreach (GRDataEnum de in dataEnums)
    //        {
    //            GRDataCurveConfig cc = new GRDataCurveConfig(de, 1, 
    //                Xdgk.GRCommon.GRCurveType.GetGRDataCurveColor(de));
    //            t.Add(cc);
    //        }
    //        return t;
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <returns></returns>
    //    static public GRDataCurveConfigCollection GetDefaultCurveConfigCollection(GRCurveType type)
    //    {
    //        return GetTable()[type.GRCurveTypeEnum] as GRDataCurveConfigCollection;
    //    }
    //}
}
