using System;
using System.Diagnostics;
using System.Windows.Forms;
using Xdgk.Common;

namespace K.UC
{
    public partial class UCTimeDefine : UserControl
    {

        #region UCTimeDefine
        /// <summary>
        /// 
        /// </summary>
        public UCTimeDefine()
        {
            InitializeComponent();
            FillDayOffset();
        }
        #endregion //UCTimeDefine

        #region UCTimeDefine_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCTimeDefine_Load(object sender, EventArgs e)
        {
        }
        #endregion //UCTimeDefine_Load

        #region CycleType
        /// <summary>
        /// 
        /// </summary>
        public CycleTypeEnum CycleType
        {
            get
            {
                return _cycleType;
            }
            set
            {
                _cycleType = value;
                FillDayOffset();
            }
        } private CycleTypeEnum _cycleType = CycleTypeEnum.Week;
        #endregion //CycleType

        #region DayOfCycle
        /// <summary>
        /// 
        /// </summary>
        public int DayOfCycle
        {
            get
            {
                return _cycleDayCount;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("DayOfCycle");
                }
                if (value != _cycleDayCount)
                {
                    _cycleDayCount = value;
                    FillDayOffset();
                }
            }
        } private int _cycleDayCount = 7;
        #endregion //DayOfCycle

        #region FillDayOffset
        /// <summary>
        /// 
        /// </summary>
        void FillDayOffset()
        {
            this.cmbDayOffset.DisplayMember = "Key";
            this.cmbDayOffset.ValueMember = "Value";
            this.cmbDayOffset.DataSource = GetDayOffsetDataSource();
        }
        #endregion //FillDayOffset

        #region GetDayOffsetDataSource
        /// <summary>
        /// 
        /// </summary>
        /// <returns>key value collection, key - name, value - offset</returns>
        private object GetDayOffsetDataSource()
        {
            object ds = null;
            if (this.CycleType == CycleTypeEnum.Week)
            {
                KeyValueCollection kvs = new KeyValueCollection();
                kvs.Add(new KeyValue("星期一", DayOfWeek.Monday));
                kvs.Add(new KeyValue("星期二", DayOfWeek.Tuesday));
                kvs.Add(new KeyValue("星期三", DayOfWeek.Wednesday));
                kvs.Add(new KeyValue("星期四", DayOfWeek.Thursday));
                kvs.Add(new KeyValue("星期五", DayOfWeek.Friday));
                kvs.Add(new KeyValue("星期六", DayOfWeek.Saturday));
                kvs.Add(new KeyValue("星期日", DayOfWeek.Sunday));

                ds = kvs;
            }

            else if (this.CycleType == CycleTypeEnum.UserDefine)
            {
                KeyValueCollection kvs = new KeyValueCollection();
                for (int i = 0; i < this.DayOfCycle; i++)
                {
                    string key = string.Format("第{0}天", i + 1);
                    int value = i;
                    kvs.Add(new KeyValue(key, i));
                }
                ds = kvs;
            }
            return ds;
        }
        #endregion //GetDayOffsetDataSource

