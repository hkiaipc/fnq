using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Xdgk.Common;
using CZGRCommon;
using System.IO;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmGRDataLast : Form, IDataGridViewFont
    {
        static NLog.Logger logger = NLog.LogManager.GetLogger("console");

        /// <summary>
        /// 保存最新数据的时间
        /// </summary>
        private DateTime _lastDataDateTime = DateTime.MinValue;

        /// <summary>
        /// 
        /// </summary>
        private MyTimer _t = new MyTimer(TimeSpan.FromSeconds(10));

        #region frmGRDataLast
        /// <summary>
        /// 
        /// </summary>
        public frmGRDataLast()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            SetDataGridViewColumnConfig();
            InsertAlarmColumn();
            this.Text = strings.GRDataLast;
            this.AutoRefresh = Config.Default.IsAutoRefreshGRDataLast;
            this._t.TimeOut = Config.Default.AutoRefreshGRDataLastTimeSpan;
            this.dataGridView1.Font = Config.Default.DataGridViewFont;

            //this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            logger.Info("frmGRDataLast");
        }
        #endregion //frmGRDataLast

        #region InsertAlarmColumn
        /// <summary>
        /// 
        /// </summary>
        private void InsertAlarmColumn()
        {
            DataGridViewImageColumn c = new DataGridViewImageColumn(true);
            c.Name = "GRAlarm";
            c.HeaderText = "报警";
            c.DataPropertyName = "GRAlarm";
            c.Width = 50;
            c.ValuesAreIcons = true;
            //c.SortMode = DataGridViewColumnSortMode.Automatic;
            c.Icon = FNGRQRC.Properties.Resources.empty;

            dataGridView1.Columns.Insert(0, c);
        }
        #endregion //InsertAlarmColumn

        #region SetDataGridViewColumnConfig
        /// <summary>
        /// 
        /// </summary>
        private void SetDataGridViewColumnConfig()
        {
            foreach (DGVColumnConfig cc in DGVColumnConfigs.GR)
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
        #endregion //SetDataGridViewColumnConfig

        #region frmGRDataLast_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGRDataLast_Load(object sender, EventArgs e)
        {
            FillStreet();
            Queries();
        }
        #endregion //frmGRDataLast_Load

        #region FillStreet
        /// <summary>
        /// 
        /// </summary>
        private void FillStreet()
        {
            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteStreetDataTable();
            DataRow row = tbl.NewRow();
            row[0] = strings.All;
            tbl.Rows.InsertAt(row, 0);

            this.cmbStreet.DisplayMember = "Street";
            this.cmbStreet.ValueMember = "Street";
            this.cmbStreet.DataSource = tbl;

        }
        #endregion //FillStreet

        #region btnRefresh_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Queries();
        }
        #endregion //btnRefresh_Click


        #region AddDataTableIconColumn
        /// <summary>
        /// 向tbl中添加图标列
        /// </summary>
        /// <param name="tbl"></param>
        private void AddDataTableIconColumn(DataTable tbl)
        {
            tbl.Columns.Add(new DataColumn("GRAlarm", typeof(Icon)));
            foreach (DataRow row in tbl.Rows)
            {
                row["GRAlarm"] = FNGRQRC.Properties.Resources.empty;
            }
        }
        #endregion //AddDataTableIconColumn

        #region MarkLastDateTime
        /// <summary>
        /// 
        /// </summary>
        private void MarkLastDateTime(DataTable tbl)
        {
            string filterExpression = "";
            string sort = "DT desc";
            DataRow[] rows = tbl.Select(filterExpression, sort);
            if (rows.Length != 0)
            {
                this._lastDataDateTime = (DateTime)rows[0]["DT"];
                logger.Info("LastDataDateTime: " + _lastDataDateTime);
            }
        }
        #endregion //MarkLastDateTime


        #region HasExceptionValue
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastDataTable"></param>
        /// <param name="lastDateTime"></param>
        /// <param name="ads"></param>
        /// <returns></returns>
        private bool HasExceptionValue(DataTable lastDataTable, DateTime lastDateTime, AlarmDefineCollection ads)
        {
            foreach (AlarmDefine ad in ads)
            {
                RangeAlarmDefine rad = ad as RangeAlarmDefine;
                if (rad != null)
                {
                    string filter = string.Format(" DT > '{0}' and ({1} < {2} or {1} > {3})",
                       lastDateTime, rad.Name, rad.Min, rad.Max);
                    DataRow[] rows = lastDataTable.Select(filter);
                    if (rows.Length > 0)
                        return true;
                }
            }
            return false;
        }
        #endregion //HasExceptionValue

        #region Queries
        /// <summary>
        /// 
        /// </summary>
        public void Queries()
        {
            this.Query();
            this.QueryGRAlarm();
            this._t.Last = DateTime.Now;
        }
        #endregion //Queries

        #region Query
        /// <summary>
        /// 
        /// </summary>
        public void Query()
        {
            Point currentCellAddress = this.dataGridView1.CurrentCellAddress;

            int index = 0;
            DataGridViewRow dgvr = this.dataGridView1.CurrentRow;
            if (dgvr != null)
            {
                index = dgvr.Index;
            }

            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteGRLastDataTableWithStreet(
                this.GetSelectedStreet()
                );

            Helper.AddCalcColumn(tbl, CalcColumnInfoCollection.GRDataCalcColumns);

            AddDataTableIconColumn(tbl);
            AddGRAlarmDataCollectionColumn(tbl);
            //AddDataColumns(tbl);

            this.dataGridView1.DataSource = tbl;

            bool hasException = HasExceptionValue(tbl, _lastDataDateTime, Config.Default.AlarmDefineCollection);
            logger.Info(hasException);
            if (hasException)
            {
                SoundPlayer.PlayAlarmSound();
            }

            this.SortGridviewWithOldSetting();

            if (currentCellAddress != null)
            {
                if (IsCurrentCellAddressValid(currentCellAddress))
                {
                    this.dataGridView1.CurrentCell = this.dataGridView1[
                        currentCellAddress.X,
                        currentCellAddress.Y];
                }
            }

            MarkLastDateTime(tbl);
        }
        #endregion //Query

        #region IsCurrentCellAddressValid
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private bool IsCurrentCellAddressValid(Point address)
        {
            return address.X >= 0 &&
                address.Y >= 0 &&
                address.X < this.dataGridView1.Columns.Count &&
                address.Y < this.dataGridView1.Rows.Count;

        }
        #endregion //IsCurrentCellAddressValid

        #region AddDataColumns
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        private void AddDataColumns(DataTable tbl)
        {
            // 1. 日计划耗热量列, 原始值列
            //
            // 2. 计划流量列:  = (1) * 1000 / (24 * DiffT1 * 4.1868)
            //
            // 3. 实际流量与计划流量差列: I1 - (2)
            //

            DataColumn c = new DataColumn("DPQ", typeof(float));
            tbl.Columns.Add(c);
            foreach (DataRow r in tbl.Rows)
            {
                int grDeviceID = Convert.ToInt32(r["DeviceID"]);
                DateTime dt = Convert.ToDateTime(r["DT"]);
                int month = dt.Month;
                int planHeatMonth = CZGRQRCApp.Default.DBI.GetGRDevicePlanHeat(grDeviceID, month);
                int days = DateTime.DaysInMonth(dt.Year, dt.Month);
                int planHeatDay = planHeatMonth / days;
                r["DPQ"] = planHeatDay;
            }
            c = new DataColumn("PI1", typeof(float), "DPQ * 1000 / (24 * DiffT1 * 4.1868)");
            tbl.Columns.Add(c);

            c = new DataColumn("DiffI1", typeof(float), "I1 - PI1");
            tbl.Columns.Add(c);


        }
        #endregion //AddDataColumns


        #region AddGRAlarmDataCollectionColumn
        /// <summary>
        /// 添加供热数据集合列
        /// </summary>
        /// <param name="tbl"></param>
        private void AddGRAlarmDataCollectionColumn(DataTable tbl)
        {
            DataColumn c = new DataColumn("GRAlarmDatas", typeof(GRAlarmDataCollection));
            tbl.Columns.Add(c);
            foreach (DataRow row in tbl.Rows)
            {
                row["GRAlarmDatas"] = new GRAlarmDataCollection();
            }
        }
        #endregion //AddGRAlarmDataCollectionColumn


        #region QueryGRAlarm
        /// <summary>
        /// 
        /// </summary>
        public void QueryGRAlarm()
        {

            DataTable gralarmTbl = CZGRQRCApp.Default.DBI.ExecuteGRAlarmDataTable(
                this.QueryGRAlarmDateTime);
            bool hasAlarm = gralarmTbl.Rows.Count > 0;


            UpdateDataGridViewAlarm(gralarmTbl);


            // TODOX:
            //
            this.QueryGRAlarmDateTime = DateTime.Now;

            CZGRQRCApp.Default.UCAlarm.AddGRAlarm(gralarmTbl);

            if (hasAlarm)
            {
                SoundPlayer.PlayAlarmSound();
                if (Config.Default.EnableGRAlarmPopup)
                {
                    frmGRAlarmPopup2 f2 = new frmGRAlarmPopup2();
                    //f2.Parent = this;
                    f2.GRAlarmDataTable = gralarmTbl;
                    f2.Show(this);
                }
            }

        }
        #endregion //QueryGRAlarm


        #region DataGridViewDataSource
        /// <summary>
        /// 
        /// </summary>
        private DataTable DataGridViewDataSource
        {
            get { return this.dataGridView1.DataSource as DataTable; }
        }
        #endregion //DataGridViewDataSource


        #region UpdateDataGridViewAlarm
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gralarmTbl"></param>
        private void UpdateDataGridViewAlarm(DataTable gralarmTbl)
        {
            foreach (DataRow row in gralarmTbl.Rows)
            {
                string displayName = row[DataColumnNames.StationName].ToString();
                //this.dataGridView1.
                //int displayNameColumnIndex = 2;
                //DataGridViewRow dgvrow = GetDataGridViewRow(displayNameColumnIndex, stationName);

                //if (dgvrow != null)
                //{
                //    Icon ico =FNGRQRC.Properties.Resources.Exclamation16; 
                //    UpdateGRAlarmIcon(dgvrow,ico);

                //    // 
                //    //
                //    GRAlarmDataCollection gralarmdatas = GetDataGirdViewRowGRAlarmDataCollection(dgvrow);
                //    gralarmdatas.Add(CreateGRAlarmData(row));
                //}
                string expression = string.Format("StationName = '{0}'", displayName);
                DataTable tbl = DataGridViewDataSource;
                DataRow[] selrows = tbl.Select(expression);
                if (selrows.Length > 0)
                {
                    GRAlarmDataCollection gralarmdatas = selrows[0]["GRAlarmDatas"] as GRAlarmDataCollection;
                    gralarmdatas.Add(CreateGRAlarmData(row));
                    selrows[0]["GRAlarm"] = FNGRQRC.Properties.Resources.Exclamation16;
                }
            }
        }
        #endregion //UpdateDataGridViewAlarm


        #region UpdateGRAlarmIcon
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgvrow"></param>
        private static void UpdateGRAlarmIcon(DataGridViewRow dgvrow, Icon ico)
        {
            DataGridViewImageCell imageCell = dgvrow.Cells[0] as DataGridViewImageCell;
            imageCell.Value = ico;
        }
        #endregion //UpdateGRAlarmIcon


        #region CreateGRAlarmData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private GRAlarmData CreateGRAlarmData(DataRow row)
        {
            GRAlarmData a = new GRAlarmData(
                Convert.ToDateTime(row["DT"]),
                row[DataColumnNames.StationName].ToString(),
                row["Content"].ToString());
            return a;
        }
        #endregion //CreateGRAlarmData


        #region GetDataGirdViewRowGRAlarmDataCollection
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgvrow"></param>
        /// <returns></returns>
        private GRAlarmDataCollection GetDataGirdViewRowGRAlarmDataCollection(DataGridViewRow dgvrow)
        {
            //if (dgvrow.Tag == null)
            //{
            //    dgvrow.Tag = new GRAlarmDataCollection();
            //}
            //return (GRAlarmDataCollection)dgvrow.Tag;
            DataRowView drv = dgvrow.DataBoundItem as DataRowView;
            return drv["GRAlarmDatas"] as GRAlarmDataCollection;
        }
        #endregion //GetDataGirdViewRowGRAlarmDataCollection


        #region GetDataGridViewRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private DataGridViewRow GetDataGridViewRow(int columnIndex, string value)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (StringHelper.Equal(row.Cells[columnIndex].Value.ToString(), value))
                {
                    return row;
                }
            }
            return null;
        }
        #endregion //GetDataGridViewRow


        #region QueryGRAlarmDateTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime QueryGRAlarmDateTime
        {
            get { return _queryGRAlarmDateTime; }
            set { _queryGRAlarmDateTime = value; }
        } private DateTime _queryGRAlarmDateTime = DateTime.Now;
        #endregion //QueryGRAlarmDateTime


        #region UpdateDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        private void UpdateDataTable(DataTable source, DataTable destination)
        {
            //string columnName = "StationName";
            string columnName = "StationName";
            foreach (DataRow row in source.Rows)
            {
                string expression = string.Format("{0} = '{1}'", columnName, row[columnName].ToString());
                DataRow[] selectedRows = destination.Select(expression);
                if (selectedRows.Length > 0)
                {

                    DataRow selectedRow1 = selectedRows[0];
                    for (int i = 0; i < selectedRow1.Table.Columns.Count; i++)
                    {
                        if (selectedRow1.Table.Columns[i].ColumnName == "GRAlarm" ||
                            selectedRow1.Table.Columns[i].ColumnName == "GRAlarmDatas")
                        {
                            continue;
                        }

                        if (selectedRow1.Table.Columns[i].ReadOnly == false)
                        {
                            selectedRow1[i] = row[i];
                        }
                    }
                }
                else
                {
                    // TODO: add new row
                    //
                    //DataRow newRow = destination.NewRow();
                    //destination.Rows.Add(newRow);

                }
            }
        }
        #endregion //UpdateDataTable

        #region GetDataFormatterCollection
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataFormatterCollection GetDataFormatterCollection()
        {
            DataFormatterCollection s = new DataFormatterCollection();
            s.Add(new SingleFormatter());
            s.Add(new Int32Formatter());

            //s.Add();
            return s;
        }
        #endregion //GetDataFormatterCollection

        #region btnExport_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string filename = CZGRCommon.Path.GetTempFileName("xls");
            CZGRCommon.ExcelExporter ee = new CZGRCommon.ExcelExporter(filename,
                //GetDataFormatterCollection());
                DataGridViewFormatters.DefaultDataFormatterCollection);

            ee.ExportedEvent += new EventHandler(ee_ExportedEvent);
            //CCC ccc = CCCFactory.CreateGRDataCCC(this.dataGridView1);
            ee.Export(this.dataGridView1);

            ProcessStartInfo si = new ProcessStartInfo(filename);
            si.ErrorDialog = true;
            Process.Start(si);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ee_ExportedEvent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ExcelExporter ee = sender as ExcelExporter;
            //ee.XlsFile.deletera
            DeleteGRAlarmColumn(ee);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ee"></param>
        private void DeleteGRAlarmColumn(ExcelExporter ee)
        {
            int col = 1;
            int row = 1;
            FlexCel.Core.TXlsCellRange cellRange = new FlexCel.Core.TXlsCellRange(
                row, col, row, col);
            ee.XlsFile.DeleteRange(cellRange, FlexCel.Core.TFlxInsertMode.ShiftColRight);
        }
        #endregion //btnExport_Click


        #region dataGridView1_CellFormatting
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //e.columnindex
            DataGridViewCellFormatter.FormatPumpText(this.dataGridView1, e);

            // 异常数据颜色设置
            //
            if (Config.Default.EnableGRExceptionValueColor)
            {
                DataGridViewCellFormatter.FormatExceptionColor(this.dataGridView1, e);
            }

            //if (Config.Default.EnableGRAlarmValueColor)
            //{
            //    DataGridViewCellFormatter.FormatGRAlarmValueColor(this.dataGridView1, e);
            //}
        }
        #endregion //dataGridView1_CellFormatting

        #region btnHistoryData_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistoryData_Click(object sender, EventArgs e)
        {
            string name = GetSelectedGRDeviceName();
            if (name != null)
            {
                frmMain mainForm = this.ParentForm as frmMain;
                //mainForm.Process(
                mainForm.Process(name, CZGRCommon.DataValue.GR, CZGRCommon.AppearanceValue.Query);
            }
        }
        #endregion //btnHistoryData_Click

        #region GetSelectedGRDeviceID
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetSelectedGRDeviceID()
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = this.dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                int id = (int)((DataRowView)row.DataBoundItem)["DeviceID"];
                return id;
            }
            return -1;
        }
        #endregion //GetSelectedGRDeviceID

        #region GetSelectedGRDeviceName
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetSelectedGRDeviceName()
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = this.dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                string name = row.Cells[DataColumnNames.StationName].Value.ToString();
                return name;
            }
            return null;
        }
        #endregion //GetSelectedGRDeviceName

        #region btnTempCurve_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTempCurve_Click(object sender, EventArgs e)
        {
            string name = GetSelectedGRDeviceName();
            if (name != null)
            {
                frmMain mainForm = this.ParentForm as frmMain;
                //mainForm.Process(
                mainForm.Process(name, CZGRCommon.DataValue.GRTemp, CZGRCommon.AppearanceValue.Curve);
            }
        }
        #endregion //btnTempCurve_Click

        #region btnPressCurve_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPressCurve_Click(object sender, EventArgs e)
        {
            string name = GetSelectedGRDeviceName();
            if (name != null)
            {
                frmMain mainForm = this.ParentForm as frmMain;
                //mainForm.Process(
                mainForm.Process(name, CZGRCommon.DataValue.GRPress, CZGRCommon.AppearanceValue.Curve);
            }
        }
        #endregion //btnPressCurve_Click

        #region timer1_Tick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_t.IsTimeOut())
            {
                this.Queries();
            }
        }
        #endregion //timer1_Tick

        #region AutoRefresh
        /// <summary>
        /// 
        /// </summary>
        public bool AutoRefresh
        {
            get { return _autoRefresh; }
            set
            {
                _autoRefresh = value;
                this.timer1.Enabled = _autoRefresh;
            }
        } private bool _autoRefresh = false;
        #endregion //AutoRefresh


        #region dataGridView1_CellContentClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion //dataGridView1_CellContentClick


        #region dataGridView1_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow dgvrow = this.dataGridView1.Rows[e.RowIndex];
            //object obj = dgvrow.DataBoundItem;
            GRAlarmDataCollection grAlarmDatas = GetDataGirdViewRowGRAlarmDataCollection(dgvrow);
            if (grAlarmDatas.Count > 0)
            {
                PopupGRAlarmDataForm(grAlarmDatas);
                grAlarmDatas.Clear();

                UpdateGRAlarmIcon(dgvrow, FNGRQRC.Properties.Resources.empty);
            }
            else
            {
                PopupGRDataForm(dgvrow);
            }
        }
        #endregion //dataGridView1_CellDoubleClick


        #region PopupGRAlarmDataForm
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gralarmdatas"></param>
        private void PopupGRAlarmDataForm(GRAlarmDataCollection gralarmdatas)
        {
            // TODO:
            //
            //throw new NotImplementedException();
            //MessageBox.Show(gralarmdatas.Count.ToString());
            frmGRAlarmPopup f = new frmGRAlarmPopup(gralarmdatas);
            f.ShowDialog(this);
        }
        #endregion //PopupGRAlarmDataForm


        #region PopupGRDataForm
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgvrow"></param>
        private void PopupGRDataForm(DataGridViewRow dgvrow)
        {
            string displayName = GetSelectedGRDeviceName();
            int deviceID = GetSelectedGRDeviceID();
            if (deviceID > 0)
            {

                //if (displayName != null)
                //{
                //if (IsZGStation(displayName))
                if (IsZGStation(deviceID))
                {
                    frmGRFlowZG.PopupGRFlowZGForm(displayName, this);
                }
                else
                {
                    frmGRFlowJG.PopupGRFlowJGForm(displayName, this);
                }

            }
        }
        #endregion //PopupGRDataForm


        #region IsZGStation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceID"></param>
        /// <returns></returns>
        private bool IsZGStation(int deviceID)
        {
            string extend = CZGRQRCApp.Default.DBI.GetDeviceExtend(deviceID);
            KeyValueCollection keyValues = Split(extend);
            KeyValue r = keyValues.Find("HtmMode");
            if (r != null)
            {
                return StringHelper.Equal(r.Value.ToString(), "Direct");
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="displayname"></param>
        /// <returns></returns>
        private bool IsZGStation(string displayname)
        {
            return CZGRQRCApp.Default.ZGStationList.Include(displayname);
        }
        #endregion //IsZGStation

        #region Split
        private KeyValueCollection Split(string config)
        {
            KeyValueCollection r = new KeyValueCollection();
            string[] kvArray = config.Split(';');
            foreach (string kv in kvArray)
            {
                string[] k_v = kv.Split('=');
                if (k_v.Length == 2)
                {
                    string k = k_v[0];
                    string v = k_v[1];

                    KeyValue newkv = new KeyValue(k, v);
                    r.Add(newkv);
                }
            }
            return r;
        }
        #endregion //Split

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

        #region cmbStreet_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            Query();
        }
        #endregion //cmbStreet_SelectedIndexChanged

        #region GetSelectedStreet
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetSelectedStreet()
        {
            string r = null;
            if (this.cmbStreet.SelectedIndex >= 0)
            {
                if (this.cmbStreet.Text != strings.All)
                {
                    r = this.cmbStreet.Text;
                }
            }
            return r;
        }
        #endregion //GetSelectedStreet

        #region dataGridView1_Sorted
        private DataGridViewColumn _gdSortColumn;
        private SortOrder _gdOrder;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            _gdSortColumn = this.dataGridView1.SortedColumn;
            _gdOrder = this.dataGridView1.SortOrder;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SortGridviewWithOldSetting()
        {
            if (_gdSortColumn != null && _gdOrder != SortOrder.None)
            {
                ListSortDirection listSortDir = _gdOrder == SortOrder.Ascending ?
                    ListSortDirection.Ascending : ListSortDirection.Descending;
                this.dataGridView1.Sort(_gdSortColumn, listSortDir);
            }
        }
        #endregion //dataGridView1_Sorted
    }
}
