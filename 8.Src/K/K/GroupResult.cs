
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using KDB;
using Xdgk.Common;


namespace K
{
    internal class GroupResult
    {
#region TblGroup
        /// <summary>
        /// 
        /// </summary>
        public tblGroup TblGroup
        {
            get
            {
                if (_tblGroup == null)
                {
                    _tblGroup = new tblGroup();
                }
                return _tblGroup;
            }
            set
            {
                _tblGroup = value;
            }
        } private tblGroup _tblGroup;
#endregion //TblGroup

#region PersonResults
        /// <summary>
        /// 
        /// </summary>
        public PersonResultCollection PersonResults
        {
            get
            {
                if (_personResults == null)
                {
                    _personResults = new PersonResultCollection();
                }
                return _personResults;
            }
            set
            {
                _personResults = value;
            }
        } private PersonResultCollection _personResults;
#endregion //PersonResults
    }

}
