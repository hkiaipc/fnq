﻿namespace K.Forms
{
    partial class frmGroupItem
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnDeletePerson = new System.Windows.Forms.Button();
            this.lvPerson = new System.Windows.Forms.ListView();
            this.cmbWorkDefine = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lvStation = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeleteStation = new System.Windows.Forms.Button();
            this.btnAddStation = new System.Windows.Forms.Button();
            this.chkSpecialStation = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(124, 454);
            this.okButton.TabIndex = 13;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(202, 454);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "名称:";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(124, 6);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(150, 21);
            this.txtGroupName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "人员:";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(280, 59);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(75, 23);
            this.btnAddPerson.TabIndex = 6;
            this.btnAddPerson.Text = "添加";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnDeletePerson
            // 
            this.btnDeletePerson.Location = new System.Drawing.Point(280, 88);
            this.btnDeletePerson.Name = "btnDeletePerson";
            this.btnDeletePerson.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePerson.TabIndex = 7;
            this.btnDeletePerson.Text = "删除";
            this.btnDeletePerson.UseVisualStyleBackColor = true;
            this.btnDeletePerson.Click += new System.EventHandler(this.btnDeletePerson_Click);
            // 
            // lvPerson
            // 
            this.lvPerson.CheckBoxes = true;
            this.lvPerson.Location = new System.Drawing.Point(124, 59);
            this.lvPerson.Name = "lvPerson";
            this.lvPerson.Size = new System.Drawing.Size(150, 160);
            this.lvPerson.TabIndex = 5;
            this.lvPerson.UseCompatibleStateImageBehavior = false;
            this.lvPerson.View = System.Windows.Forms.View.List;
            // 
            // cmbWorkDefine
            // 
            this.cmbWorkDefine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkDefine.FormattingEnabled = true;
            this.cmbWorkDefine.Location = new System.Drawing.Point(124, 33);
            this.cmbWorkDefine.Name = "cmbWorkDefine";
            this.cmbWorkDefine.Size = new System.Drawing.Size(150, 20);
            this.cmbWorkDefine.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "班次:";
            // 
            // lvStation
            // 
            this.lvStation.CheckBoxes = true;
            this.lvStation.Enabled = false;
            this.lvStation.Location = new System.Drawing.Point(124, 261);
            this.lvStation.Name = "lvStation";
            this.lvStation.Size = new System.Drawing.Size(150, 187);
            this.lvStation.TabIndex = 10;
            this.lvStation.UseCompatibleStateImageBehavior = false;
            this.lvStation.View = System.Windows.Forms.View.List;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "站点:";
            // 
            // btnDeleteStation
            // 
            this.btnDeleteStation.Enabled = false;
            this.btnDeleteStation.Location = new System.Drawing.Point(280, 290);
            this.btnDeleteStation.Name = "btnDeleteStation";
            this.btnDeleteStation.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteStation.TabIndex = 12;
            this.btnDeleteStation.Text = "删除";
            this.btnDeleteStation.UseVisualStyleBackColor = true;
            this.btnDeleteStation.Click += new System.EventHandler(this.btnDeleteStation_Click);
            // 
            // btnAddStation
            // 
            this.btnAddStation.Enabled = false;
            this.btnAddStation.Location = new System.Drawing.Point(280, 261);
            this.btnAddStation.Name = "btnAddStation";
            this.btnAddStation.Size = new System.Drawing.Size(75, 23);
            this.btnAddStation.TabIndex = 11;
            this.btnAddStation.Text = "添加";
            this.btnAddStation.UseVisualStyleBackColor = true;
            this.btnAddStation.Click += new System.EventHandler(this.btnAddStation_Click);
            // 
            // chkSpecialStation
            // 
            this.chkSpecialStation.AutoSize = true;
            this.chkSpecialStation.Location = new System.Drawing.Point(124, 239);
            this.chkSpecialStation.Name = "chkSpecialStation";
            this.chkSpecialStation.Size = new System.Drawing.Size(72, 16);
            this.chkSpecialStation.TabIndex = 8;
            this.chkSpecialStation.Text = "指定站点";
            this.chkSpecialStation.UseVisualStyleBackColor = true;
            this.chkSpecialStation.CheckedChanged += new System.EventHandler(this.chkSpecialStation_CheckedChanged);
            // 
            // frmGroupItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 486);
            this.Controls.Add(this.chkSpecialStation);
            this.Controls.Add(this.btnDeleteStation);
            this.Controls.Add(this.btnAddStation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvStation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbWorkDefine);
            this.Controls.Add(this.lvPerson);
            this.Controls.Add(this.btnDeletePerson);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtGroupName);
            this.Name = "frmGroupItem";
            this.Text = "部门";
            this.Load += new System.EventHandler(this.frmGroupItem_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.txtGroupName, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnAddPerson, 0);
            this.Controls.SetChildIndex(this.btnDeletePerson, 0);
            this.Controls.SetChildIndex(this.lvPerson, 0);
            this.Controls.SetChildIndex(this.cmbWorkDefine, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lvStation, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnAddStation, 0);
            this.Controls.SetChildIndex(this.btnDeleteStation, 0);
            this.Controls.SetChildIndex(this.chkSpecialStation, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnDeletePerson;
        private System.Windows.Forms.ListView lvPerson;
        private System.Windows.Forms.ComboBox cmbWorkDefine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvStation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeleteStation;
        private System.Windows.Forms.Button btnAddStation;
        private System.Windows.Forms.CheckBox chkSpecialStation;
    }
}