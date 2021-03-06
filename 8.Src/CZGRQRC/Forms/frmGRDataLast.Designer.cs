﻿namespace FNGRQRC
{
    partial class frmGRDataLast
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPressCurve = new System.Windows.Forms.Button();
            this.btnTempCurve = new System.Windows.Forms.Button();
            this.btnHistoryData = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbStreet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(697, 279);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(12, 297);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(93, 297);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPressCurve
            // 
            this.btnPressCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPressCurve.Location = new System.Drawing.Point(634, 297);
            this.btnPressCurve.Name = "btnPressCurve";
            this.btnPressCurve.Size = new System.Drawing.Size(75, 23);
            this.btnPressCurve.TabIndex = 7;
            this.btnPressCurve.Text = "压力曲线";
            this.btnPressCurve.UseVisualStyleBackColor = true;
            this.btnPressCurve.Click += new System.EventHandler(this.btnPressCurve_Click);
            // 
            // btnTempCurve
            // 
            this.btnTempCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTempCurve.Location = new System.Drawing.Point(553, 297);
            this.btnTempCurve.Name = "btnTempCurve";
            this.btnTempCurve.Size = new System.Drawing.Size(75, 23);
            this.btnTempCurve.TabIndex = 6;
            this.btnTempCurve.Text = "温度曲线";
            this.btnTempCurve.UseVisualStyleBackColor = true;
            this.btnTempCurve.Click += new System.EventHandler(this.btnTempCurve_Click);
            // 
            // btnHistoryData
            // 
            this.btnHistoryData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistoryData.Location = new System.Drawing.Point(472, 297);
            this.btnHistoryData.Name = "btnHistoryData";
            this.btnHistoryData.Size = new System.Drawing.Size(75, 23);
            this.btnHistoryData.TabIndex = 5;
            this.btnHistoryData.Text = "历史数据";
            this.btnHistoryData.UseVisualStyleBackColor = true;
            this.btnHistoryData.Click += new System.EventHandler(this.btnHistoryData_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbStreet
            // 
            this.cmbStreet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbStreet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStreet.FormattingEnabled = true;
            this.cmbStreet.Location = new System.Drawing.Point(221, 299);
            this.cmbStreet.Name = "cmbStreet";
            this.cmbStreet.Size = new System.Drawing.Size(121, 20);
            this.cmbStreet.TabIndex = 4;
            this.cmbStreet.SelectedIndexChanged += new System.EventHandler(this.cmbStreet_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "分区:";
            // 
            // frmGRDataLast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 332);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStreet);
            this.Controls.Add(this.btnHistoryData);
            this.Controls.Add(this.btnTempCurve);
            this.Controls.Add(this.btnPressCurve);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmGRDataLast";
            this.Text = "frmGRDataLast";
            this.Load += new System.EventHandler(this.frmGRDataLast_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPressCurve;
        private System.Windows.Forms.Button btnTempCurve;
        private System.Windows.Forms.Button btnHistoryData;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbStreet;
        private System.Windows.Forms.Label label1;
    }
}