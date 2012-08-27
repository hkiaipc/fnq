using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CZGRCommon;

namespace CZGRQRC
{
    public partial class frmOneStationCalcHeat : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public frmOneStationCalcHeat()
        {
            InitializeComponent();
            this.ucSelectCondition1.IsAddAll = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = true;
            DataGridViewColumnHelper.SetDataGridViewColumn(this.dataGridView1, 
                DGVColumnConfigs.StationHeat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOneStationCalcHeat_Load(object sender, EventArgs e)
        {
            this.ucSelectCondition1.Begin = this.ucSelectCondition1.Begin.Date + Config.Default.CalcHeatStartTime.TimeOfDay;
            this.ucSelectCondition1.End = this.ucSelectCondition1.End.Date + Config.Default.CalcHeatStartTime.TimeOfDay;

        }

        /// <summary>
        /// 
        /// </summary>
        private void Calc()
        {
            DataTable dgvDSTable = null;

            // r - range
            //
            DateTime rb = this.ucSelectCondition1.Begin;
            DateTime re = this.ucSelectCondition1.End;
            string stationName = this.ucSelectCondition1.StationName;

            if (re <= rb)
            {
                NUnit.UiKit.UserMessage.DisplayFailure("开始时间必须小于结束时间！");
                return;
            }
            TimeSpan tsUnit = TimeSpan.FromDays(1);
            DateTime b = rb;
            DateTime e = b + tsUnit;
            NN nn = new NN();
            do
            {
                DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteCalcHeat(stationName, b, e);
                // TODO: process day heat
                //
                CalcHeatHelper.AddCalcColumns(tbl, b, nn);
                if (dgvDSTable != null)
                    dgvDSTable.Merge(tbl);
                else
                    dgvDSTable = tbl;
                //this.Merge(dgvDSTable, tbl);
                // next day
                //
                b = e;
                e = e + tsUnit;
                // 与截止日期差一天问题。1-21 ~ 1-24 实际 1-21 ~ 1-23
                //
                //if (e > re)
                //{
                //    e = re;
                //}
                if (e > re)
                {
                    e = re;
                }
                if (b >= re)
                    break;
                
            }
            while (e <= re);
            this.dataGridView1.DataSource = dgvDSTable;

            this.txtSumHeat.Text = CalcSum(dgvDSTable).ToString("f2");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        private double CalcSum(DataTable tbl)
        {
            if (tbl == null)
                return 0;
            object obj = tbl.Compute("sum(Heat)", "Heat > 0");
            if (obj == DBNull.Value)
                return 0;
            else
                return Convert.ToDouble(obj);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl1"></param>
        /// <param name="tbl2"></param>
        private void Merge(DataTable tbl1, DataTable tbl2)
        {
            if (tbl1 == null)
            {
                tbl1 = tbl2;
            }
            else
            {
                tbl1.Merge(tbl2);
            }
        }

        private void ucSelectCondition1_OKEvent(object sender, EventArgs e)
        {
            Calc();
        }

        private void ucSelectCondition1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSelectCondition1_ExportEvent(object sender, EventArgs e)
        {
            // TODO: 到处耗热量合计
            //
            string f = ExcelExporter.GenerateFileName();
            ExcelExporter ee = new ExcelExporter(f, DataGridViewFormatters.DefaultDataFormatterCollection);
            CCC ccc = CCCFactory.CreateGRDataCCC(this.dataGridView1);
            ee.Export(dataGridView1, ccc);
            //Process.Execute(f);
            ProcessStartInfo si = new ProcessStartInfo(f);
            si.ErrorDialog = true;
            Process.Start(si);
        }
    }
}
