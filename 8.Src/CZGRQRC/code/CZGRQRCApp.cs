using System;
using Xdgk.Common;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class CZGRQRCApp
    {
        #region Default
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
        #endregion //Default

        #region Init
        /// <summary>
        /// 
        /// </summary>
        static private void Init()
        {
            s_default = new CZGRQRCApp();
        }
        #endregion //Init

        #region CZGRQRCApp
        /// <summary>
        /// 
        /// </summary>
        public CZGRQRCApp()
        {
            _dbi = new CZGRWEBDBI.DBI(GetConnectionString());
        }
        #endregion //CZGRQRCApp

        #region GetConnectionString
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
        #endregion //GetConnectionString

        #region DBI
        /// <summary>
        /// 
        /// </summary>
        public CZGRWEBDBI.DBI DBI
        {
            get { return _dbi; }
        } private CZGRWEBDBI.DBI _dbi;
        #endregion //DBI

        #region AlarmDefineCollection
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
        #endregion //AlarmDefineCollection

        #region Renderer
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
        #endregion //Renderer

        #region CreateRenderer
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
        #endregion //CreateRenderer

        #region UCAlarm
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
        #endregion //UCAlarm

        #region frmMain
        /// <summary>
        /// 
        /// </summary>
        public frmMain frmMain
        {
            get { return _frmMain; }
            set { _frmMain = value; }
        } private frmMain _frmMain;
        #endregion //frmMain

        #region ZGStationList
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
        #endregion //ZGStationList

        #region LoginedUser
        /// <summary>
        /// 
        /// </summary>
        public User LoginedUser
        {
            get
            {
                return _loginedUser;
            }
            set
            {
                _loginedUser = value;
            }
        } private User _loginedUser;
        #endregion //LoginedUser

    }

    #region ZGStationList
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
    #endregion //ZGStationList
}
