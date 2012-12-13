
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
    internal class PersonResult
    {
#region TblPerson
        /// <summary>
        /// 
        /// </summary>
        public tblPerson TblPerson
        {
            get
            {
                return _tblPerson;
            }
            set
            {
                _tblPerson = value;
            }
        } private tblPerson _tblPerson;
#endregion //TblPerson

#region TimeResults
        /// <summary>
        /// 
        /// </summary>
        public TimeResultCollection TimeResults
        {
            get
            {
                //if (_timeResults == null)
                //{
                //    _timeResults = new TimeResultCollection();
                //}
                return _timeResults;
            }
            set
            {
                _timeResults = value;
            }
        } private TimeResultCollection _timeResults;
#endregion //TimeResults

    }

}
