using System;
using System.Collections.Generic;
using System.Text;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name

        #region Password
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get
            {
                if (_password == null)
                {
                    _password = string.Empty;
                }
                return _password;
            }
            set
            {
                _password = value;
            }
        } private string _password;
        #endregion //Password
        #region RightEnum
        /// <summary>
        /// 
        /// </summary>
        public RightEnum RightEnum
        {
            get
            {
                if (_rightEnum == null)
                {
                    _rightEnum = new RightEnum();
                }
                return _rightEnum;
            }
            set
            {
                _rightEnum = value;
            }
        } private RightEnum _rightEnum = RightEnum.User;
        #endregion //RightEnum

    }

    /// <summary>
    /// 
    /// </summary>
    public enum RightEnum
    {
        /// <summary>
        /// 
        /// </summary>
        User = 0,
        Admin = 1,
    }
}
