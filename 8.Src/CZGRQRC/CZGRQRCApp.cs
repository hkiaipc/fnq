using System;
using Xdgk.Common;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CZGRQRC
{

    /// <summary>
    /// 
    /// </summary>
    public class CZGRQRCApp
    {
        /// <summary>
        /// 
        /// </summary>
        static public CZGRQRCApp Default
        {
            get
            {
                if (s_default == null)
                {
                    Init();
                }
                return s_default;
            }
        } static private CZGRQRCApp s_default;

        /// <summary>
        /// 
        /// </summary>
        static private void Init()
        {
            s_default = new CZGRQRCApp();
        }

        /// <summary>
        /// 
        /// </summary>
        public CZGRQRCApp()
        {
            _dbi = new CZGRWEBDBI.DBI(GetConnectionString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static private string GetConnectionString()
        {
            // TODO: GetConnectionString
            //
            //return "Data Source=.;Initial Catalog=czgrdb;User ID=sa;Pwd=sa";
            XmlDocument doc = new XmlDocument();
            doc.Load("configs\\dbconfig.xml");
            XmlNodeList nodelist = doc.SelectNodes("/activerecord/config/add");
            foreach (XmlNode node in nodelist)
            {
                if (node.Name == "add")
                {
                    if (node.Attributes["key"].Value == "connection.connection_string")
                    {
                        return node.Attributes["value"].Value;
                    }
                }
            }
            throw new Exception("not find 'connection.connection_string' config item");
        }

        /// <summary>
        /// 
        /// </summary>
        public CZGRWEBDBI.DBI DBI
        {
            get { return _dbi; }
        } private CZGRWEBDBI.DBI _dbi;

        /// <summary>
        /// 
        /// </summary>
        public AlarmDefineCollection AlarmDefineCollection
        {
            get
            {
                return Config.Default.AlarmDefineCollection;
            }
        } 
        ///// <summary>
        ///// 
        ///// </summary>
        //public ComparatorCollection ComparatorCollection
        //{
        //    get
        //    {
        //        if (_comparatorCollection == null)
        //        {
        //            _comparatorCollection = new ComparatorCollection();
        //            foreach (CompareValues cv in Config.Default.CompareValuesCollection)
        //            {
        //                Comparator c = CreateComparator(cv);
        //                _comparatorCollection.Add(c);
        //            }
        //        }
        //        return _comparatorCollection;
        //    }
        //} private ComparatorCollection _comparatorCollection;

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="cv"></param>
        ///// <returns></returns>
        //private Comparator CreateComparator(CompareValues cv)
        //{
        //    if (cv is RangeValues)
        //    {
        //        RangeValues rv = cv as RangeValues;
        //        return new RangeComparator(rv);
        //    }
        //    throw new NotImplementedException("cannot create comparator by " + cv.GetType().Name);
        //}


        /// <summary>
        /// 
        /// </summary>
        public Renderer Renderer
        {
            get
            {
                if (_renderer == null)
                {
                    _renderer = CreateRenderer();
                }
                return _renderer;
            }
        }private Renderer _renderer;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Renderer CreateRenderer()
        {
            RendererType rt = Config.Default.RendererType;
            if (rt == RendererType.Fore)
                return new ForeColorRenderer();
            if (rt == RendererType.Back)
                return new BackColorRenderer();
            throw new NotImplementedException("cannot create renderer by " + rt);
        }


        /// <summary>
        /// 
        /// </summary>
        public UC.UCAlarm UCAlarm
        {
            get
            {
                return this.frmMain.UCAlarm;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public frmMain frmMain
        {
            get { return _frmMain; }
            set { _frmMain = value; }
        } private frmMain _frmMain;

        /// <summary>
        /// 
        /// </summary>
        public ZGStationList ZGStationList
        {
            get
            {
                if (_zgstationlist == null)
                {
                    _zgstationlist = new ZGStationList();
                }
                return _zgstationlist;
            }
        } private ZGStationList _zgstationlist;

    }

    /// <summary>
    /// 
    /// </summary>
    public class ZGStationList
    {
        private List<string> _zgStationList = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        public ZGStationList()
        {
            string filename = "configs/zgstation.txt";
            string[] allines = File.ReadAllLines(filename);
            foreach (string l in allines)
            {
                if (l.Trim().Length > 0)
                {
                    _zgStationList.Add(l.Trim());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Include(string name)
        {
            foreach (string s in _zgStationList)
            {
                if (StringHelper.Equal(name, s))
                {
                    return true;
                }
            }
            return false; 
        }
    }
}
