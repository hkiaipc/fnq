using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Xdgk.GRCommon;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmContrastCurveSelect : NUnit.UiKit.SettingsDialogBase
    {

        /// <summary>
        /// 
        /// </summary>
        private const int ForDrawCurveCount = 2;

        /// <summary>
        /// 
        /// </summary>
        public GRStationCurveInfoCollection DrawCurveInfoCollection
        {
            get
            {
                if (_drawCurceInfoCollection == null)
                {
                    _drawCurceInfoCollection = new GRStationCurveInfoCollection();
                }
                return _drawCurceInfoCollection;
            }
        }  private GRStationCurveInfoCollection _drawCurceInfoCollection;

        /// <summary>
        /// 
        /// </summary>
        public frmContrastCurveSelect()
        {
            InitializeComponent();
            BindGRCurve();
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindGRCurve()
        {
            BindingSource bs = new BindingSource();
            this.lstCurveName.DataSource = bs;

            bs.DataSource = this.DrawCurveInfoCollection;
            this.lstCurveName.DataSource = bs;

            this.lstCurveName.DisplayMember = "Display";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.DrawCurveInfoCollection.Count >= ForDrawCurveCount)
            {
                string s = string.Format(strings.CurveCountEnough, ForDrawCurveCount);
                NUnit.UiKit.UserMessage.DisplayInfo(s);
                return;
            }

            UCCurveSelectCondition f = new UCCurveSelectCondition();
            DialogResult dr = f.ShowDialog();

            if (dr == DialogResult.OK)
            {
                GRStationCurveInfo info = f.StationCurveInfo;
                BindingSource bs = this.lstCurveName.DataSource as BindingSource;
                bs.Add(info);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            object obj = this.lstCurveName.SelectedItem;
            if (obj != null)
            {
                GRStationCurveInfo info = obj as GRStationCurveInfo;
                BindingSource bs = this.lstCurveName.DataSource as BindingSource;
                bs.Remove(info);
                //this.DrawCurveInfoCollection.Remove(info);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmContrastCurveSelect_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstCurveName_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = this.lstCurveName.SelectedValue;
            if (obj != null)
            {
                GRStationCurveInfo info = obj as GRStationCurveInfo;
                this.txtCurveInfo.Text = info.GetDetail();
            }
            else
            {
                this.txtCurveInfo.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.DrawCurveInfoCollection.Count == ForDrawCurveCount )
            {
                frmContrastCurve f = new frmContrastCurve(this._drawCurceInfoCollection);
                f.ShowDialog();
                //this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            else
            {
                string s = string.Format(strings.CurveCountNotEnough, ForDrawCurveCount);
                NUnit.UiKit.UserMessage.DisplayInfo(s);
            }
        }

        /// <summary>
        /// edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            GRStationCurveInfo s = this.lstCurveName.SelectedItem as GRStationCurveInfo ;
            System.Diagnostics.Debug.Assert(s !=null);
            UCCurveSelectCondition f = new UCCurveSelectCondition(s);
            f.ShowDialog();
        }
    }
}
