
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;


namespace fnbx
{
    using TMStatusPair = KeyValuePair<FLStatus, FLStatus>;
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
                _receiverList.Add(new TMStatusPair(FLStatus.Created, FLStatus.Received));
                _receiverList.Add(new TMStatusPair(FLStatus.Received, FLStatus.Completed));
            }
            return _receiverList;
        } static private List<TMStatusPair> _receiverList;


        public override bool CanModifyTMStatus(FLStatus current)
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

        public override bool CanActivateForRp(ADEState ade, FLStatus current)
        {
            bool r = false;
            switch (ade)
            {
                case ADEState.Add:
                    r = current == FLStatus.Created;
                    break;

                case ADEState.Delete:
                    break;

                case ADEState.Edit:
                    r = current == FLStatus.Received ||
                        current == FLStatus.Completed;

                    break;

                default:
                    break;

            }
            return r;
        }

        public override bool CanActivateForTm(ADEState ade, FLStatus current)
        {
            return false;
        }

        public override string ToString()
        {
            return "»Øµ¥Ô±";
        }


        public override List<KeyValuePair<FLStatus, FLStatus>> GetStatusPairList()
        {
            return GetReceiverList();
        }
    }

}
