using System;
using System.Configuration;

namespace K
{
    public class Config
    {
        #region Default
        /// <summary>
        /// 
        /// </summary>
        static public Config Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new Config();
                    Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _default.NormalStartWorkTimeSpan = TimeSpan.Parse(cfg.AppSettings.Settings["normalstart"].Value);
                    _default.NormalStopWorkTimeSpan = TimeSpan.Parse(cfg.AppSettings.Settings["normalstop"].Value);
                    _default.LaterEarlyTimeSpan = TimeSpan.Parse(cfg.AppSettings.Settings["laterearly"].Value);
                }
                return _default;
            }
        } static private Config _default;
        #endregion //Default

        #region NormalStartWorkTimeSpan
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan NormalStartWorkTimeSpan
        {
            get
            {
                return _normalStartWorkTimeSpan;
            }
            set
            {
                if (CheckTimeSpan(value))
                {
                    _normalStartWorkTimeSpan = value;
                }
            }
        } private TimeSpan _normalStartWorkTimeSpan = TimeSpan.FromHours(2d);
        #endregion //NormalStartWorkTimeSpan

        #region CheckTimeSpan
        /// <summary>
        /// 5 minute ~ 8 hour
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static private bool CheckTimeSpan(TimeSpan value)
        {
            return value >= TimeSpan.FromMinutes(5d) && value <= TimeSpan.FromHours(8d);
        }
        #endregion //CheckTimeSpan

        #region NormalStopWorkTimeSpan
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan NormalStopWorkTimeSpan
        {
            get
            {
                return _normalStopWorkTimeSpan;
            }
            set
            {
                if (CheckTimeSpan(value))
                {
                    _normalStopWorkTimeSpan = value;
                }
            }
        } private TimeSpan _normalStopWorkTimeSpan = TimeSpan.FromHours(2d);
        #endregion //NormalStopWorkTimeSpan

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
                if (CheckTimeSpan(value))
                {
                    _laterEarlyTimeSpan = value;
                }
            }
        } private TimeSpan _laterEarlyTimeSpan = TimeSpan.FromHours(2d);
        #endregion //LaterEarlyTimeSpan

        #region Save
        /// <summary>
        /// 
        /// </summary>
        internal void Save()
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            cfg.AppSettings.Settings["normalstart"].Value = NormalStartWorkTimeSpan.ToString();
            cfg.AppSettings.Settings["normalstop"].Value = NormalStopWorkTimeSpan.ToString();

            cfg.AppSettings.Settings["laterearly"].Value = LaterEarlyTimeSpan.ToString();
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        #endregion //Save
    }
}
