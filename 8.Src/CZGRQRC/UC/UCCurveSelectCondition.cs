using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Xdgk.GRCommon;
using Xdgk.Common;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    //public partial class UCCurveSelectCondition : UserControl
    public partial class UCCurveSelectCondition :NUnit.UiKit.SettingsDialogBase 
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OKEvent;

        private ADEStatus _adeState;
        /// <summary>
        /// 
        /// </summary>
        public UCCurveSelectCondition()
        {
            InitializeComponent();
            InitControls();
            _adeState = ADEStatus.Add;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public UCCurveSelectCondition ( GRStationCurveInfo info )
        {
            InitializeComponent();
            InitControls();
            this.StationCurveInfo = info;
            _adeState = ADEStatus.Edit;
        }


        /// <summary>
        /// 
        /// </summary>
        private void InitControls()
        {
            this.cmbStationName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCurveName.DropDownStyle = ComboBoxStyle.DropDownList;

            StationNameFiller.FillStationName(this.cmbStationName, false);
            this.FillCurveName();

            this.dtpBegin.Value = DateTime.Now.Date;
            this.dtpBeginTime.Value = DateTime.Parse("1900-1-1 00:00:00");
            this.dtpEnd.Value = (DateTime.Now.Date + TimeSpan.Parse("1")).Date;
            this.dtpEndTime.Value = DateTime.Parse("1900-1-1 00:00:00");
        }

        #region UCCurveSelectCondition_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCurveSelectCondition_Load(object sender, EventArgs e)
        {
        }
        #endregion //UCCurveSelectCondition_Load


        #region FillCurveName
        /// <summary>
        /// 
        /// </summary>
        private void FillCurveName()
        {
            this.cmbCurveName.DataSource = this.GRCurveCollection;
            this.cmbCurveName.DisplayMember = "Text";
            this.cmbCurveName.ValueMember = "GRCurveTypeEnum";
        }
        #endregion //FillCurveName


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



        #region GRCurveCollection
        /// <summary>
        /// 
        /// </summary>
        public GRCurveTypeCollection GRCurveCollection
        {
            get
            {
                if (_grCurveCollection == null)
                {
                    _grCurveCollection = new GRCurveTypeCollection();

                    GRCurveType temperatureCurve = new GRCurveType(GRCurveTypeEnum.TemperatureCurve, CurveStrings.TemperautreCurve);
                    GRCurveType pressureCurve = new GRCurveType(GRCurveTypeEnum.PressureCurve, CurveStrings.PressureCurve);
                    //GRCurveType otCurve = new GRCurveType(GRCurveTypeEnum.OTCurve, CurveStrings.OTCurve);
                    GRCurveType fluxCurve = new GRCurveType(GRCurveTypeEnum.FluxCurve, CurveStrings.FluxCurve);
                    //GRCurveType heatCurve = new GRCurveType(GRCurveTypeEnum.HeatCurve, CurveStrings.HeatCurve);

                    _grCurveCollection.Add(temperatureCurve);
                    _grCurveCollection.Add(pressureCurve);
                    //_grCurveCollection.Add(otCurve);
                    _grCurveCollection.Add(fluxCurve);
                    //_grCurveCollection.Add(heatCurve);
                }
                return _grCurveCollection;
            } 
        } private GRCurveTypeCollection _grCurveCollection;
        #endregion //GRCurveCollection

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


        #region cancelButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
        #endregion //cancelButton_Click


        #region okButton_Click
        //private DateTime Com
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (_adeState == ADEStatus.Add)
            {
                _stationCurveInfo = new GRStationCurveInfo();
            }
                _stationCurveInfo.StationName = this.cmbStationName.Text;
                _stationCurveInfo.GRCurveType = (GRCurveType)this.cmbCurveName.SelectedItem;

                _stationCurveInfo.Begin = this.Begin;
                _stationCurveInfo.End = this.End;

            //}
            //else if (_adeState == ADEState.Edit)
            //{
            //}
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion //okButton_Click


        #region StationCurveInfo
        /// <summary>
        /// 
        /// </summary>
        public GRStationCurveInfo StationCurveInfo
        {
            get
            {
                return _stationCurveInfo;
            }
            set
            {
                if (_stationCurveInfo == value)
                    return;

                _stationCurveInfo = value;
                if (_stationCurveInfo == null)
                    return;
                this.cmbStationName.Text = _stationCurveInfo.StationName;
                this.cmbCurveName.Text = _stationCurveInfo.GRCurveType.Text;
                this.Begin = _stationCurveInfo.Begin;
                this.End = _stationCurveInfo.End;
            }
        } private GRStationCurveInfo _stationCurveInfo;
        #endregion //StationCurveInfo

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCurveName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
