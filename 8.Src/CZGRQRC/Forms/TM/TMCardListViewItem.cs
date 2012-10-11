using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
//using CZGRDBI;
using CZGRWEBDBI;

namespace FNGRQRC
{
    internal class TMCardListViewItem : ListViewItem 
    {
        private int _fieldCount = 3;
        private int CARDSNIDX = 0;
        private int PERSONIDX = 1;
        private int REMARKIDX = 2;

        /// <summary>
        /// 
        /// </summary>
        internal DBCard DBCard
        {
            get { return _dbcard; }
        } private DBCard _dbcard;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        internal TMCardListViewItem(DBCard card)
        {
            string[] items = GetEmptyItems();
            this.SubItems.AddRange(items);
            this._dbcard = card;
            Update(_dbcard);
        }

        internal void Update(DBCard card)
        {
            this.CardSN = card.SN;
            this.Person = card.Person;
            this.Remark = card.Remark;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string[] GetEmptyItems()
        {
            int n = this._fieldCount;
            string[] items = new string[n];
            for (int i = 0; i < n; i++)
            {
                items[i] = string.Empty;
            }
            return items;
        }

        /// <summary>
        /// 
        /// </summary>
        public string CardSN
        {
            get { return this.SubItems[CARDSNIDX].Text; }
            set { this.SubItems[CARDSNIDX].Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Person
        {
            get { return this.SubItems[PERSONIDX].Text; }
            set { this.SubItems[PERSONIDX].Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get { return this.SubItems[REMARKIDX].Text; }
            set { this.SubItems[REMARKIDX].Text = value; }
        }
    }
}
