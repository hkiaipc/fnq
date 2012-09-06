using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCSelectCondition : UserControl
    {

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OKEvent;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler ExportEvent;


        #region UCSelectCondition
        /// <summary>
        /// 
        /// </summary>
        public UCSelectCondition()
        {
            InitializeComponent();
        }
        #endregion //UCSelectCondition

        public string[] DeviceTypes
        {
            get
            {
                if (_deviceTypes == null)
                {
                    _deviceTypes = new string[] { };
                }
                return _deviceTypes;
            }
            set
            {
                _deviceTypes = value;
            }
        } private string[] _deviceTypes;
        #region UCSelectCondition_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSelectCondition_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                //FillStationName(this.cmbStationName , true);
                StationNameFiller.FillStationName(this.cmbStationName, this.IsAddAll, this.DeviceTypes);

                this.dtpBegin.Value = DateTime.Now.Date;
                this.dtpBeginTime.Value = DateTime.Parse("1900-1-1 00:00:00");
                this.dtpEnd.Value = (DateTime.Now.Date + TimeSpan.Parse("1")).Date;
                this.dtpEndTime.Value = DateTime.Parse("1900-1-1 00:00:00");
            }
        }
        #endregion //UCSelectCondition_Load



        #region CombineDateTime
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datePart"></param>
        /// <param name="timePart"></param>
        /// <returns></returns>
        private DateTime CombineDateTime(DateTime datePart, DateTime timePart)
        {
            return datePart.Date + timePart.TimeOfDay;
        }
        #endregion //CombineDateTime


        #region Begin
        /// <summary>
        /// 
        /// </summary>
        public DateTime Begin
        {
            get 
            {
                DateTime dt = CombineDateTime(dtpBegin.Value, dtpBeginTime.Value);
                return dt;
            }

            set
            {
                this.dtpBegin.Value = value;
                this.dtpBeginTime.Value = value;
            }
        }
        #endregion //Begin


        #region End
        /// <summary>
        /// 
        /// </summary>
        public DateTime End
        {
            get { return CombineDateTime(dtpEnd.Value, dtpEndTime.Value); }
            set
            {
                this.dtpEnd.Value = value;
                this.dtpEndTime.Value = value;
            }
        }
        #endregion //End


        #region StationName
        /// <summary>
        /// 
        /// </summary>
        public string StationName
        {
            get { return this.cmbStationName.Text; }
            set
            {
                if (value == null)
                    value = string.Empty;
                this.cmbStationName.Text = value;
            }
        }
        #endregion //StationName


        //#region CreateStationDeviceArray
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="tbl"></param>
        ///// <returns></returns>
        //private StationDeviceCollection CreateStationDeviceArray(DataTable tbl)
        //{
        //    StationDeviceCollection sds = new StationDeviceCollection();
        //    foreach (DataRow row in tbl.Rows)
        //    {
        //        sds.Add(new StationDevice(row[DataColumnNames.StationName].ToString(), row[DataColumnNames.DeviceName].ToString()));
        //    }
        //    return sds;
        //}
        //#endregion //CreateStationDeviceArray


        #region IsAddAll
        /// <summary>
        /// 
        /// </summary>
        public bool IsAddAll
        {
            get { return _isAddAll; }
            set { _isAddAll = value; }
        } private bool _isAddAll = true;
        #endregion //IsAddAll


        //#region FillStationName
        ///// <summary>
        ///// 
        ///// </summary>
        //private void FillStationName(ComboBox stationCombox, bool addAll)
        //{
        //    DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteStationName();
        //    StationDeviceCollection sds = CreateStationDeviceArray(tbl);
        //    if (IsAddAll)
        //    {
        //        sds.Insert(0, new StationDevice(strings.All, ""));
        //    }
        //    //if (addAll)
        //    //{
        //    //    DataRow row = tbl.NewRow();
        //    //    row["StationID"] = -1;
        //    //    row["StationName"] = strings.All;
        //    //    tbl.Rows.InsertAt(row, 0);
        //    //}

        //    stationCombox.DataSource = sds;
        //    stationCombox.DisplayMember = "StationName";
        //    stationCombox.ValueMember = "This";
        //}
        //#endregion //FillStationName


        #region btnOK_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {

            if (this.OKEvent != null)
            {
                using (new CP.Windows.Forms.WaitCursor(this))
                {
                    OKEvent(this, EventArgs.Empty);
                }
            }
        }
        #endregion //btnOK_Click


        #region ShowExport
        /// <summary>
        /// 
        /// </summary>
        public bool ShowExport
        {
            get { return this.btnExport.Visible; }
            set { this.btnExport.Visible = value; }
        }
        #endregion //ShowExport


        #region btnExport_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.ExportEvent != null)
            {
                using (new CP.Windows.Forms.WaitCursor(this))
                {
                    ExportEvent(this, EventArgs.Empty);
                }
            }
        }
        #endregion //btnExport_Click
    }
}
