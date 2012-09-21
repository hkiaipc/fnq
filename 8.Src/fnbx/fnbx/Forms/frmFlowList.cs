using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BXDB;
using Xdgk.Common;

namespace fnbx
{
    public partial class frmFlowList : Form
    {

        #region frmFlowList
        public frmFlowList()
        {
            InitializeComponent();
        }
        #endregion //frmFlowList

        #region AddFL
        /// <summary>
        /// 
        /// </summary>
        private void AddFL()
        {
            Right rt = App.Default.GetLoginOperatorRight();
            if (!rt.CanActivateForFL(Xdgk.Common.ADEState.Add, FLStatus.Created))
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.CannotCreateMT);
                return;
            }

            tblFlow fl = FlowFactory.Create();



            frmFlow f = new frmFlow();
            f.FL = fl;

            //frmMT f = new frmMT();
            //f.Maintain = fl;
            //f.AdeStatus = Xdgk.Common.ADEState.Add;

            if (f.ShowDialog() == DialogResult.OK)
            {
            }
            this.Fill();
        }
        #endregion //AddFL

        #region frmMTList_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMTList_Load(object sender, EventArgs e)
        {
            SetDataGtidViewColumns();
            Fill();
            
        }
        #endregion //frmMTList_Load

        #region SetDataGtidViewColumns
        /// <summary>
        /// 
        /// </summary>
        private void SetDataGtidViewColumns()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns.Clear();

            string[] displayColumns = App.Default.Config.DisplayFlowColumns;

            DGVColumnConfigCollection dgvccs = DataGirdviewColumnProvider.GetFlowDgvColumnConfigs(displayColumns);
            foreach (DGVColumnConfig item in dgvccs)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = item.DataPropertyName;
                col.HeaderText = item.Text;
                col.DefaultCellStyle.Format = item.Format;

                this.dataGridView1.Columns.Add(col);
            }
        }
        #endregion //SetDataGtidViewColumns

        #region Fill
        /// <summary>
        /// 
        /// </summary>
        private void Fill()
        {
            //this.dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;

            BxdbDataContext dc = DBFactory.GetBxdbDataContext();

            var r = from q in dc.tblFlow
                    select q;

            F[] fs =FlowConverter.Convert(r.ToArray());
            DataTable tbl = FlowConverter.Convert(fs);
            this.dataGridView1.DataSource = tbl;
        }
        #endregion //Fill

        #region CheckSelectedFlow
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
        #endregion //CheckSelectedFlow

        #region GetSelectedFlow
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private tblFlow GetSelectedFlow()
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                int index = this.dataGridView1.SelectedCells[0].RowIndex;
                tblFlow fl = (tblFlow)((DataRowView)(this.dataGridView1.Rows[index].DataBoundItem))["TblFlow"];
                return fl;
            }
            else
            {
                return null;
            }
        }
        #endregion //GetSelectedFlow

     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region 新建
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            AddFL();
        }
        #endregion //新建

        #region tsbView_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbView_Click(object sender, EventArgs e)
        {
            ViewFL();
        }
        #endregion //tsbView_Click

        #region ViewFL
        /// <summary>
        /// 
        /// </summary>
        private void ViewFL()
        {
            tblFlow fl = this.GetSelectedFlow();
            if (!CheckSelectedFlow(fl))
            {
                return;
            }
            var db = DBFactory .GetBxdbDataContext ();

            var v = db.tblFlow.First(c => c.fl_id == fl.fl_id);

            frmFlow f = new frmFlow();
            f.FL = v;
            if (f.ShowDialog() == DialogResult.OK)
            {
                Fill();
            }
        }
        #endregion //ViewFL

        #region tsbDelete_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            this.DeleteFL();
        }
        #endregion //tsbDelete_Click

        #region DeleteFL
        /// <summary>
        /// 
        /// </summary>
        private void DeleteFL()
        {
            tblFlow fl = this.GetSelectedFlow();
            if (!CheckSelectedFlow(fl))
            {
                return;
            }

            Right rt = App.Default.GetLoginOperatorRight();
            if (!rt.CanActivateForFL(Xdgk.Common.ADEState.Delete, fl.GetFLStatus()))
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.CannotDeleteMT);
                return;
            }

            if (NUnit.UiKit.UserMessage.Ask(Strings.SureDelete) == DialogResult.Yes)
            {
                using (BxdbDataContext db = DBFactory.GetBxdbDataContext())
                {
                    try
                    {
                        var v = db.tblFlow.First(c => c.fl_id == fl.fl_id);

                        db.tblIntroducer.DeleteOnSubmit(v.tblIntroducer);
                        db.tblMaintain.DeleteOnSubmit(v.tblMaintain);
                        if (v.tblReceive != null)
                        {
                            db.tblReceive.DeleteOnSubmit(v.tblReceive);
                        }

                        if (v.tblReply != null)
                        {
                            db.tblReply.DeleteOnSubmit(v.tblReply);
                        }
                        db.tblFlow.DeleteOnSubmit(v);

                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                        return;
                    }
                }

                Fill();
            }
        }
        #endregion //DeleteFL

        #region tsbFind_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbFind_Click(object sender, EventArgs e)
        {
            NUnit.UiKit.UserMessage.DisplayFailure("NotImplemented");

            if (new frmColumnSelect().ShowDialog() == DialogResult.OK)
            {
                this.SetDataGtidViewColumns();
                this.Fill();
            }
        }
        #endregion //tsbFind_Click
    }
}
