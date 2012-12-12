using System;
using System.Diagnostics;
using Xdgk.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.UC
{
    public partial class UCTimeDefine : UserControl
    {
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

        /// <summary>
        /// 
        /// </summary>
        public UCTimeDefine()
        {
            InitializeComponent();
            FillDayOffset();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCTimeDefine_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        void FillDayOffset()
        {
            this.cmbDayOffset.DisplayMember = "Key";
            this.cmbDayOffset.ValueMember = "Value";
            this.cmbDayOffset.DataSource = GetDayOffsetDataSource();
        }

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
                //string[] weekNames = new string[] { 
                //    "星期一", "星期二", "星期三", 
                //    "星期四", "星期五", "星期六", "星期日" };

                //for (int i = 0; i < weekNames.Length; i++)
                //{
                //    kvs.Add(new KeyValue(weekNames[i], i));
                //}

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

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }

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
                    // TODO:
                    //
                    this.CycleType = CycleTypeEnum.UserDefine;
                    this.DayOfCycle = userWD.DayOfCycle;
                }
            }
        } private WorkDefine _workDefine;

        internal TimeDefine TimeDefine
        {
            get { return _timeDefine; }
            set
            {
                _timeDefine = value;

                this.dtpBegin.Value = TimeSpanHelper.TimeSpanToDateTime(_timeDefine.Begin);
                this.dtpEnd.Value = TimeSpanHelper.TimeSpanToDateTime(_timeDefine.End);

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

        internal TimeDefine CreateTimeDefineByUI()
        {
            TimeDefine r = null;
            if (this.CycleType == CycleTypeEnum.Week)
            {
                WeekTimeDefine weekTD = TimeDefine.CreateWeekTimeDefine(
                    this.GetBeginDayOfWeek(),
                    this.dtpBegin.Value.TimeOfDay,
                    this.GetEndDayOfWeek(),
                    this.dtpEnd.Value.TimeOfDay);
                r = weekTD;

            }

            if (this.CycleType == CycleTypeEnum.UserDefine)
            {
                UserTimeDefine userTD = TimeDefine.CreateUserTimeDefine(
                    this.DayOfCycle,
                    this.GetBeginDayOffset(),
                    this.dtpBegin.Value.TimeOfDay,
                    this.GetEndDayOffSet(),
                    this.dtpEnd.Value.TimeOfDay);
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

        private int GetBeginDayOffset()
        {
            return (int)this.cmbDayOffset.SelectedValue;
        }

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

        private DayOfWeek GetBeginDayOfWeek()
        {
            return (DayOfWeek)this.cmbDayOffset.SelectedValue;
        }

        
    }
}
