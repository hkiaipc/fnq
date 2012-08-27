using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FlexCel.Core;
using CZGRCommon;
using System.Diagnostics;
using Xdgk.Common;

namespace CZGRQRC
{
    public partial class frmGRDataQR : Form, IDataGridViewFont
    {
        /// <summary>
        /// 
        /// </summary>
        public frmGRDataQR()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            SetDataGridViewColumnConfig();
            //this.ucSelectCondition1.OKEvent += new EventHandler(ucSelectCondition1_OKEvent);
            this.Text = strings.GRData;
            this.dataGridView1.Font = Config.Default.DataGridViewFont;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetDataGridViewColumnConfig()
        {
            foreach (DGVColumnConfig cc in DGVColumnConfigs.GRHistory )
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = cc.DataPropertyName;
                column.HeaderText = cc.Text;
                column.DataPropertyName = cc.DataPropertyName;
                column.DefaultCellStyle.Format = cc.Format;
                //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns.Add(column);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucSelectCondition1_OKEvent(object sender, EventArgs e)
        {
            Query();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Query()
        {
            DataTable tbl = null;
            if (this.ucSelectCondition1.StationName == strings.All)
            {
                tbl = CZGRQRCApp.Default.DBI.ExecuteGRDataTable(ucSelectCondition1.Begin,
                    ucSelectCondition1.End);
            }
            else
            {
                tbl = CZGRQRCApp.Default.DBI.ExecuteGRDataTable(ucSelectCondition1.StationName,
                    ucSelectCondition1.Begin,
                    ucSelectCondition1.End);
            }

            Helper.AddCalcColumn(tbl, CalcColumnInfoCollection.GRDataCalcColumns);
            this.dataGridView1.DataSource = tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGRDataQR_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCellFormatter.FormatPumpText(this.dataGridView1, e);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        public void Query(string stationName)
        {
            this.ucSelectCondition1.StationName = stationName;
            this.Query();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSelectCondition1_ExportEvent(object sender, EventArgs e)
        {
            if (ExcelExporter.CanExport(this.dataGridView1))
            {
                string f = ExcelExporter.GenerateFileName();
                ExcelExporter ee = new ExcelExporter(f, DataGridViewFormatters.DefaultDataFormatterCollection);
                CCC ccc = CCCFactory.CreateGRDataCCC(this.dataGridView1);
                ee.Export(dataGridView1, ccc);
                //Process.Execute(f);
                ProcessStartInfo si = new ProcessStartInfo(f);
                si.ErrorDialog = true;
                Process.Start(si);
            }
            else
            {
                string s = string.Format("数据行数不能大于 {0}", ExcelExporter.MaxRowCount);
                NUnit.UiKit.UserMessage.DisplayFailure(s);
            }
        }

        #region IDataGridViewFont 成员

        /// <summary>
        /// 
        /// </summary>
        public Font DataGridViewFont
        {
            get
            {
                return this.dataGridView1.Font;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("DataGridViewFont");
                this.dataGridView1.Font = value;
            }
        }

        #endregion

       
    }



}
