namespace FNGRQRC
{
    partial class frmFirstStationDataHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ucSelectCondition1 = new FNGRQRC.UCSelectCondition();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(186, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(405, 339);
            this.dataGridView1.TabIndex = 3;
            // 
            // ucSelectCondition1
            // 
            this.ucSelectCondition1.Begin = new System.DateTime(2012, 10, 18, 11, 34, 28, 586);
            this.ucSelectCondition1.DeviceTypes = new string[] {
        "Xd100e"};
            this.ucSelectCondition1.End = new System.DateTime(2012, 10, 18, 11, 34, 28, 586);
            this.ucSelectCondition1.IsAddAll = true;
            this.ucSelectCondition1.Location = new System.Drawing.Point(12, 12);
            this.ucSelectCondition1.Name = "ucSelectCondition1";
            this.ucSelectCondition1.ShowExport = true;
            this.ucSelectCondition1.Size = new System.Drawing.Size(168, 253);
            this.ucSelectCondition1.StationName = "";
            this.ucSelectCondition1.TabIndex = 4;
            this.ucSelectCondition1.OKEvent += new System.EventHandler(this.ucSelectCondition1_OKEvent);
            this.ucSelectCondition1.ExportEvent += new System.EventHandler(this.ucSelectCondition1_ExportEvent);
            // 
            // frmFirstStationDataHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 363);
            this.Controls.Add(this.ucSelectCondition1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmFirstStationDataHistory";
            this.Text = "首站历史数据";
            this.Load += new System.EventHandler(this.frmFirstStationDataHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private UCSelectCondition ucSelectCondition1;
    }
}