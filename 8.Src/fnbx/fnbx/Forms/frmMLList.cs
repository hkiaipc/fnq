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
    public partial class frmMLList : NUnit.UiKit.SettingsDialogBase  
    {
        public frmMLList()
        {
            InitializeComponent();
        }

        private void frmMLList_Load(object sender, EventArgs e)
        {
            Fill ();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Fill ()
        {
            BXDB.BxdbDataContext dc = DBFactory.GetBxdbDataContext();
            var r = from p in dc.tblMaintainLevel
                    select p;
            //var r = db.tblMaintainLevel.ToList();
            this.dataGridView1.DataSource = r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tblMaintainLevel ml = GetSelectedMaintainLevel();
            frmML f = new frmML(ml);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.Fill();
            }
        }

        private tblMaintainLevel GetSelectedMaintainLevel()
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = this.dataGridView1.SelectedCells[0].RowIndex;
                object obj = this.dataGridView1.Rows[rowIndex].DataBoundItem;
                tblMaintainLevel ml = (tblMaintainLevel)obj;
                //frmML f = new frmML(ml);
                //f.ShowDialog();
                return ml;
            }
            return null;
        }
    }
}
