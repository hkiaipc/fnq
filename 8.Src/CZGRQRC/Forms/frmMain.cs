using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;
using CZGRCommon;
//using CZGRMap;
//using frmArcGis;
//using btGR;
using Xdgk.GRCommon;

namespace FNGRQRC
{

    /// <summary>
    /// 
    /// </summary>
    public partial class frmMain : Form
    {
        /// <summary>
        /// 
        /// </summary>
        static private NUnit.Core.Logger logger = NUnit.Core.InternalTrace.GetLogger(typeof(frmMain));

        private CommandLineOptions _cmdLineOpt;

        /// <summary>
        /// 
        /// </summary>
        public frmMain(CommandLineOptions cmdLineOpt)
        {
            //btGRMain.frmLogin f = new btGRMain.frmLogin();
            //f.ShowDialog();

            InitializeComponent();
            //this.Text = strings.AppText;
            this.Text = GetMainFormText();
            this._cmdLineOpt = cmdLineOpt;
            this.mnu2Data.Visible = Config.Default.Show2DataGather;
        }

        string GetMainFormText()
        {
            string s = System.Configuration.ConfigurationSettings.AppSettings["text"];
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            //Application.StartupPath 
            //this.toolStrip1.ImageList = this.imageList1;
            //this.tsbMap.ImageIndex = 0;

            this.mnuUserManager.Visible = CZGRQRCApp.Default.LoginedUser.RightEnum == RightEnum.Admin;
            Process(_cmdLineOpt);
            SetBackgroundImage();

            // not visible alarm
            //
            this.splitter1.Visible = false;
            this.ucAlarm1.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetBackgroundImage()
        {
            Image img = null;
            try
            {
                img = Image.FromFile("resources\\bg.jpg");
            }
            catch (System.IO.FileNotFoundException)
            {
            }
            this.BackgroundImage = img;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dr = NUnit.UiKit.UserMessage.Ask(strings.AreYouExit);
            //if (dr == DialogResult.No)
            //{
            //    e.Cancel = true;   
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuGR_Click(object sender, EventArgs e)
        {
            frmGRDataQR f = GetGRDataQRForm();
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuXG_Click(object sender, EventArgs e)
        {
            frmXGDataQR f = GetXGQRForm();
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        private frmXGDataQR GetXGQRForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmXGDataQR)
                {
                    return (frmXGDataQR)f;
                }
            }

            frmXGDataQR nf = new frmXGDataQR();
            nf.MdiParent = this;
            return nf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAlarm_Click(object sender, EventArgs e)
        {
            frmGRAlarm f = GetGRAlarmQRForm();
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        private frmGRAlarm GetGRAlarmQRForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmGRAlarm)
                {
                    return (frmGRAlarm)f;
                }
            }

            frmGRAlarm nf = new frmGRAlarm();
            nf.MdiParent = this;
            return nf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WindowMessageCode.WM_COPYDATA:
                    COPYDATASTRUCT cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                    ProcessCopyDataStruct(cds);
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdLineOpt"></param>
        public void Process(CommandLineOptions cmdLineOpt)
        {
            Process(cmdLineOpt.StationName, cmdLineOpt.Data, cmdLineOpt.Appearance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="data"></param>
        /// <param name="apperance"></param>
        public void Process(string stationName, string data, string apperance)
        {
            if (StringHelper.Equal(AppearanceValue.Query, apperance))
            {
                if (StringHelper.Equal(data, DataValue.GR))
                {
                    frmGRDataQR f = GetGRDataQRForm();
                    f.Show();
                    f.Activate();
                    f.Query(stationName);
                }
                else if (StringHelper.Equal(data, DataValue.GRAlarm))
                {
                    frmGRAlarm f = GetGRAlarmQRForm();
                    f.Show();
                    f.Activate();
                    f.Query(stationName);
                }
                else if (StringHelper.Equal(data, DataValue.XG))
                {
                    frmXGDataQR f = GetXGQRForm();
                    f.Show();
                    f.Activate();
                    f.Query(stationName);
                }
                else
                {
                }
            }
            else if (StringHelper.Equal(AppearanceValue.Curve, apperance))
            {
                if (StringHelper.Equal(data, DataValue.GRPress))
                {
                    frmPressCurve f = GetPressCurveForm();
                    f.Show();
                    f.Activate();
                    f.DrawCurve(stationName);
                }
                else if (StringHelper.Equal(data, DataValue.GRTemp))
                {
                    frmTempCurve f = GetTempCurveForm();
                    f.Show();
                    f.Activate();
                    f.DrawCurve(stationName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cds"></param>
        private void ProcessCopyDataStruct(COPYDATASTRUCT cds)
        {
            string s = cds.lpData;
            string[] args = s.Split(' ');
            CommandLineOptions cmdlineopt = new CommandLineOptions(args);
            Process(cmdlineopt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private frmGRDataQR GetGRDataQRForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmGRDataQR)
                {
                    return (frmGRDataQR)f;
                }
            }

            frmGRDataQR nf = new frmGRDataQR();
            nf.MdiParent = this;
            return nf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            string s = string.Format("{0}\r\n\r\n版本: {1}",
                //strings.AppText,
                GetMainFormText(),
                Application.ProductVersion);

            NUnit.UiKit.UserMessage.DisplayInfo(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuTempCurve_Click(object sender, EventArgs e)
        {
            frmTempCurve f = GetTempCurveForm();
            f.Show();
            f.Activate();

        }

        /// <summary>
        /// 
        /// </summary>
        private frmTempCurve GetTempCurveForm()
        {
            // todo: temp curve
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmTempCurve)
                {
                    return (frmTempCurve)f;
                }
            }

            //frmGRDataQR nf = new frmGRDataQR();
            frmTempCurve nf = new frmTempCurve();
            nf.MdiParent = this;
            return nf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void mnuPressCurve_Click(object sender, EventArgs e)
        {
            frmPressCurve f = GetPressCurveForm();
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowMapForm()
        {
            //frmCZGRMap f = GetCZGRMapForm();
            //f.Show();
            //f.Activate();
            //f.TopLevel = true;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //private frmCZGRMap GetCZGRMapForm()
        //{
        //    foreach (Form f in this.MdiChildren)
        //    {
        //        if (f is frmCZGRMap)
        //        {
        //            return (frmCZGRMap)f;
        //        }
        //    }

        //    frmCZGRMap nf = new frmCZGRMap();
        //    nf.MdiParent = this;
        //    return nf;
        //}

        /// <summary>
        /// 
        /// </summary>
        private frmPressCurve GetPressCurveForm()
        {
            // todo: press curve
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmPressCurve)
                {
                    return (frmPressCurve)f;
                }
            }

            //frmGRDataQR nf = new frmGRDataQR();
            frmPressCurve nf = new frmPressCurve();
            nf.MdiParent = this;
            return nf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuGRDataLast_Click(object sender, EventArgs e)
        {
            frmGRDataLast f = GetGRDataLastForm();
            f.Show();
            f.Activate();
            //f.Query();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private frmGRDataLast GetGRDataLastForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmGRDataLast)
                {
                    return (frmGRDataLast)f;
                }
            }
            frmGRDataLast nf = new frmGRDataLast();
            nf.MdiParent = this;
            return nf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuHeat_Click(object sender, EventArgs e)
        {
            //frmCalcHeat f = GetCalcHeatForm();
            //f.Show();
            //f.Activate();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //private btGR.frmGisMain GetGisForm()
        //{
        //    foreach (Form f in this.MdiChildren)
        //    {
        //        if (f is frmGisMain)
        //            return (frmGisMain)f;
        //    }
        //    frmGisMain nf = new frmGisMain();
        //    nf.MdiParent = this;
        //    nf.GisEvent += new GisEventHandler(nf_GisEvent);
        //    return nf;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void nf_GisEvent(object sender, GisEventArgs e)
        //{
        //    try
        //    {
        //        // TODO: getdisplayname
        //        //
        //        string displayname = CZGRQRCApp.Default.DBI.GetGRDeviceDisplayName(e.StationName);

        //        frmGRFlow.PopupGRFlowForm(displayname, this);
        //    }
        //    catch( Exception ex )
        //    {
        //        logger.Error(ex.ToString());
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="e"></param>
        ///// <param name="displayname"></param>
        //private void PopupGRFlowForm(string displayname)
        //{
        //    DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteGRLastDataTable(displayname);
        //    if (tbl.Rows.Count > 0)
        //    {
        //        DataRow row = tbl.Rows[0];
        //        frmGRFlow f = new frmGRFlow();
        //        f.FillDatas(row);
        //        //f.MdiParent = this;
        //        //f.Show();
        //        f.ShowDialog(this);
        //    }
        //    else
        //    {
        //        string s = string.Format("{0} 没有最新数据！", displayname);
        //        NUnit.UiKit.UserMessage.Display(s);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //private frmCalcHeat GetCalcHeatForm()
        //{
        //    foreach (Form f in this.MdiChildren)
        //    {
        //        if (f is frmCalcHeat)
        //        {
        //            return (frmCalcHeat)f;
        //        }
        //    }
        //    frmCalcHeat nf = new frmCalcHeat();
        //    nf.MdiParent = this;
        //    return nf;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //private frmOneStationCalcHeat GetOneStationCalcHeat()
        //{
        //    foreach (Form f in this.MdiChildren)
        //    {
        //        if (f is frmOneStationCalcHeat)
        //        {
        //            return (frmOneStationCalcHeat)f;
        //        }
        //    }
        //    frmOneStationCalcHeat nf = new frmOneStationCalcHeat();
        //    nf.MdiParent = this;
        //    return nf;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnu2Data_Click(object sender, EventArgs e)
        {
            //frmStationGather f = new frmStationGather();
            //f.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            //frmMain2 f2 = new frmMain2();
            //f2.ShowDialog();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        //{
        //    if (e.Button == tbbGRDataLast)
        //    {
        //        mnuGRDataLast_Click(this, null);
        //    }
        //    if (e.Button == tbbGRHistory)
        //    {
        //        mnuGR_Click(this, null);
        //    }
        //    if (e.Button == tbbGRAlarm)
        //    {
        //        mnuAlarm_Click(this, null);
        //    }
        //    if (e.Button == tbbTempCurve)
        //    {
        //        mnuTempCurve_Click(this, null);
        //    }
        //    if (e.Button == tbbPressCurve)
        //    {
        //        mnuPressCurve_Click(this, null);
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuToolbar_Click(object sender, EventArgs e)
        {
            //this.toolBar1.Visible = !this.toolBar1.Visible;
            this.toolStrip1.Visible = !this.toolStrip1.Visible;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuStatusbar_Click(object sender, EventArgs e)
        {
            this.statusBar1.Visible = !this.statusBar1.Visible;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuView_Popup(object sender, EventArgs e)
        {
            this.mnuToolbar.Checked = this.toolStrip1.Visible;
            this.mnuStatusbar.Checked = this.statusBar1.Visible;
            this.mnuShowGRAlarm.Checked = this.ucAlarm1.Visible;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFont_Click(object sender, EventArgs e)
        {
            //FNGRQRC.Config.Default.
            FontDialog f = new FontDialog();
            f.Font = Config.Default.DataGridViewFont;
            DialogResult dr = f.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                Config.Default.DataGridViewFont = f.Font;
                // TODO: update data gridview font
                //
                SetDataGridViewFormsFont();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void SetDataGridViewFormsFont()
        {
            Type idgvFontType = typeof(IDataGridViewFont);

            foreach (Form form in this.MdiChildren)
            {
                if (idgvFontType.IsInstanceOfType(form))
                {
                    IDataGridViewFont idgvFont = (IDataGridViewFont)form;
                    idgvFont.DataGridViewFont = Config.Default.DataGridViewFont;
                }
            }
        }

        private void tsbPressCurve_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbTempCurve_Click(object sender, EventArgs e)
        {

        }

        ///// <summary>
        ///// 
        ///// </summary>
        //private void ShowGisForm()
        //{
        //    frmGisMain f = GetGisForm();
        //    f.Show();
        //    f.Activate();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //if (e.ClickedItem == tsbGis)
            //{
            //    ShowGisForm();
            //}
            if (e.ClickedItem == tsbMap)
            {
                ShowMapForm();
            }
            if (e.ClickedItem == tsbGRDataLast)
            {
                mnuGRDataLast_Click(this, null);
            }
            if (e.ClickedItem == tsbGRDataHistory)
            {
                mnuGR_Click(this, null);
            }
            if (e.ClickedItem == tsbGRAlarm)
            {
                mnuAlarm_Click(this, null);
            }
            if (e.ClickedItem == tsbTempCurve)
            {
                mnuTempCurve_Click(this, null);
            }
            if (e.ClickedItem == tsbPressCurve)
            {
                mnuPressCurve_Click(this, null);
            }
            if (e.ClickedItem == tsbExit1)
            {
                Close();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        public UC.UCAlarm UCAlarm
        {
            get { return this.ucAlarm1; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuShowGRAlarm_Click(object sender, EventArgs e)
        {
            this.ucAlarm1.Visible = !ucAlarm1.Visible;
            this.splitter1.Visible = ucAlarm1.Visible;
            this.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuStationHeat_Click(object sender, EventArgs e)
        {
            //frmOneStationCalcHeat f = GetOneStationCalcHeat();
            //f.Show();
            //f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSettings_Click(object sender, EventArgs e)
        {
            FNGRQRC.Forms.frmSettings f = new FNGRQRC.Forms.frmSettings();
            f.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuConstrastCurve_Click(object sender, EventArgs e)
        {
            frmContrastCurveSelect f = new frmContrastCurveSelect();
            DialogResult dr = f.ShowDialog();

            if (dr == DialogResult.OK)
            {
                GRStationCurveInfoCollection infos = f.DrawCurveInfoCollection;
                frmContrastCurve fcc = new frmContrastCurve(infos);
                fcc.ShowDialog();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOT_Click(object sender, EventArgs e)
        {
            frmOT f = GetOTForm();
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private frmOT GetOTForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmOT)
                {
                    return (frmOT)f;
                }
            }
            frmOT nf = new frmOT();
            nf.MdiParent = this;
            return nf;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //private frmEMDataQR GetEMDataForm()
        //{
        //    foreach (Form f in this.MdiChildren)
        //    {
        //        if (f is frmEMDataQR)
        //        {
        //            return (frmEMDataQR)f;
        //        }
        //    }

        //    frmEMDataQR nf = new frmEMDataQR();
        //    nf.MdiParent = this;
        //    return nf;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuGRDevicePlanHeat_Click(object sender, EventArgs e)
        {
            frmPlanHeat f = new frmPlanHeat();
            f.ShowDialog(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuEM_Click(object sender, EventArgs e)
        {
            //frmEMDataQR f = this.GetEMDataForm();
            //f.Show();
            //f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuEMCurve_Click(object sender, EventArgs e)
        {
            //frmEMCurve f = GetEMCurveForm();
            //f.Show();
            //f.Activate();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //private frmEMCurve GetEMCurveForm()
        //{
        //    foreach (Form f in this.MdiChildren)
        //    {
        //        if (f is frmEMCurve)
        //        {
        //            return (frmEMCurve)f;
        //        }
        //    }

        //    frmEMCurve nf = new frmEMCurve();
        //    nf.MdiParent = this;
        //    return nf;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuRecruit_Click(object sender, EventArgs e)
        {
            frmRecruitDataQR f = GetRecruitDataQRForm();
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private frmRecruitDataQR GetRecruitDataQRForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmRecruitDataQR)
                {
                    return (frmRecruitDataQR)f;
                }
            }
            frmRecruitDataQR nf = new frmRecruitDataQR();
            nf.MdiParent = this;
            return nf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuRecruitCurve_Click(object sender, EventArgs e)
        {
            frmRecruitCurve f = GetRecruitCurveForm();
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private frmRecruitCurve GetRecruitCurveForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmRecruitCurve)
                {
                    return (frmRecruitCurve)f;
                }
            }
            frmRecruitCurve nf = new frmRecruitCurve();
            nf.MdiParent = this;
            return nf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuTM_Click(object sender, EventArgs e)
        {
            frmTMCardManager f = GetTMCardManagerForm();
            f.Show();
            f.Activate();
        }

        private frmTMCardManager GetTMCardManagerForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmTMCardManager)
                {
                    return (frmTMCardManager)f;
                }
            }

            frmTMCardManager nf = new frmTMCardManager();
            nf.MdiParent = this;
            return nf;
        }

        private frmUserManager GetUserManagerForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmUserManager)
                {
                    return (frmUserManager)f;
                }
            }

            frmUserManager nf = new frmUserManager();
            nf.MdiParent = this;
            return nf;

        }

        private void mnuUserManager_Click(object sender, EventArgs e)
        {
            frmUserManager f = GetUserManagerForm();
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuShuoZhan_Click(object sender, EventArgs e)
        {
            frmFirstStationDataLast f = GetShouZhanForm();
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private frmFirstStationDataLast GetShouZhanForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmFirstStationDataLast)
                {
                    return (frmFirstStationDataLast)f;
                }
            }
            frmFirstStationDataLast nf = new frmFirstStationDataLast();
            nf.MdiParent = this;
            return nf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private frmFirstStationDataHistory GetFirstStationDataHistoryForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmFirstStationDataHistory)
                {
                    return (frmFirstStationDataHistory)f;
                }
            }
            frmFirstStationDataHistory nf = new frmFirstStationDataHistory();
            nf.MdiParent = this;
            return nf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private frmFirstStationPressCurve  GetFirstStationPressCurveForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmFirstStationPressCurve )
                {
                    return (frmFirstStationPressCurve)f;
                }
            }
            frmFirstStationPressCurve nf = new frmFirstStationPressCurve();
            nf.MdiParent = this;
            return nf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private frmFirstStationTempCurve  GetFirstStationTempCurveForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmFirstStationTempCurve )
                {
                    return (frmFirstStationTempCurve)f;
                }
            }
            frmFirstStationTempCurve nf = new frmFirstStationTempCurve();
            nf.MdiParent = this;
            return nf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFirstStationDataHistory_Click(object sender, EventArgs e)
        {
            frmFirstStationDataHistory f = GetFirstStationDataHistoryForm();
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFirstStationPressCurve_Click(object sender, EventArgs e)
        {
            frmFirstStationPressCurve f = GetFirstStationPressCurveForm();
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFirstStationTempCurve_Click(object sender, EventArgs e)
        {
            frmFirstStationTempCurve f = GetFirstStationTempCurveForm();
            f.Show();
            f.Activate();
        }




    }
}
