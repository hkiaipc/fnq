
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;


namespace fnbx
{
    abstract public class Right
    {
        public const int
            SenderValue = 0,
            ReceiverValue = 1,
            AdminValue = 2;


        static private Right _sender = new SenderRight();
        static private Right _receiver = new ReceiverRight();
        static private Right _admin = new AdminRight();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public Right GetRight(int value)
        {
            if (value == SenderValue)
            {
                return _sender;
            }
            if (value == ReceiverValue)
            {
                return _receiver;
            }
            if (value == AdminValue)
            {
                return _admin;
            }
            throw new NotSupportedException();
        }


        private int _value;

        /// <summary>
        /// 
        /// </summary>
        protected Right(int value)
        {
            _value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        abstract public bool CanModifyTMStatus(MTStatus current);
        abstract public bool CanActivateForTm(ADEState ade, MTStatus current);
        abstract public bool CanActivateForRp(ADEState ade, MTStatus current);
    }

}
