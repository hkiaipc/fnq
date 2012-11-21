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

        #region CycleDayCount
        /// <summary>
        /// 
        /// </summary>
        public int CycleDayCount
        {
            get
            {
                return _cycleDayCount;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("CycleDayCount");
                }
                if (value != _cycleDayCount)
                {
                    _cycleDayCount = value;
                    FillDayOffset();
                }
            }
        } private int _cycleDayCount = 7;
        #endregion //CycleDayCount

        /// <summary>
        /// 
        /// </summary>
        public UCTimeDefine()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCTimeDefine_Load(object sender, EventArgs e)
        {
            FillDayOffset();
        }

        void FillDayOffset()
        {
            this.cmbDayOffset.DisplayMember = "Key";
            this.cmbDayOffset.ValueMember = "Value";
            this.cmbDayOffset.DataSource = GetDayOffsetDataSource();
        }

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
                for (int i = 0; i < this.CycleDayCount; i++)
                {
                    string key = string.Format("第{0}天", i + 1);
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

                this.CycleType = _workDefine.CycleType;
                this.CycleDayCount = _workDefine.DayOfCycle;
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
                this.cmbDayOffset.SelectedValue = _timeDefine.DayOffset;
            }
        } private TimeDefine _timeDefine;

        internal TimeDefine CreateTimeDefineByUI()
        {
            TimeDefine td = new TimeDefine();
            td.DayOffset = (int)this.cmbDayOffset.SelectedValue;
            td.Begin = this.dtpBegin.Value.TimeOfDay;
            td.End = this.dtpEnd.Value.TimeOfDay;

            return td;
        }

     

    }
}
