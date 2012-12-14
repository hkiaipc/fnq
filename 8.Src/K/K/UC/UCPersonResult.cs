using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.UC
{
    public partial class UCPersonResult : UserControl
    {
        public UCPersonResult(DataTable tbl)
        {
            InitializeComponent();
            this.dataGridView1.DataSource = tbl;
        }
        public UCPersonResult()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
