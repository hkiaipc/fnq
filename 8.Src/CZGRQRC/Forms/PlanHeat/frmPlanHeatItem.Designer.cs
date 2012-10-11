namespace FNGRQRC
{
    partial class frmPlanHeatItem
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
            this.lblMonth = new System.Windows.Forms.Label();
            this.numMonth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numPlanHeat = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlanHeat)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(50, 72);
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(128, 72);
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(6, 11);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(35, 12);
            this.lblMonth.TabIndex = 19;
            this.lblMonth.Text = "月份:";
            // 
            // numMonth
            // 
            this.numMonth.Location = new System.Drawing.Point(80, 9);
            this.numMonth.Name = "numMonth";
            this.numMonth.Size = new System.Drawing.Size(120, 21);
            this.numMonth.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "计划耗热量:";
            // 
            // numPlanHeat
            // 
            this.numPlanHeat.Location = new System.Drawing.Point(80, 36);
            this.numPlanHeat.Name = "numPlanHeat";
            this.numPlanHeat.Size = new System.Drawing.Size(120, 21);
            this.numPlanHeat.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "GJ";
            // 
            // frmPlanHeatItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 103);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numPlanHeat);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.numMonth);
            this.Name = "frmPlanHeatItem";
            this.Text = "月耗热量";
            this.Load += new System.EventHandler(this.frmPlanHeatItem_Load);
            this.Controls.SetChildIndex(this.numMonth, 0);
            this.Controls.SetChildIndex(this.lblMonth, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.numPlanHeat, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlanHeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.NumericUpDown numMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPlanHeat;
        private System.Windows.Forms.Label label1;
    }
}