using System;
using System.Diagnostics;
using Xdgk.Common;
using FlexCel;
using FlexCel.XlsAdapter;
using KDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms
{
    public partial class frmKResultGenerate : Form
    {
        public frmKResultGenerate()
        {
            InitializeComponent();

            this.FillGroup();
        }

        private void frmKResultGenerate_Load(object sender, EventArgs e)
        {

        }

        void FillPerson(int groupID)
        {
            DB db = DBFactory.GetDB();
            var r = from q in db.tblPerson
                    where q.GroupID == groupID
                    orderby q.PersonName
                    select q;

            this.cmbPerson.DisplayMember = "PersonName";
            this.cmbPerson.ValueMember = "PersonID";
            this.cmbPerson.DataSource = r;
        }

        void FillGroup()
        {
            DB db = DBFactory.GetDB();
            List<tblGroup> groupList = db.tblGroup.ToList();

            this.cmbGroup.DisplayMember ="GroupName";
            this.cmbGroup.ValueMember = "GroupID";

            this.cmbGroup.DataSource = groupList;
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbGroup.SelectedIndex >= 0)
            {
                int groupID = (int)this.cmbGroup.SelectedValue;
                FillPerson(groupID);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // clear panel
            //
            this.panel1.Controls.Clear();

            DateTime month = new DateTime(
                this.dtpMonth.Value.Year,
                this.dtpMonth.Value.Month,
                1);

            DB db = DBFactory.GetDB();
            KResultGenerator gen = new KResultGenerator(db, month);
            GroupResultCollection grs = gen.Generate();
            _groupResults = grs;

            Control c =  UIHelper.Create(grs);
            c.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(c);


        }

        /// <summary>
        /// 
        /// </summary>
        private GroupResultCollection _groupResults;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// export to excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (_groupResults != null)
            {
                new Exporter().Export(_groupResults);
            }
        }
    }

    internal class Exporter
    {
        private GroupResultCollection _grs;

        internal void Export(GroupResultCollection grs)
        {
            _grs = grs;

            string file = Path.GetTempFileName("xls");
            XlsFile xls = new XlsFile();
            xls.NewFile(GetPersonCount());

            int n = 0;
            foreach (GroupResult gr in grs)
            {
                foreach (PersonResult pr in gr.PersonResults)
                {
                    n++;
                    xls.ActiveSheet = n;
                    xls.SheetName = gr.TblGroup.GroupName + " " + pr.TblPerson.PersonName;
                    DataTable tbl = ResultDataTableConverter.ToPersonResultDataTable(pr);
                    Write(xls, tbl);
                }
            }
            xls.Save(file);

            Open(file);
        }

        private void Open(string filename)
        {
            ProcessStartInfo si = new ProcessStartInfo(filename);
            si.ErrorDialog = true;

            Process process = new Process();
            process.StartInfo = si;
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
            }
            process.Dispose();
        }

        private void Write(XlsFile xls, DataTable tbl)
        {
            int r = 1, c = 1;
            foreach ( DataColumn col in tbl.Columns )
            {
                xls.SetCellValue(r, c, col.ColumnName);
                c++;
            }

            r++;
            
            int colCount = tbl.Columns.Count ;
            foreach (DataRow row in tbl.Rows)
            {
                for (int i = 0; i < colCount; i++)
                {
                    xls.SetCellValue(r, i + 1, row[i]);
                }
                r++;
            }
        }

        private int GetPersonCount()
        {
            int n = 0;
            foreach (GroupResult gr in _grs)
            {
                foreach (PersonResult pr in gr.PersonResults)
                {
                    n++;
                }
            }
            return n;
        }
    }
}
