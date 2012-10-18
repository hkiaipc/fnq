using System;
using System.Collections.Generic;
using System.Text;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class CalcColumnInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="expression"></param>
        public CalcColumnInfo(string name, string expression)
        {
            this.Name = name;
            this.Expression = expression;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="expression"></param>
        /// <param name="dataType"></param>
        public CalcColumnInfo(string name, string expression, Type dataType)
            : this(name, expression)
        {
            this.DataType = dataType;
        }


        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null ||
                    value.Trim().Length == 0)
                {
                    throw new ArgumentNullException("Name");
                }
                _name = value;
            }
        } private string _name;

        /// <summary>
        /// 
        /// </summary>
        public string Expression
        {
            get { return _expression; }
            set
            {
                if (value == null ||
                    value.Trim().Length == 0)
                {
                    throw new ArgumentNullException("Expression");
                }
                _expression = value;
            }
        } private string _expression;


        /// <summary>
        /// 
        /// </summary>
        public Type DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        } private Type _dataType = typeof(float);
    }
}
