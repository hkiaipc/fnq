using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmGRFlow : Form
    {


        #region frmGRFlow
        /// <summary>
        /// 
        /// </summary>
        public frmGRFlow()
        {
            InitializeComponent();
            //this.StationName = stationName;
        }
        #endregion //frmGRFlow


        #region frmGRFlow_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGRFlow_Load(object sender, EventArgs e)
        {
        }
        #endregion //frmGRFlow_Load


        #region FillDatas
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public void FillDatas(DataRow row)
        {
            this.lblGT1.Text = FormatTempValue(row[DataColumnNames.GT1]);
            this.lblBT1.Text = FormatTempValue(row[DataColumnNames.BT1]);

            this.lblGP1.Text = FormatPressValue(row[DataColumnNames.GP1]);
            this.lblBP1.Text = FormatPressValue(row[DataColumnNames.BP1]);

            this.lblGT2.Text = FormatTempValue(row[DataColumnNames.GT2]);
            this.lblBT2.Text = FormatTempValue(row[DataColumnNames.BT2]);

            this.lblGP2.Text = FormatPressValue(row[DataColumnNames.GP2]);
            this.lblBP2.Text = FormatPressValue(row[DataColumnNames.BP2]);

            this.lblDisplayName.Text = row[DataColumnNames.StationName].ToString();
            this.lblDT.Text = row[DataColumnNames.DT].ToString();

            this.lblValve.Text = Convert.ToInt32(row["OD"]).ToString() + " %";
            //
            //

            this.lblCyc.Text = GetCyclePumpState(row);


            //
            //
            this.lblRe.Text = GetRecruitPumpState(row);
            this.lblI1.Text = GetIValue(row[DataColumnNames.I1]);

            this.lblWL.Text = Convert.ToSingle(row[DataColumnNames.WL]).ToString("f2") +" m";
            this.lblCMBusPress.Text = Convert.ToSingle(row["CMBusPress"]).ToString ("f2") + " MPa";

            this.lblBusVolt.Text = Convert.ToInt32(row["Busvolt"]) + " V";

            //FillListView();
        }
        #endregion //FillDatas


        #region GetIValue
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetIValue(object p)
        {
            float f = Convert.ToSingle(p);
            string fs = Config.Default.GetDigitsFormatString();
            return f.ToString(fs) + " t/h";
        }
        #endregion //GetIValue


        #region FillListView
        /// <summary>
        /// 
        /// </summary>
        private void FillListView()
        {
            Label[] nameLabels = new Label[] { lblGT1Name, lblBT1Name, lblGP1Name, lblBP1Name, 
                lblGT2Name, lblBT2Name, lblGP2Name, lblBP2Name, lblCycName, lblReName };
            Label[] valueLabels = new Label[] { lblGT1, lblBT1, lblGP1, lblBP1, 
                lblGT2, lblBT2, lblGP2, lblBP2,lblCyc, lblRe };

            for (int i = 0; i < nameLabels.Length; i++)
            {
                AddListViewItem(nameLabels[i].Text, valueLabels[i].Text);
            }
        }
        #endregion //FillListView


        #region AddListViewItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        private void AddListViewItem(string name, string value)
        {
            ListViewItem lvi = listView1.Items.Add(name);
            lvi.SubItems.Add(value);
            //this.listView1.Items.Add(lvi);
        }
        #endregion //AddListViewItem

        

        #region GetCyclePumpState
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetCyclePumpState(DataRow row)
        {
            bool CM1 = Convert.ToBoolean(row["CM1"]);
            float cm1hz = Convert.ToSingle(row["cm1hz"]);
            float cm1ampere = Convert.ToSingle(row["cm1ampere"]);

            bool CM2 = Convert.ToBoolean(row["CM2"]);
            float cm2hz = Convert.ToSingle(row["cm2hz"]);
            float cm2ampere = Convert.ToSingle(row["cm2ampere"]);

            string s1 = string.Format("1# {0} {1}Hz {2}A",
                CM1 ? "运行" : "停止",
                cm1hz,
                cm1ampere);

            string s2 = string.Format("2# {0} {1}Hz {2}A",
                CM2 ? "运行" : "停止",
                cm2hz,
                cm2ampere);

            return s1 + Environment.NewLine + s2;

            //if (_grdataLvi.CM1 || _grdataLvi.CM2)
            //if (CM1 || CM2)
            //{
            //    //return "循环泵: " + "运行";
            //    return "运行";
            //}
            //else
            //{
            //    //return "循环泵: "+ "停止";
            //    return "停止";
            //}
        }
        #endregion //GetCyclePumpState


        #region GetRecruitPumpState
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetRecruitPumpState(DataRow row)
        {
            bool RM1 = Convert.ToBoolean(row["RM1"]);
            bool RM2 = Convert.ToBoolean(row["RM2"]);
            string s1 = string.Format("1# {0}",
                RM1 ? "运行" : "停止");

            string s2 = string.Format("2# {0}",
                RM2 ? "运行" : "停止");

            return s1 + Environment.NewLine + s2;

            //if (_grdataLvi.CM1 || _grdataLvi.CM2)
            //if (RM1 || RM2)
            //{
            //    //return "补水泵: " + "运行";
            //    return "运行";
            //}
            //else
            //{
            //    //return "补水泵: " + "停止";
            //    return "停止";
            //}
        }
        #endregion //GetRecruitPumpState


        #region FormatTempValue
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string FormatTempValue(object obj)
        {
            float val = Convert.ToSingle(obj);
            string fs = Config.Default.GetDigitsFormatString();
            string s = val.ToString(fs) + " ℃";
            return s;
        }
        #endregion //FormatTempValue


        #region FormatPressValue
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string FormatPressValue(object obj)
        {
            float val = Convert.ToSingle(obj);
            string fs = Config.Default.GetDigitsFormatString();
            string s = val.ToString(fs) + " MPa";
            return s;
        }
        #endregion //FormatPressValue

        ///// <summary>
        ///// 
        ///// </summary>
        //public string StationName
        //{
        //    get { return _stationName; }
        //    set { _stationName = value; }
        //} private string _stationName;


        #region label2_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {

        }
        #endregion //label2_Click



        #region PopupGRFlowForm
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="displayname"></param>
        static public void PopupGRFlowForm(string displayname, IWin32Window owner)
        {
            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteGRLastDataTable(displayname);
            if (tbl.Rows.Count > 0)
            {
                DataRow row = tbl.Rows[0];
                frmGRFlow f = new frmGRFlow();
                f.FillDatas(row);
                //f.MdiParent = this;
                //f.Show();
                f.ShowDialog(owner);
                //f.Show(owner);
            }
            else
            {
                string s = string.Format("{0} 没有最新数据！", displayname);
                NUnit.UiKit.UserMessage.Display(s, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion //PopupGRFlowForm


        #region frmGRFlow_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGRFlow_KeyPress(object sender, KeyPressEventArgs e)
        {
            // esc
            //
            if (e.KeyChar == (char)Keys.Escape )
            {
                this.Close();
            }
        }
        #endregion //frmGRFlow_KeyPress


        #region lblDisplayName_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDisplayName_Click(object sender, EventArgs e)
        {
            //foreach (Form f in Application.OpenForms)
            //{
            //    if (f is frmMain)
            //    {
            //        ((frmMain)f).mnuPressCurve_Click(this, null);
            //        return;
            //    }
            //}
        }
        #endregion //lblDisplayName_Click
    }
}
