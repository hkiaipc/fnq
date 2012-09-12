namespace fnbx
{
    partial class frmMT
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMT = new System.Windows.Forms.TabPage();
            this.ucMt1 = new fnbx.UCMt();
            this.tpRP = new System.Windows.Forms.TabPage();
            this.ucRp1 = new fnbx.UCRp();
            this.btnModifyStatus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTMStatus = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssTimeout = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tpMT.SuspendLayout();
            this.tpRP.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(523, 489);
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(611, 489);
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpMT);
            this.tabControl1.Controls.Add(this.tpRP);
            this.tabControl1.Location = new System.Drawing.Point(2, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(693, 458);
            this.tabControl1.TabIndex = 39;
            // 
            // tpMT
            // 
            this.tpMT.Controls.Add(this.ucMt1);
            this.tpMT.Location = new System.Drawing.Point(4, 21);
            this.tpMT.Name = "tpMT";
            this.tpMT.Padding = new System.Windows.Forms.Padding(3);
            this.tpMT.Size = new System.Drawing.Size(685, 433);
            this.tpMT.TabIndex = 0;
            this.tpMT.Text = "报修信息";
            this.tpMT.UseVisualStyleBackColor = true;
            // 
            // ucMt1
            // 
            this.ucMt1.Location = new System.Drawing.Point(6, 6);
            this.ucMt1.Maintain = null;
            this.ucMt1.Name = "ucMt1";
            this.ucMt1.Size = new System.Drawing.Size(647, 399);
            this.ucMt1.TabIndex = 0;
            // 
            // tpRP
            // 
            this.tpRP.Controls.Add(this.ucRp1);
            this.tpRP.Location = new System.Drawing.Point(4, 21);
            this.tpRP.Name = "tpRP";
            this.tpRP.Padding = new System.Windows.Forms.Padding(3);
            this.tpRP.Size = new System.Drawing.Size(685, 433);
            this.tpRP.TabIndex = 1;
            this.tpRP.Text = "回单信息";
            this.tpRP.UseVisualStyleBackColor = true;
            // 
            // ucRp1
            // 
            this.ucRp1.Location = new System.Drawing.Point(6, 6);
            this.ucRp1.Name = "ucRp1";
            this.ucRp1.Reply = null;
            this.ucRp1.Size = new System.Drawing.Size(586, 251);
            this.ucRp1.TabIndex = 0;
            // 
            // btnModifyStatus
            // 
            this.btnModifyStatus.Location = new System.Drawing.Point(274, 494);
            this.btnModifyStatus.Name = "btnModifyStatus";
            this.btnModifyStatus.Size = new System.Drawing.Size(75, 23);
            this.btnModifyStatus.TabIndex = 40;
            this.btnModifyStatus.Text = "修改";
            this.btnModifyStatus.UseVisualStyleBackColor = true;
            this.btnModifyStatus.Click += new System.EventHandler(this.btnModifyStatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 41;
            this.label1.Text = "状态:";
            // 
            // txtTMStatus
            // 
            this.txtTMStatus.BackColor = System.Drawing.Color.White;
            this.txtTMStatus.Location = new System.Drawing.Point(122, 494);
            this.txtTMStatus.Name = "txtTMStatus";
            this.txtTMStatus.ReadOnly = true;
            this.txtTMStatus.Size = new System.Drawing.Size(146, 21);
            this.txtTMStatus.TabIndex = 42;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssTimeout});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(695, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 43;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssTimeout
            // 
            this.tssTimeout.ForeColor = System.Drawing.Color.Red;
            this.tssTimeout.Name = "tssTimeout";
            this.tssTimeout.Size = new System.Drawing.Size(680, 17);
            this.tssTimeout.Spring = true;
            this.tssTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 525);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtTMStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModifyStatus);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMT";
            this.Text = "报修";
            this.Load += new System.EventHandler(this.frmMT_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.btnModifyStatus, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTMStatus, 0);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.tabControl1.ResumeLayout(false);
            this.tpMT.ResumeLayout(false);
            this.tpRP.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMT;
        private System.Windows.Forms.TabPage tpRP;
        private UCMt ucMt1;
        private UCRp ucRp1;
        private System.Windows.Forms.Button btnModifyStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTMStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssTimeout;
        private System.Windows.Forms.Timer timer1;
    }
}