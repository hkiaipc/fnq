using System;
using System.Diagnostics;
using KDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K
{
    public partial class frmStationSelect : NUnit.UiKit.SettingsDialogBase 
    {
        private List<tblStation> _stationList;

        public frmStationSelect(List<tblStation> stationList)
        {
            Debug.Assert(stationList != null);
            InitializeComponent();

            this._stationList = stationList;
        }

        private void frmStationSelect_Load(object sender, EventArgs e)
        {
            Fill();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Fill()
        {

            this.listView1.Items.Clear();
            foreach (tblStation item in _stationList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.StationName;
                lvi.Tag = item;
                this.listView1.Items.Add(lvi);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<tblStation> SelectedTblStationList
        {
            get
            {
                return _selectedTblStationList;              
            }
            //set
            //{
            //    if (value == null)
            //    {
            //        return;
            //    }

            //    _selectedTblStationList = value;

            //    foreach (ListViewItem lvi in this.listView1.Items)
            //    {
            //        tblStation st = lvi.Tag as tblStation;
            //        foreach ( tblStation st2 in _selectedTblStationList )
            //        {
            //            if (st.StationID == st2.StationID)
            //            {
            //                lvi.Checked = true;
            //            }
            //        }
            //    }
            //}
        } private List<tblStation> _selectedTblStationList = new List<tblStation>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if (lvi.Checked)
                {
                    tblStation st = lvi.Tag as tblStation;
                    this._selectedTblStationList.Add(st);

                    this._stationList.Remove(st);
                }
            }

            if (this._selectedTblStationList.Count == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure("请先选择站点");
                return;
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
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
