using System;
using KDB;
using Xdgk.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms
{
    public partial class frmTMDataQuery : Form
    {

        private enum QueryStyleEnum
        {
            ByStation,
            ByPerson,
        }

        public frmTMDataQuery()
        {
            InitializeComponent();
            this.Begin = DateTime.Now.Date.AddDays(-1d);
            this.End = DateTime.Now.Date;
            BindQueryStyle();
            BindStation();
            BindPerson();
        }

        private void BindPerson()
        {
            DB db = DBFactory.GetDB();
            var r = from q in db.tblPerson
                    orderby q.PersonName
                    select q;

            this.cmbPerson.DisplayMember = "PersonName";
            this.cmbPerson.ValueMember = "PersonID";
            this.cmbPerson.DataSource = r;
        }

        private void BindStation()
        {
            DB db = DBFactory.GetDB();
            var r = from q in db.tblStation
                    orderby q.StationName
                    select q;

            this.cmbStation.DisplayMember = "StationName";
            this.cmbStation.ValueMember = "StationID";
            this.cmbStation.DataSource = r;
        }

        private void BindQueryStyle()
        {
            KeyValueCollection kvs = new KeyValueCollection();
            kvs.Add(new KeyValue("按站点", QueryStyleEnum.ByStation));
            kvs.Add(new KeyValue("按人员", QueryStyleEnum.ByPerson));

            this.cmbQueryStyle.DisplayMember = "Key";
            this.cmbQueryStyle.ValueMember = "Value";
            this.cmbQueryStyle.DataSource = kvs;
        }


        private void frmTMDataQuery_Load(object sender, EventArgs e)
        {
            this.panPerson.Location = this.panStation.Location;
        }

        private void cmbQueryStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryStyleEnum style = this.SelectedQueryStyleEnum;
            this.panPerson.Visible = style == QueryStyleEnum.ByPerson;
            this.panStation.Visible = style == QueryStyleEnum.ByStation;
        }

        /// <summary>
        /// 
        /// </summary>
        private QueryStyleEnum SelectedQueryStyleEnum
        {
            get
            {
                return (QueryStyleEnum)this.cmbQueryStyle.SelectedValue;
            }
            set
            {
                this.cmbQueryStyle.SelectedValue = value;
            }
        }

        public DateTime Begin
        {
            get { return this.dtpBegin.Value; }
            set { this.dtpBegin.Value = value; }
        }

        public DateTime End
        {
            get { return this.dtpEnd.Value; }
            set { this.dtpEnd.Value = value; }
        }

        public int SelectedPersonID
        {
            get 
            {
                if (this.cmbPerson.Items.Count == 0)
                {
                    return -1;
                }
                return (int)this.cmbPerson.SelectedValue;
            }
            set
            {
                try
                {
                    this.cmbPerson.SelectedValue = value;
                }
                catch
                {
                }
            }
        }

        public int SelectedStationID
        {
            get {
                if (this.cmbStation.Items.Count == 0)
                {
                    return -1;
                }
                return (int)this.cmbStation.SelectedValue;
            }
            set {
                try
                {
                    this.cmbStation.SelectedValue = value;
                }
                catch { }

            }
        }

        private void Query()
        {
            DB db = DBFactory.GetDB();
            object ds = null;
            if (this.SelectedQueryStyleEnum == QueryStyleEnum.ByStation)
            {
                var r = from q in db.tblTmData
                    where q.TmDataDT >= this.Begin && q.TmDataDT < this.End
                        && q.tblDevice.tblStation.StationID == this.SelectedStationID
                    select q;
                DataTable t = ConvertToDataTable(r.ToList());
                ds = t;
            }
            if (this.SelectedQueryStyleEnum == QueryStyleEnum.ByPerson)
            {

                int tmID = GetSelectedPersonTMID(db);

                var r = from q in db.tblTmData
                        where q.TmDataDT >= this.Begin && q.TmDataDT < this.End
                            && q.tblTM.TmID == tmID
                        select q;
                        //select new { datetetttt = q.TmDataDT,
                        //snnn= q.tblTM.TmSN };
                DataTable t = ConvertToDataTable(r.ToList());
                ds = t ;
            }

            this.dataGridView1.DataSource = ds;
        }

        private DataTable ConvertToDataTable(IList<tblTmData> list)
        {
            DataTable tbl = new DataTable();

            tbl.Columns.Add("StationName", typeof(string));
            tbl.Columns.Add("PersonName", typeof(string));
            tbl.Columns.Add("TMSN", typeof(string));
            tbl.Columns.Add("DT", typeof(DateTime));

            foreach (tblTmData item in list)
            {
                DataRow row = tbl.NewRow();
                tbl.Rows.Add ( 
                    item.tblDevice.tblStation.StationName ,
                    item.tblTM.tblPerson.First ().PersonName ,
                    item.tblTM.TmSN ,
                    item.TmDataDT );
            }

            return tbl;
        }

        private int GetSelectedPersonTMID(DB db)
        {
            var r = from q in db.tblPerson
                    where q.PersonID == SelectedPersonID
                    select q.TmID;

            if (r.Count() > 0)
            {
                return (int)r.First();
            }
            else
            {
                return -1;
            }

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Query();
        }
    }
}
