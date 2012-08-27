//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Windows.Forms;

//namespace CZGRQRC
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class ExcelExporter
//    {

//        //private DataGridView dgv;
//        private string _fileName;

//        /// <summary>
//        /// 
//        /// </summary>
//        public ExcelExporter( string fileName)
//        {
//            //if (dgv == null)
//            //    throw new ArgumentNullException("dgv");
//            if (fileName == null || fileName.Trim().Length == 0)
//                throw new ArgumentException("fileName");

//            _fileName = fileName;
//            //_dgv = dgv;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="lv"></param>
//        public void Export(ListView lv)
//        {
//            FlexCel.XlsAdapter.XlsFile xls = new FlexCel.XlsAdapter.XlsFile(true);
//            xls.NewFile(1);
//            int row = 1;
//            int col = 1;

//            foreach (ColumnHeader ch in lv.Columns)
//            {
//                xls.SetCellValue(row, col, ch.Text);
//                col++;
//            }

//            row++;
//            foreach( ListViewItem lvi in lv.Items )
//            {
//                col = 1;
//                foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
//                {
//                    xls.SetCellValue(row, col, lvsi.Text);
//                    col++;
//                }
//                row++;
//            }
//            xls.Save(this._fileName);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public void Export(DataGridView dgv)
//        {
//            FlexCel.XlsAdapter.XlsFile xls = new FlexCel.XlsAdapter.XlsFile(true);
//            xls.NewFile(1);
//            int row = 1;
//            int col = 1;
//            object val = null;

//            // column headtext
//            //
//            foreach (DataGridViewColumn dgvcol in dgv.Columns)
//            {
//                val = dgvcol.HeaderText;
//                xls.SetCellValue(row, col, val);
//                col++;
//            }

//            // grid row value
//            //
//            row++;
//            foreach (DataGridViewRow dgvrow in dgv.Rows)
//            {
//                col = 1;
//                foreach (DataGridViewCell cell in dgvrow.Cells)
//                {
//                    val = cell.FormattedValue;
//                    xls.SetCellValue(row, col, val);
//                    col++;
//                }
//                row++;
//            }
//            xls.Save(_fileName);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        static public string GenerateFileName()
//        {
//            string f = DateTime.Now.ToString();
//            f = f.Replace('-', '_');
//            f = f.Replace(':', '_');
//            f = f.Replace(' ', '_');
//            f += ".xls";
//            return f;
//        }
//    }

//    /// <summary>
//    /// 
//    /// </summary>
//    public class Process
//    {
//        static public void Execute(string filename)
//        {
//            System.Diagnostics.Process process = new System.Diagnostics.Process();
//            process.StartInfo.ErrorDialog = true;
//            process.StartInfo.FileName = filename;
//            process.Start();
//        }
//    }
//}
