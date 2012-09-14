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
    public partial class frmFlowList : Form
    {
        public frmFlowList()
        {
            InitializeComponent();
        }

        private void AddFL()
        {
            Right rt = App.Default.GetLoginOperatorRight();
            if (!rt.CanActivateForFL(Xdgk.Common.ADEState.Add, FLStatus.Created))
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.CannotCreateMT);
                return;
            }

            //tblMaintain fl = MaintainFactory.Create();
            tblFlow fl = FlowFactory.Create();
            frmFlow f = new frmFlow();
            f.FL = fl;

            //frmMT f = new frmMT();
            //f.Maintain = fl;
            //f.AdeStatus = Xdgk.Common.ADEState.Add;

            if (f.ShowDialog() == DialogResult.OK)
            {
                this.Fill();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            var r = from q in dc.tblFlow
                    select q;

            this.dataGridView1.DataSource = r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fl"></param>
        /// <returns></returns>
        private bool CheckSelectedFlow(tblFlow fl)
        {
            if (fl == null)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.SelectMTFirst);
            }
            return fl != null;
        }

        private tblFlow GetSelectedFlow()
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                int index = this.dataGridView1.SelectedCells[0].RowIndex;
                tblFlow mt = (tblFlow )this.dataGridView1.Rows[index].DataBoundItem;
                return mt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeleteFL ()
        {
            tblFlow fl = this.GetSelectedFlow();
            if (CheckSelectedFlow(fl))
            {
                Right rt = App.Default.GetLoginOperatorRight();
                if (!rt.CanActivateForFL(Xdgk.Common.ADEState.Delete, fl.GetFLStatus()))
                {
                    NUnit.UiKit.UserMessage.DisplayFailure(Strings.CannotDeleteMT);
                    return;
                }

                if (NUnit.UiKit.UserMessage.Ask(Strings.SureDelete) == DialogResult.Yes)
                {
                    BxdbDataContext dc = Class1.GetBxdbDataContext();
                    dc.tblFlow.DeleteOnSubmit(fl);

                    dc.SubmitChanges();
                    Fill();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ViewFL ()
        {
            tblFlow  fl = this.GetSelectedFlow();
            if (CheckSelectedFlow (fl))
            {
                //frmMT f = new frmMT();
                frmFlow f = new frmFlow();
                f.FL = fl;
                //f.AdeStatus = Xdgk.Common.ADEState.Edit;
                //f.Maintain = fl;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Fill();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            AddFL();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbView_Click(object sender, EventArgs e)
        {
            ViewFL();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            this.DeleteFL();
        }

        private void tsbFind_Click(object sender, EventArgs e)
        {
            NUnit.UiKit.UserMessage.DisplayFailure("NotImplemented");
        }
    }
}
