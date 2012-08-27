using System;
using System.Collections.Generic;
using System.Text;

namespace CZGRWEBDBI
{
    public class DBInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int Version
        {
            get { return _version; }
            set { _version = value; }
        } private int _version;

        /// <summary>
        /// 
        /// </summary>
        public string Project
        {
            get { return _project; }
            set { _project = value; }
        } private string _project;

        /// <summary>
        /// 
        /// </summary>
        public DateTime DT
        {
            get { return _dt; }
            set { _dt = value; }
        } private DateTime _dt;
    }
}
