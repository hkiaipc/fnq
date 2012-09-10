using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BXDB;

namespace fnbx
{
    public partial class frmOperatorList : NUnit.UiKit.SettingsDialogBase
    {
        public frmOperatorList()
        {
            InitializeComponent();
        }

        #region Fill
        /// <summary>
        /// 
        /// </summary>
        private void Fill()
        {
            BxdbDataContext dc = Class1.GetBxdbDataContext();
            var r = from q in dc.tblOperator
                    select q;

            this.dataGridView1.DataSource = r;
        }
        #endregion //Fill

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOperator_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOperator f = new frmOperator();
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Fill();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tblOperator op = GetSelectedOperator();
            if (op != null)
            {
                frmOperator f = new frmOperator(op);
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tblOperator op = GetSelectedOperator();
            if (op != null)
            {
                if (NUnit.UiKit.UserMessage.Ask("delete?") == DialogResult.Yes)
                {
                    BXDB.BxdbDataContext dc = Class1.GetBxdbDataContext();
                    dc.tblOperator.DeleteOnSubmit(op);
                    dc.SubmitChanges();

                    Fill();
                }
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure("not select");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private tblOperator GetSelectedOperator()
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                int idx = this.dataGridView1.SelectedCells[0].RowIndex;
                tblOperator op = (tblOperator)this.dataGridView1.Rows[idx].DataBoundItem;
                return op;
            }
            else
            {
                return null;
            }
        }
    }
}
