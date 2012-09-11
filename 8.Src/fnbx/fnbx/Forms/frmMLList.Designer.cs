namespace fnbx
{
    partial class frmMLList
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblMaintainLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ml_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ml_arrive_hl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ml_reply_hl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaintainLevelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            //this.okButton.Location = new System.Drawing.Point(358, 393);
            //this.okButton.Text = "修改";
            //this.okButton.Click += new System.EventHandler(this.okButton_Click);
            //// 
            //// cancelButton
            //// 
            //this.cancelButton.Location = new System.Drawing.Point(446, 393);
            //this.cancelButton.Text = "关闭";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ml_name,
            this.ml_arrive_hl,
            this.ml_reply_hl});
            this.dataGridView1.DataSource = this.tblMaintainLevelBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(506, 363);
            this.dataGridView1.TabIndex = 19;
            // 
            // tblMaintainLevelBindingSource
            // 
            this.tblMaintainLevelBindingSource.DataSource = typeof(BXDB.tblMaintainLevel);
            // 
            // ml_name
            // 
            this.ml_name.DataPropertyName = "ml_name";
            this.ml_name.HeaderText = "名称";
            this.ml_name.Name = "ml_name";
            this.ml_name.ReadOnly = true;
            // 
            // ml_arrive_hl
            // 
            this.ml_arrive_hl.DataPropertyName = "ml_arrive_hl";
            this.ml_arrive_hl.HeaderText = "到达时间(分钟)";
            this.ml_arrive_hl.Name = "ml_arrive_hl";
            this.ml_arrive_hl.ReadOnly = true;
            this.ml_arrive_hl.Width = 150;
            // 
            // ml_reply_hl
            // 
            this.ml_reply_hl.DataPropertyName = "ml_reply_hl";
            this.ml_reply_hl.HeaderText = "回复时限(分钟)";
            this.ml_reply_hl.Name = "ml_reply_hl";
            this.ml_reply_hl.ReadOnly = true;
            this.ml_reply_hl.Width = 150;
            // 
            // frmMLList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 429);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmMLList";
            this.Text = "报修等级";
            this.Load += new System.EventHandler(this.frmMLList_Load);
            //this.Controls.SetChildIndex(this.okButton, 0);
            //this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaintainLevelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource tblMaintainLevelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ml_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ml_arrive_hl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ml_reply_hl;
    }
}