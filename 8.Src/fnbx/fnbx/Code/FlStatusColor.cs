using System;
using System.Xml;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fnbx
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Serializable]
    public class FlStatusColor
    {
        public FlStatusColor ()
        {
        }

        public FlStatusColor(FLStatus status, Color color)
        {
            this.Status = status;
            this.Color = color;
        }

        #region Status
        /// <summary>
        /// 
        /// </summary>
        public FLStatus  Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        } private FLStatus _status;
        #endregion //Status

        #region Color
        /// <summary>
        /// 
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        } private Color _color;
        #endregion //Color

        /// <summary>
        /// 
        /// </summary>
        [System.Xml.Serialization.XmlElement ("Color")]
        public int ColorValue
        {
            get { return _color.ToArgb(); }
            set { _color = Color.FromArgb(value); }
        } 


    }

    [Serializable]
    public class FlStatusColorCollection : Xdgk.Common.Collection<FlStatusColor>
    {
        public Color GetColor(FLStatus status)
        {
            FlStatusColor r = null;
            foreach (FlStatusColor item in this)
            {
                if (item.Status == status)
                {
                    r = item;
                    break;
                }
            }

            if (r != null)
            {
                return r.Color;
            }
            else
            {
                return Color.Yellow;
            }
        }
    }
}
