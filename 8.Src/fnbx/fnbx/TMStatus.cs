
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;


namespace fnbx
{

    public class TextAttribute : Attribute
    {
        public TextAttribute(string text)
        {
            this._text = text;
        }

        #region Text
        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get
            {
                if (_text == null)
                {
                    _text = string.Empty;
                }
                return _text;
            }
            set
            {
                _text = value;
            }
        } private string _text;
        #endregion //Text
    }

    public enum MTStatus
    {
        /// <summary>
        /// 
        /// </summary>
        [Text("�½�")]
        Created = 10,

        /// <summary>
        /// 
        /// </summary>
        [Text("�ѽ���")]
        Received = 20,

        //Stoped = 30,
        /// <summary>
        /// 
        /// </summary>
        [Text("�����")]
        Completed = 40,

        /// <summary>
        /// 
        /// </summary>
        [Text("�ѹر�")]
        Closed = 50,

        /// <summary>
        /// 
        /// </summary>
        [Text("�ѳ�ʱ")]
        Timeouted = 60,
    }

}
