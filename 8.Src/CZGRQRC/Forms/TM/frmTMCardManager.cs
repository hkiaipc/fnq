using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using CZGRDBI;
using CZGRWEBDBI;

namespace CZGRQRC
{
    //public partial class frmTMCardManager : NUnit.UiKit.SettingsDialogBase
    public partial class frmTMCardManager : Form 
    {
        //private IList _dbcards;
        private DBCard[] _dbcards;
        /// <summary>
        /// 
        /// </summary>
        public frmTMCardManager()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTMCardManager_Load(object sender, EventArgs e)
        {
            FillListView();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillListView()
        {
            // TODO:
            //
            //_dbcards = DBCard.GetAll();
            _dbcards = CZGRQRCApp.Default.DBI.ExecuteTmDBCard();
            foreach (DBCard item in _dbcards)
            {
                TMCardListViewItem lvi = new TMCardListViewItem(item);
                lvi.Tag = item;
                this.tmCardListView1.Items.Add(lvi);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTMCardItem f = new frmTMCardItem(_dbcards);
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                DBCard card = f.DBCard;
                TMCardListViewItem lvi = new TMCardListViewItem(card);
                lvi.Tag = f.DBCard;
                this.tmCardListView1.Items.Add(lvi);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            TMCardListViewItem lvi = GetSelectedTMCardLvi();
            if (lvi != null)
            {
                DBCard card = lvi.DBCard;
                frmTMCardItem f = new frmTMCardItem(_dbcards, card);
                DialogResult dr = f.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    lvi.Update(card);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            TMCardListViewItem lvi = GetSelectedTMCardLvi();
            if (lvi != null)
            {
                string s = string.Format("确定要删除 '{0}' 吗？", lvi.CardSN); 
                DialogResult dr = NUnit.UiKit.UserMessage.Ask(s);
                if (dr == DialogResult.Yes)
                {
                    DBCard card = lvi.DBCard;
                    // TODO:
                    //
                    //card.Delete();
                    CZGRQRCApp.Default.DBI.DeleteTmCard(card.CardID);
                    this.tmCardListView1.Items.Remove(lvi);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private TMCardListViewItem GetSelectedTMCardLvi()
        {
            if (this.tmCardListView1.SelectedItems.Count > 0)
            {
                return tmCardListView1.SelectedItems[0] as TMCardListViewItem;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
