namespace fnbx
{
    partial class frmMTList
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
            this.itidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mlidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rpidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtposedtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtcreatedtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtbegindtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtstatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtlocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtcontentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtremarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtparentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtfeeinfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtmarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblIntroducerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblMaintain1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblMaintainLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblOperatorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblReplyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblMaintainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaintainBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itidDataGridViewTextBoxColumn,
            this.mtidDataGridViewTextBoxColumn,
            this.mlidDataGridViewTextBoxColumn,
            this.rpidDataGridViewTextBoxColumn,
            this.opidDataGridViewTextBoxColumn,
            this.mtposedtDataGridViewTextBoxColumn,
            this.mtcreatedtDataGridViewTextBoxColumn,
            this.mtbegindtDataGridViewTextBoxColumn,
            this.mtstatusDataGridViewTextBoxColumn,
            this.mtlocationDataGridViewTextBoxColumn,
            this.mtcontentDataGridViewTextBoxColumn,
            this.mtremarkDataGridViewTextBoxColumn,
            this.mtparentDataGridViewTextBoxColumn,
            this.mtfeeinfoDataGridViewTextBoxColumn,
            this.mtmarkDataGridViewTextBoxColumn,
            this.tblIntroducerDataGridViewTextBoxColumn,
            this.tblMaintain1DataGridViewTextBoxColumn,
            this.tblMaintainLevelDataGridViewTextBoxColumn,
            this.tblOperatorDataGridViewTextBoxColumn,
            this.tblReplyDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblMaintainBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(694, 384);
            this.dataGridView1.TabIndex = 0;
            // 
            // itidDataGridViewTextBoxColumn
            // 
            this.itidDataGridViewTextBoxColumn.DataPropertyName = "it_id";
            this.itidDataGridViewTextBoxColumn.HeaderText = "it_id";
            this.itidDataGridViewTextBoxColumn.Name = "itidDataGridViewTextBoxColumn";
            this.itidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mtidDataGridViewTextBoxColumn
            // 
            this.mtidDataGridViewTextBoxColumn.DataPropertyName = "mt_id";
            this.mtidDataGridViewTextBoxColumn.HeaderText = "mt_id";
            this.mtidDataGridViewTextBoxColumn.Name = "mtidDataGridViewTextBoxColumn";
            this.mtidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mlidDataGridViewTextBoxColumn
            // 
            this.mlidDataGridViewTextBoxColumn.DataPropertyName = "ml_id";
            this.mlidDataGridViewTextBoxColumn.HeaderText = "ml_id";
            this.mlidDataGridViewTextBoxColumn.Name = "mlidDataGridViewTextBoxColumn";
            this.mlidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rpidDataGridViewTextBoxColumn
            // 
            this.rpidDataGridViewTextBoxColumn.DataPropertyName = "rp_id";
            this.rpidDataGridViewTextBoxColumn.HeaderText = "rp_id";
            this.rpidDataGridViewTextBoxColumn.Name = "rpidDataGridViewTextBoxColumn";
            this.rpidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // opidDataGridViewTextBoxColumn
            // 
            this.opidDataGridViewTextBoxColumn.DataPropertyName = "op_id";
            this.opidDataGridViewTextBoxColumn.HeaderText = "op_id";
            this.opidDataGridViewTextBoxColumn.Name = "opidDataGridViewTextBoxColumn";
            this.opidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mtposedtDataGridViewTextBoxColumn
            // 
            this.mtposedtDataGridViewTextBoxColumn.DataPropertyName = "mt_pose_dt";
            this.mtposedtDataGridViewTextBoxColumn.HeaderText = "mt_pose_dt";
            this.mtposedtDataGridViewTextBoxColumn.Name = "mtposedtDataGridViewTextBoxColumn";
            this.mtposedtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mtcreatedtDataGridViewTextBoxColumn
            // 
            this.mtcreatedtDataGridViewTextBoxColumn.DataPropertyName = "mt_create_dt";
            this.mtcreatedtDataGridViewTextBoxColumn.HeaderText = "mt_create_dt";
            this.mtcreatedtDataGridViewTextBoxColumn.Name = "mtcreatedtDataGridViewTextBoxColumn";
            this.mtcreatedtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mtbegindtDataGridViewTextBoxColumn
            // 
            this.mtbegindtDataGridViewTextBoxColumn.DataPropertyName = "mt_begin_dt";
            this.mtbegindtDataGridViewTextBoxColumn.HeaderText = "mt_begin_dt";
            this.mtbegindtDataGridViewTextBoxColumn.Name = "mtbegindtDataGridViewTextBoxColumn";
            this.mtbegindtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mtstatusDataGridViewTextBoxColumn
            // 
            this.mtstatusDataGridViewTextBoxColumn.DataPropertyName = "mt_status";
            this.mtstatusDataGridViewTextBoxColumn.HeaderText = "mt_status";
            this.mtstatusDataGridViewTextBoxColumn.Name = "mtstatusDataGridViewTextBoxColumn";
            this.mtstatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mtlocationDataGridViewTextBoxColumn
            // 
            this.mtlocationDataGridViewTextBoxColumn.DataPropertyName = "mt_location";
            this.mtlocationDataGridViewTextBoxColumn.HeaderText = "mt_location";
            this.mtlocationDataGridViewTextBoxColumn.Name = "mtlocationDataGridViewTextBoxColumn";
            this.mtlocationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mtcontentDataGridViewTextBoxColumn
            // 
            this.mtcontentDataGridViewTextBoxColumn.DataPropertyName = "mt_content";
            this.mtcontentDataGridViewTextBoxColumn.HeaderText = "mt_content";
            this.mtcontentDataGridViewTextBoxColumn.Name = "mtcontentDataGridViewTextBoxColumn";
            this.mtcontentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mtremarkDataGridViewTextBoxColumn
            // 
            this.mtremarkDataGridViewTextBoxColumn.DataPropertyName = "mt_remark";
            this.mtremarkDataGridViewTextBoxColumn.HeaderText = "mt_remark";
            this.mtremarkDataGridViewTextBoxColumn.Name = "mtremarkDataGridViewTextBoxColumn";
            this.mtremarkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mtparentDataGridViewTextBoxColumn
            // 
            this.mtparentDataGridViewTextBoxColumn.DataPropertyName = "mt_parent";
            this.mtparentDataGridViewTextBoxColumn.HeaderText = "mt_parent";
            this.mtparentDataGridViewTextBoxColumn.Name = "mtparentDataGridViewTextBoxColumn";
            this.mtparentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mtfeeinfoDataGridViewTextBoxColumn
            // 
            this.mtfeeinfoDataGridViewTextBoxColumn.DataPropertyName = "mt_fee_info";
            this.mtfeeinfoDataGridViewTextBoxColumn.HeaderText = "mt_fee_info";
            this.mtfeeinfoDataGridViewTextBoxColumn.Name = "mtfeeinfoDataGridViewTextBoxColumn";
            this.mtfeeinfoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mtmarkDataGridViewTextBoxColumn
            // 
            this.mtmarkDataGridViewTextBoxColumn.DataPropertyName = "mt_mark";
            this.mtmarkDataGridViewTextBoxColumn.HeaderText = "mt_mark";
            this.mtmarkDataGridViewTextBoxColumn.Name = "mtmarkDataGridViewTextBoxColumn";
            this.mtmarkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tblIntroducerDataGridViewTextBoxColumn
            // 
            this.tblIntroducerDataGridViewTextBoxColumn.DataPropertyName = "tblIntroducer";
            this.tblIntroducerDataGridViewTextBoxColumn.HeaderText = "tblIntroducer";
            this.tblIntroducerDataGridViewTextBoxColumn.Name = "tblIntroducerDataGridViewTextBoxColumn";
            this.tblIntroducerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tblMaintain1DataGridViewTextBoxColumn
            // 
            this.tblMaintain1DataGridViewTextBoxColumn.DataPropertyName = "tblMaintain1";
            this.tblMaintain1DataGridViewTextBoxColumn.HeaderText = "tblMaintain1";
            this.tblMaintain1DataGridViewTextBoxColumn.Name = "tblMaintain1DataGridViewTextBoxColumn";
            this.tblMaintain1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tblMaintainLevelDataGridViewTextBoxColumn
            // 
            this.tblMaintainLevelDataGridViewTextBoxColumn.DataPropertyName = "tblMaintainLevel";
            this.tblMaintainLevelDataGridViewTextBoxColumn.HeaderText = "tblMaintainLevel";
            this.tblMaintainLevelDataGridViewTextBoxColumn.Name = "tblMaintainLevelDataGridViewTextBoxColumn";
            this.tblMaintainLevelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tblOperatorDataGridViewTextBoxColumn
            // 
            this.tblOperatorDataGridViewTextBoxColumn.DataPropertyName = "tblOperator";
            this.tblOperatorDataGridViewTextBoxColumn.HeaderText = "tblOperator";
            this.tblOperatorDataGridViewTextBoxColumn.Name = "tblOperatorDataGridViewTextBoxColumn";
            this.tblOperatorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tblReplyDataGridViewTextBoxColumn
            // 
            this.tblReplyDataGridViewTextBoxColumn.DataPropertyName = "tblReply";
            this.tblReplyDataGridViewTextBoxColumn.HeaderText = "tblReply";
            this.tblReplyDataGridViewTextBoxColumn.Name = "tblReplyDataGridViewTextBoxColumn";
            this.tblReplyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tblMaintainBindingSource
            // 
            this.tblMaintainBindingSource.DataSource = typeof(BXDB.tblMaintain);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 61);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(165, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "x";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "*";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(308, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(166, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "view for rp";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmMTList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 445);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frmMTList";
            this.Text = "frmMTList";
            this.Load += new System.EventHandler(this.frmMTList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaintainBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn itidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mlidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rpidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn opidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtposedtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtcreatedtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtbegindtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtstatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtlocationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtcontentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtremarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtparentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtfeeinfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtmarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblIntroducerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblMaintain1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblMaintainLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblOperatorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblReplyDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource tblMaintainBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}