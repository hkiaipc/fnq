using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BXDB;

namespace fnbx
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCRc : UserControl,IReadonly ,IView 
    {
        public UCRc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public tblReceive Receive
        {
            get { return _receive; }
            set
            {
                _receive = value;
                if (_receive != null)
                {
                    this.dtpReceived.Value = _receive.rc_dt;

                    this.Readonly = IsReadonly(App.Default.GetLoginOperatorRight(),
                        this._receive.tblFlow[0].GetMtStatus());
                }
            }
        } private tblReceive _receive;

        #region IReadonly 成员

        /// <summary>
        /// 
        /// </summary>
        public bool Readonly
        {
            get
            {
                return _readonly;
            }
            set
            {
                if (value != _readonly)
                {
                    _readonly = value;
                    this.dtpReceived.Readonly = _readonly;
                }
            }
        } private bool _readonly;

        #endregion

        #region IView 成员

        public void UpdateModel()
        {
            _rc.rc_dt = this.dtpReceived.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CheckInput()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public tblReceive Rc
        {
            get { return _rc; }
            set
            {
                if (_rc != value)
                {
                    _rc = value;
                    if (_rc != null)
                    {
                        this.dtpReceived.Value = _rc.rc_dt;
                    }
                }
            }
        } private tblReceive _rc;

        #endregion

        #region IView 成员


        public bool IsReadonly(Right rt, FLStatus status)
        {
            //return rt.Value = fnbx .Right.
            return true;
        }

        #endregion
    }
}
