namespace FNGRQRC
{
    partial class frmGRDataQR
    {            
        System.Windows.Forms.DataGridView dataGridView1;
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
            this.ucSelectCondition1 = new FNGRQRC.UCSelectCondition();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucSelectCondition1
            // 
            this.ucSelectCondition1.IsAddAll = true;
            this.ucSelectCondition1.Location = new System.Drawing.Point(12, 12);
            this.ucSelectCondition1.Name = "ucSelectCondition1";
            this.ucSelectCondition1.ShowExport = true;
            this.ucSelectCondition1.Size = new System.Drawing.Size(169, 280);
            this.ucSelectCondition1.StationName = "<全部>";
            this.ucSelectCondition1.TabIndex = 0;
            this.ucSelectCondition1.OKEvent += new System.EventHandler(this.ucSelectCondition1_OKEvent);
            this.ucSelectCondition1.ExportEvent += new System.EventHandler(this.ucSelectCondition1_ExportEvent);
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(187, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 21;
            dataGridView1.Size = new System.Drawing.Size(503, 280);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // frmGRDataQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 304);
            this.Controls.Add(dataGridView1);
            this.Controls.Add(this.ucSelectCondition1);
            this.Name = "frmGRDataQR";
            this.Text = "frmGRDataQR";
            this.Load += new System.EventHandler(this.frmGRDataQR_Load);
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private UCSelectCondition ucSelectCondition1;
    }
}