namespace fnbx
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRelogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMTNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMTQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoginManage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuMT,
            this.mnuSetting,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(718, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRelogin,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(57, 20);
            this.mnuFile.Text = "文件(&F)";
            // 
            // mnuRelogin
            // 
            this.mnuRelogin.Name = "mnuRelogin";
            this.mnuRelogin.Size = new System.Drawing.Size(137, 22);
            this.mnuRelogin.Text = "重新登录(&R)";
            this.mnuRelogin.Click += new System.EventHandler(this.mnuRelogin_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(137, 22);
            this.mnuExit.Text = "退出(&X)";
            // 
            // mnuMT
            // 
            this.mnuMT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMTNew,
            this.mnuMTQuery});
            this.mnuMT.Name = "mnuMT";
            this.mnuMT.Size = new System.Drawing.Size(71, 20);
            this.mnuMT.Text = "维修单(&M)";
            // 
            // mnuMTNew
            // 
            this.mnuMTNew.Name = "mnuMTNew";
            this.mnuMTNew.Size = new System.Drawing.Size(114, 22);
            this.mnuMTNew.Text = "新建(&N)";
            // 
            // mnuMTQuery
            // 
            this.mnuMTQuery.Name = "mnuMTQuery";
            this.mnuMTQuery.Size = new System.Drawing.Size(114, 22);
            this.mnuMTQuery.Text = "查询(&Q)";
            this.mnuMTQuery.Click += new System.EventHandler(this.mnuMTQuery_Click);
            // 
            // mnuSetting
            // 
            this.mnuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLoginManage,
            this.mnuML});
            this.mnuSetting.Name = "mnuSetting";
            this.mnuSetting.Size = new System.Drawing.Size(57, 20);
            this.mnuSetting.Text = "设置(&S)";
            // 
            // mnuLoginManage
            // 
            this.mnuLoginManage.Name = "mnuLoginManage";
            this.mnuLoginManage.Size = new System.Drawing.Size(152, 22);
            this.mnuLoginManage.Text = "登录管理(&L)";
            // 
            // mnuML
            // 
            this.mnuML.Name = "mnuML";
            this.mnuML.Size = new System.Drawing.Size(152, 22);
            this.mnuML.Text = "报修等级(&M)";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(58, 20);
            this.mnuHelp.Text = "帮助(&H)";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(152, 22);
            this.mnuAbout.Text = "关于(&A)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLogin});
            this.statusStrip1.Location = new System.Drawing.Point(0, 412);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(718, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLogin
            // 
            this.tssLogin.Name = "tssLogin";
            this.tssLogin.Size = new System.Drawing.Size(703, 17);
            this.tssLogin.Spring = true;
            this.tssLogin.Text = "toolStripStatusLabel1";
            this.tssLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 434);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuMT;
        private System.Windows.Forms.ToolStripMenuItem mnuMTNew;
        private System.Windows.Forms.ToolStripMenuItem mnuMTQuery;
        private System.Windows.Forms.ToolStripMenuItem mnuSetting;
        private System.Windows.Forms.ToolStripMenuItem mnuLoginManage;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripStatusLabel tssLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuML;
        private System.Windows.Forms.ToolStripMenuItem mnuRelogin;
    }
}

