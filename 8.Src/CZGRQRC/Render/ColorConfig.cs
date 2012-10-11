using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using Xdgk.Common;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class ColorConfig
    {
        #region ColorConfig
        /// <summary>
        /// 
        /// </summary>
        public ColorConfig()
            : this(Color.Black, Color.Red)
        {
        }
        #endregion //ColorConfig

        #region ColorConfig
        /// <summary>
        /// 
        /// </summary>
        /// <param name="normalColor"></param>
        /// <param name="exceptionColor"></param>
        public ColorConfig(Color normalColor, Color exceptionColor)
            : this(normalColor, exceptionColor, exceptionColor, exceptionColor, exceptionColor, exceptionColor)
        {
        }
        #endregion //ColorConfig

        #region ColorConfig
        /// <summary>
        /// 
        /// </summary>
        /// <param name="normalColor"></param>
        /// <param name="lowColor"></param>
        /// <param name="lowLowColor"></param>
        /// <param name="highColor"></param>
        /// <param name="highHighColor"></param>
        public ColorConfig(Color normalColor, Color exceptionColor, Color lowColor, Color lowLowColor, Color highColor, Color highHighColor)
        {
            this.NormalColor = normalColor;
            this.ExceptionColor = exceptionColor;
            this.LowColor = lowColor;
            this.LowLowColor = lowLowColor;
            this.HighColor = highColor;
            this.HighHighColor = highHighColor;
        }
        #endregion //ColorConfig

        #region NormalColor
        /// <summary>
        /// 
        /// </summary>
        /// 
        [XmlIgnore]
        public Color NormalColor
        {
            //get { return _normalColor; }
            //set { _normalColor = value; }
            get { return _serializableNormalColor.ToColor(); }
            set { _serializableNormalColor = new SerializableColor(value); }
        } //private Color _normalColor;
        #endregion //NormalColor

        #region SerializableNormalColor
        /// <summary>
        /// 
        /// </summary>
        /// 
        [XmlElement("NormalColor")]
        public SerializableColor SerializableNormalColor
        {
            get { return _serializableNormalColor; }
            set { _serializableNormalColor = value; }
        } private SerializableColor _serializableNormalColor;
        #endregion //SerializableNormalColor

        #region ExceptionColor
        /// <summary>
        /// 
        /// </summary>
        /// 
        [XmlIgnore]
        public Color ExceptionColor
        {
            get { return _serializableExceptionColor.ToColor(); }
            set { _serializableExceptionColor = SerializableColor.FromColor(value); }
        } //private Color _exceptionColor;
        #endregion //ExceptionColor

        #region SerializableExceptionColor
        /// <summary>
        /// 
        /// </summary>
        /// 
        [XmlElement("ExceptionColor")]
        public SerializableColor SerializableExceptionColor
        {
            get { return _serializableExceptionColor; }
            set { _serializableExceptionColor = value; }
        } private SerializableColor _serializableExceptionColor;
        #endregion //SerializableExceptionColor

        #region SerializableLowColor
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("LowColor")]
        public SerializableColor SerializableLowColor
        {
            get { return _serializableLowColor; }
            set { _serializableLowColor = value; }
        } private SerializableColor _serializableLowColor;
        #endregion //SerializableLowColor

        #region SerializableLowLowColor
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("LowLowColor")]
        public SerializableColor SerializableLowLowColor
        {
            get { return _serializableLowLowColor; }
            set { _serializableLowLowColor = value; }
        } private SerializableColor _serializableLowLowColor;
        #endregion //SerializableLowLowColor

        #region SerializableHighColor
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("HighColor")]
        public SerializableColor SerializableHighColor
        {
            get { return _serializableHighColor; }
            set { _serializableHighColor = value; }
        } private SerializableColor _serializableHighColor;
        #endregion //SerializableHighColor

        #region SerializableHighHighColor
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("HighHighColor")]
        public SerializableColor SerializableHighHighColor
        {
            get { return _serializableHighHighColor; }
            set { _serializableHighHighColor = value; }
        } private SerializableColor _serializableHighHighColor;
        #endregion //SerializableHighHighColor

        #region LowColor
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public Color LowColor
        {
            get { return _serializableLowColor.ToColor(); }
            set { _serializableLowColor  = SerializableColor.FromColor(value); }
        }
        #endregion //LowColor

        #region LowLowColor
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public Color LowLowColor
        {
            get { return _serializableLowLowColor.ToColor(); }
            set { _serializableLowLowColor = SerializableColor.FromColor(value); }
        }
        #endregion //LowLowColor

        #region HighColor
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public Color HighColor
        {
            get { return _serializableHighColor.ToColor(); }
            set { _serializableHighColor = SerializableColor.FromColor(value); }
        }
        #endregion //HighColor

        #region HighHighColor
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public Color HighHighColor
        {
            get { return _serializableHighHighColor.ToColor(); }
            set { _serializableHighHighColor = SerializableColor.FromColor(value); }
        }
        #endregion //HighHighColor

    }
}