        #region dtpEnd_ValueChanged
        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }
        #endregion //dtpEnd_ValueChanged

        #region WorkDefine
        internal WorkDefine WorkDefine
        {
            get { return _workDefine; }
            set
            {
                Debug.Assert(value != null);

                _workDefine = value;

                if (_workDefine is UserWorkDefine)
                {
                    UserWorkDefine userWD = _workDefine as UserWorkDefine;
                    this.CycleType = CycleTypeEnum.UserDefine;
                    this.DayOfCycle = userWD.DayOfCycle;
                }
            }
        } private WorkDefine _workDefine;
        #endregion //WorkDefine

        #region TimeDefine
        internal TimeDefine TimeDefine
        {
            get
            {
                return _timeDefine;
            }
            set
            {
                _timeDefine = value;

                this.dtpBegin.Value = TimeSpanHelper.TimeSpanToDateTime(_timeDefine.Begin);
                this.dtpEnd.Value = TimeSpanHelper.TimeSpanToDateTime(_timeDefine.End);

                this.dtpBeginTimeSpan.Value = DateTimeHelper.ConvertToDateTime(_timeDefine.NormalBeginTimeSpan);
                this.dtpEndTimeSpan.Value = DateTimeHelper.ConvertToDateTime(_timeDefine.NormalEndTimeSpan);

                if (_timeDefine is WeekTimeDefine)
                {
                    WeekTimeDefine weekTD = (WeekTimeDefine)_timeDefine;
                    this.cmbDayOffset.SelectedValue = weekTD.BeginWeek;
                }
                else if (_timeDefine is UserTimeDefine)
                {
                    UserTimeDefine userTD = (UserTimeDefine)_timeDefine;
                    this.cmbDayOffset.SelectedValue = userTD.BeginDayOffset;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        } private TimeDefine _timeDefine;
        #endregion //TimeDefine

        #region CreateTimeDefineByUI
        internal TimeDefine CreateTimeDefineByUI()
        {
            TimeDefine r = null;
            if (this.CycleType == CycleTypeEnum.Week)
            {
                WeekTimeDefine weekTD = TimeDefine.CreateWeekTimeDefine(
                    this.GetBeginDayOfWeek(),
                    this.dtpBegin.Value.TimeOfDay,
                    this.GetEndDayOfWeek(),
                    this.dtpEnd.Value.TimeOfDay,
                    
                    this.dtpBeginTimeSpan.Value.TimeOfDay,
                    this.dtpEndTimeSpan.Value.TimeOfDay);
                r = weekTD;

            }

            if (this.CycleType == CycleTypeEnum.UserDefine)
            {
                UserTimeDefine userTD = TimeDefine.CreateUserTimeDefine(
                    this.DayOfCycle,
                    this.GetBeginDayOffset(),
                    this.dtpBegin.Value.TimeOfDay,
                    this.GetEndDayOffSet(),
                    this.dtpEnd.Value.TimeOfDay,
                    this.dtpBeginTimeSpan.Value.TimeOfDay,
                    this.dtpEndTimeSpan.Value.TimeOfDay);
                r = userTD;
            }
            //TimeDefine td = new TimeDefine();
            //td.DayOffset = (int)this.cmbDayOffset.SelectedValue;
            //td.Begin = this.dtpBegin.Value.TimeOfDay;
            //td.End = this.dtpEnd.Value.TimeOfDay;

            //return td;
            Debug.Assert(r != null);
            return r;
        }
        #endregion //CreateTimeDefineByUI

        #region GetBeginDayOffset
        private int GetBeginDayOffset()
        {
            return (int)this.cmbDayOffset.SelectedValue;
        }
        #endregion //GetBeginDayOffset

        #region GetEndDayOffSet
        private int GetEndDayOffSet()
        {
            if (this.dtpEnd.Value.TimeOfDay <= this.dtpBegin.Value.TimeOfDay)
            {
                int n = GetBeginDayOffset();
                return (n + 1) % this.DayOfCycle;
            }
            else
            {
                return GetBeginDayOffset();
            }
        }
        #endregion //GetEndDayOffSet

        #region GetEndDayOfWeek
        private DayOfWeek GetEndDayOfWeek()
        {
            if (this.dtpEnd.Value.TimeOfDay <= this.dtpBegin.Value.TimeOfDay)
            {
                int n = (int)GetBeginDayOfWeek();
                return (DayOfWeek)((n + 1) % 7);
            }
            else
            {
                return GetBeginDayOfWeek();
            }
        }
        #endregion //GetEndDayOfWeek

        #region GetBeginDayOfWeek
        private DayOfWeek GetBeginDayOfWeek()
        {
            return (DayOfWeek)this.cmbDayOffset.SelectedValue;
        }
        #endregion //GetBeginDayOfWeek
    }
}
