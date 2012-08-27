using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CZGRQRC.UC
{
    public partial class UCCalcHeatCondition2 : UCCalcHeatCondition 
    {
        public UCCalcHeatCondition2()
        {
            InitializeComponent();
            this.dtpEndDT.Value = DateTime.Now.Date + TimeSpan.FromDays(1);
            this.dtpEndTime.Value = DateTime.Now.Date + TimeSpan.Parse("8:00");
        }


        /// <summary>
        /// 
        /// </summary>
        override public DateTime End
        {
            get 
            {
                return dtpEndDT.Value.Date + dtpEndTime.Value.TimeOfDay;
            }
        }
    }
}
