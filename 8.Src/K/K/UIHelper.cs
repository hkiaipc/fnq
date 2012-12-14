using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K.UC;
using System.Windows.Forms;

namespace K
{
    internal class UIHelper
    {
        internal UCGroupResults Create(GroupResultCollection gpResults)
        {
            UCGroupResults r = new UCGroupResults();

            foreach (GroupResult gr in gpResults)
            {
                UCPersonResults ucPrs = Create(gr);
                TabPage page = new TabPage("name");
                page.Controls.Add(ucPrs);
                r.TabC.TabPages.Add(page);
            }
            return r;
        }

        private UCPersonResults Create(GroupResult gr)
        {
            UCPersonResults r = new UCPersonResults();
            foreach ( PersonResult pr in gr.PersonResults )
            {
                TabPage page = new TabPage("p -name");
                page.Controls.Add(
                    new UCPersonResult(
                        new ResultDataTableConverter().ToPersonResultDataTable(
                            pr)
                            )
                            );
                r.TabC.TabPages.Add(page);
            }

            return r;
        }
    }
}
