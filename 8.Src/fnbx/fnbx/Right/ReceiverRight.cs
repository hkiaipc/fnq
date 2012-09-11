
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;


namespace fnbx
{
    using TMStatusPair = KeyValuePair<MTStatus, MTStatus>;
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
                _receiverList.Add(new TMStatusPair(MTStatus.Created, MTStatus.Received));
                _receiverList.Add(new TMStatusPair(MTStatus.Received, MTStatus.Completed));
            }
            return _receiverList;
        } static private List<TMStatusPair> _receiverList;


        public override bool CanModifyTMStatus(MTStatus current)
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

        public override bool CanActivateForRp(ADEState ade, MTStatus current)
        {
            bool r = false;
            switch (ade)
            {
                case ADEState.Add:
                    r = current == MTStatus.Created;
                    break;

                case ADEState.Delete:
                    break;

                case ADEState.Edit:
                    r = current == MTStatus.Received ||
                        current == MTStatus.Completed;

                    break;

                default:
                    break;

            }
            return r;
        }

        public override bool CanActivateForTm(ADEState ade, MTStatus current)
        {
            return false;
        }

        public override string ToString()
        {
            return "»Øµ¥Ô±";
        }

    }

}
