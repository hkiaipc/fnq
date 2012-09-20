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

        ///// <summary>
        ///// 
        ///// </summary>
        //public tblReceive Receive
        //{
        //    get { return _receive; }
        //    set
        //    {
        //        _receive = value;
        //        if (_receive != null)
        //        {
        //            this.dtpReceived.Value = _receive.rc_dt;

        //            this.Readonly = IsReadonly(App.Default.GetLoginOperatorRight(),
        //                this._receive.tblFlow[0].GetFLStatus());
        //        }
        //    }
        //} private tblReceive _receive;


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

        public void UpdateModel()
        {
            if (this.Rc != null)
            {
                _rc.rc_dt = this.dtpReceived.Value;
            }
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
                        this.Readonly = IsReadonly(
                            App.Default.GetLoginOperatorRight(), 
                            _rc.tblFlow[0].GetFLStatus());
                    }
                }
                this.Visible = _rc != null;
            }
        } private tblReceive _rc;



        public bool IsReadonly(Right rt, FLStatus status)
        {
            //return rt.Value = fnbx .Right.
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tblReceive"></param>
        /// <returns></returns>
        internal tblReceive UpdateReceive(BxdbDataContext db, tblReceive tblReceive)
        {
            if (this.Rc == null)
            {
                return null;
            }

            if (tblReceive == null)
            {
                tblReceive = new tblReceive();
            }

            tblReceive.rc_dt = this.dtpReceived.Value;
            tblReceive.tblOperator = db.tblOperator.First(c => c.op_id == App.Default.LoginOperator.op_id);

            if (tblReceive.rc_id == 0)
            {
                db.tblReceive.InsertOnSubmit(tblReceive);
            }
            return tblReceive;
        }
    }
}
