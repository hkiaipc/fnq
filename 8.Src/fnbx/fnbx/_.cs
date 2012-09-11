using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;


namespace fnbx
{
    using TMStatusPair = KeyValuePair<TMStatus, TMStatus>;
    class _
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public enum TMStatus
    {
        Created = 10,
        Received = 20,
        //Stoped = 30,
        Completed = 40,
        Closed = 50,
        Timeouted = 60,
    }


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
        abstract public bool CanModifyTMStatus(TMStatus current);
        abstract public bool CanActivateForTm(ADEState ade, TMStatus current);
        abstract public bool CanActivateForRp(ADEState ade, TMStatus current);
    }

    public class SenderRight : Right
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static private List<TMStatusPair> GetSenderList()
        {
            if (_senderList == null)
            {
                _senderList = new List<TMStatusPair>();
                _senderList.Add(new TMStatusPair(TMStatus.Completed, TMStatus.Closed));
            }
            return _senderList;
        } static private List<TMStatusPair> _senderList;

        public SenderRight()
            : base(Right.SenderValue)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public override bool CanModifyTMStatus(TMStatus current)
        {
            bool r = false;
            foreach (TMStatusPair item in GetSenderList())
            {
                if (item.Key == current)
                {
                    r = true;
                    break;
                }
            }
            return r;
        }

        public override bool CanActivateForRp(ADEState ade, TMStatus current)
        {
            return false;
        }

        public override bool CanActivateForTm(ADEState ade, TMStatus current)
        {
            bool r = false;
            switch (ade)
            {
                case ADEState.Add:
                    r = true;
                    break;

                case ADEState.Delete:
                    r = current == TMStatus.Created;
                    break;

                case ADEState.Edit:
                    r = current == TMStatus.Created;
                    break;

                default:
                    break;

            }
            return r;
        }
    }

    public class ReceiverRight : Right
    {
        public ReceiverRight()
            : base(Right.ReceiverValue)
        {
        }
        static private List<TMStatusPair> GetReceiverList()
        {
            if (_receiverList == null)
            {
                _receiverList = new List<TMStatusPair>();
                _receiverList.Add(new TMStatusPair(TMStatus.Created, TMStatus.Received));
                _receiverList.Add(new TMStatusPair(TMStatus.Received, TMStatus.Completed));
            }
            return _receiverList;
        } static private List<TMStatusPair> _receiverList;


        public override bool CanModifyTMStatus(TMStatus current)
        {
            bool r = false;
            foreach (TMStatusPair item in GetReceiverList())
            {
                if (item.Key == current)
                {
                    r = true;
                    break;
                }
            }
            return r;
        }

        public override bool CanActivateForRp(ADEState ade, TMStatus current)
        {
            bool r = false;
            switch (ade)
            {
                case ADEState.Add:
                    r = current == TMStatus.Created;
                    break;

                case ADEState.Delete:
                    break;

                case ADEState.Edit:
                    r = current == TMStatus.Received ||
                        current == TMStatus.Completed;
                    
                    break;

                default:
                    break;

            }
            return r;
        }

        public override bool CanActivateForTm(ADEState ade, TMStatus current)
        {
            return false;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class AdminRight : Right
    {
        static private List<TMStatusPair> GetList()
        {
            if (_list == null)
            {
                _list = new List<TMStatusPair>();
                _list.Add(new TMStatusPair(TMStatus.Created, TMStatus.Received));
                _list.Add(new TMStatusPair(TMStatus.Created, TMStatus.Timeouted));
                _list.Add(new TMStatusPair(TMStatus.Received, TMStatus.Timeouted));
                _list.Add(new TMStatusPair(TMStatus.Received, TMStatus.Completed));
                _list.Add(new TMStatusPair(TMStatus.Completed, TMStatus.Closed));

            }
            return _list;
        } static private List<TMStatusPair> _list;

        /// <summary>
        /// 
        /// </summary>
        public AdminRight()
            : base(Right.AdminValue)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public override bool CanModifyTMStatus(TMStatus current)
        {
            bool r = false;
            foreach (TMStatusPair item in GetList())
            {
                if (item.Key == current)
                {
                    r = true;
                    break;
                }
            }
            return r;
        }

        public override bool CanActivateForTm(ADEState ade, TMStatus current)
        {
            bool r = false;
            switch (ade)
            {
                case ADEState.Add:
                    break;

                case ADEState.Delete:
                    r = true;
                    break;

                case ADEState.Edit:
                    break;

                default:
                    break;

            }
            return r;
        }

        public override bool CanActivateForRp(ADEState ade, TMStatus current)
        {
            bool r = false;
            switch (ade)
            {
                case ADEState.Add:
                    break;

                case ADEState.Delete:
                    r = true;
                    break;

                case ADEState.Edit:
                    break;

                default:
                    break;

            }
            return r;
        }
    }
}
