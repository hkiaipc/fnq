namespace fnbx
{
    partial class frmFlowList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFlowList));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.tblFlowBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.新建NToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbFind = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFlowBindingSource3)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(694, 409);
            this.dataGridView1.TabIndex = 2;
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
            // tblFlowBindingSource3
            // 
            this.tblFlowBindingSource3.DataSource = typeof(BXDB.tblFlow);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripButton,
            this.tsbView,
            this.tsbDelete,
            this.tsbFind});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(694, 36);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 新建NToolStripButton
            // 
            this.新建NToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("新建NToolStripButton.Image")));
            this.新建NToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建NToolStripButton.Name = "新建NToolStripButton";
            this.新建NToolStripButton.Size = new System.Drawing.Size(50, 33);
            this.新建NToolStripButton.Text = "新建(&N)";
            this.新建NToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.新建NToolStripButton.Click += new System.EventHandler(this.新建NToolStripButton_Click);
            // 
            // tsbView
            // 
            this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
            this.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(33, 33);
            this.tsbView.Text = "View";
            this.tsbView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbView.Click += new System.EventHandler(this.tsbView_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(42, 33);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbFind
            // 
            this.tsbFind.Image = ((System.Drawing.Image)(resources.GetObject("tsbFind.Image")));
            this.tsbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFind.Name = "tsbFind";
            this.tsbFind.Size = new System.Drawing.Size(31, 33);
            this.tsbFind.Text = "Find";
            this.tsbFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFind.Click += new System.EventHandler(this.tsbFind_Click);
            // 
            // frmFlowList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 445);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmFlowList";
            this.Text = "frmMTList";
            this.Load += new System.EventHandler(this.frmMTList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFlowBindingSource3)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn itidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rpidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtstatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtparentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtmarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblIntroducerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblMaintain1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblReplyDataGridViewTextBoxColumn;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 新建NToolStripButton;
        private System.Windows.Forms.ToolStripButton tsbView;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbFind;
    }
}