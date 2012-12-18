using System;
using System.Windows.Forms;
using K.Forms;
using K.Forms.TM;
using K.Forms.WD;

namespace K
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formType"></param>
        /// <returns></returns>
        private Form ActivateMdiForm(Type formType)
        {
            Form r = null;
            foreach ( Form item in this.MdiChildren )
            {
                if (item.GetType() == formType)
                {
                    r = item;
                    break;
                }
            }

            if (r == null)
            {
                r = (Form)Activator.CreateInstance(formType);
                r.MdiParent = this;
            }

            r.Show();
            r.Activate();
            return r;
        }

        private void mnuGroup_Click(object sender, EventArgs e)
        {
            ActivateMdiForm(typeof(frmGroup));
        }

        private void mnuPerson_Click(object sender, EventArgs e)
        {
            ActivateMdiForm(typeof(frmPerson));
        }

        private void mnuTM_Click(object sender, EventArgs e)
        {
            ActivateMdiForm(typeof(frmTM));
        }

        private void mnuWorkDefine_Click(object sender, EventArgs e)
        {
            ActivateMdiForm(typeof(frmWorkDefine));
        }

        private void mnuKResult_Click(object sender, EventArgs e)
        {
            ActivateMdiForm(typeof(frmKResultGenerate));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            Forms.frmConfig f = new frmConfig();
            f.ShowDialog();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            string msg = string.Format("考勤系统\r\n\r\nv{0}", Application.ProductVersion);
            NUnit.UiKit.UserMessage.DisplayInfo(msg);
        }

        private void mnuQuery_Click(object sender, EventArgs e)
        {
            ActivateMdiForm(typeof(frmTMDataQuery));
        }
    }
}
