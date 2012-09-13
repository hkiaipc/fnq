
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

    public enum FLStatus
    {

        /// <summary>
        /// 
        /// </summary>
        [Text("新建")]
        New = 0,


        /// <summary>
        /// 
        /// </summary>
        [Text("已创建")]
        Created = 10,

        /// <summary>
        /// 
        /// </summary>
        [Text("已接收")]
        Received = 20,

        //Stoped = 30,
        /// <summary>
        /// 
        /// </summary>
        [Text("已完成")]
        Completed = 40,

        /// <summary>
        /// 
        /// </summary>
        [Text("已关闭")]
        Closed = 50,

        /// <summary>
        /// 
        /// </summary>
        [Text("已超时")]
        Timeouted = 60,
    }

}
