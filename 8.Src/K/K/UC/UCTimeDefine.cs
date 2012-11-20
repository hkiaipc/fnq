using System;
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

            else if (this.CycleType == CycleTypeEnum.UserDefine )
            {
                KeyValueCollection kvs = new KeyValueCollection();
                for (int i = 0; i < this.CycleDayCount; i++)
                {
                    string key = string.Format("第{0}天", i + 1);
                    kvs.Add(new KeyValue(key,i));
                }
                ds = kvs;
            }
            return ds;
        }
    }
}
