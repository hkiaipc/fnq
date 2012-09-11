
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;


namespace fnbx
{
    using TMStatusPair = KeyValuePair<MTStatus, MTStatus>;
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
                _senderList.Add(new TMStatusPair(MTStatus.Completed, MTStatus.Closed));
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
        public override bool CanModifyTMStatus(MTStatus current)
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

        public override bool CanActivateForRp(ADEState ade, MTStatus current)
        {
            return false;
        }

        public override bool CanActivateForTm(ADEState ade, MTStatus current)
        {
            bool r = false;
            switch (ade)
            {
                case ADEState.Add:
                    r = true;
                    break;

                case ADEState.Delete:
                    r = current == MTStatus.Created;
                    break;

                case ADEState.Edit:
                    r = current == MTStatus.Created;
                    break;

                default:
                    break;

            }
            return r;
        }

        public override string ToString()
        {
            return "Ω”œﬂ‘±";
        }
    }

}
