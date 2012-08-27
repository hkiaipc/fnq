namespace CZGRQRC
{
    partial class frmOneStationCalcHeat
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
            this.ucSelectCondition1 = new CZGRQRC.UCSelectCondition();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSumHeat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(186, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(435, 363);
            this.dataGridView1.TabIndex = 1;
            // 
            // ucSelectCondition1
            // 
            this.ucSelectCondition1.Begin = new System.DateTime(2010, 3, 11, 0, 0, 0, 0);
            this.ucSelectCondition1.End = new System.DateTime(2010, 3, 12, 0, 0, 0, 0);
            this.ucSelectCondition1.IsAddAll = true;
            this.ucSelectCondition1.Location = new System.Drawing.Point(12, 12);
            this.ucSelectCondition1.Name = "ucSelectCondition1";
            this.ucSelectCondition1.ShowExport = true;
            this.ucSelectCondition1.Size = new System.Drawing.Size(168, 253);
            this.ucSelectCondition1.StationName = "<全部>";
            this.ucSelectCondition1.TabIndex = 0;
            this.ucSelectCondition1.Load += new System.EventHandler(this.ucSelectCondition1_Load);
            this.ucSelectCondition1.OKEvent += new System.EventHandler(this.ucSelectCondition1_OKEvent);
            this.ucSelectCondition1.ExportEvent += new System.EventHandler(this.ucSelectCondition1_ExportEvent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "累计耗热量：";
            // 
            // txtSumHeat
            // 
            this.txtSumHeat.BackColor = System.Drawing.Color.White;
            this.txtSumHeat.Location = new System.Drawing.Point(93, 293);
            this.txtSumHeat.Name = "txtSumHeat";
            this.txtSumHeat.ReadOnly = true;
            this.txtSumHeat.Size = new System.Drawing.Size(77, 21);
            this.txtSumHeat.TabIndex = 3;
            // 
            // frmOneStationCalcHeat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 387);
            this.Controls.Add(this.txtSumHeat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ucSelectCondition1);
            this.Name = "frmOneStationCalcHeat";
            this.Text = "阶段耗热量";
            this.Load += new System.EventHandler(this.frmOneStationCalcHeat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UCSelectCondition ucSelectCondition1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSumHeat;
    }
}