using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace fnbx
{
    public partial class frmColumnSelect : NUnit.UiKit.SettingsDialogBase 
    {
        public frmColumnSelect()
        {
            InitializeComponent();
        }

        private void frmColumnSelect_Load(object sender, EventArgs e)
        {
            DGVColumnConfigCollection s = DataGirdviewColumnProvider.GetFlowDgvColumnConfigs();
            foreach (DGVColumnConfig item in s)
            {
                ListViewItem lvi = new ListViewItem(item.Text);
                lvi.Tag = item ;
                lvi.Checked = IsVisible(item.DataPropertyName);
                this.listView1.Items.Add(lvi);
            }
        }

        private bool IsVisible(string text)
        {
            return App.Default.Config.DisplayFlowColumns.Contains(text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string[] GetSelectedColumns()
        {
            IList<string> r = new List<string>();
            foreach (ListViewItem item in this.listView1.Items)
            {
                if (item.Checked)
                {
                    DGVColumnConfig d = (DGVColumnConfig)item.Tag;
                    r.Add(d.DataPropertyName);
                }
            }
            return r.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            string[] s = GetSelectedColumns ();
            if (s.Length == 0 )
            {
                NUnit.UiKit.UserMessage.DisplayFailure ("not select");
                return ;
            }

            App.Default.Config.DisplayFlowColumns = s;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
