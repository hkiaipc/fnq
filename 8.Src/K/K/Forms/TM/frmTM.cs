using System;
using KDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms.TM
{
    public partial class frmTM : Form
    {
        public frmTM()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void frmTM_Load(object sender, EventArgs e)
        {
            Fill();
        }

        /// <summary>
        /// 
        /// </summary>
        void Fill()
        {
            DB db = DBFactory.GetDB();

            var r = from q in db.tblTM
                    select q;

            this.dataGridView1.DataSource = ConvertToDataTable(r.ToList ());
        }

        private object ConvertToDataTable(List<tblTM> list)
        {
            DataTable t = new DataTable();
            t.Columns.Add("TM", typeof(string));
            t.Columns.Add("PersonName", typeof(string));
            t.Columns.Add("tblTM", typeof(object));

            foreach (var item in list)
            {

                object[] values = new object[] { item.TmSN, GetPersonName(item),item };
                t.Rows.Add(values);
            }
            return t;
        }

        private object GetPersonName(tblTM item)
        {
            if (item.tblPerson.Count > 0)
            {
                return item.tblPerson[0].PersonName;
            }
            return string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTMItem f = new frmTMItem();
            if(f.ShowDialog () == DialogResult .OK )
            {
                Fill ();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmTMItem f = new frmTMItem();
            f.TblTM = GetSelectedTM();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Fill();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private tblTM GetSelectedTM()
        {
            DataRowView v = this.dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            tblTM tm = v["tblTM"] as tblTM;
            return tm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow == null)
            {
                return;
            }

                tblTM tm = GetSelectedTM();
                if (tm.tblPerson.Count > 0)
                {
                    NUnit.UiKit.UserMessage.DisplayFailure("TM卡已经分配给人员, 不能删除");
                    return;
                }

            if (NUnit.UiKit.UserMessage.Ask(Strings.SureDelete) == DialogResult.Yes)
            {
                DB db = DBFactory.GetDB();
                var r = from q in db.tblTM 
                        where q.TmID == tm.TmID 
                        select q ;

                tblTM tm2 = r.First();
                db.tblTM.DeleteOnSubmit(tm2);

                db.SubmitChanges();


                Fill();

            }
        }
    }
}
