﻿using System;
using KDB ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms
{
    public partial class frmPersonItem : NUnit.UiKit.SettingsDialogBase 
    {
        public frmPersonItem()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool IsAdd()
        {
            return this.TblPerson == null;
        }

        /// <summary>
        /// 
        /// </summary>
        public tblPerson TblPerson
        {
            get { return _tblPerson; }
            set { _tblPerson = value; }
        } private tblPerson _tblPerson;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (IsAdd())
            {
                Add();
            }
            else
            {
                Edit();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        tblTM GetSelectedTm(DB db)
        {
            if (this.txtTM.Text.Trim().Length == 0)
            {
                return null;
            }
            else
            {
                var r = from q in db.tblTM
                        where q.TmSN == this.txtTM.Text.Trim()
                        select q;
                tblTM tm = r.First();
                return tm;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Edit()
        {
            DB db = DBFactory.GetDB();

            var r = from q in db.tblPerson
                    where q.PersonID == this.TblPerson.PersonID
                    select q;

            tblPerson person = r.First();
            person.PersonName = this.txtPersonName.Text.Trim();
            person.tblTM = this.GetSelectedTm(db);

            db.SubmitChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        private void Add()
        {
            DB db = DBFactory.GetDB();

            tblPerson p = new tblPerson();
            p.PersonName = this.txtPersonName.Text;
            p.tblTM = GetSelectedTm(db);

            db.tblPerson.InsertOnSubmit(p);

            db.SubmitChanges();
        }

        private void frmPersonItem_Load(object sender, EventArgs e)
        {
            if (!IsAdd ())
            {
                this.txtPersonName.Text = this.TblPerson.PersonName;
                if (this.TblPerson.tblTM != null)
                {
                    this.txtTM.Text = this.TblPerson.tblTM.TmSN;
                }
            }
        }
    }
}