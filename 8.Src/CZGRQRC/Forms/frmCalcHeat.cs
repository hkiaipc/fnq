using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Xdgk.Common;
using CZGRCommon;
using NLog;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmCalcHeat : Form, IDataGridViewFont
    {

        static private Logger log = LogManager.GetCurrentClassLogger();

        #region Members
        #endregion //Members

        #region frmCalcHeat
        /// <summary>
        /// 
        /// </summary>
        public frmCalcHeat()
        {
            InitializeComponent();
            SetDataGridViewColumnConfig();
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.Text = strings.CostHeat;
            this.dataGridView1.Font = Config.Default.DataGridViewFont;
        }
        #endregion //frmCalcHeat

        #region SetDataGridViewColumnConfig
        /// <summary>
        /// 
        /// </summary>
        private void SetDataGridViewColumnConfig()
        {
            foreach (DGVColumnConfig cc in DGVColumnConfigs.Heat)
            {
                if (cc.Visible)
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
        }
        #endregion //SetDataGridViewColumnConfig

        #region FillCalcColumns
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        private void FillCalcColumns(DataTable tbl)
        {
            foreach (DataRow row in tbl.Rows)
            {
                DateTime b = (DateTime)row[DataColumnNames.DTBegin];
                DateTime e = (DateTime)row[DataColumnNames.DTEnd];
                TimeSpan ts = e - b;
                float f = (float)(ts.TotalSeconds / TimeSpan.Parse("1.00:00:00").TotalSeconds);
                row[DataColumnNames.DayRate] = f;
            }
        }
        #endregion //FillCalcColumns

        //#region AddCalcColumns
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="tbl"></param>
        //private void AddCalcColumns(DataTable tbl)
        //{
        //    DataColumn c = new DataColumn(DataColumnNames.S1, typeof(int), DataColumnFormulas.S1Diff);
        //    tbl.Columns.Add(c);

        //    //c = new DataColumn( DataColumnNames.SupportArea, typeof(float));
        //    //tbl.Columns.Add(c);
        //    //FillSupptArea(tbl);

        //    c = new DataColumn(DataColumnNames.DayRate, typeof(float));
        //    tbl.Columns.Add(c);
        //    FillCalcColumns(tbl);

        //    //string calcHeatFormula = "s1 * (gt1 - bt1) * 4.1868 / dayrate / 1000";
        //    string calcHeatFormula = Config.Default.CalcHeatFormula;
        //    c = new DataColumn(DataColumnNames.Heat, typeof(float), calcHeatFormula);
        //    tbl.Columns.Add(c);


        //    c = new DataColumn(DataColumnNames.I1, typeof(float), DataColumnFormulas.InstantFluxFormula);
        //    tbl.Columns.Add(c);

        //    c = new DataColumn(DataColumnNames.ItemHeat, typeof(float), DataColumnFormulas.ItemHeat);
        //    tbl.Columns.Add(c);

        //    double phTheMonth = CZGRQRCApp.Default.DBI.GetPlanHeat(this.ucCalcHeatCondition1.Begin);
        //    int days = GetDaysInMonth(this.ucCalcHeatCondition1.Begin);
        //    double totalSupportArea = CZGRQRCApp.Default.DBI.GetTotalSupportArea();

        //    // update month plan heat
        //    //
        //    this.txtMonthPlanHeat.Text = phTheMonth.ToString();
        //    this.txtMonthDays.Text = days.ToString();
        //    this.txtTotalSupportArea.Text = totalSupportArea.ToString("f2");


        //    string planHeatFormula = string.Format(DataColumnFormulas.PlanHeat,
        //        //CZGRQRCApp.Default.DBI.GetPlanHeat(this.ucCalcHeatCondition1.Begin),
        //        phTheMonth,
        //        totalSupportArea,
        //        days);
        //    this.LastPlanHeatFormula = planHeatFormula;

        //    //planHeatFormula = "s1";
        //    c = new DataColumn(DataColumnNames.PlanHeat, typeof(float), planHeatFormula);
        //    tbl.Columns.Add(c);
        //}
        //#endregion //AddCalcColumns

        #region LastPlanHeatFormula
        /// <summary>
        /// 
        /// </summary>
        public string LastPlanHeatFormula
        {
            get { return _lastPlanHeatFormula; }
            set { _lastPlanHeatFormula = value; }
        } private string _lastPlanHeatFormula;
        #endregion //LastPlanHeatFormula

        #region GetDaysInMonth
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int GetDaysInMonth(DateTime dt)
        {
            // 16 = 31 - 15 + 1
            //
            if (dt.Month == 11)
                return 16;

            if (dt.Month == 3)
                return 15;

            return DateTime.DaysInMonth(
                dt.Year,
                dt.Month);
        }
        #endregion //GetDaysInMonth

        #region ucCalcHeatCondition1_OKEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCalcHeatCondition1_OKEvent(object sender, EventArgs e)
        {
            DateTime begin = this.ucCalcHeatCondition1.Begin;
            DateTime end = this.ucCalcHeatCondition1.End;
            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteCalcHeat(begin, end);

            // move to calcHeatHelper class
            //
            //AddCalcColumns(tbl);
            NN nn = new NN();
            CalcHeatHelper.AddCalcColumns(tbl, this.ucCalcHeatCondition1.Begin, nn);

            // update month plan heat
            //
            this.txtMonthPlanHeat.Text = nn.PlanHeatTheMonth.ToString();
            this.txtMonthDays.Text = nn.MonthDays.ToString();
            this.txtTotalSupportArea.Text = nn.TotalSupportArea.ToString("f2");
            this.LastPlanHeatFormula = nn.LastPlanHeatFormula;

            //FillCalcColumns(tbl);

            //StationNameFilter.Default.InitRemoveReplaceNames();
            // remove
            //
            //StationNameFilter.Default.RemoveRows(tbl);
            //StationNameFilter.Default.ReplaceDisplayNames(tbl);

            EMDataCalculator.Fill(tbl, begin, end);

            this.dataGridView1.DataSource = tbl;
        }
        #endregion //ucCalcHeatCondition1_OKEvent

        #region ucCalcHeatCondition1_ExportEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCalcHeatCondition1_ExportEvent(object sender, EventArgs e)
        {
            string filename = CZGRCommon.Path.GetTempFileName("xls");
            DataFormatterCollection dfs = new DataFormatterCollection();
            dfs.Add(new SingleFormatter());
            dfs.Add(new DoubleFormatter());
            dfs.Add(new Int32Formatter());
            CZGRCommon.ExcelExporter ee = new CZGRCommon.ExcelExporter(filename, dfs);


            // 耗热量计算公式
            //
            LinesAttache aaa = new LinesAttache();
            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteHeatCommentDataTable();
            List<III> iiis = CreateIIIs();
            CZGRCommon.CCC ccc = CreateCCC(iiis);

            aaa.Lines.Add("");
            aaa.Lines.Add("注：");

            foreach (DataRow row in tbl.Rows)
            {
                string content = row["content"].ToString().Trim();
                if (content.Length > 0)
                {
                    aaa.Lines.Add(content);
                }
            }
            //aaa.Lines.Add("\t注：日耗热量 = 日流量 * ( 一次供温 - 一次回温 ) * 4.1816 / 1000");

            ee.AttacheCollection.Add(aaa);

            //ee.Export(this.dataGridView1, ccc);
            ee.Export(this.dataGridView1);

            ProcessStartInfo si = new ProcessStartInfo(filename);
            si.ErrorDialog = true;
            Process.Start(si);
        }
        #endregion //ucCalcHeatCondition1_ExportEvent


        #region CreateCCC
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private CCC CreateCCC(List<III> iiis)
        {
            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteExtraGRDeviceDataTable();

            AddPlanHeatColumn(tbl);

            CCC ccc = new CCC(tbl);
            foreach (III iii in iiis)
            {
                ccc.List.Add(iii);
            }

            //int n = 3;
            //ccc.List.Add(new III("street", 1));
            //ccc.List.Add(new III("name", 2));
            //ccc.List.Add(new III("registeredArea", n));
            //n++;
            //ccc.List.Add(new III("supportArea", n));
            //n++;
            //ccc.List.Add(new III("planHeat", n));
            // TODO: 
            // 
            // add extraGRDeivce registeredArea, supportArea, planHeat
            // registeredArea, supportArea - from tblExtraGRDevice
            // planHeat = dayPlanHeat / totalSupportArea * supportArea
            //
            return ccc;
        }
        #endregion //CreateCCC

        #region CreateIIIs
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<III> CreateIIIs()
        {
            List<III> iiis = new List<III>();
            //int n = 1;
            DataTable tbl = this.dataGridView1.DataSource as DataTable;
            if (tbl == null)
                return iiis;

            string[] names = { "street", "displayname", "registeredArea", "supportArea", "planHeat" };
            //string[] mapnames = { "street", "displayname", "registeredArea", "supportArea", "planHeat" };
            foreach (DataColumn dc in tbl.Columns)
            {
                foreach (string name in names)
                {
                    if (StringHelper.Equal(dc.ColumnName, name))
                    {
                        string extraName = name;
                        if (name == "displayname")
                            extraName = "name";
                        III iii = new III(extraName, this.dataGridView1.Columns[name].DisplayIndex + 1);
                        //III iii = new III(name, n++);
                        iiis.Add(iii);
                    }
                }
            }
            return iiis;
        }
        #endregion //CreateIIIs


        #region AddPlanHeatColumn
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        private void AddPlanHeatColumn(DataTable tbl)
        {
            tbl.Columns.Add("planHeat", typeof(float), this.LastPlanHeatFormula);
        }
        #endregion //AddPlanHeatColumn


        #region frmCalcHeat_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCalcHeat_Load(object sender, EventArgs e)
        {
            this.VisibleParams(false);
        }
        #endregion //frmCalcHeat_Load


        #region VisibleParams
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void VisibleParams(bool value)
        {
            this.label1.Visible = value;
            this.label2.Visible = value;
            this.label3.Visible = value;
            this.label4.Visible = value;
            this.label5.Visible = value;
            this.label6.Visible = value;
            this.txtMonthDays.Visible = value;
            this.txtMonthPlanHeat.Visible = value;
            this.txtTotalSupportArea.Visible = value;
        }
        #endregion //VisibleParams

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

        #region ucCalcHeatCondition1_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCalcHeatCondition1_Load(object sender, EventArgs e)
        {

        }
        #endregion //ucCalcHeatCondition1_Load
    }

    /// <summary>
    /// 
    /// </summary>
    public class CalcHeatHelper
    {
        #region AddCalcColumns
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        static public void AddCalcColumns(DataTable tbl, DateTime begin, NN nn)
        {
            DataColumn c = new DataColumn(DataColumnNames.S1, typeof(int), DataColumnFormulas.S1Diff);
            tbl.Columns.Add(c);

            //c = new DataColumn( DataColumnNames.SupportArea, typeof(float));
            //tbl.Columns.Add(c);
            //FillSupptArea(tbl);

            c = new DataColumn(DataColumnNames.DayRate, typeof(float));
            tbl.Columns.Add(c);
            FillCalcColumns(tbl);

            //string calcHeatFormula = "s1 * (gt1 - bt1) * 4.1868 / dayrate / 1000";
            string calcHeatFormula = Config.Default.CalcHeatFormula;
            c = new DataColumn(DataColumnNames.Heat, typeof(float), calcHeatFormula);
            tbl.Columns.Add(c);


            c = new DataColumn(DataColumnNames.I1, typeof(float), DataColumnFormulas.InstantFluxFormula);
            tbl.Columns.Add(c);

            c = new DataColumn(DataColumnNames.ItemHeat, typeof(float), DataColumnFormulas.ItemHeat);
            tbl.Columns.Add(c);

            // 2011-03-03 add recruit flux
            // 
            c = new DataColumn ( DataColumnNames.ShiShuiLiang , typeof (int), DataColumnFormulas.ShiShuiLiangFormula);
            tbl.Columns.Add(c);

            //double phTheMonth = CZGRQRCApp.Default.DBI.GetPlanHeat(this.ucCalcHeatCondition1.Begin);
            //int days = GetDaysInMonth(this.ucCalcHeatCondition1.Begin);

            double phTheMonth = CZGRQRCApp.Default.DBI.GetPlanHeat(begin);
            int days = GetDaysInMonth(begin);
            double totalSupportArea = CZGRQRCApp.Default.DBI.GetTotalSupportArea();

            // update month plan heat
            //
            //this.txtMonthPlanHeat.Text = phTheMonth.ToString();
            //this.txtMonthDays.Text = days.ToString();
            //this.txtTotalSupportArea.Text = totalSupportArea.ToString("f2");
            nn.PlanHeatTheMonth = phTheMonth;
            nn.MonthDays = days;
            nn.TotalSupportArea = totalSupportArea;


            string planHeatFormula = string.Format(DataColumnFormulas.PlanHeat,
                //CZGRQRCApp.Default.DBI.GetPlanHeat(this.ucCalcHeatCondition1.Begin),
                phTheMonth,
                totalSupportArea,
                days);
            //this.LastPlanHeatFormula = planHeatFormula;
            nn.LastPlanHeatFormula = planHeatFormula;

            //planHeatFormula = "s1";
            c = new DataColumn(DataColumnNames.PlanHeat, typeof(float), planHeatFormula);
            tbl.Columns.Add(c);
        }
        #endregion //AddCalcColumns

        #region FillCalcColumns
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        static private void FillCalcColumns(DataTable tbl)
        {
            foreach (DataRow row in tbl.Rows)
            {
                DateTime b = (DateTime)row[DataColumnNames.DTBegin];
                DateTime e = (DateTime)row[DataColumnNames.DTEnd];
                TimeSpan ts = e - b;
                float f = (float)(ts.TotalSeconds / TimeSpan.Parse("1.00:00:00").TotalSeconds);
                row[DataColumnNames.DayRate] = f;
            }
        }
        #endregion //FillCalcColumns

        #region GetDaysInMonth
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        static private int GetDaysInMonth(DateTime dt)
        {
            // 16 = 31 - 15 + 1
            //
            if (dt.Month == 11)
                return 16;

            if (dt.Month == 3)
                return 15;

            return DateTime.DaysInMonth(
                dt.Year,
                dt.Month);
        }
        #endregion //GetDaysInMonth
    }

    /// <summary>
    /// 
    /// </summary>
    public class EMDataCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        static private Logger log = LogManager.GetCurrentClassLogger();

        const string ColumnName = "em";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        static public void Fill(DataTable desc, DateTime begin, DateTime end)
        {
            Fill(desc, begin, end, TimeSpan.FromDays(1));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="timeRange">时间范围, 根据已知时间段计算出指定时间范围的耗电量</param>
        static public void Fill(DataTable desc, DateTime begin, DateTime end, TimeSpan timeRange)
        {
            // 1. add em column to desc table
            //
            AddEMEnergyColumn(desc);

            // 2. get emdata table
            //
            DataTable emTable = CZGRQRCApp.Default.DBI.ExecuteEMData(begin, end);
            log.Info("em table row count = {0}", emTable.Rows.Count);

            // 3. calc day em energy
            //
            // 4. fill desc em column with name
            //
            foreach (DataRow row in desc.Rows)
            {
                // displayname ?
                //
                string stationName = row[DataColumnNames.StationName].ToString();
                int energy = CalcEnergy(emTable, stationName, timeRange);
                row[ColumnName] = energy;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emTable"></param>
        /// <param name="stationName"></param>
        /// <returns></returns>
        private static int CalcEnergy(DataTable emTable, string stationName, TimeSpan timeRange)
        {
            if (timeRange == TimeSpan.Zero)
            {
                throw new ArgumentException("timeRange can not equal TimeSpan.Zero");
            }

            string expression = string.Format(
                "{0} = '{1}'",
                DataColumnNames.StationName, stationName);

            DataRow[] rows = emTable.Select(expression ,DataColumnNames.DT);
            if (rows.Length <= 1)
                return 0;

            DateTime minDT = Convert.ToDateTime(rows[0][DataColumnNames.DT]);
            DateTime maxDT = Convert.ToDateTime(rows[rows.Length - 1][DataColumnNames.DT]);
            TimeSpan ts = maxDT - minDT;

            double tsRatio = ts.TotalSeconds / timeRange.TotalSeconds;
            log.Info("{0} from {1} to {2}, ratio {3}", stationName, minDT, maxDT, tsRatio);

            int min = Convert.ToInt32(rows[0][DataColumnNames.EMEnergy]);
            int max = Convert.ToInt32(rows[rows.Length - 1][DataColumnNames.EMEnergy]);

            int rangeValue = max - min;
            int dayValue = (int)(rangeValue / tsRatio);
            log.Info("max-min = {0}, result = {1}", rangeValue, dayValue);

            if (dayValue < 0)
            {
                dayValue = 0;
            }

            return dayValue; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        static private void AddEMEnergyColumn(DataTable tbl)
        {
            DataColumn c = new DataColumn(ColumnName, typeof(int));
            tbl.Columns.Add(c);
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class NN
    {
        public double PlanHeatTheMonth;
        public int MonthDays;
        public double TotalSupportArea;
        public string LastPlanHeatFormula;
    }

}
