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
            this.tblFlowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblMaintainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tblFlowBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tblFlowBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblFlowBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.flidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flparentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rcidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flstatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblFlow1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblReceiveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblMaintainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblFlowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaintainBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblFlowBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFlowBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFlowBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // tblFlowBindingSource
            // 
            this.tblFlowBindingSource.DataSource = typeof(BXDB.tblFlow);
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
            // tblFlowBindingSource1
            // 
            this.tblFlowBindingSource1.DataSource = typeof(BXDB.tblFlow);
            // 
            // tblFlowBindingSource2
            // 
            this.tblFlowBindingSource2.DataMember = "tblFlow";
            this.tblFlowBindingSource2.DataSource = this.tblMaintainBindingSource;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flidDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.flparentDataGridViewTextBoxColumn,
            this.mtidDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.rcidDataGridViewTextBoxColumn,
            this.flstatusDataGridViewTextBoxColumn,
            this.tblFlow1DataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn3,
            this.tblReceiveDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn4,
            this.tblMaintainDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblFlowBindingSource3;
            this.dataGridView1.Location = new System.Drawing.Point(147, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // tblFlowBindingSource3
            // 
            this.tblFlowBindingSource3.DataSource = typeof(BXDB.tblFlow);
            // 
            // flidDataGridViewTextBoxColumn
            // 
            this.flidDataGridViewTextBoxColumn.DataPropertyName = "fl_id";
            this.flidDataGridViewTextBoxColumn.HeaderText = "fl_id";
            this.flidDataGridViewTextBoxColumn.Name = "flidDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "it_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "it_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // flparentDataGridViewTextBoxColumn
            // 
            this.flparentDataGridViewTextBoxColumn.DataPropertyName = "fl_parent";
            this.flparentDataGridViewTextBoxColumn.HeaderText = "fl_parent";
            this.flparentDataGridViewTextBoxColumn.Name = "flparentDataGridViewTextBoxColumn";
            // 
            // mtidDataGridViewTextBoxColumn
            // 
            this.mtidDataGridViewTextBoxColumn.DataPropertyName = "mt_id";
            this.mtidDataGridViewTextBoxColumn.HeaderText = "mt_id";
            this.mtidDataGridViewTextBoxColumn.Name = "mtidDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "rp_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "rp_id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // rcidDataGridViewTextBoxColumn
            // 
            this.rcidDataGridViewTextBoxColumn.DataPropertyName = "rc_id";
            this.rcidDataGridViewTextBoxColumn.HeaderText = "rc_id";
            this.rcidDataGridViewTextBoxColumn.Name = "rcidDataGridViewTextBoxColumn";
            // 
            // flstatusDataGridViewTextBoxColumn
            // 
            this.flstatusDataGridViewTextBoxColumn.DataPropertyName = "fl_status";
            this.flstatusDataGridViewTextBoxColumn.HeaderText = "fl_status";
            this.flstatusDataGridViewTextBoxColumn.Name = "flstatusDataGridViewTextBoxColumn";
            // 
            // tblFlow1DataGridViewTextBoxColumn
            // 
            this.tblFlow1DataGridViewTextBoxColumn.DataPropertyName = "tblFlow1";
            this.tblFlow1DataGridViewTextBoxColumn.HeaderText = "tblFlow1";
            this.tblFlow1DataGridViewTextBoxColumn.Name = "tblFlow1DataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "tblIntroducer";
            this.dataGridViewTextBoxColumn3.HeaderText = "tblIntroducer";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // tblReceiveDataGridViewTextBoxColumn
            // 
            this.tblReceiveDataGridViewTextBoxColumn.DataPropertyName = "tblReceive";
            this.tblReceiveDataGridViewTextBoxColumn.HeaderText = "tblReceive";
            this.tblReceiveDataGridViewTextBoxColumn.Name = "tblReceiveDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "tblReply";
            this.dataGridViewTextBoxColumn4.HeaderText = "tblReply";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // tblMaintainDataGridViewTextBoxColumn
            // 
            this.tblMaintainDataGridViewTextBoxColumn.DataPropertyName = "tblMaintain";
            this.tblMaintainDataGridViewTextBoxColumn.HeaderText = "tblMaintain";
            this.tblMaintainDataGridViewTextBoxColumn.Name = "tblMaintainDataGridViewTextBoxColumn";
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
            ((System.ComponentModel.ISupportInitialize)(this.tblFlowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaintainBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblFlowBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFlowBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFlowBindingSource3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn itidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rpidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtstatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtparentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtmarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblIntroducerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblMaintain1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblReplyDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource tblMaintainBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.BindingSource tblFlowBindingSource;
        private System.Windows.Forms.BindingSource tblFlowBindingSource1;
        private System.Windows.Forms.BindingSource tblFlowBindingSource2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn flidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn flparentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn rcidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flstatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblFlow1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblReceiveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblMaintainDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource tblFlowBindingSource3;
    }
}