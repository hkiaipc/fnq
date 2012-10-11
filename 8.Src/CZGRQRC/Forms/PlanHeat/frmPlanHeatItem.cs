using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;
using CZGRWEBDBI;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmPlanHeatItem : NUnit.UiKit.SettingsDialogBase
    {
        private ADEStatus _adeState;

        private PlanHeatItem _planHeatItem;
        private int _grDeviceID;
        private int _editMonth = -1;
        private int _planHeatID = -1;

        /// <summary>
        /// 
        /// </summary>
        private void InitControls()
        {
            // 1 ~ 12 month
            //
            this.numMonth.Minimum = 1;
            this.numMonth.Maximum = 12;

            // 0 ~ 10^8 GJ
            //
            this.numPlanHeat.Minimum = 0;
            this.numPlanHeat.Maximum = 10000 * 10000;   
        }

        /// <summary>
        /// 
        /// </summary>
        public frmPlanHeatItem( int grdeviceID, int planHeatID, PlanHeatItem planHeatItem)
        {
            if (planHeatItem == null)
                throw new ArgumentNullException("dbGRPlanHeat");

            InitializeComponent();
            InitControls();
            this._planHeatItem = planHeatItem;
            this._grDeviceID = grdeviceID;
            this._planHeatID = planHeatID;
            this._editMonth = planHeatItem.Month;
            this._adeState = ADEStatus.Edit;


            this.numMonth.Value = this._planHeatItem.Month;
            this.numPlanHeat.Value = this._planHeatItem.PlanHeat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbgrDevice"></param>
        public frmPlanHeatItem(int  grDeviceID)
        {
            InitializeComponent();
            InitControls();

            this._grDeviceID = grDeviceID;
            this._adeState = ADEStatus.Add;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPlanHeatItem_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (ExistMonth((int)this.numMonth.Value, _planHeatID))
            {
                // TODO: 
                //
                NUnit.UiKit.UserMessage.DisplayInfo(string.Format("月份已存在!",
                    (int)this.numMonth.Value));
                return;
            }

            if (_adeState == ADEStatus.Add)
            {
                //_planHeatItem = new DBGRPlanHeat();
                //_planHeatItem.DBGRDevice = this._grDeviceID;
                //_planHeatItem.Month = (int)this.numMonth.Value;
                //_planHeatItem.PlanHeat = (int)this.numPlanHeat.Value;

                //_planHeatItem.Save();
                //_grDeviceID.PlanHeats.Add(_planHeatItem);
                CZGRQRCApp.Default.DBI.InsertPlanHeat(this._grDeviceID, 
                    (int)this.numMonth.Value,
                    (int)this.numPlanHeat.Value);
            }
            else if (_adeState == ADEStatus.Edit)
            {
                //_planHeatItem.Month = (int)this.numMonth.Value;
                //_planHeatItem.PlanHeat = (int)this.numPlanHeat.Value;
                //_planHeatItem.Save();
                CZGRQRCApp.Default.DBI.UpdatePlanHeat(this._planHeatID, 
                    (int)this.numMonth.Value,
                    (int)this.numPlanHeat.Value);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        private bool ExistMonth(int month, int ignorePlanHeatID)
        {
            return CZGRQRCApp.Default.DBI.ExistMonth(this._grDeviceID, month, ignorePlanHeatID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
