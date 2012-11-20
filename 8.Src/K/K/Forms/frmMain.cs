using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using K.Forms;
using K.Forms.TM;

namespace K
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuGroup_Click(object sender, EventArgs e)
        {
            Forms.frmGroup f = new K.Forms.frmGroup();
            f.ShowDialog();
        }

        private void mnuPerson_Click(object sender, EventArgs e)
        {
            frmPerson f = new frmPerson();
            f.ShowDialog();
        }

        private void mnuTM_Click(object sender, EventArgs e)
        {
            frmTM f = new frmTM();
            f.ShowDialog();
        }
    }
}
