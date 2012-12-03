using System;
using System.Diagnostics;
using System.Drawing;
using FlexCel.XlsAdapter;

namespace FNGRQRC.Forms
{
    abstract class ExporterBase
    {
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
            xls.SetCellValue(pt.X, pt.Y, value);
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
