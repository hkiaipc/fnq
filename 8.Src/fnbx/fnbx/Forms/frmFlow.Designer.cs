namespace fnbx
{
    partial class frmFlow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFlow));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssFLStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssModifyStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssTimeout = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.保存SToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.打印PToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tsbModifyStatus = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpIT = new System.Windows.Forms.TabPage();
            this.ucIt1 = new fnbx.UCIt();
            this.tpMT = new System.Windows.Forms.TabPage();
            this.ucMt1 = new fnbx.UCMt();
            this.tpRP = new System.Windows.Forms.TabPage();
            this.ucRc1 = new fnbx.UCRc();
            this.ucRp1 = new fnbx.UCRp();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpIT.SuspendLayout();
            this.tpMT.SuspendLayout();
            this.tpRP.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssFLStatus,
            this.tssModifyStatus,
            this.tssTimeout});
            this.statusStrip1.Location = new System.Drawing.Point(0, 383);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(660, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssFLStatus
            // 
            this.tssFLStatus.Name = "tssFLStatus";
            this.tssFLStatus.Size = new System.Drawing.Size(109, 17);
            this.tssFLStatus.Text = "toolStripStatusLabel1";
            this.tssFLStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssModifyStatus
            // 
            this.tssModifyStatus.AutoSize = false;
            this.tssModifyStatus.IsLink = true;
            this.tssModifyStatus.Name = "tssModifyStatus";
            this.tssModifyStatus.Size = new System.Drawing.Size(40, 17);
            this.tssModifyStatus.Text = "修改";
            this.tssModifyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssModifyStatus.Click += new System.EventHandler(this.tssModifyStatus_Click);
            // 
            // tssTimeout
            // 
            this.tssTimeout.AutoSize = false;
            this.tssTimeout.ForeColor = System.Drawing.Color.Red;
            this.tssTimeout.Name = "tssTimeout";
            this.tssTimeout.Size = new System.Drawing.Size(496, 17);
            this.tssTimeout.Spring = true;
            this.tssTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存SToolStripButton,
            this.打印PToolStripButton,
            this.tsbModifyStatus});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(660, 36);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 保存SToolStripButton
            // 
            this.保存SToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripButton.Image")));
            this.保存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripButton.Name = "保存SToolStripButton";
            this.保存SToolStripButton.Size = new System.Drawing.Size(49, 33);
            this.保存SToolStripButton.Text = "保存(&S)";
            this.保存SToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.保存SToolStripButton.Click += new System.EventHandler(this.保存SToolStripButton_Click);
            // 
            // 打印PToolStripButton
            // 
            this.打印PToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打印PToolStripButton.Image")));
            this.打印PToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印PToolStripButton.Name = "打印PToolStripButton";
            this.打印PToolStripButton.Size = new System.Drawing.Size(49, 33);
            this.打印PToolStripButton.Text = "打印(&P)";
            this.打印PToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.打印PToolStripButton.Click += new System.EventHandler(this.打印PToolStripButton_Click);
            // 
            // tsbModifyStatus
            // 
            this.tsbModifyStatus.Image = ((System.Drawing.Image)(resources.GetObject("tsbModifyStatus.Image")));
            this.tsbModifyStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModifyStatus.Name = "tsbModifyStatus";
            this.tsbModifyStatus.Size = new System.Drawing.Size(35, 33);
            this.tsbModifyStatus.Text = "修改";
            this.tsbModifyStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbModifyStatus.Click += new System.EventHandler(this.tsbModifyStatus_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpIT);
            this.tabControl1.Controls.Add(this.tpMT);
            this.tabControl1.Controls.Add(this.tpRP);
            this.tabControl1.Location = new System.Drawing.Point(0, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(645, 324);
            this.tabControl1.TabIndex = 2;
            // 
            // tpIT
            // 
            this.tpIT.Controls.Add(this.ucIt1);
            this.tpIT.Location = new System.Drawing.Point(4, 21);
            this.tpIT.Name = "tpIT";
            this.tpIT.Padding = new System.Windows.Forms.Padding(3);
            this.tpIT.Size = new System.Drawing.Size(637, 299);
            this.tpIT.TabIndex = 2;
            this.tpIT.Text = "联系人";
            this.tpIT.UseVisualStyleBackColor = true;
            // 
            // ucIt1
            // 
            this.ucIt1.It = null;
            this.ucIt1.Location = new System.Drawing.Point(8, 6);
            this.ucIt1.Name = "ucIt1";
            this.ucIt1.Readonly = false;
            this.ucIt1.Size = new System.Drawing.Size(464, 257);
            this.ucIt1.TabIndex = 0;
            // 
            // tpMT
            // 
            this.tpMT.Controls.Add(this.ucMt1);
            this.tpMT.Location = new System.Drawing.Point(4, 21);
            this.tpMT.Name = "tpMT";
            this.tpMT.Padding = new System.Windows.Forms.Padding(3);
            this.tpMT.Size = new System.Drawing.Size(637, 299);
            this.tpMT.TabIndex = 0;
            this.tpMT.Text = "报修";
            this.tpMT.UseVisualStyleBackColor = true;
            // 
            // ucMt1
            // 
            this.ucMt1.Location = new System.Drawing.Point(3, 6);
            this.ucMt1.Maintain = null;
            this.ucMt1.Name = "ucMt1";
            this.ucMt1.Readonly = false;
            this.ucMt1.Size = new System.Drawing.Size(630, 301);
            this.ucMt1.TabIndex = 0;
            // 
            // tpRP
            // 
            this.tpRP.Controls.Add(this.ucRc1);
            this.tpRP.Controls.Add(this.ucRp1);
            this.tpRP.Location = new System.Drawing.Point(4, 21);
            this.tpRP.Name = "tpRP";
            this.tpRP.Padding = new System.Windows.Forms.Padding(3);
            this.tpRP.Size = new System.Drawing.Size(637, 299);
            this.tpRP.TabIndex = 1;
            this.tpRP.Text = "回单";
            this.tpRP.UseVisualStyleBackColor = true;
            // 
            // ucRc1
            // 
            this.ucRc1.Location = new System.Drawing.Point(8, 6);
            this.ucRc1.Name = "ucRc1";
            this.ucRc1.Rc = null;
            this.ucRc1.Readonly = false;
            this.ucRc1.Size = new System.Drawing.Size(311, 25);
            this.ucRc1.TabIndex = 1;
            // 
            // ucRp1
            // 
            this.ucRp1.Location = new System.Drawing.Point(8, 37);
            this.ucRp1.Name = "ucRp1";
            this.ucRp1.Readonly = false;
            this.ucRp1.Reply = null;
            this.ucRp1.Size = new System.Drawing.Size(586, 251);
            this.ucRp1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 405);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmFlow";
            this.Text = "frmFlow";
            this.Load += new System.EventHandler(this.frmFlow_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFlow_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFlow_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpIT.ResumeLayout(false);
            this.tpMT.ResumeLayout(false);
            this.tpRP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 保存SToolStripButton;
        private System.Windows.Forms.ToolStripButton 打印PToolStripButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMT;
        private System.Windows.Forms.TabPage tpRP;
        private UCMt ucMt1;
        private UCRc ucRc1;
        private UCRp ucRp1;
        private System.Windows.Forms.TabPage tpIT;
        private UCIt ucIt1;
        private System.Windows.Forms.ToolStripStatusLabel tssTimeout;
        private System.Windows.Forms.ToolStripButton tsbModifyStatus;
        private System.Windows.Forms.ToolStripStatusLabel tssFLStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel tssModifyStatus;
    }
}