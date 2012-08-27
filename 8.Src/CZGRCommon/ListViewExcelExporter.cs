using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CZGRCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class ListViewExcelExporter : ExcelExporter
    {
        #region ListViewExcelExporter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public ListViewExcelExporter(string fileName, ListView listview)
            : base(fileName)
        {
            this.lv = listview;
        }
        #endregion //ListViewExcelExporter

        #region Members
        /// <summary>
        /// 
        /// </summary>
        private ListView lv;
        #endregion //Members

        #region Export
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lv"></param>
        public void Export()
        {
            FlexCel.XlsAdapter.XlsFile xls = new FlexCel.XlsAdapter.XlsFile(true);
            xls.NewFile(1);
            int row = 1;
            int col = 1;

            foreach (ColumnHeader ch in lv.Columns)
            {
                xls.SetCellValue(row, col, ch.Text);
                col++;
            }

            row++;
            foreach (ListViewItem lvi in lv.Items)
            {
                col = 1;
                //foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                for (int subItemIndex = 0; subItemIndex < lvi.SubItems.Count; subItemIndex++)
                {
                    ListViewItem.ListViewSubItem lvsi = lvi.SubItems[subItemIndex];
                    if (lvsi.Text != string.Empty)
                    {
                        //ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                        TypeCode typeCode = GetTypeCode(lv.Columns, subItemIndex);
                        object value = null;
                        if (typeCode == TypeCode.Int32 || typeCode == TypeCode.Int16 || typeCode == TypeCode.Int64)
                        {
                            value = Convert.ToInt32(lvsi.Text);
                        }
                        else if (typeCode == TypeCode.Single)
                        {
                            float fvalue = Convert.ToSingle(lvsi.Text);
                            value = Math.Round(fvalue, 2);
                        }
                        else
                        {
                            value = lvsi.Text;
                        }
                        xls.SetCellValue(row, col, value);
                    }
                    col++;

                }
                row++;
            }
            xls.Save(this.FileName);
        }
        #endregion //Export

        #region GetTypeCode
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnHeaderCollection"></param>
        /// <param name="subItemIndex"></param>
        /// <returns></returns>
        private TypeCode GetTypeCode(ListView.ColumnHeaderCollection columnHeaderCollection, 
                int subItemIndex)
        {
            ColumnHeader ch = columnHeaderCollection[subItemIndex];
            if (ch.Tag != null)
            {
                return (TypeCode)ch.Tag;
            }
            return TypeCode.String;
        }
        #endregion //GetTypeCode
    }
}
