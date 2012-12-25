using System;
using K.Forms;
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
        public UCPersonResult(DataTable tbl, TimeSpan sumOfWorkTimeSpan)
        {
            InitializeComponent();
            this.dataGridView1.DataSource = tbl;

            this.label1.Text = string.Format("累计工作时长: {0}", sumOfWorkTimeSpan);
        }
        public UCPersonResult()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataRowView vrow = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView ;
                DataRow row = vrow.Row;// as DataRow;

                string personName = row[ResultDataTableColumnNames.PersonName].ToString();
                string sb = row[ResultDataTableColumnNames.StandardBegin].ToString();

                DateTime b = DateTime.Parse(sb);

                b = new DateTime(b.Year, b.Month, 1);
                DateTime end = DateTimeHelper.NextMonth(b);

                frmTMDataQuery f = new frmTMDataQuery(personName, b, end);
                f.ShowDialog();
            }
        }

    }
}
