namespace CZGRQRC
{
    partial class frmContrastCurve
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
            this.zedFirst = new ZedGraph.ZedGraphControl();
            this.zedSecond = new ZedGraph.ZedGraphControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbHorizontal = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedFirst
            // 
            this.zedFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedFirst.Location = new System.Drawing.Point(0, 0);
            this.zedFirst.Name = "zedFirst";
            this.zedFirst.ScrollGrace = 0;
            this.zedFirst.ScrollMaxX = 0;
            this.zedFirst.ScrollMaxY = 0;
            this.zedFirst.ScrollMaxY2 = 0;
            this.zedFirst.ScrollMinX = 0;
            this.zedFirst.ScrollMinY = 0;
            this.zedFirst.ScrollMinY2 = 0;
            this.zedFirst.Size = new System.Drawing.Size(764, 255);
            this.zedFirst.TabIndex = 0;
            // 
            // zedSecond
            // 
            this.zedSecond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedSecond.Location = new System.Drawing.Point(0, 0);
            this.zedSecond.Name = "zedSecond";
            this.zedSecond.ScrollGrace = 0;
            this.zedSecond.ScrollMaxX = 0;
            this.zedSecond.ScrollMaxY = 0;
            this.zedSecond.ScrollMaxY2 = 0;
            this.zedSecond.ScrollMinX = 0;
            this.zedSecond.ScrollMinY = 0;
            this.zedSecond.ScrollMinY2 = 0;
            this.zedSecond.Size = new System.Drawing.Size(764, 247);
            this.zedSecond.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.zedFirst);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.zedSecond);
            this.splitContainer1.Size = new System.Drawing.Size(764, 506);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_MouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHorizontal});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(764, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbHorizontal
            // 
            this.tsbHorizontal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHorizontal.Image = global::CZGRQRC.Properties.Resources.split;
            this.tsbHorizontal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHorizontal.Name = "tsbHorizontal";
            this.tsbHorizontal.Size = new System.Drawing.Size(28, 28);
            this.tsbHorizontal.Text = "toolStripButton1";
            this.tsbHorizontal.ToolTipText = "排列方式";
            this.tsbHorizontal.Click += new System.EventHandler(this.tsbVertical_Click);
            // 
            // frmContrastCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 537);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmContrastCurve";
            this.Text = "对比曲线";
            this.Load += new System.EventHandler(this.frmContrastCurve_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedFirst;
        private ZedGraph.ZedGraphControl zedSecond;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbHorizontal;
    }
}