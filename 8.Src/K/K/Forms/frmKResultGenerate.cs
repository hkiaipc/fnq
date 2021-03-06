﻿using System;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// button gather
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (_groupResults == null)
            {
                NUnit.UiKit.UserMessage.DisplayFailure("未生成考勤结果, 无法统计");
                return;
            }

            PersonGatherCollection r = KGatherGenerator.Generator(_groupResults);
            DataTable tbl = GatherDataTableConverter.ToGatherDataTable(r);
            tbl.ExtendedProperties["month"] = this.dtpMonth.Value;

            frmGather f = new frmGather(tbl);
            f.ShowDialog();
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
                    xls.SheetName = GetSheetName(gr, pr);
                    DataTable tbl = ResultDataTableConverter.ToPersonResultDataTable(pr);
                    Write(xls, tbl, pr.CalcSumOfWorkTimeSpan());
                }
            }
            xls.Save(file);

            Open(file);
        }

        private Dictionary<string, int> _sheetNameDict = new Dictionary<string, int>();

        private string GetSheetName(GroupResult gr, PersonResult pr)
        {
            string baseName = gr.TblGroup.GroupName + " " + pr.TblPerson.PersonName;
            string name = baseName;
            if (_sheetNameDict.ContainsKey(baseName))
            {
                _sheetNameDict[baseName]++;
                name = baseName + _sheetNameDict[baseName];
            }
            else
            {
                _sheetNameDict[baseName] = 0;
            }
            return name;
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

        private void Write(XlsFile xls, DataTable tbl, TimeSpan ts)
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

            xls.SetCellValue(r, 1, string.Format("累计工作时长: {0}", ts));
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

    internal class DataTableExporter
    {
        private DataTable _tbl;
        private DateTime _month;

        internal DataTableExporter(DateTime month, DataTable tbl)
        {
            _month = month;
            _tbl = tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void Export()
        {
            string file = Path.GetTempFileName("xls");
            XlsFile xls = new XlsFile();
            xls.NewFile();
            string title = string.Format("鑫丰热力供热处职工人员考勤表 {0}-{1}", _month.Year, _month.Month);
            xls.SetCellValue(1, 1, title);
            
            int r = 3;
            int c = 1;
            foreach (DataColumn col in _tbl.Columns)
            {
                xls.SetCellValue(r, c, col.ColumnName);
                c++;
            }

            foreach (DataRow row in _tbl.Rows)
            {
                r++;
                for (int i = 0; i < _tbl.Columns.Count; i++)
                {
                    xls.SetCellValue(r, i + 1, row[i]);
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

    }
}
