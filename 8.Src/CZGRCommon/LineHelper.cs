using System;
using System.Drawing;
using System.Data;
using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
using ZedGraph;

namespace CZGRCommon
{
    public class LineHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public LineHelper( string text, Color color )
            : this( text, color, 1, SymbolType.None )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsY2Axis
        {
            get { return _isY2Axis; }
            set { _isY2Axis = value; }
        } private bool _isY2Axis;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <param name="symbol"></param>
        public LineHelper(string text, Color color, int width, SymbolType symbol)
        {
            this.Text = text;
            this.Color = color;
            this.LineWidth = width;
            this.SymbolType = symbol;
        }

        /// <summary>
        /// 
        /// </summary>
        public int LineWidth
        {
            get { return _lineWidth; }
            set 
            {
                if (_lineWidth < 1)
                    throw new ArgumentOutOfRangeException("LineWidth", value, "must >=1");
                _lineWidth = value; 
            }
        } private int _lineWidth = 1;


        /// <summary>
        /// 
        /// </summary>
        public SymbolType SymbolType
        {
            get { return _symbolType; }
            set { _symbolType = value; }
        } private SymbolType _symbolType = SymbolType.None;


        /// <summary>
        /// 
        /// </summary>
        public Symbol Symbol
        {
            get { return new Symbol(this.SymbolType, this.Color); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        } private string _text;


        /// <summary>
        /// 
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        } private Color _color;

        /// <summary>
        /// 
        /// </summary>
        public PointPairList PointList
        {
            get
            {
                if (_pointList == null)
                    _pointList = new PointPairList();
                return _pointList; 
            }
        } private PointPairList _pointList;
    }
}
