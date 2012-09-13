using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BXDB;

namespace fnbx
{
    public partial class frmFlow : Form
    {
        public frmFlow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFlow_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public tblFlow FL
        {
            get { return _fl; }
            set
            {
                if (_fl != value)
                {
                    _fl = value;
                    if (_fl != null)
                    {
                        UpdateView();
                    }
                }
            }
        } private tblFlow _fl;

        /// <summary>
        /// 
        /// </summary>
        private void UpdateView()
        {
            ucIt1.It = _fl.tblIntroducer;
            ucMt1.Maintain = _fl.tblMaintain;
            ucRc1.Rc = _fl.tblReceive;
            ucRp1.Reply = _fl.tblReply;

        }
    }
}
