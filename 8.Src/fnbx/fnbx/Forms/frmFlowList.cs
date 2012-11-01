using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Dynamic;
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
            if (!rt.CanActivateForFL(Xdgk.Common.ADEStatus.Add, FLStatus.Created))
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.CannotCreateMT);
                return;
            }

            tblFlow fl = FlowFactory.Create();



            frmFlow f = new frmFlow();
            f.FL = fl;

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

            if (this.ucCondition1.Visible)
            {
                FillWithCondition();
            }
            else
            {
                BxdbDataContext dc = DBFactory.GetBxdbDataContext();

                var r = from q in dc.tblFlow
                        select q;

                BindToDataGridView(r);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillWithCondition()
        {
            bool hasStatus = this.ucCondition1.EnabledFLStatus;
            FLStatus status = this.ucCondition1.SelectedFLStatus ;

            bool hasDT = this.ucCondition1.EnabledDateTime ;
            DateTime begin = this.ucCondition1.Begin ;
            DateTime end = this.ucCondition1.End ;

            bool hasIt = this.ucCondition1.EnabledIt;
            string it = this.ucCondition1.ItName ;


            Fill(hasStatus, status, hasDT, begin, end, hasIt, it);
        }
        #endregion //Fill

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        private void BindToDataGridView(IQueryable<tblFlow> r)
        {
            FlowData[] fs = FlowConverter.Convert(r.ToArray());
            DataTable tbl = FlowConverter.Convert(fs);
            this.dataGridView1.DataSource = tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="hasDT"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="it"></param>
        private void Fill(bool hasStatus, FLStatus status, bool hasDT, DateTime begin, DateTime end, bool hasIt, string it)
        {
            BxdbDataContext dc = DBFactory.GetBxdbDataContext();

            //if 
            //var r = from q in dc.tblFlow
            //        where
            //        q.fl_status == 1 &&
            //            q.tblMaintain.mt_pose_dt >= begin &&
            //            q.tblMaintain.mt_pose_dt < end &&
            //            q.tblMaintain.mt_id == 77 &&
            //            q.tblIntroducer.it_name == it 

            //        select q;

            StringBuilder sb = new StringBuilder();
            int count = 0;
            List<object> paramList = new List<object>();


            if (hasStatus)
            {
                sb.AppendFormat("fl_status == @{0}", count++);

                paramList.Add((int)status);
            }

            if (hasDT)
            {
                CheckAnd(sb);

                sb.AppendFormat (
                    "tblMaintain.mt_pose_dt >= @{0} and tblMaintain.mt_pose_dt < @{1}",
                    count++, count++);

                paramList.Add(begin);
                paramList.Add(end);
            }

            if (hasIt)
            {
                CheckAnd(sb);
                sb.AppendFormat(
                    "tblIntroducer.it_name = @{0}",
                    count++);
                paramList.Add(it);
            }
            if (sb.Length == 0)
            {
                sb.Append("true");
            }
            var r1 = from q in dc.tblFlow
                    .Where(sb.ToString(), paramList.ToArray ())
                    select q;

            BindToDataGridView(r1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        private static void CheckAnd(StringBuilder sb)
        {
            if (sb.Length > 0)
            {
                sb.Append(" AND ");
            }
        }

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

    
        #region dataGridView1_CellContentClick 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion //dataGridView1_CellContentClick

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
            if (!rt.CanActivateForFL(Xdgk.Common.ADEStatus.Delete, fl.GetFLStatus()))
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
            this.tsbFind.Checked = !this.tsbFind.Checked;
            this.ucCondition1.Visible = this.tsbFind.Checked;

            return;

            NUnit.UiKit.UserMessage.DisplayFailure("NotImplemented");

            if (new frmColumnSelect().ShowDialog() == DialogResult.OK)
            {
                this.SetDataGtidViewColumns();
                this.Fill();
            }
        }
        #endregion //tsbFind_Click

        #region dataGridView1_RowsAdded
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            return;
        }
        #endregion //dataGridView1_RowsAdded

        #region dataGridView1_DataBindingComplete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Console.WriteLine("dataGridView1_DataBindingComplete" + DateTime.Now );
            foreach (DataGridViewRow rv in this.dataGridView1.Rows)
            {
                tblFlow flow = GetTblFlow(rv);
                Color c = GetColor(flow.GetFLStatus());
                rv.DefaultCellStyle.BackColor = c;
            }
        }
        #endregion //dataGridView1_DataBindingComplete

        #region GetColor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fLStatus"></param>
        /// <returns></returns>
        private Color GetColor(FLStatus fLStatus)
        {
            Color c = App.Default.Config.StatusColors.GetColor(fLStatus);
            return c;
        }
        #endregion //GetColor

        #region GetTblFlow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private tblFlow GetTblFlow(DataGridViewRow row)
        {
            DataRowView view = (DataRowView)row.DataBoundItem;
            tblFlow flow = (tblFlow)view.Row["tblFlow"];
            return flow;
        }
        #endregion //GetTblFlow

        #region ucCondition1_QuertyEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCondition1_QuertyEvent(object sender, EventArgs e)
        {
            FillWithCondition();          
        }
        #endregion //ucCondition1_QuertyEvent

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            Fill();
        }

    }
}
