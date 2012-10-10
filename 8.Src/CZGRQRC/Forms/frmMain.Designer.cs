namespace CZGRQRC
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuTM = new System.Windows.Forms.MenuItem();
            this.mnuView = new System.Windows.Forms.MenuItem();
            this.mnuToolbar = new System.Windows.Forms.MenuItem();
            this.mnuStatusbar = new System.Windows.Forms.MenuItem();
            this.mnuShowGRAlarm = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuGRDataLast = new System.Windows.Forms.MenuItem();
            this.mnuGR = new System.Windows.Forms.MenuItem();
            this.mnuAlarm = new System.Windows.Forms.MenuItem();
            this.mnuXG = new System.Windows.Forms.MenuItem();
            this.mnuOT = new System.Windows.Forms.MenuItem();
            this.mnuEM = new System.Windows.Forms.MenuItem();
            this.mnuRecruit = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuHeat = new System.Windows.Forms.MenuItem();
            this.mnuStationHeat = new System.Windows.Forms.MenuItem();
            this.mnu2Data = new System.Windows.Forms.MenuItem();
            this.mnuCurve = new System.Windows.Forms.MenuItem();
            this.mnuTempCurve = new System.Windows.Forms.MenuItem();
            this.mnuPressCurve = new System.Windows.Forms.MenuItem();
            this.mnuEMCurve = new System.Windows.Forms.MenuItem();
            this.mnuRecruitCurve = new System.Windows.Forms.MenuItem();
            this.mnuConstrastCurve = new System.Windows.Forms.MenuItem();
            this.mnuConfig = new System.Windows.Forms.MenuItem();
            this.mnuFont = new System.Windows.Forms.MenuItem();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.mnuGRDevicePlanHeat = new System.Windows.Forms.MenuItem();
            this.mnuHelp = new System.Windows.Forms.MenuItem();
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.mnuTest = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGis = new System.Windows.Forms.ToolStripButton();
            this.tsbMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbGRDataLast = new System.Windows.Forms.ToolStripButton();
            this.tsbGRDataHistory = new System.Windows.Forms.ToolStripButton();
            this.tsbGRAlarm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTempCurve = new System.Windows.Forms.ToolStripButton();
            this.tsbPressCurve = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ucAlarm1 = new CZGRQRC.UC.UCAlarm();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuView,
            this.menuItem1,
            this.mnuCurve,
            this.mnuConfig,
            this.mnuHelp});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuTM,
            this.menuItem3,
            this.mnuExit});
            this.mnuFile.Text = "文件(&F)";
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 2;
            this.mnuExit.Text = "退出(&X)";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuTM
            // 
            this.mnuTM.Index = 0;
            this.mnuTM.Text = "TM卡管理(&C)";
            this.mnuTM.Click += new System.EventHandler(this.mnuTM_Click);
            // 
            // mnuView
            // 
            this.mnuView.Index = 1;
            this.mnuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuToolbar,
            this.mnuStatusbar,
            this.mnuShowGRAlarm});
            this.mnuView.Text = "视图(&V)";
            this.mnuView.Popup += new System.EventHandler(this.mnuView_Popup);
            // 
            // mnuToolbar
            // 
            this.mnuToolbar.Index = 0;
            this.mnuToolbar.Text = "工具栏(&T)";
            this.mnuToolbar.Click += new System.EventHandler(this.mnuToolbar_Click);
            // 
            // mnuStatusbar
            // 
            this.mnuStatusbar.Index = 1;
            this.mnuStatusbar.Text = "状态栏(&S)";
            this.mnuStatusbar.Click += new System.EventHandler(this.mnuStatusbar_Click);
            // 
            // mnuShowGRAlarm
            // 
            this.mnuShowGRAlarm.Index = 2;
            this.mnuShowGRAlarm.Text = "报警窗口(&A)";
            this.mnuShowGRAlarm.Visible = false;
            this.mnuShowGRAlarm.Click += new System.EventHandler(this.mnuShowGRAlarm_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuGRDataLast,
            this.mnuGR,
            this.mnuAlarm,
            this.mnuXG,
            this.mnuOT,
            this.mnuEM,
            this.mnuRecruit,
            this.menuItem2,
            this.mnuHeat,
            this.mnuStationHeat,
            this.mnu2Data});
            this.menuItem1.Text = "数据(&D)";
            // 
            // mnuGRDataLast
            // 
            this.mnuGRDataLast.Index = 0;
            this.mnuGRDataLast.Text = "最新供热数据(&L)";
            this.mnuGRDataLast.Click += new System.EventHandler(this.mnuGRDataLast_Click);
            // 
            // mnuGR
            // 
            this.mnuGR.Index = 1;
            this.mnuGR.Text = "供热数据(&G)";
            this.mnuGR.Click += new System.EventHandler(this.mnuGR_Click);
            // 
            // mnuAlarm
            // 
            this.mnuAlarm.Index = 2;
            this.mnuAlarm.Text = "报警数据(&A)";
            this.mnuAlarm.Click += new System.EventHandler(this.mnuAlarm_Click);
            // 
            // mnuXG
            // 
            this.mnuXG.Index = 3;
            this.mnuXG.Text = "巡更数据(&X)";
            this.mnuXG.Click += new System.EventHandler(this.mnuXG_Click);
            // 
            // mnuOT
            // 
            this.mnuOT.Index = 4;
            this.mnuOT.Text = "室外温度(&O)";
            this.mnuOT.Visible = false;
            this.mnuOT.Click += new System.EventHandler(this.mnuOT_Click);
            // 
            // mnuEM
            // 
            this.mnuEM.Index = 5;
            this.mnuEM.Text = "电量数据(&E)";
            this.mnuEM.Visible = false;
            this.mnuEM.Click += new System.EventHandler(this.mnuEM_Click);
            // 
            // mnuRecruit
            // 
            this.mnuRecruit.Index = 6;
            this.mnuRecruit.Text = "补水数据(&B))";
            this.mnuRecruit.Visible = false;
            this.mnuRecruit.Click += new System.EventHandler(this.mnuRecruit_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 7;
            this.menuItem2.Text = "-";
            this.menuItem2.Visible = false;
            // 
            // mnuHeat
            // 
            this.mnuHeat.Index = 8;
            this.mnuHeat.Text = "日耗热量(&H)";
            this.mnuHeat.Visible = false;
            this.mnuHeat.Click += new System.EventHandler(this.mnuHeat_Click);
            // 
            // mnuStationHeat
            // 
            this.mnuStationHeat.Index = 9;
            this.mnuStationHeat.Text = "阶段耗热量(&R)";
            this.mnuStationHeat.Visible = false;
            this.mnuStationHeat.Click += new System.EventHandler(this.mnuStationHeat_Click);
            // 
            // mnu2Data
            // 
            this.mnu2Data.Index = 10;
            this.mnu2Data.Text = "二次数据统计...";
            this.mnu2Data.Visible = false;
            this.mnu2Data.Click += new System.EventHandler(this.mnu2Data_Click);
            // 
            // mnuCurve
            // 
            this.mnuCurve.Index = 3;
            this.mnuCurve.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuTempCurve,
            this.mnuPressCurve,
            this.mnuEMCurve,
            this.mnuRecruitCurve,
            this.mnuConstrastCurve});
            this.mnuCurve.Text = "曲线(&C)";
            // 
            // mnuTempCurve
            // 
            this.mnuTempCurve.Index = 0;
            this.mnuTempCurve.Text = "温度曲线(&T)...";
            this.mnuTempCurve.Click += new System.EventHandler(this.mnuTempCurve_Click);
            // 
            // mnuPressCurve
            // 
            this.mnuPressCurve.Index = 1;
            this.mnuPressCurve.Text = "压力曲线(&P)...";
            this.mnuPressCurve.Click += new System.EventHandler(this.mnuPressCurve_Click);
            // 
            // mnuEMCurve
            // 
            this.mnuEMCurve.Index = 2;
            this.mnuEMCurve.Text = "电量曲线(&E)...";
            this.mnuEMCurve.Visible = false;
            this.mnuEMCurve.Click += new System.EventHandler(this.mnuEMCurve_Click);
            // 
            // mnuRecruitCurve
            // 
            this.mnuRecruitCurve.Index = 3;
            this.mnuRecruitCurve.Text = "补水曲线(&B)...";
            this.mnuRecruitCurve.Visible = false;
            this.mnuRecruitCurve.Click += new System.EventHandler(this.mnuRecruitCurve_Click);
            // 
            // mnuConstrastCurve
            // 
            this.mnuConstrastCurve.Index = 4;
            this.mnuConstrastCurve.Text = "对比曲线(C)...";
            this.mnuConstrastCurve.Click += new System.EventHandler(this.mnuConstrastCurve_Click);
            // 
            // mnuConfig
            // 
            this.mnuConfig.Index = 4;
            this.mnuConfig.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFont,
            this.mnuOptions,
            this.mnuGRDevicePlanHeat});
            this.mnuConfig.Text = "设置(&S)";
            // 
            // mnuFont
            // 
            this.mnuFont.Index = 0;
            this.mnuFont.Text = "字体(&F)";
            this.mnuFont.Click += new System.EventHandler(this.mnuFont_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.Index = 1;
            this.mnuOptions.Text = "报警设定(&A)...";
            this.mnuOptions.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuGRDevicePlanHeat
            // 
            this.mnuGRDevicePlanHeat.Index = 2;
            this.mnuGRDevicePlanHeat.Text = "理论耗热量(H)...";
            this.mnuGRDevicePlanHeat.Visible = false;
            this.mnuGRDevicePlanHeat.Click += new System.EventHandler(this.mnuGRDevicePlanHeat_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Index = 5;
            this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAbout,
            this.mnuTest});
            this.mnuHelp.Text = "帮助(&H)";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Index = 0;
            this.mnuAbout.Text = "关于(&A)";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // mnuTest
            // 
            this.mnuTest.Index = 1;
            this.mnuTest.Text = "Test";
            this.mnuTest.Visible = false;
            this.mnuTest.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 388);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(838, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 838;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGis,
            this.tsbMap,
            this.toolStripSeparator4,
            this.tsbGRDataLast,
            this.tsbGRDataHistory,
            this.tsbGRAlarm,
            this.toolStripSeparator5,
            this.tsbTempCurve,
            this.tsbPressCurve,
            this.toolStripSeparator6,
            this.tsbExit1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(838, 52);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsbGis
            // 
            this.tsbGis.Image = ((System.Drawing.Image)(resources.GetObject("tsbGis.Image")));
            this.tsbGis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGis.Name = "tsbGis";
            this.tsbGis.Size = new System.Drawing.Size(41, 49);
            this.tsbGis.Text = "地  图";
            this.tsbGis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbGis.Visible = false;
            // 
            // tsbMap
            // 
            this.tsbMap.Image = global::CZGRQRC.Properties.Resources.Pipe;
            this.tsbMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMap.Name = "tsbMap";
            this.tsbMap.Size = new System.Drawing.Size(59, 49);
            this.tsbMap.Text = "管网示意";
            this.tsbMap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMap.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 52);
            this.toolStripSeparator4.Visible = false;
            // 
            // tsbGRDataLast
            // 
            this.tsbGRDataLast.Image = global::CZGRQRC.Properties.Resources.Last;
            this.tsbGRDataLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGRDataLast.Name = "tsbGRDataLast";
            this.tsbGRDataLast.Size = new System.Drawing.Size(59, 49);
            this.tsbGRDataLast.Text = "最新数据";
            this.tsbGRDataLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbGRDataHistory
            // 
            this.tsbGRDataHistory.Image = global::CZGRQRC.Properties.Resources.History;
            this.tsbGRDataHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGRDataHistory.Name = "tsbGRDataHistory";
            this.tsbGRDataHistory.Size = new System.Drawing.Size(59, 49);
            this.tsbGRDataHistory.Text = "历史数据";
            this.tsbGRDataHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbGRAlarm
            // 
            this.tsbGRAlarm.Image = ((System.Drawing.Image)(resources.GetObject("tsbGRAlarm.Image")));
            this.tsbGRAlarm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGRAlarm.Name = "tsbGRAlarm";
            this.tsbGRAlarm.Size = new System.Drawing.Size(59, 49);
            this.tsbGRAlarm.Text = "报警数据";
            this.tsbGRAlarm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 52);
            // 
            // tsbTempCurve
            // 
            this.tsbTempCurve.Image = ((System.Drawing.Image)(resources.GetObject("tsbTempCurve.Image")));
            this.tsbTempCurve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTempCurve.Name = "tsbTempCurve";
            this.tsbTempCurve.Size = new System.Drawing.Size(59, 49);
            this.tsbTempCurve.Text = "温度曲线";
            this.tsbTempCurve.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbTempCurve.Click += new System.EventHandler(this.tsbTempCurve_Click);
            // 
            // tsbPressCurve
            // 
            this.tsbPressCurve.Image = ((System.Drawing.Image)(resources.GetObject("tsbPressCurve.Image")));
            this.tsbPressCurve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPressCurve.Name = "tsbPressCurve";
            this.tsbPressCurve.Size = new System.Drawing.Size(59, 49);
            this.tsbPressCurve.Text = "压力曲线";
            this.tsbPressCurve.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPressCurve.Click += new System.EventHandler(this.tsbPressCurve_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 52);
            // 
            // tsbExit1
            // 
            this.tsbExit1.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit1.Image")));
            this.tsbExit1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit1.Name = "tsbExit1";
            this.tsbExit1.Size = new System.Drawing.Size(59, 49);
            this.tsbExit1.Text = "退出系统";
            this.tsbExit1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 51);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 51);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 51);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::CZGRQRC.Properties.Resources.Delete;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(45, 48);
            this.tsbExit.Text = "退  出";
            this.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 279);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(838, 4);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // ucAlarm1
            // 
            this.ucAlarm1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucAlarm1.Location = new System.Drawing.Point(0, 283);
            this.ucAlarm1.Name = "ucAlarm1";
            this.ucAlarm1.Size = new System.Drawing.Size(838, 105);
            this.ucAlarm1.TabIndex = 9;
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CZGRQRC.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(838, 410);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ucAlarm1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusBar1);
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.MenuItem mnuGR;
        private System.Windows.Forms.MenuItem mnuXG;
        private System.Windows.Forms.MenuItem mnuAlarm;
        private System.Windows.Forms.MenuItem mnuHelp;
        private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.MenuItem mnuCurve;
        private System.Windows.Forms.MenuItem mnuTempCurve;
        private System.Windows.Forms.MenuItem mnuPressCurve;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuGRDataLast;
        private System.Windows.Forms.MenuItem mnuHeat;
        private System.Windows.Forms.MenuItem mnu2Data;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolBarButton tbbGRDataLast;
        private System.Windows.Forms.MenuItem mnuTest;
        private System.Windows.Forms.ToolBarButton tbbGRHistory;
        private System.Windows.Forms.ToolBarButton tbbGRAlarm;
        private System.Windows.Forms.ToolBarButton tbbTempCurve;
        private System.Windows.Forms.ToolBarButton tbbPressCurve;
        private System.Windows.Forms.ToolBarButton tbbSeparator1;
        private System.Windows.Forms.ToolBarButton tbbSeparator2;
        private System.Windows.Forms.ToolBarButton tbbExit;
        private System.Windows.Forms.MenuItem mnuView;
        private System.Windows.Forms.MenuItem mnuToolbar;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.MenuItem mnuStatusbar;
        private System.Windows.Forms.MenuItem mnuFont;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbMap;
        private System.Windows.Forms.ToolStripButton tsbGRDataLast;
        private System.Windows.Forms.ToolStripButton tsbGRDataHistory;
        private System.Windows.Forms.ToolStripButton tsbGRAlarm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbTempCurve;
        private System.Windows.Forms.ToolStripButton tsbPressCurve;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbGis;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbExit1;
        private CZGRQRC.UC.UCAlarm ucAlarm1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.MenuItem mnuShowGRAlarm;
        private System.Windows.Forms.MenuItem mnuStationHeat;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuOptions;
        private System.Windows.Forms.MenuItem mnuConstrastCurve;
        private System.Windows.Forms.MenuItem mnuConfig;
        private System.Windows.Forms.MenuItem mnuOT;
        private System.Windows.Forms.MenuItem mnuGRDevicePlanHeat;
        private System.Windows.Forms.MenuItem mnuEM;
        private System.Windows.Forms.MenuItem mnuEMCurve;
        private System.Windows.Forms.MenuItem mnuRecruit;
        private System.Windows.Forms.MenuItem mnuRecruitCurve;
        private System.Windows.Forms.MenuItem mnuTM;
        private System.Windows.Forms.MenuItem menuItem3;
    }
}

