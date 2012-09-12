using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fnbx
{
    public partial class UCDateTimePicker : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public UCDateTimePicker()
        {
            InitializeComponent();

            this.Value = DateTime.Now;
        }


        /// <summary>
        /// 
        /// </summary>
        public DateTime Value
        {
            get { return dtpDate.Value.Date + TimeSpan.FromSeconds((int)dtpTime.Value.TimeOfDay.TotalSeconds); }
            set
            {
                this.dtpDate.Value = value.Date;
                this.dtpTime.Value = value;
            }
        }
    }
}
