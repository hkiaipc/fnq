namespace K.Forms
{
    partial class frmTMDataQuery
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTMSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.cmbQueryStyle = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPerson = new System.Windows.Forms.ComboBox();
            this.cmbStation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panPerson = new System.Windows.Forms.Panel();
            this.panStation = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panPerson.SuspendLayout();
            this.panStation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(97, 237);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStationName,
            this.colPersonName,
            this.colTMSN,
            this.colDT});
            this.dataGridView1.Location = new System.Drawing.Point(193, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(579, 413);
            this.dataGridView1.TabIndex = 1;
            // 
            // colStationName
            // 
            this.colStationName.DataPropertyName = "StationName";
            this.colStationName.HeaderText = "站点";
            this.colStationName.Name = "colStationName";
            this.colStationName.ReadOnly = true;
            this.colStationName.Width = 120;
            // 
            // colPersonName
            // 
            this.colPersonName.DataPropertyName = "PersonName";
            this.colPersonName.HeaderText = "人员";
            this.colPersonName.Name = "colPersonName";
            this.colPersonName.ReadOnly = true;
            this.colPersonName.Width = 120;
            // 
            // colTMSN
            // 
            this.colTMSN.DataPropertyName = "TMSN";
            this.colTMSN.HeaderText = "卡号";
            this.colTMSN.Name = "colTMSN";
            this.colTMSN.ReadOnly = true;
            this.colTMSN.Width = 120;
            // 
            // colDT
            // 
            this.colDT.DataPropertyName = "DT";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.colDT.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDT.HeaderText = "时间";
            this.colDT.Name = "colDT";
            this.colDT.ReadOnly = true;
            this.colDT.Width = 140;
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(6, 32);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(150, 21);
            this.dtpBegin.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "开始时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "结束时间:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(6, 80);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(150, 21);
            this.dtpEnd.TabIndex = 4;
            // 
            // cmbQueryStyle
            // 
            this.cmbQueryStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueryStyle.FormattingEnabled = true;
            this.cmbQueryStyle.Location = new System.Drawing.Point(6, 137);
            this.cmbQueryStyle.Name = "cmbQueryStyle";
            this.cmbQueryStyle.Size = new System.Drawing.Size(150, 20);
            this.cmbQueryStyle.TabIndex = 6;
            this.cmbQueryStyle.SelectedIndexChanged += new System.EventHandler(this.cmbQueryStyle_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "方式:";
            // 
            // cmbPerson
            // 
            this.cmbPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerson.FormattingEnabled = true;
            this.cmbPerson.Location = new System.Drawing.Point(3, 17);
            this.cmbPerson.Name = "cmbPerson";
            this.cmbPerson.Size = new System.Drawing.Size(150, 20);
            this.cmbPerson.TabIndex = 8;
            // 
            // cmbStation
            // 
            this.cmbStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStation.FormattingEnabled = true;
            this.cmbStation.Location = new System.Drawing.Point(3, 17);
            this.cmbStation.Name = "cmbStation";
            this.cmbStation.Size = new System.Drawing.Size(150, 20);
            this.cmbStation.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "人员:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "站点:";
            // 
            // panPerson
            // 
            this.panPerson.Controls.Add(this.cmbPerson);
            this.panPerson.Controls.Add(this.label4);
            this.panPerson.Location = new System.Drawing.Point(3, 219);
            this.panPerson.Name = "panPerson";
            this.panPerson.Size = new System.Drawing.Size(160, 50);
            this.panPerson.TabIndex = 12;
            // 
            // panStation
            // 
            this.panStation.Controls.Add(this.cmbStation);
            this.panStation.Controls.Add(this.label5);
            this.panStation.Location = new System.Drawing.Point(3, 163);
            this.panStation.Name = "panStation";
            this.panStation.Size = new System.Drawing.Size(160, 50);
            this.panStation.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panStation);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.panPerson);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbQueryStyle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 219);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件";
            // 
            // frmTMDataQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 437);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnQuery);
            this.Name = "frmTMDataQuery";
            this.Text = "巡更数据";
            this.Load += new System.EventHandler(this.frmTMDataQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panPerson.ResumeLayout(false);
            this.panPerson.PerformLayout();
            this.panStation.ResumeLayout(false);
            this.panStation.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.ComboBox cmbQueryStyle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPerson;
        private System.Windows.Forms.ComboBox cmbStation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panPerson;
        private System.Windows.Forms.Panel panStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTMSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDT;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}