using System;
using KDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms.WD
{
    public partial class frmWorkDefine : Form
    {
        public frmWorkDefine()
        {
            InitializeComponent();
        }

        private void frmWorkDefine_Load(object sender, EventArgs e)
        {
            Fill();
        }

        /// <summary>
        /// 
        /// </summary>
        void Fill()
        {
            DB db = DBFactory.GetDB();
            var r = from q in db.tblWorkDefine
                    select q;

            this.dataGridView1.DataSource = r;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmWorkDefineItem f = new frmWorkDefineItem();
            f.WorkDefine = WorkDefine.Create(CycleTypeEnum.Week);
            f.IsAdd = true;
            if (f.ShowDialog() == DialogResult.OK)
            {
                Fill();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            tblWorkDefine tblWD = GetSelectedWorkDefine();
            if (tblWD != null)
            {
                frmWorkDefineItem f = new frmWorkDefineItem();

                f.TblWorkDefine = tblWD;
                f.IsAdd = false;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Fill();
                }
            }
        }

        private tblWorkDefine GetSelectedWorkDefine()
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                return this.dataGridView1.CurrentRow.DataBoundItem as tblWorkDefine;
            }
            return null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            tblWorkDefine wd = this.GetSelectedWorkDefine();
            if (wd != null)
            {
                    DB db = DBFactory.GetDB();
                    tblWorkDefine temp = db.tblWorkDefine.Single(
                        c => c.WorkDefineID == wd.WorkDefineID);

                    if (temp.tblGroup.Count > 0)
                    {
                        string msg = "该班次正在被使用, 无法删除";
                        NUnit.UiKit.UserMessage.DisplayFailure(msg);
                        return;
                    }

                if (NUnit.UiKit.UserMessage.Ask(Strings.SureDelete) == DialogResult.Yes)
                {

                    db.tblWorkDefine.DeleteOnSubmit(temp);

                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        NUnit.UiKit.UserMessage.DisplayFailure(ex.ToString());
                        return;
                    }

                    Fill();
                }
            }
        }
    }
}
