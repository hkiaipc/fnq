using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Xdgk.Common;
using System.Xml.Serialization;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class Config : Xdgk.Common.SelfSerializer
    {
        #region ConfigFileName
        /// <summary>
        /// 
        /// </summary>
        public const string ConfigFileName = "CZGRQRCConfig.xml";
        #endregion //ConfigFileName

        #region Save
        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            this.Save(ConfigFileName);
        }
        #endregion //Save

        #region Default
        /// <summary>
        /// 
        /// </summary>
        static public Config Default
        {
            get
            {
                if (s_default == null)
                {
                    try
                    {
                        object obj = Xdgk.Common.SelfSerializer.Load(typeof(Config), ConfigFileName );
                        if (obj != null)
                            s_default = (Config)obj;
                    }
                    catch
                    {
                        s_default = new Config();
                        //Xdgk.Common.SelfSerializer ss = new Xdgk.Common.SelfSerializer();
                        s_default.Save(ConfigFileName);
                    }
                }
                return s_default;
            }
        } static private Config s_default;
        #endregion //Default

        #region IsAutoRefreshGRDataLast
        /// <summary>
        /// 
        /// </summary>
        public bool IsAutoRefreshGRDataLast
        {
            get { return _isAutoRefreshGRDataLast; }
            set { _isAutoRefreshGRDataLast = value; }
        } private bool _isAutoRefreshGRDataLast = false;
        #endregion //IsAutoRefreshGRDataLast

        #region AutoRefreshGRDataLastTicks
        /// <summary>
        /// for xmlSerializer
        /// </summary>
        /// 
        [XmlElement("AutoRefreshGRDataLastTimeSpan")]
        public string AutoRefreshGRDataLastTicks
        {
            get { return _autoRefreshGRDataLastTimeSpan.ToString(); }
            set
            {
                _autoRefreshGRDataLastTimeSpan = TimeSpan.Parse(value);
            }
        }
        #endregion //AutoRefreshGRDataLastTicks

        #region AutoRefreshGRDataLastTimeSpan
        /// <summary>
        /// 
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public TimeSpan AutoRefreshGRDataLastTimeSpan
        {
            get
            {
                if (_autoRefreshGRDataLastTimeSpan <= TimeSpan.Parse("00:01:00"))
                {
                    _autoRefreshGRDataLastTimeSpan = TimeSpan.Parse("00:01:00");
                }
                return _autoRefreshGRDataLastTimeSpan;
            }
            set
            {
                _autoRefreshGRDataLastTimeSpan = value;
            }
        } private TimeSpan _autoRefreshGRDataLastTimeSpan = TimeSpan.Parse("00:10:00");
        #endregion //AutoRefreshGRDataLastTimeSpan

        #region CalcHeatStartTime
        /// <summary>
        /// 计算日耗热量的起始时间，只取时间部分
        /// </summary>
        public DateTime CalcHeatStartTime
        {
            get
            {
                return _calcHeatStartTime;
            }
            set
            {
                _calcHeatStartTime = value;
            }
        } private DateTime _calcHeatStartTime = DateTime.Parse("2000-1-1 8:00:00");
        #endregion //CalcHeatStartTime

        #region IsShowDateTimeCurveTitle
        /// <summary>
        /// 
        /// </summary>
        public bool IsShowDateTimeCurveTitle
        {
            get { return _isShowDateTimeCurveTitle; }
            set { _isShowDateTimeCurveTitle = value; }
        } private bool _isShowDateTimeCurveTitle = true;
        #endregion //IsShowDateTimeCurveTitle

        #region CalcHeatFormula
        /// <summary>
        /// 
        /// </summary>
        public string CalcHeatFormula
        {
            get { return _calcHeatFormula; }
            set { _calcHeatFormula = value; }
        } private string _calcHeatFormula = "s1 * (gt1 - bt1) * 4.1868 / dayrate / 1000";
        #endregion //CalcHeatFormula

        #region Show2DataGather
        /// <summary>
        ///
        /// </summary>
        public bool Show2DataGather
        {
            get { return _show2DataGather; }
            set { _show2DataGather = value; }
        } private bool _show2DataGather;
        #endregion //Show2DataGather

        #region Digits
        /// <summary>
        /// 
        /// </summary>
        public int Digits
        {
            get { return _digits; }
            set
            {
                if (value < 0)
                    value = 0;
                _digits = value; 
            }
        } private int _digits = 2;
        #endregion //Digits

        #region GetDigitsFormatString
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetDigitsFormatString()
        {
            return "F" + Digits;
        }
        #endregion //GetDigitsFormatString

        #region DataGridViewFont
        /// <summary>
        /// 
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public Font DataGridViewFont
        {
            get
            {
                //if (_dataGridViewFont == null)
                //    _dataGridViewFont = System.Windows.Forms.Form.DefaultFont;
                //return _dataGridViewFont;
                if( _serializableDataGridViewFont.GetFont () == null )
                {
                    _serializableDataGridViewFont.SetFont(System.Windows.Forms.Form.DefaultFont);
                }
                return _serializableDataGridViewFont.GetFont();
            }
            //set { _dataGridViewFont = value; }
            set 
            {
                if( value != null ){
                    _serializableDataGridViewFont.SetFont(value);
                }
            }
            //} private Font _dataGridViewFont;
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [XmlElement("DataGridViewFont")]
        public SerializableFont SerializableDataGridViewFont
        {
            get { return _serializableDataGridViewFont; }
            set { _serializableDataGridViewFont = value; }
        } private SerializableFont _serializableDataGridViewFont;
        #endregion //DataGridViewFont

        #region IsDebug
        /// <summary>
        /// 
        /// </summary>
        public bool IsDebug
        {
            get { return _isDebug; }
            set { _isDebug = value; }
        } private bool _isDebug;
        #endregion //IsDebug

        #region AlarmDefineCollection
        /// <summary>
        /// 
        /// </summary>
        public AlarmDefineCollection AlarmDefineCollection
        {
            get
            {
                if (_compareValuesCollection == null)
                {
                    _compareValuesCollection = new AlarmDefineCollection();
                    //RangeAlarmDefine a = new RangeAlarmDefine("gt1", 50, 90);
                    //_compareValuesCollection.Add(a);

                    //RangeValues b = new RangeValues("bt1", 20, 70);
                    //RangeValues c = new RangeValues("gp1", 0.4f, 0.8f);
                    //RangeValues d = new RangeValues("bp1", 0.2f, 0.6f);

                    //RangeValues e = new RangeValues("gt2", 40, 80);
                    //RangeValues f = new RangeValues("bt2", 10, 40);
                    //RangeValues g = new RangeValues("gp2", 0.2f, 0.6f);
                    //RangeValues h = new RangeValues("bp2", 0.1f, 0.5f);
                    //_compareValuesCollection.Add(b);
                    //_compareValuesCollection.Add(c);
                    //_compareValuesCollection.Add(d);
                    //_compareValuesCollection.Add(e);
                    //_compareValuesCollection.Add(f);
                    //_compareValuesCollection.Add(g);
                    //_compareValuesCollection.Add(h);
                }
                return _compareValuesCollection;
            }
            set { _compareValuesCollection = value; }
        } private AlarmDefineCollection _compareValuesCollection;
        #endregion //AlarmDefineCollection

        #region ColorConifg
        /// <summary>
        /// 
        /// </summary>
        public ColorConfig ColorConifg
        {
            get 
            {
                if (_colorConfig == null)
                    _colorConfig = new ColorConfig();
                return _colorConfig; 
            }
            set { _colorConfig = value; }
        } private ColorConfig _colorConfig;
        #endregion //ColorConifg

        #region RendererType
        /// <summary>
        /// 
        /// </summary>
        public RendererType RendererType
        {
            get { return _rendererType; }
            set { _rendererType = value; }
        } private RendererType _rendererType = RendererType.Fore;
        #endregion //RendererType


        #region GRAlarmMaxCount
        /// <summary>
        /// 报警窗口最大记录条数
        /// </summary>
        public int GRAlarmMaxCount
        {
            get { return _gralarmMaxCount; }
            set 
            {
                _gralarmMaxCount = value;
                if (_gralarmMaxCount <= 0)
                    _gralarmMaxCount = 1;
            }
        } private int _gralarmMaxCount = 7;
        #endregion //GRAlarmMaxCount

        #region EnableGRExceptionValueColor
        /// <summary>
        /// 是否启用最新供热数据超范围数据颜色显示
        /// </summary>
        public bool EnableGRExceptionValueColor
        {
            get { return _enableGRExceptionValueColor; }
            set { _enableGRExceptionValueColor = value; }
        } private bool _enableGRExceptionValueColor = false;
        #endregion //EnableGRExceptionValueColor

        #region EnableGRAlarmValueColor
        /// <summary>
        /// 是否启用报警相关数据颜色显示
        /// </summary>
        public bool EnableGRAlarmValueColor
        {
            get { return _enableGRAlarmValueColor; }
            set { _enableGRAlarmValueColor = value; }
        } private bool _enableGRAlarmValueColor = false;
        #endregion //EnableGRAlarmValueColor


        #region EnableGRAlarmPopup
        /// <summary>
        /// 
        /// </summary>
        public bool EnableGRAlarmPopup
        {
            get { return _enableGRAlarmPopup; }
            set { _enableGRAlarmPopup = value; }
        } private bool _enableGRAlarmPopup = false;
        #endregion //EnableGRAlarmPopup


    }
}
