﻿using System;
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
    public partial class frmMTList : Form
    {
        public frmMTList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Right rt = App.Default.GetLoginOperatorRight();
            if (!rt.CanActivateForTm(Xdgk.Common.ADEState.Add, MTStatus.Created))
            {
                NUnit.UiKit.UserMessage.DisplayFailure("cannot add tm");
                return;
            }

            tblMaintain mt = MaintainFactory.Create();

            frmMT f = new frmMT();
            f.Maintain = mt;
            f.AdeStatus = Xdgk.Common.ADEState.Add;

            if (f.ShowDialog() == DialogResult.OK)
            {
                this.Fill();
            }
        }

        private void frmMTList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Fill()
        {
            BxdbDataContext dc = Class1.GetBxdbDataContext();

            var r = from q in dc.tblMaintain
                    select q;

            this.dataGridView1.DataSource = r;
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            tblMaintain mt = this.GetSelectedMaintain();

            Right rt = App.Default.GetLoginOperatorRight();
            if (!rt.CanActivateForTm(Xdgk.Common.ADEState.Edit, mt.GetMtStatus()))
            {
                NUnit.UiKit.UserMessage.DisplayFailure("cannot edit");
                return;
            }

            frmMT f = new frmMT();
            f.AdeStatus = Xdgk.Common.ADEState.Edit;
            f.IsViewMode = true;
            f.Maintain = mt;
            if (f.ShowDialog() == DialogResult.OK)
            {
                Fill();
            }
        }

        private tblMaintain GetSelectedMaintain()
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                int index = this.dataGridView1.SelectedCells[0].RowIndex;
                tblMaintain mt = (tblMaintain)this.dataGridView1.Rows[index].DataBoundItem;
                return mt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// del
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            tblMaintain mt = this.GetSelectedMaintain();

            Right rt = App.Default.GetLoginOperatorRight();
            if (!rt.CanActivateForTm(Xdgk.Common.ADEState.Delete, mt.GetMtStatus()))
            {
                NUnit.UiKit.UserMessage.DisplayFailure("cannot delete.");
                return ;
            }

            if (NUnit.UiKit.UserMessage.Ask("delete?") == DialogResult.Yes)
            {
                BxdbDataContext dc = Class1.GetBxdbDataContext();
                dc.tblMaintain.DeleteOnSubmit(mt);

                dc.SubmitChanges();
                Fill();
            }
        }

        /// <summary>
        /// jie dan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            tblMaintain mt = this.GetSelectedMaintain();
            // TOOD: mt == null
            //

            frmMT f = new frmMT();
            f.Maintain = mt;
            if (f.ShowDialog() == DialogResult.OK)
            {
                Fill();
            }
        }
    }
}
