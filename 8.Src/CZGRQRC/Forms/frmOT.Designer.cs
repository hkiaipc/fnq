namespace CZGRQRC
{
    partial class frmOT
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
            this.ucotCondition1 = new CZGRQRC.UC.UCOTCondition();
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
            this.dataGridView1.Size = new System.Drawing.Size(381, 347);
            this.dataGridView1.TabIndex = 1;
            // 
            // ucotCondition1
            // 
            this.ucotCondition1.Begin = new System.DateTime(2010, 10, 26, 0, 0, 0, 0);
            this.ucotCondition1.End = new System.DateTime(2010, 10, 27, 0, 0, 0, 0);
            this.ucotCondition1.Location = new System.Drawing.Point(12, 12);
            this.ucotCondition1.Name = "ucotCondition1";
            this.ucotCondition1.Size = new System.Drawing.Size(168, 201);
            this.ucotCondition1.TabIndex = 2;
            this.ucotCondition1.OKEvent += new System.EventHandler(this.ucotCondition1_OKEvent);
            this.ucotCondition1.ExportEvent += new System.EventHandler(this.ucotCondition1_ExportEvent);
            // 
            // frmOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 370);
            this.Controls.Add(this.ucotCondition1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmOT";
            this.Text = "室外温度";
            this.Load += new System.EventHandler(this.frmOT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private CZGRQRC.UC.UCOTCondition ucotCondition1;
    }
}