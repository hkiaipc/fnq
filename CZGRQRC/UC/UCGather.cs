using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CZGRQRC
{
    public partial class UCGather : UserControl
    {
        public UCGather()
        {
            InitializeComponent();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public GatherClass GatherClass
        //{
        //    get { return _gatherClass; }
        //    set 
        //    {
        //        _gatherClass = value;
        //        UpdateGatherClass();
        //    }
        //} private GatherClass _gatherClass;

        public IList<GatherClass> GatherClasses
        {
            get { return _gatherClasses; }
            set 
            {
                if (_gatherClasses == null)
                {
                    _gatherClasses = value;
                }
                UpdateGatherClass();
            }
        } private IList<GatherClass> _gatherClasses;

        /// <summary>
        /// 
        /// </summary>
        private void UpdateGatherClass()
        {
            if (_gatherClasses == null)
            {
                this.cmbDataType.Items.Clear();
                this.txtData.Clear();
            }
            else
            {
                this.cmbDataType.DataSource = this.GatherClasses;
                this.cmbDataType.DisplayMember = "Text";
                this.cmbDataType.ValueMember = "This";
                this.NewMethod();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewMethod();
        }

        /// <summary>
        /// 
        /// </summary>
        private void NewMethod()
        {
            if (this.cmbDataType.SelectedIndex >= 0)
            {
                object obj = this.cmbDataType.SelectedValue;
                this.txtData.Text = obj.ToString();
            }
        } 
    }
}
