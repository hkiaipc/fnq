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
    public partial class UCIt : UserControl, IReadonly, IView
    {
        public UCIt()
        {
            InitializeComponent();
        }

        #region Readonly
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
                if (_readonly != value)
                {
                    _readonly = value;

                    //
                    //
                    //this.txtIntroducerName.ReadOnly = true;
                    ReadonlyHelper.SetReadonlyStyle(
                        new Control[] { this.txtIntroducerName, this.txtAddress, this.txtPhone },
                        _readonly);
                }
            }
        } private bool _readonly;

        #endregion

        #region It
        public tblIntroducer It
        {
            get { return _it; }
            set
            {
                if (_it != value)
                {
                    _it = value;
                    if (_it != null)
                    {
                        txtIntroducerName.Text = _it.it_name;
                        txtAddress.Text = _it.it_address;
                        txtPhone.Text = _it.it_phone;
                        // TODO: jiaof
                        //

                        this.Readonly = IsReadonly(App.Default.GetLoginOperatorRight(),
                            _it.tblFlow[0].GetFLStatus());

                    }
                }
            }
        } private tblIntroducer _it;
        #endregion //It

        #region UpdateModel
        /// <summary>
        /// 
        /// </summary>
        public void UpdateModel()
        {
            _it.it_name = txtIntroducerName.Text.Trim();
            _it.it_phone = txtPhone.Text.Trim();
            _it.it_address = txtAddress.Text.Trim();
        }
        #endregion //UpdateModel

        #region CheckInput
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CheckInput()
        {
            bool r = true;
            if (this.txtIntroducerName.Text.Trim().Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.ITNameEmpty);
                r = false;
            }
            else if (this.txtAddress.Text.Trim().Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.ITAddressEmpty);
                r = false;
            }
            else if (this.txtPhone.Text.Trim().Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.ITPhoneEmpty);
                r = false;
            }
            return r;
        }
        #endregion //CheckInput

        #region IView 成员


        public bool IsReadonly(Right rt, FLStatus status)
        {
            return !(rt.Value == fnbx.Right.SenderValue &&
                (status == FLStatus.New || status == FLStatus.Created));
        }

        #endregion
    }
}
