using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;
using System.Data;

namespace CZGRCommon
{
    //public delegate void ExportedEventHandler( object sender );

    /// <summary>
    /// DataViewGrid excel exporter
    /// </summary>
    public class ExcelExporter
    {

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler ExportedEvent;

        #region DataFormatterCollection
        /// <summary>
        /// 
        /// </summary>
        public DataFormatterCollection DataFormatterCollection
        {
            get
            {
                if (_dataFormatterCollection == null)
                    _dataFormatterCollection = new DataFormatterCollection();
                return _dataFormatterCollection;
            }
            set
            {
                this._dataFormatterCollection = value;
            }
        } private DataFormatterCollection _dataFormatterCollection;
        #endregion //DataFormatterCollection

        #region FileName
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set 
            {
                if (value == null || value.Trim().Length == 0)
                throw new ArgumentException("fileName");

                _fileName = value; 
            }
        } private string _fileName;
        #endregion //FileName

        #region ExcelExporter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public ExcelExporter(string fileName)
        {
            this.FileName = fileName;
        }
        #endregion //ExcelExporter

        #region ExcelExporter
        /// <summary>
        /// 
        /// </summary>
        public ExcelExporter(string fileName, DataFormatterCollection dataFormatterCollection)
            : this(fileName)
        {
            this.DataFormatterCollection = dataFormatterCollection;
        }
        #endregion //ExcelExporter

        #region Export
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        public void Export(DataGridView dgv)
        {
            this.Export(dgv, null);
        }
        #endregion //Export

        #region XlsFile
        /// <summary>
        /// 
        /// </summary>
        public FlexCel.XlsAdapter.XlsFile XlsFile
        {
            get { return _xlsFile; }
        } private FlexCel.XlsAdapter.XlsFile _xlsFile;
        #endregion //XlsFile

        /// <summary>
        /// 最大导出行数
        /// </summary>
        public static readonly int MaxRowCount = 65000;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public bool CanExport(DataGridView dgv)
        {
            return dgv.Rows.Count <= MaxRowCount;
        }

        #region Export
        /// <summary>
        /// 
        /// </summary>
        public void Export(DataGridView dgv, CCC ccc)
        {
            //if (dgv.Rows.Count > MaxRowCount)
            //{
            //    return;
            //}

            FlexCel.XlsAdapter.XlsFile xls = new FlexCel.XlsAdapter.XlsFile(true);
            xls.NewFile(1);

            _xlsFile = xls;

            int row = 1;
            int col = 1;
            object val = null;

            // column headtext
            //
            foreach (DataGridViewColumn dgvcol in dgv.Columns)
            //for( int i=0; i<dgv.Columns.Count; i++ )
            {
                //Console.WriteLine(dgvcol.DisplayIndex);

                val = dgvcol.HeaderText;
                xls.SetCellValue(row, col + dgvcol.DisplayIndex, val);
                //col++;
            }

            // grid row value
            //
            row++;
            foreach (DataGridViewRow dgvrow in dgv.Rows)
            {
                col = 1;
                foreach (DataGridViewCell cell in dgvrow.Cells)
                {
                    //dgvrow.Cells[
                    object cellObject = cell.Value;

                    if (cellObject != null)
                    {
                        IDataFormatter formatter = this.DataFormatterCollection.GetDataFormatter(cell.ValueType);
                        if (formatter != null)
                        {
                            val = formatter.Format(cell.Value);
                            //val = Math.Round((float)cell.Value, 2);
                        }
                        else
                        {
                            val = cell.FormattedValue;
                        }
                        xls.SetCellValue(row, col + dgv.Columns[cell.ColumnIndex].DisplayIndex, val);
                        //col++;
                    }
                }
                row++;
                //if (row > MaxRowCount)
                //    break;
            }
            if (ccc != null)
            {
                ExportCCC(xls, ccc, row);
            }

            //
            //
            AddAttacheCollection();

            // remove columns
            //
            //FlexCel.Core.TXlsCellRange cellRange = new FlexCel.Core.TXlsCellRange(1,1,1,1);
            //xls.DeleteRange(cellRange, FlexCel.Core.TFlxInsertMode.ShiftColRight);

            OnExported();
            xls.Save(_fileName);
        }
        #endregion //Export

        /// <summary>
        /// 
        /// </summary>
        private void OnExported()
        {
            if (this.ExportedEvent != null)
            {
                ExportedEvent(this, EventArgs.Empty);
            }
        }


        #region AddAttacheCollection
        /// <summary>
        /// 
        /// </summary>
        public void AddAttacheCollection()
        {
            foreach (Attache att in this.AttacheCollection)
            {
                att.Add(this);
            }
        }
        #endregion //AddAttacheCollection

        #region AttacheCollection
        /// <summary>
        /// 
        /// </summary>
        public AttacheCollection AttacheCollection
        {
            get { return _attacheCollection; }
        } private AttacheCollection _attacheCollection = new AttacheCollection();
        #endregion //AttacheCollection

        #region ExportCCC
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xls"></param>
        /// <param name="ccc"></param>
        private void ExportCCC(FlexCel.XlsAdapter.XlsFile xls, CCC ccc, int beginRow)
        {
            foreach (DataRow row in ccc.DataTable.Rows)
            {
                foreach (III iii in ccc.List)
                {
                    object obj = row[iii.ColumnName];
                    IDataFormatter formatter = this.DataFormatterCollection.GetDataFormatter(ccc.DataTable.Columns[iii.ColumnName].DataType);
                    if (formatter != null)
                    {
                        obj = formatter.Format(obj);
                    }
                    xls.SetCellValue(beginRow, iii.XlsColumn, obj);
                }
                beginRow++;
            }

            this.CurrentRow = beginRow;
        }
        #endregion //ExportCCC

        #region GenerateFileName
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public string GenerateFileName()
        {
            return CZGRCommon.Path.GetTempFileName("xls");
        }
        #endregion //GenerateFileName

        #region Export
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="selectedListview"></param>
        public static void Export(string fileName, ListView selectedListview)
        {
            new ListViewExcelExporter(fileName, selectedListview).Export();
        }
        #endregion //Export

        #region CurrentRow
        //public AttacheCollection
        /// <summary>
        /// 获取或设置xls当前行, 数据将从当前行开始写入
        /// </summary>
        public int CurrentRow
        {
            get { return _currentRow; }
            set 
            {
                if (_currentRow < 1)
                    throw new ArgumentOutOfRangeException("CurrentRow must >= 1");
                _currentRow = value; 
            }
        } private int _currentRow = 1;
        #endregion //CurrentRow
    }

    /// <summary>
    /// 
    /// </summary>
    abstract public class Attache 
    {
        abstract public void Add(ExcelExporter ee);
    }

    /// <summary>
    /// 
    /// </summary>
    public class LinesAttache : Attache 
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> Lines
        {
            get { return _lines; }
        } private List<string> _lines = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xls"></param>
        public override void Add(ExcelExporter ee)
        {
            int row = ee.CurrentRow;
            foreach( string line in this.Lines )
            {
                ee.XlsFile.SetCellValue(row++, 1, line);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AttacheCollection : Xdgk.Common.Collection<Attache>
    {
    }
}
