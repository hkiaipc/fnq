using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Xdgk.Common;

namespace K
{
    class KConfigException : Exception
    {
        public KConfigException(string msg)
            : base(msg)
        {

        }
    }

    public enum LeaveEnum
    {
        Private = 0,
        Sick = 1,
        Vacation = 2,
        //Out = 3,
    }

    enum KResultEnum
    {
        Normal = 0,
        Later = 1,
        Early = 2,

        LaterEarly = 3,
        Lose = 4,
        Leave = 5,

        Out = 6,
        Rest = 7,
        None = 999,
    }
}
