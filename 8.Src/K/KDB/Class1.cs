using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KDB
{
    public class DBFactory
    {
        static public KDB.DB GetDB()
        {
            DB db = new DB();
            return db;
        }
    }
}
