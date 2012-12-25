using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K.UC;
using System.Windows.Forms;

namespace K
{
    internal class UIHelper
    {
        static internal UCGroupResults Create(GroupResultCollection gpResults)
        {
            UCGroupResults r = new UCGroupResults();

            foreach (GroupResult gr in gpResults)
            {
                UCPersonResults ucPrs = Create(gr);
                ucPrs.Dock = DockStyle.Fill;

                string gpName = gr.TblGroup.GroupName;
                TabPage page = new TabPage(gpName);

                page.Controls.Add(ucPrs);

                r.TabC.TabPages.Add(page);
            }
            return r;
        }

        static private UCPersonResults Create(GroupResult gr)
        {
            UCPersonResults r = new UCPersonResults();
            foreach ( PersonResult pr in gr.PersonResults )
            {
                DataTable tbl = ResultDataTableConverter.ToPersonResultDataTable(pr);
                TimeSpan ts = pr.CalcSumOfWorkTimeSpan();
                UCPersonResult ucPr = new UCPersonResult(tbl, ts);
                ucPr.Dock = DockStyle.Fill;

                string personName = pr.TblPerson.PersonName;

                TabPage page = new TabPage(personName);
                page.Controls.Add(ucPr);

                r.TabC.TabPages.Add(page);
            }

            return r;
        }
    }
}
