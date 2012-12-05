using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using FlexCel.Core;
using FlexCel.XlsAdapter;

namespace FNGRQRC.Forms
{
    abstract class ExporterBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xls"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="enumerable"></param>
        internal int SetCellValues(XlsFile xls, int row, int col, IEnumerable enumerable)
        {
            foreach (object val in enumerable)
            {
                //xls.SetCellValue(row, col, val);
                SetCellValue(xls, row, col, val);
                col++;
            }

            return col - 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xls"></param>
        /// <param name="startPoint"></param>
        /// <param name="enumerable"></param>
        internal void SetCellValues(XlsFile xls, Point startPoint, IEnumerable enumerable)
        {
            SetCellValues(xls, startPoint.X, startPoint.Y, enumerable);
        }
        #region NumberOfDot
        /// <summary>
        /// 
        /// </summary>
        public int NumberOfDot
        {
            get
            {
                return _numberOfDot;
            }
            set
            {
                _numberOfDot = value;
            }
        } private int _numberOfDot = 2;
        #endregion //NumberOfDot

        internal object Format(object value)
        {
            if (value is double ||
                value is float ||
                value is decimal)
            {
                return Math.Round(
                    Convert.ToDouble(value), NumberOfDot);
            }
            else
            {
                return value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        protected ExporterBase(DateTime b, DateTime e)
        {
            this.B = b;
            this.E = e;
        }

        internal void Open(string filename)
        {
            ProcessStartInfo si = new ProcessStartInfo(filename);
            si.ErrorDialog = true;

            Process process = new Process();
            process.StartInfo = si;
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
            }
            process.Dispose();
        }

        internal void SetCellValue(XlsFile xls, Point pt, object value)
        {
            SetCellValue(xls, pt.X, pt.Y, value);
        }


        internal void SetCellValue(XlsFile xls, int row, int col, object value)
        {
            xls.SetCellValue(row, col,
                Format(value));

            SetBorder(xls, row, col);
        }

        internal void MergeCells(XlsFile xls, int row, int col, int colCount, bool hasBorder)
        {
            xls.MergeCells(row, col, row, col + colCount - 1);
            if (hasBorder)
            {
                SetBorder(xls, row, col, row, col + colCount - 1);
            }
        }

        internal void MergeCells(XlsFile xls, int row, int col, int colCount )
        {
            MergeCells(xls, row, col, colCount, false);
        }

        #region CellFormat
        /// <summary>
        /// 
        /// </summary>
        public int GetCellFormat(XlsFile xls)
        {
            if (_cellXF == -1)
            {
                TFlxFormat format = xls.GetDefaultFormat;
                format.Borders.Bottom.Style = TFlxBorderStyle.Thin;
                format.Borders.Top.Style = TFlxBorderStyle.Thin;
                format.Borders.Left.Style = TFlxBorderStyle.Thin;
                format.Borders.Right.Style = TFlxBorderStyle.Thin;
                _cellXF = xls.AddFormat(format);
            }
            return _cellXF;
        } private int _cellXF = -1;
        #endregion //CellFormat

        #region MergedCellFormat
        /// <summary>
        /// 
        /// </summary>
        public int GetMergedCellFormat(XlsFile xls)
        {
            if (_mergedCellXF == -1)
            {
                TFlxFormat format = xls.GetDefaultFormat;
                format.Borders.Bottom.Style = TFlxBorderStyle.Thin;
                format.Borders.Top.Style = TFlxBorderStyle.Thin;
                format.Borders.Left.Style = TFlxBorderStyle.Thin;
                format.Borders.Right.Style = TFlxBorderStyle.Thin;

                format.HAlignment = THFlxAlignment.center;

                _mergedCellXF = xls.AddFormat(format);
            }
            return _mergedCellXF;
        } private int _mergedCellXF = -1;
        #endregion //MergedCellFormat


        internal void SetBorder(XlsFile xls, int row, int col, int row2, int col2)
        {
            int xf = GetMergedCellFormat(xls);
            xls.SetCellFormat(row, col, row2, col2, xf);
        }

        internal void SetBorder(XlsFile xls, int row, int col)
        {
            TFlxFormat format = xls.GetDefaultFormat;

            format.Borders.Bottom.Style = TFlxBorderStyle.Thin;
            format.Borders.Top.Style = TFlxBorderStyle.Thin;
            format.Borders.Left.Style = TFlxBorderStyle.Thin;
            format.Borders.Right.Style = TFlxBorderStyle.Thin;

            int xf = xls.AddFormat(format);
            xls.SetCellFormat(row, col, xf);
        }

        abstract internal void Export();

        #region B
        /// <summary>
        /// 
        /// </summary>
        public DateTime B
        {
            get
            {
                return _b;
            }
            set
            {
                _b = value;
            }
        } private DateTime _b;
        #endregion //B

        #region E
        /// <summary>
        /// 
        /// </summary>
        public DateTime E
        {
            get
            {
                return _e;
            }
            set
            {
                _e = value;
            }
        } private DateTime _e;
        #endregion //E

    }
}
