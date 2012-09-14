
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;


namespace fnbx
{

    using TMStatusPair = KeyValuePair<FLStatus, FLStatus>;

    /// <summary>
    /// 
    /// </summary>
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

        abstract public List<TMStatusPair> GetStatusPairList();

        public int Value
        {
            get
            {
                return _value;
            }
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
        abstract public bool CanModifyFLStatus(FLStatus current);
        abstract public bool CanActivateForFL(ADEState ade, FLStatus current);
        //abstract public bool CanActivateForRp(ADEState ade, FLStatus current);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public FLStatus[] GetPossibles(FLStatus current)
        {
            List<TMStatusPair> list = this.GetStatusPairList();

            List<FLStatus> r = new List<FLStatus>();
            foreach (TMStatusPair item in list)
            {
                if (item.Key == current)
                {
                    r.Add(item.Value);
                }
            }

            return r.ToArray();
        }
    }

}
