using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace CZGRQRC
{
    public partial class frmPlanHeat : NUnit.UiKit.SettingsDialogBase
    {
        /// <summary>
        /// 
        /// </summary>
        public frmPlanHeat()
        {
            InitializeComponent();

            this.dgvPlanHeat.AutoGenerateColumns = false;

            DGVColumnConfigCollection cs = new Xdgk.Common.DGVColumnConfigCollection();
            cs.Add(new DGVColumnConfig("Month", "", "月份"));
            cs.Add(new DGVColumnConfig("PlanHeat", "", "计划耗热量"));

            DataGridViewColumnHelper.SetDataGridViewColumn(this.dgvPlanHeat, cs);

            RefreshGRDeviceNameListbox();
        }

        /// <summary>
        /// 
        /// </summary>
        public frmPlanHeat(int grdeviceID)
            : this()
        {
            this._grDeviceID = grdeviceID;
            this.lstDeviceName.SelectedValue = _grDeviceID;
        }

        /// <summary>
        /// 
        /// </summary>
        private int _grDeviceID = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPlanHeat_Load(object sender, EventArgs e)
        {
            this.dgvPlanHeat.AllowUserToAddRows = false;
            this.dgvPlanHeat.ReadOnly = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshGRDeviceNameListbox()
        {
            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteGRDeviceTable();
            this.lstDeviceName.DisplayMember = "DisplayName";
            this.lstDeviceName.ValueMember = "DeviceID";
            this.lstDeviceName.DataSource = tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshPlanHeatDataGridView(int selectedGRDeviceID)
        {
            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteGRDevicePlanHeatDataTable(_grDeviceID);
            this.dgvPlanHeat.DataSource = tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPlanHeatItem f = new frmPlanHeatItem(this._grDeviceID);
            DialogResult dr = f.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                RefreshPlanHeatDataGridView(_grDeviceID);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanHeat.CurrentRow != null)
            {
                DataRowView rv = this.dgvPlanHeat.CurrentRow.DataBoundItem as DataRowView ;
                int month = Convert.ToInt32(rv["month"]);
                int planHeat = Convert.ToInt32(rv["planHeat"]);
                int planHeatID = Convert.ToInt32(rv["planHeatID"]);

                PlanHeatItem item = new PlanHeatItem();
                item.Month = month;
                item.PlanHeat = planHeat;
                frmPlanHeatItem f = new frmPlanHeatItem(this._grDeviceID, planHeatID, item);
                DialogResult dr = f.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    RefreshPlanHeatDataGridView(this._grDeviceID);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstDeviceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstDeviceName.SelectedItem != null)
            {
                int id = Convert.ToInt32(this.lstDeviceName.SelectedValue);
                _grDeviceID = id;
                RefreshPlanHeatDataGridView(id);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if( this.dgvPlanHeat.CurrentRow != null )
            {
                DataRowView rv = this.dgvPlanHeat.CurrentRow.DataBoundItem as DataRowView;
                int id = Convert.ToInt32(rv["planHeatID"]);
                CZGRQRCApp.Default.DBI.DeletePlanHeat(id);
                this.RefreshPlanHeatDataGridView(_grDeviceID);
            }
        }
    }
}
