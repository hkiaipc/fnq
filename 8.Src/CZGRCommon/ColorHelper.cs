using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;

namespace CZGRCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class ColorHelper
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
                new object[]{strings.GT1, Color.Red},
                new object[]{strings.BT1, Color.Purple},
                new object[]{strings.GT2, Color.FromArgb(255,0,255)}, 
                new object[]{strings.BT2, Color.Green}, 
                new object[]{strings.OT, Color.Blue},

                new object[]{strings.GP1, Color.Red},
                new object[]{strings.BP1, Color.Purple},
                new object[]{strings.GP2, Color.FromArgb(255,0,255)}, 
                new object[]{strings.BP2, Color.Green},

                new object[]{strings.I1, Color.Yellow},
                new object[]{strings.H1, Color.RosyBrown}

                
            };

            _colorTable = new Hashtable();
            foreach (object[] a in maps)
            {
                _colorTable.Add(a[0], a[1]);
            }
        }
        #endregion //InitColorTable

        #region GetLineColor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineName"></param>
        /// <returns></returns>
        static public  Color GetLineColor(string lineName)
        {
            return (Color)ColorTable[lineName];
        }
        #endregion //GetLineColor
    }
}
