namespace CZGRQRC
{
    partial class frmCalcHeat
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
            this.txtMonthPlanHeat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonthDays = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalSupportArea = new System.Windows.Forms.TextBox();
            this.ucCalcHeatCondition1 = new CZGRQRC.UCCalcHeatCondition();
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
            this.dataGridView1.Size = new System.Drawing.Size(511, 388);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtMonthPlanHeat
            // 
            this.txtMonthPlanHeat.Location = new System.Drawing.Point(12, 203);
            this.txtMonthPlanHeat.Name = "txtMonthPlanHeat";
            this.txtMonthPlanHeat.ReadOnly = true;
            this.txtMonthPlanHeat.Size = new System.Drawing.Size(118, 21);
            this.txtMonthPlanHeat.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "月计划耗热量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "GJ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "天";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "月供热天数：";
            // 
            // txtMonthDays
            // 
            this.txtMonthDays.Location = new System.Drawing.Point(12, 247);
            this.txtMonthDays.Name = "txtMonthDays";
            this.txtMonthDays.ReadOnly = true;
            this.txtMonthDays.Size = new System.Drawing.Size(118, 21);
            this.txtMonthDays.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "平方米";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "总供热面积：";
            // 
            // txtTotalSupportArea
            // 
            this.txtTotalSupportArea.Location = new System.Drawing.Point(12, 291);
            this.txtTotalSupportArea.Name = "txtTotalSupportArea";
            this.txtTotalSupportArea.ReadOnly = true;
            this.txtTotalSupportArea.Size = new System.Drawing.Size(118, 21);
            this.txtTotalSupportArea.TabIndex = 8;
            // 
            // ucCalcHeatCondition1
            // 
            this.ucCalcHeatCondition1.Location = new System.Drawing.Point(6, 12);
            this.ucCalcHeatCondition1.Name = "ucCalcHeatCondition1";
            this.ucCalcHeatCondition1.Size = new System.Drawing.Size(174, 141);
            this.ucCalcHeatCondition1.TabIndex = 1;
            this.ucCalcHeatCondition1.Load += new System.EventHandler(this.ucCalcHeatCondition1_Load);
            this.ucCalcHeatCondition1.OKEvent += new System.EventHandler(this.ucCalcHeatCondition1_OKEvent);
            this.ucCalcHeatCondition1.ExportEvent += new System.EventHandler(this.ucCalcHeatCondition1_ExportEvent);
            // 
            // frmCalcHeat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 413);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalSupportArea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMonthDays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMonthPlanHeat);
            this.Controls.Add(this.ucCalcHeatCondition1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmCalcHeat";
            this.Text = "frmCalcHeat";
            this.Load += new System.EventHandler(this.frmCalcHeat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private UCCalcHeatCondition ucCalcHeatCondition1;
        private System.Windows.Forms.TextBox txtMonthPlanHeat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMonthDays;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalSupportArea;
    }
}