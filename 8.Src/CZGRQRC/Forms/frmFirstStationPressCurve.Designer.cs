namespace FNGRQRC
{
    partial class frmFirstStationPressCurve
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.ucSelectCondition1 = new FNGRQRC.UCSelectCondition();
            this.ucGatherDataGridView1 = new FNGRQRC.UCGatherDataGridView();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.Location = new System.Drawing.Point(233, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(485, 406);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // ucSelectCondition1
            // 
            this.ucSelectCondition1.Begin = new System.DateTime(2012, 10, 19, 9, 57, 31, 515);
            this.ucSelectCondition1.DeviceTypes = new string[] {
        "xd100e"};
            this.ucSelectCondition1.End = new System.DateTime(2012, 10, 19, 9, 57, 31, 515);
            this.ucSelectCondition1.IsAddAll = true;
            this.ucSelectCondition1.Location = new System.Drawing.Point(12, 12);
            this.ucSelectCondition1.Name = "ucSelectCondition1";
            this.ucSelectCondition1.ShowExport = true;
            this.ucSelectCondition1.Size = new System.Drawing.Size(215, 250);
            this.ucSelectCondition1.StationName = "<全部>";
            this.ucSelectCondition1.TabIndex = 0;
            this.ucSelectCondition1.Load += new System.EventHandler(this.ucSelectCondition1_Load);
            this.ucSelectCondition1.OKEvent += new System.EventHandler(this.ucSelectCondition1_OKEvent);
            // 
            // ucGatherDataGridView1
            // 
            this.ucGatherDataGridView1.GatherClasses = null;
            this.ucGatherDataGridView1.Location = new System.Drawing.Point(12, 268);
            this.ucGatherDataGridView1.Name = "ucGatherDataGridView1";
            this.ucGatherDataGridView1.Size = new System.Drawing.Size(215, 150);
            this.ucGatherDataGridView1.TabIndex = 1;
            this.ucGatherDataGridView1.Visible = false;
            // 
            // frmFirstStationPressCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 430);
            this.Controls.Add(this.ucGatherDataGridView1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.ucSelectCondition1);
            this.Name = "frmFirstStationPressCurve";
            this.Text = "frmPressCurve";
            this.Load += new System.EventHandler(this.frmPressCurve_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCSelectCondition ucSelectCondition1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private UCGatherDataGridView ucGatherDataGridView1;
    }
}