namespace CZGRQRC
{
    partial class frmContrastCurveSelect
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstCurveName = new System.Windows.Forms.ListBox();
            this.txtCurveInfo = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(104, 215);
            this.okButton.TabIndex = 5;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(182, 215);
            this.cancelButton.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(260, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(260, 70);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstCurveName
            // 
            this.lstCurveName.FormattingEnabled = true;
            this.lstCurveName.ItemHeight = 12;
            this.lstCurveName.Location = new System.Drawing.Point(12, 12);
            this.lstCurveName.Name = "lstCurveName";
            this.lstCurveName.Size = new System.Drawing.Size(242, 76);
            this.lstCurveName.TabIndex = 0;
            this.lstCurveName.SelectedIndexChanged += new System.EventHandler(this.lstCurveName_SelectedIndexChanged);
            // 
            // txtCurveInfo
            // 
            this.txtCurveInfo.BackColor = System.Drawing.Color.White;
            this.txtCurveInfo.Location = new System.Drawing.Point(12, 94);
            this.txtCurveInfo.Multiline = true;
            this.txtCurveInfo.Name = "txtCurveInfo";
            this.txtCurveInfo.ReadOnly = true;
            this.txtCurveInfo.Size = new System.Drawing.Size(242, 115);
            this.txtCurveInfo.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(260, 41);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmContrastCurveSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 249);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtCurveInfo);
            this.Controls.Add(this.lstCurveName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmContrastCurveSelect";
            this.Text = "对比曲线选择";
            this.Load += new System.EventHandler(this.frmContrastCurveSelect_Load);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.lstCurveName, 0);
            this.Controls.SetChildIndex(this.txtCurveInfo, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lstCurveName;
        private System.Windows.Forms.TextBox txtCurveInfo;
        private System.Windows.Forms.Button btnEdit;
    }
}