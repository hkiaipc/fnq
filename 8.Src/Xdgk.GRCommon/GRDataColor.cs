using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace Xdgk.GRCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class GRDataColorMap
    {
        #region ColorTable
        /// <summary>
        /// 
        /// </summary>
        static private Hashtable ColorTable
        {
            get 
            {
                if( _colorTable == null )
                {
                    InitColorTable();
                }
                return _colorTable;
            }
        } static private Hashtable _colorTable;
        #endregion //ColorTable

        #region InitColorTable
        /// <summary>
        /// 
        /// </summary>
        static private void InitColorTable()
        {
            object[][] maps = new object[][] 
            {
                new object[]{GRDataEnum.GT1, Color.Red},
                new object[]{GRDataEnum.BT1, Color.Purple},
                new object[]{GRDataEnum.GT2, Color.FromArgb(255,0,255)}, 
                new object[]{GRDataEnum.BT2, Color.Green}, 
                new object[]{GRDataEnum.OT, Color.Blue},

                new object[]{GRDataEnum.GP1, Color.Red},
                new object[]{GRDataEnum.BP1, Color.Purple},
                new object[]{GRDataEnum.GP2, Color.FromArgb(255,0,255)}, 
                new object[]{GRDataEnum.BP2, Color.Green},

                new object[]{GRDataEnum.I1, Color.Red},
                //new object[]{GRDataEnum.H1, Color.RosyBrown}

                
            };

            _colorTable = new Hashtable();
            foreach (object[] a in maps)
            {
                _colorTable.Add(a[0], a[1]);
            }
        }
        #endregion //InitColorTable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataEnum"></param>
        /// <returns></returns>
        static public Color GetGRDataCurveColor(GRDataEnum dataEnum)
        {
            object obj = ColorTable[dataEnum];
            if (obj != null)
            {
                return (Color)obj;
            }
            else
            {
                return Color.Black;
            }
        }
    }

}
