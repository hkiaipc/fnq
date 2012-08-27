using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.GRCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class GRData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="text"></param>
        private GRData(GRDataEnum e, string text)
        {
            _grDataEnum = e;
            this._text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        public GRDataEnum GRDataEnum
        {
            get
            {
                return _grDataEnum;
            }
        } private GRDataEnum _grDataEnum;

        /// <summary>
        /// 
        /// </summary>
        private string Text
        {
            get
            {
                return _text;
            }
        } private string _text;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        static public GRData GetGRData(GRDataEnum e)
        {
            foreach (GRData d in GRDatas)
            {
                if (e == d.GRDataEnum)
                {
                    return d;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        static public string GetGRDataText(GRDataEnum e)
        {
            GRData d = GetGRData(e);
            if (d != null)
            {
                return d.Text;
            }
            else
            {
                return e.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static public GRData[] GRDatas
        {
            get
            {
                if (_grdatas == null)
                {
                    _grdatas = new GRData[] {
                        new GRData(GRDataEnum.DT, GRDataStrings.DT ),
                        new GRData(GRDataEnum.GT1, GRDataStrings.GT1),
                        new GRData(GRDataEnum.BT1, GRDataStrings.BT1),
                        new GRData(GRDataEnum.GT2, GRDataStrings.GT2),
                        new GRData(GRDataEnum.BT2, GRDataStrings.BT2),
                        new GRData(GRDataEnum.GP1, GRDataStrings.GP1),
                        new GRData(GRDataEnum.BP1, GRDataStrings.BP1),
                        new GRData(GRDataEnum.GP2, GRDataStrings.GP2),
                        new GRData(GRDataEnum.BP2, GRDataStrings.BP2),
                        new GRData(GRDataEnum.OT, GRDataStrings.OT),
                        new GRData(GRDataEnum.I1, GRDataStrings.I1),
                        new GRData(GRDataEnum.IR, GRDataStrings.IR),
                        new GRData(GRDataEnum.S1, GRDataStrings.S1),
                        new GRData(GRDataEnum.SR, GRDataStrings.SR),
                        new GRData(GRDataEnum.I2, GRDataStrings.I2),
                        new GRData(GRDataEnum.S2, GRDataStrings.S2),
                        new GRData(GRDataEnum.GTBase2, GRDataStrings.GTBase2),
                        new GRData(GRDataEnum.WL, GRDataStrings.WL),
                        new GRData(GRDataEnum.OD, GRDataStrings.OD),
                        new GRData(GRDataEnum.PA2, GRDataStrings.PA2),
                        new GRData(GRDataEnum.CM1, GRDataStrings.CM1),
                        new GRData(GRDataEnum.CM2, GRDataStrings.CM2),
                        new GRData(GRDataEnum.CM3, GRDataStrings.CM3),
                        new GRData(GRDataEnum.RM1, GRDataStrings.RM1),
                        new GRData(GRDataEnum.RM2, GRDataStrings.RM2),
                        new GRData(GRDataEnum.RM3, GRDataStrings.RM3),
                    };
                }
                return _grdatas;
            }
        } static private GRData[] _grdatas;
    }
}
