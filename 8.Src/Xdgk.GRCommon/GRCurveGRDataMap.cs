using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Xdgk.GRCommon
{
    /// <summary>
    /// 
    /// </summary>
    internal class GRCurveGRDataMap
    {
        /// <summary>
        /// 
        /// </summary>
        static private Hashtable Table
        {
            get
            {
                if (_table == null)
                {
                    _table = new Hashtable();
                    _table.Add(GRCurveTypeEnum.TemperatureCurve, new GRDataEnum[] { GRDataEnum.GT1,
                        GRDataEnum.BT1, GRDataEnum.GT2, GRDataEnum.BT2});

                    _table.Add(GRCurveTypeEnum.PressureCurve, new GRDataEnum[] {
                        GRDataEnum.GP1, GRDataEnum.BP1, GRDataEnum.GP2, GRDataEnum.BP2 });

                    _table.Add(GRCurveTypeEnum.OTCurve, new GRDataEnum[] { GRDataEnum.OT });

                    _table.Add(GRCurveTypeEnum.FluxCurve, new GRDataEnum[] { GRDataEnum.I1 });
                    _table.Add(GRCurveTypeEnum.HeatCurve, new GRDataEnum[] { GRDataEnum.WL});
                }
                return _table;
            }
        } static private Hashtable _table;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        static internal GRDataEnum[] GetGRDataEnums(GRCurveTypeEnum e)
        {
            object obj = Table[e];
            if (obj != null)
            {
                return (GRDataEnum[])obj;
            }
            else
            {
                return null;
            }
        }
    }
}
