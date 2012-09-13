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
    public partial class UCDateTimePicker : UserControl, IReadonly 
    {
        /// <summary>
        /// 
        /// </summary>
        public UCDateTimePicker()
        {
            InitializeComponent();

            this.dtpDate.ValueChanged += new EventHandler(dtpDate_ValueChanged);
            this.dtpTime.ValueChanged += new EventHandler(dtpTime_ValueChanged);
            this.Value = DateTime.Now;
        }

        void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged();
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

        private void OnValueChanged()
        {
                if (this.ValueChanged != null)
                {
                    this.ValueChanged(this, EventArgs.Empty);
                }
        }

        #region IReadonly 成员

        public bool Readonly
        {
            get
            {
                return _readonly;
            }
            set
            {
                if (_readonly != value)
                {
                    _readonly = value;
                    this.dtpDate.Enabled = !_readonly;
                    this.dtpTime.Enabled = !_readonly;
                }
            }
        } private bool _readonly;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler ValueChanged;
    }
}
