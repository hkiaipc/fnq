using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class DataGridViewCellFormatter
    {
        static NLog.Logger logger = NLog.LogManager.GetLogger("console");
        /// <summary>
        /// 
        /// </summary>
        public DataGridViewCellFormatter()
        {
        }

        /// <summary>
        /// 格式化泵状态文字
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="e"></param>
        static public void FormatPumpText(DataGridView dgv, DataGridViewCellFormattingEventArgs e)
        {
            // TODO:
            //
            string name = dgv.Columns[e.ColumnIndex].DataPropertyName;
            if (IsPumpName(name))
            {
                bool b = (bool)e.Value;
                e.Value = b ? strings.Run : strings.Stop;

                e.FormattingApplied = true;
            }
            //// 1. data name 
            //ComparatorCollection comparators = CZGRQRCApp.Default.ComparatorCollection;
            //Comparator c = comparators.GetComparator(name);
            //if (c != null)
            //{
            //    CompareResult cr = c.Compare(e.Value);
            //    // 2. compare
            //    // 3. set forecolor
            //    ForeColorRenderer render = new ForeColorRenderer();
            //    render.Render(new CellStyleBackForeColor(e.CellStyle), cr, Config.Default.ColorConifg);
            //}

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="e"></param>
        static public void FormatExceptionColor( DataGridView dgv, DataGridViewCellFormattingEventArgs e )
        {
            //dgv.DataSource 
            object dtobj = dgv.Rows[e.RowIndex].Cells["DT"].Value;
            DateTime currentRowDT = (DateTime)dtobj;

            //Console.WriteLine(dtobj );
            string name = dgv.Columns[e.ColumnIndex].DataPropertyName;
            // 1. data name 
            //ComparatorCollection comparators = CZGRQRCApp.Default.ComparatorCollection;
            //Comparator c = comparators.GetComparator(name);
            AlarmDefineCollection cvs = CZGRQRCApp.Default.AlarmDefineCollection;
            AlarmDefine c = cvs.GetAlarmDefine(name);
            if (c != null)
            {
                CompareResult cr = c.Compare(e.Value);

                e.CellStyle = DataGridViewCellStyleManager.GetCellStyle(e.CellStyle, cr);
            }
        }

        ///// <summary>
        ///// 设置报警相关数据的颜色
        ///// </summary>
        ///// <param name="dgv"></param>
        ///// <param name="e"></param>
        //static public void FormatGRAlarmValueColor(DataGridView dgv, DataGridViewCellFormattingEventArgs e)
        //{
        //    // dataname
        //    //
        //    string name = dgv.Columns[e.ColumnIndex].DataPropertyName;
        //    //if (name == "BP2")
        //    {
        //        string displayName = dgv.Rows[e.RowIndex].Cells[DataColumnNames.DisplayName].Value.ToString();
        //        bool b = CZGRQRCApp.Default.UCAlarm.HasAlarm(displayName, name);
        //        CompareResult cr = new CompareResult(!b);
        //        //cr = new CompareResult(false);
        //        ForeColorRenderer render = new ForeColorRenderer();
        //        render.Render(new CellStyleBackForeColor(e.CellStyle), cr, Config.Default.ColorConifg);
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        public class DataGridViewCellStyleManager
        {
            static private Hashtable _h = new Hashtable();   
            /// <summary>
            /// 
            /// </summary>
            /// <param name="cr"></param>
            /// <returns></returns>
            static public DataGridViewCellStyle GetCellStyle(DataGridViewCellStyle baseCellStyle, CompareResult cr)
            {
                DataGridViewCellStyle cs = baseCellStyle;
                if (Config.Default.RendererType == RendererType.Fore)
                {
                    switch (cr.CompareResultEnum)
                    {
                        case CompareResultEnum.Normal:
                            cs.ForeColor = Config.Default.ColorConifg.NormalColor;
                            break;

                        case CompareResultEnum.LowAlarm:
                            cs.ForeColor = Config.Default.ColorConifg.LowColor;
                            break;

                        case CompareResultEnum.HighAlarm:
                            cs.ForeColor = Config.Default.ColorConifg.HighColor;
                            break;

                        case CompareResultEnum.LowLowalarm:
                            cs.ForeColor = Config.Default.ColorConifg.LowLowColor;
                            break;

                        case CompareResultEnum.HighHighAlarm:
                            cs.ForeColor = Config.Default.ColorConifg.HighHighColor;
                            break;

                        default:
                            throw new ArgumentException(cr.CompareResultEnum.ToString());
                    }
                }
                else
                {
                    switch (cr.CompareResultEnum)
                    {
                        case CompareResultEnum.Normal:
                            cs.BackColor = Config.Default.ColorConifg.NormalColor;
                            break;

                        case CompareResultEnum.LowAlarm:
                            cs.BackColor = Config.Default.ColorConifg.LowColor;
                            break;

                        case CompareResultEnum.HighAlarm:
                            cs.BackColor = Config.Default.ColorConifg.HighColor;
                            break;

                        case CompareResultEnum.LowLowalarm:
                            cs.BackColor = Config.Default.ColorConifg.LowLowColor;
                            break;

                        case CompareResultEnum.HighHighAlarm:
                            cs.BackColor = Config.Default.ColorConifg.HighHighColor;
                            break;

                        default:
                            throw new ArgumentException(cr.CompareResultEnum.ToString());
                    }

                }
                return cs;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public class CellStyleBackForeColor : IBackForeColor
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="dgvCellStyle"></param>
            public CellStyleBackForeColor(DataGridViewCellStyle dgvCellStyle)
            {
                if (dgvCellStyle == null)
                    throw new ArgumentNullException("dgvCellStyle");
                _dgvCellStyle = dgvCellStyle;
            }

            private DataGridViewCellStyle _dgvCellStyle;

            #region IBackForeColor 成员

            public System.Drawing.Color BackColor
            {
                get { return _dgvCellStyle.BackColor; }
                set { _dgvCellStyle.BackColor = value; }
            }

            public System.Drawing.Color ForeColor
            {
                get { return _dgvCellStyle.ForeColor; }
                set { _dgvCellStyle.ForeColor = value; }
            }

            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static private bool IsPumpName(string name)
        {
            if (name.Length == 3)
            {
                string temp = name.Substring(0, 2).ToUpper();
                return temp == "RM" || temp == "CM";
            }
            return false;
        }
    }
}
