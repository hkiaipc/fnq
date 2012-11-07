namespace FNGRQRC
{
    partial class frmFirstStationDetail
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(584, 359);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "关闭";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(440, 359);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKey,
            this.colDT,
            this.colIR,
            this.colSR});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(644, 341);
            this.dataGridView1.TabIndex = 0;
            // 
            // colKey
            // 
            this.colKey.DataPropertyName = "Name";
            this.colKey.FillWeight = 150F;
            this.colKey.HeaderText = "名称";
            this.colKey.Name = "colKey";
            this.colKey.ReadOnly = true;
            this.colKey.Width = 150;
            // 
            // colDT
            // 
            this.colDT.DataPropertyName = "DT";
            this.colDT.FillWeight = 150F;
            this.colDT.HeaderText = "时间";
            this.colDT.Name = "colDT";
            this.colDT.ReadOnly = true;
            this.colDT.Width = 150;
            // 
            // colIR
            // 
            this.colIR.DataPropertyName = "IR";
            this.colIR.FillWeight = 150F;
            this.colIR.HeaderText = "瞬时";
            this.colIR.Name = "colIR";
            this.colIR.ReadOnly = true;
            this.colIR.Width = 150;
            // 
            // colSR
            // 
            this.colSR.DataPropertyName = "SR";
            this.colSR.HeaderText = "累计";
            this.colSR.Name = "colSR";
            this.colSR.ReadOnly = true;
            this.colSR.Width = 150;
            // 
            // frmFirstStationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 392);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmFirstStationDetail";
            this.Text = "流量详细信息";
            this.Load += new System.EventHandler(this.frmFirstStationDetail_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSR;
    }
}