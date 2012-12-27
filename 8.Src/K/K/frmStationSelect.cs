using System;
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
        public frmStationSelect()
        {
            InitializeComponent();
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
            DB db = DBFactory.GetDB();
            var stations = from q in db.tblStation
                           where q.tblDevice.Any(c => c.DeviceType == "xgdevice")
                           orderby q.StationName 
                           select q;

            foreach (tblStation item in stations.ToList())
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
            set
            {
                if (value == null)
                {
                    return;
                }

                _selectedTblStationList = value;

                foreach (ListViewItem lvi in this.listView1.Items)
                {
                    tblStation st = lvi.Tag as tblStation;
                    foreach ( tblStation st2 in _selectedTblStationList )
                    {
                        if (st.StationID == st2.StationID)
                        {
                            lvi.Checked = true;
                        }
                    }
                }
            }
        } private List<tblStation> _selectedTblStationList;
    }
}
