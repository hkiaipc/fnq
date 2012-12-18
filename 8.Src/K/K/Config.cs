using System;
using System.Configuration;

namespace K
{
    public class Config
    {
        static public Config Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new Config();
                    Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _default.NormalTimeSpan = TimeSpan.Parse(cfg.AppSettings.Settings["normal"].Value);
                    _default.LaterEarlyTimeSpan = TimeSpan.Parse(cfg.AppSettings.Settings["laterearly"].Value);
                }
                return _default;
            }
        } static private Config _default;

        #region NormalTimeSpan
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan NormalTimeSpan
        {
            get
            {
                return _normalTimeSpan;
            }
            set
            {
                _normalTimeSpan = value;
            }
        } private TimeSpan _normalTimeSpan = TimeSpan.FromHours(2d);
        #endregion //NormalTimeSpan

        #region LaterEarlyTimeSpan
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan LaterEarlyTimeSpan
        {
            get
            {
                return _laterEarlyTimeSpan;
            }
            set
            {
                _laterEarlyTimeSpan = value;
            }
        } private TimeSpan _laterEarlyTimeSpan = TimeSpan.FromHours(2d);
        #endregion //LaterEarlyTimeSpan

        internal void Save()
        {
            //  Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //  config.AppSettings.Settings.Remove(key);
            //  config.AppSettings.Settings.Add(key, value);
            //  config.Save(ConfigurationSaveMode.Modified);
            //  ConfigurationManager.RefreshSection("appSettings");  

            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfg.AppSettings.Settings["normal"].Value = NormalTimeSpan.ToString();
            cfg.AppSettings.Settings["laterearly"].Value = LaterEarlyTimeSpan.ToString();
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

}
