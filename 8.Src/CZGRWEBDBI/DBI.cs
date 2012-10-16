using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Xdgk.Common;

namespace CZGRWEBDBI
{
    public class DBI
    {
        #region Default
        /// <summary>
        /// 
        /// </summary>
        static public DBI Default
        {
            get
            {
                //if (s_default == null)
                //    throw new InvalidOperationException("DBI not init");
                return s_default;
            }
        } static private DBI s_default;
        #endregion //Default

        #region Init
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connString"></param>
        static public void Init(string connString)
        {
            if (s_default != null)
                throw new InvalidOperationException("DBI already inited");
            s_default = new DBI(connString);
        }
        #endregion //Init

        #region DBI
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connString"></param>
        public DBI(string connString)
        {
            this._connection = new SqlConnection(connString);
            this._connection.Open();
        }
        #endregion //DBI

        #region Connection
        /// <summary>
        /// 
        /// </summary>
        public SqlConnection Connection
        {
            get { return _connection; }
        } private SqlConnection _connection;
        #endregion //Connection

        #region GetDBInfo
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DBInfo GetDBInfo()
        {
            DBInfo info = new DBInfo();
            string sql = "select top 1 * from tblDBInfo";
            SqlCommand cmd = this._connection.CreateCommand();
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                info.Version = Convert.ToInt32(reader["version"]);
                info.Project = reader["project"].ToString();
                info.DT = Convert.ToDateTime(reader["DT"]);
                reader.Close();
                return info;
            }
            else
            {
                return null;
            }
            
        }
        #endregion //GetDBInfo

        #region CheckVersion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public bool CheckVersion(int version)
        {
            DBInfo info = this.GetDBInfo();
            return version == info.Version;
        }
        #endregion //CheckVersion

        #region ExecuteGRDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName">stationName = stationname + devicename</param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable ExecuteGRDataTable(string stationName, DateTime begin, DateTime end)
        {
            string sql = "SELECT * FROM vGRData WHERE (StationName = @n) AND (DT BETWEEN @b AND @e) ORDER BY DT";
            SqlCommand cmd = new SqlCommand(sql);

            SqlParameter p = null;
            p = new SqlParameter("n", stationName);
            cmd.Parameters.Add(p);

            p = new SqlParameter("b", begin);
            cmd.Parameters.Add(p);

            p = new SqlParameter("e", end);
            cmd.Parameters.Add(p);

            return ExecuteDataTable(cmd);
        }
        #endregion //ExecuteGRDataTable

        #region ExecuteXGDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable ExecuteXGDataTable(string stationName, DateTime begin, DateTime end)
        {
            string sql = "SELECT * FROM vXGData WHERE (StationName = @n) AND (DT >= @b AND DT < @e) ORDER BY DT";
            SqlCommand cmd = new SqlCommand(sql);

            SqlParameter p = null;
            p = new SqlParameter("n", stationName);
            cmd.Parameters.Add(p);

            p = new SqlParameter("b", begin);
            cmd.Parameters.Add(p);

            p = new SqlParameter("e", end);
            cmd.Parameters.Add(p);

            return ExecuteDataTable(cmd);
        }
        #endregion //ExecuteXGDataTable

        #region ExecuteXGDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable ExecuteXGDataTable(DateTime begin, DateTime end)
        {
            string sql = "SELECT * FROM vXGData WHERE (DT >= @b AND  DT < @e) ORDER BY DT";
            SqlCommand cmd = new SqlCommand(sql);
            SqlParameter p = new SqlParameter("b", begin);
            cmd.Parameters.Add(p);

            p = new SqlParameter("e", end);
            cmd.Parameters.Add(p);

            return ExecuteDataTable(cmd);
        }
        #endregion //ExecuteXGDataTable

        #region ExecuteGRDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable ExecuteGRDataTable(DateTime begin, DateTime end)
        {
            string sql = "SELECT * FROM vGRData WHERE (DT BETWEEN @b AND @e) ORDER BY DT";
            SqlCommand cmd = new SqlCommand(sql);
            SqlParameter p = new SqlParameter("b", begin);
            cmd.Parameters.Add(p);

            p = new SqlParameter("e", end);
            cmd.Parameters.Add(p);

            return ExecuteDataTable(cmd);
        }
        #endregion //ExecuteGRDataTable

        #region ExecuteDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql)
        {
            //SqlCommand cmd = this._connection.CreateCommand();
            SqlCommand cmd = new SqlCommand(sql);
            return ExecuteDataTable(cmd);
        }
        #endregion //ExecuteDataTable

        #region ExecuteDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(SqlCommand cmd)
        {
            cmd.Connection = this.Connection;
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.Fill(ds);
            return ds.Tables[0];
        }
        #endregion //ExecuteDataTable

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteStationName()
        {
            string[] deviceTypes = new string[] { "grdevice", "grdeviceModbus" };
            return ExecuteStationName(deviceTypes);
        }

        #region ExecuteStationName
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteStationName(string[] deviceTypes)
        {
            string selectCommand = "SELECT [StationID], [StationName], [DeviceName] FROM [vStationGRDevice] " +
                //"WHERE (DeviceType = 'grdevice' OR DeviceType = 'grdeviceModbus') AND StationDeleted = 0 AND DeviceDeleted = 0 " +
                //"WHERE (" + CreateDeviceCondition(deviceTypes) + ") AND StationDeleted = 0 AND DeviceDeleted = 0 " +
                "ORDER BY [StationName], [DeviceName]";
            return ExecuteDataTable(selectCommand);
        }
        #endregion //ExecuteStationName

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceTypes"></param>
        /// <returns></returns>
        private string CreateDeviceCondition(string[] deviceTypes)
        {
            string c = string.Empty;
            for( int i=0; i< deviceTypes.Length ; i++ )
            {
                c += string.Format("DeviceType = '{0}'", deviceTypes[i]);
                if (i != deviceTypes.Length - 1)
                    c += " OR ";
            }
            return c; 
        }


        /// <summary>
        /// 获取供热设备信息表
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteGRDeviceTable()
        {
            string s = "SELECT StationID, DeviceID, StationName, Street " +
                "FROM vStationGRDevice " +
                //"WHERE (StationDeleted = 0) AND (DeviceDeleted = 0) " +
                "ORDER BY StationName";
            return ExecuteDataTable(s);
        }

        #region ExecuteDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <param name="st"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(DateTime b, DateTime e, string st)
        {
            string s = string.Format("select * from vGRData where (StationName = '{0}') and ( DT between '{1}' and '{2}') order by dt",
               st, b, e);

            return ExecuteDataTable(s);
        }
        #endregion //ExecuteDataTable

        #region MakeXGDataSql
        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public string MakeXGDataSql(DateTime begin, DateTime end, string stationName)
        {
            string s = string.Format("select * from vXGData where (Name = '{0}') and ( DT between '{1}' and '{2}')",
               stationName, begin, end );
            return s;
        }
        #endregion //MakeXGDataSql

        #region User
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CanLogin(string user, string password)
        {
            user = user.Trim();
            //string sql = string.Format(
            string sql = "select count(*) from tblUser where [Name] =@n and Password = @p";
                //user, password);

            SqlCommand cmd = new SqlCommand(sql);
            AddSqlParameter(cmd, "n", user);
            AddSqlParameter(cmd, "p", password);

            int n = Convert.ToInt32(ExecuteScalar(cmd));
            return n != 0;
        }
        #endregion //

        #region GetUserIDAndRole
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void GetUserIDAndRole(string user, out int userID, out int role)
        {
            userID = -1;
            role = -1;
            string sql = "SELECT UserID, Role FROM tblUser WHERE Name = @name";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = this.Connection;
            SqlParameter p = new SqlParameter("name", user);
            cmd.Parameters.Add(p);

            SqlDataReader reader = cmd.ExecuteReader();
            if( reader.Read() )
            {
                userID = Convert.ToInt32(reader["UserID"]);
                role = Convert.ToInt32(reader["role"]);
            }
            reader.Close();
            //object obj = cmd.ExecuteScalar();
            //if (obj != DBNull.Value)
            //{
            //    return Convert.ToInt32(obj);
            //}
            //else
            //{
            //    return 0;
            //}
        }
        #endregion //GetUserIDAndRole

        #region ExecuteScalar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private object ExecuteScalar( string sql )
        {
            SqlCommand cmd = this._connection.CreateCommand();
            cmd.CommandText = sql;
            return ExecuteScalar(cmd);
        }
        #endregion //ExecuteScalar

        #region ExecuteScalar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private object ExecuteScalar(SqlCommand cmd)
        {
            cmd.Connection = this.Connection;
            return cmd.ExecuteScalar();
        }
        #endregion //ExecuteScalar

        #region ExecutePressTable
        /// <summary>
        /// 读取压力表
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <param name="st"></param>
        /// <returns></returns>
        public DataTable ExecutePressTable(DateTime b, DateTime e, string st)
        {
            string s = @"SELECT DT, GP1, BP1, GP2, BP2 FROM vGRData
                WHERE ( StationName = @st ) AND ( DT BETWEEN @b AND @e )
                ORDER BY DT";

            SqlCommand sql = new SqlCommand(s);
            sql.Connection = this.Connection;
            SqlParameter param = new SqlParameter("st", SqlDbType.NVarChar);
            param.Value = st;
            sql.Parameters.Add(param);

            param = new SqlParameter("b", SqlDbType.DateTime);
            param.Value = b;
            sql.Parameters.Add(param);

            param = new SqlParameter("e", SqlDbType.DateTime);
            param.Value = e;
            sql.Parameters.Add(param);

            
            return ExecuteDataTable(sql);
        }
        #endregion //ExecutePressTable

        #region ExecuteTemperatTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <param name="st"></param>
        /// <returns></returns>
        public DataTable ExecuteTemperatTable(DateTime b, DateTime e, string st)
        {
            // 2010-09-25 
            // add i1 for draw temp line with I1 H1
            // 
            string s = @"select DT, GT1, BT1, GT2, BT2, OT, I1 from vGRData 
                where (StationName = @st) and ( DT between @b and @e) 
                order by dt";

            SqlCommand sql = new SqlCommand(s);
            sql.Connection = this.Connection;
            SqlParameter param = new SqlParameter("st", SqlDbType.NVarChar);
            param.Value = st;
            sql.Parameters.Add(param);

            param = new SqlParameter("b", SqlDbType.DateTime);
            param.Value = b;
            sql.Parameters.Add(param);

            param = new SqlParameter("e", SqlDbType.DateTime);
            param.Value = e;
            sql.Parameters.Add(param);

            
            return ExecuteDataTable(sql);
        }
        #endregion //ExecuteTemperatTable

        #region ExecuteGRLastDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteGRLastDataTable()
        {
            string s = "select * from vGRDataLast";
            return ExecuteDataTable(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteXD100eLastDataTable()
        {
            //string s = "select * from vXd100eDataLast";
            string s = "SELECT [站名],  [时间], [一次供温], [一次回温], [一次供压], [一次回压], [瞬时流量] FROM [fngrdb2012].[dbo].[vXd100eDataLast]";
            return ExecuteDataTable(s);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public DataTable ExecuteGRLastDataTable(string stationName)
        {
            string s = string.Format("select * from vGRDataLast where StationName = '{0}'", 
                stationName);
            return ExecuteDataTable(s);
        }
        #endregion //ExecuteGRLastDataTable

        #region ExecuteUserDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteUserDataTable()
        {
            string s = "SELECT * FROM TBLUSER ORDER BY role";
            return this.ExecuteDataTable(s);
        }
        #endregion //ExecuteUserDataTable

        #region AddUser
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <param name="role"></param>
        public void AddUser(string name, string pwd, int role)
        {
            string s = "Insert into tblUser( Name, Password, Role) Values( @n, @p, @r )";
            SqlCommand cmd = new SqlCommand(s);
            SqlParameter p = null;
            p = new SqlParameter("n", name);
            cmd.Parameters.Add(p);

            p = new SqlParameter("p", pwd);
            cmd.Parameters.Add(p);

            p = new SqlParameter("r", role);
            cmd.Parameters.Add(p);

            this.ExecuteScalar(cmd);
        }
        #endregion //AddUser

        #region ExistUser
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ExistUser(string name)
        {
            string s = "SELECT COUNT(*) FROM tblUser WHERE Name = @n";
            SqlCommand cmd = new SqlCommand(s);
            cmd.Parameters.Add(new SqlParameter("n", name));

            object obj = this.ExecuteScalar(cmd);
            int count = (int)obj;
            return count > 0;
        }
        #endregion //ExistUser

        #region MatchPassword
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="oldpwd"></param>
        /// <returns></returns>
        public bool MatchPassword(int userID, string oldpwd)
        {
            string s = string.Format("Select password from tblUser where userID = '{0}'", userID );
            object obj = this.ExecuteScalar(s);
            string pwd = obj.ToString();
            return pwd == oldpwd;
        }
        #endregion //MatchPassword

        #region UpdatePassword
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="newPwd"></param>
        public void UpdatePassword(int userID, string name, string newPwd, int role)
        {
            string s = "update tblUser Set Name = @n, Role = @r, password = @p where userid = @userid";
            SqlCommand cmd = new SqlCommand(s);
            SqlParameter p = null;

            p = new SqlParameter("n", name);
            cmd.Parameters.Add(p);

            p = new SqlParameter("p", newPwd);
            cmd.Parameters.Add(p);

            p = new SqlParameter("r", role );
            cmd.Parameters.Add(p);

            p = new SqlParameter("userid", userID);
            cmd.Parameters.Add(p);

            this.ExecuteScalar(cmd);
        }
        #endregion //UpdatePassword

        #region DeleteUser
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void DeleteUser(string name)
        {
            string s = "delete from tblUser where name = @n";
            SqlCommand cmd = new SqlCommand(s);
            cmd.Parameters.Add(new SqlParameter("n", name));

            this.ExecuteScalar(cmd);
        }

        public void DeleteUser(int userID)
        {
            string s = "delete from tblUser where UserID= @id";
            SqlCommand cmd = new SqlCommand(s);
            cmd.Parameters.Add(new SqlParameter("id", userID));

            this.ExecuteScalar(cmd);
        }


        #endregion //DeleteUser

        #region ExecuteGRAlarmDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="dateTime_2"></param>
        /// <returns></returns>
        public DataTable ExecuteGRAlarmDataTable(DateTime b, DateTime e)
        {
            string s = "select * from vGRAlarmData where dt between @b and @e";
            SqlCommand cmd = new SqlCommand(s);

            SqlParameter p;
            p = new SqlParameter("b", b);
            cmd.Parameters.Add(p);

            p = new SqlParameter("e", e);
            cmd.Parameters.Add(p);

            return ExecuteDataTable(cmd);
        }
        #endregion //ExecuteGRAlarmDataTable

        /// <summary>
        /// 返回指定时间以后的报警数据
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public DataTable ExecuteGRAlarmDataTable(DateTime b)
        {
            string s = "select * from vGRAlarmData where dt > @b";

            // TODOX:
            //
            //s = "select top 5 * from vgralarmdata order by gralarmdataid";

            SqlCommand cmd = new SqlCommand(s);
            SqlParameter p;
            p = new SqlParameter("b", b);
            cmd.Parameters.Add(p);
            return ExecuteDataTable(cmd);

        }

        #region ExecuteGRAlarmDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public DataTable ExecuteGRAlarmDataTable(string dispalyName, DateTime b, DateTime e)
        {
            string s = "select * from vGRAlarmData where StationName = @n and dt between @b and @e";
            SqlCommand cmd = new SqlCommand(s);

            SqlParameter p;
            p = new SqlParameter("n", dispalyName);
            cmd.Parameters.Add(p);

            p = new SqlParameter("b", b);
            cmd.Parameters.Add(p);

            p = new SqlParameter("e", e);
            cmd.Parameters.Add(p);

            return ExecuteDataTable(cmd);
        }
        #endregion //ExecuteGRAlarmDataTable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable ExecuteCalcHeat(DateTime begin, DateTime end)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CalcHeat";
            cmd.Parameters.Add(new SqlParameter("@beginDT", begin));
            cmd.Parameters.Add(new SqlParameter("@endDT", end));

            return this.ExecuteDataTable(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable ExecuteCalcHeat(string stationName, DateTime begin, DateTime end)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "StationCalcHeat";

            cmd.Parameters.Add(new SqlParameter("@stationName", stationName));
            cmd.Parameters.Add(new SqlParameter("@beginDT", begin));
            cmd.Parameters.Add(new SqlParameter("@endDT", end));

            return this.ExecuteDataTable(cmd);
        }


        ///// <summary>
        ///// 读取热量计算中需要删除的行的名称()
        ///// </summary>
        ///// <returns></returns>
        //public string[] ReadCalcHeatRemovedNames()
        //{
        //    string DELETE = "Delete";

        //    string sql = string.Format("select * from tblConfig where Name = '{0}'", DELETE);

        //    List<string> list = new List<string>();
        //    DataTable tbl = this.ExecuteDataTable(sql);
        //    foreach (DataRow row in tbl.Rows)
        //    {
        //        list.Add( row["Content"].ToString().Trim() );
        //    }

        //    return list.ToArray();
        //}

        ///// <summary>
        ///// 获取站点的供热设备名称
        ///// </summary>
        ///// <param name="stationName"></param>
        ///// <remarks>
        ///// 单控制器站点返回站点名称
        ///// 多控制器站点返回接一次数据线控制器名称
        ///// </remarks>
        ///// <returns></returns>
        //public string GetGRDeviceDisplayName(string stationName)
        //{
        //    foreach (DictionaryEntry de in StationNameDisplayNameHashtable)
        //    {
        //        if (StringHelper.Equal(de.Key.ToString(), stationName))
        //        {
        //            return de.Value.ToString();
        //        }
        //    }
        //    return stationName;
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        //private Hashtable StationNameDisplayNameHashtable
        //{
        //    get 
        //    {
        //        if (_stationNameDisplayNameHashtable == null)
        //        {
        //            _stationNameDisplayNameHashtable = new Hashtable();
        //            Hashtable ht = ReadCalcHeatReplaceNames();
        //            foreach (DictionaryEntry de in ht )
        //            {
        //                string v = de.Value.ToString();
        //                string k = de.Key.ToString();
        //                if (_stationNameDisplayNameHashtable[v] == null)
        //                {
        //                    _stationNameDisplayNameHashtable[v] = k;
        //                }
        //            }

        //        }
        //        return _stationNameDisplayNameHashtable;
        //    }
        //} private Hashtable _stationNameDisplayNameHashtable = null;

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Hashtable ReadCalcHeatReplaceNames()
        {
            string REPLACE = "Replace";

            string sql = string.Format("select * from tblConfig where Name = '{0}'", REPLACE);

            Hashtable ht = new Hashtable();
            DataTable tbl = this.ExecuteDataTable(sql);
            foreach (DataRow row in tbl.Rows)
            {
                string s = row["Content"].ToString().Trim();
                string[] ss = s.Split(',');
                if (ss.Length >= 2)
                {
                    string o = ss[0];
                    string n = ss[1];

                    if (ht[o] == null)
                        ht[o] = n;
                }
            }
            return ht;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetHeatingDays()
        {
            string sql = "select Content from tblConfig where name = 'HeatingDays'";
            object obj = this.ExecuteScalar(sql);

            // default days
            // 122 = 4 * 30 + 2
            //
            int days = 122;
            if (obj != null && obj != DBNull.Value )
            {
                try
                {
                    days = Convert.ToInt32(obj);
                }
                catch
                {
                    // ignore
                }
            }
            if (days < 1)
                days = 1;
            return days;
        }

        /// <summary>
        /// 获取计划耗热量，单位GJ
        /// </summary>
        /// <returns></returns>
        public double[] GetPlanHeat()
        {
            string sql = "select Content from tblConfig where name = 'PlanHeat'";
            object obj = this.ExecuteScalar(sql);
            if (obj != null)
            {
                string str = obj.ToString();
                string[] ss = str.Split(',');
                List<double> phs = new List<double>();
                foreach (string s in ss)
                {
                    // 保存单位为万GJ
                    //
                    double n = double.Parse(s);
                    phs.Add(n);
                }
                return phs.ToArray();
            }
            return new double[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteHeatCommentDataTable()
        {
            string sql = "select * from tblConfig where name = 'HeatComment'";
            return this.ExecuteDataTable(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public double GetPlanHeat(DateTime dt)
        {
            // 11.15 ~ 12.15
            // 12.16 ~ 1.15
            // 1.16 ~ 2.15
            // 2.16 ~ 3.15
            //
            int month = dt.Month;
            int day = dt.Day;
            double[] phs = GetPlanHeat();
            // phs start month 11
            //
            int idx = month - 11;
            if (idx < 0)
            {
                idx += 12;
            }
            //if (day <= 15)
            //{
            //    idx--;
            //}

            if (idx < phs.Length)
            {
                return phs[idx];
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetTotalSupportArea()
        {
            // TODO: select from vStationDevice where StationDeleted = 0 AND DeviceDeleted = 0
            //
            //string sql = "select sum(supportarea) as total from tbldevice " + 
            //    "where deleted = 0 and devicetype = 'grdevice' and supportarea > 1";
            double t = GetGRDeviceTotalSupportArea();
            t += GetExtraGRDeviceTotalSupportArea();
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private double GetGRDeviceTotalSupportArea()
        {
            string sql = "select sum(supportarea) as total from vStationDevice " +
                //"where StationDeleted = 0 and DeviceDeleted = 0 and " +
                "(devicetype = 'grdevice' OR devicetype = 'grdeviceModbus') and supportarea > 1";
            object obj = this.ExecuteScalar(sql);
            return ConvertToDouble(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static double ConvertToDouble(object obj)
        {
            if (obj == DBNull.Value)
                return 0;
            else
                return Convert.ToDouble(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private double GetExtraGRDeviceTotalSupportArea()
        {
            string sql = "select sum(supportArea) from tblExtraGRDevice";
            object obj = this.ExecuteScalar(sql);
            //return Convert.ToDouble(obj);
            return ConvertToDouble(obj);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteExtraGRDeviceDataTable()
        {
            string sql = "select street, name, registeredArea, supportArea from tblExtraGRDevice order by street, name";
            return this.ExecuteDataTable(sql);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Hashtable ExecuteStationNODataTable()
        {
            Hashtable ht = new Hashtable();
            string sql = "select Content from tblConfig where Name = 'StationNO'";
            DataTable tbl = this.ExecuteDataTable(sql);

            foreach( DataRow row in tbl.Rows )
            {
                string s = row["Content"].ToString().Trim();
                string[] ss = s.Split(':');
                if (ss.Length == 2)
                {
                    string station =ss[0].ToString(); 
                    int no = int.Parse(ss[1].ToString());
                    object value = ht[station];
                    if (value == null)
                    {
                        ht.Add(station, no);
                    }
                }
            }
            return ht;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable ExecuteOTDataTable(DateTime begin, DateTime end)
        {
            string s = "select * from tblOT where dt between @b and @e order by dt";
            SqlCommand cmd = new SqlCommand(s);

            SqlParameter p;
            p = new SqlParameter("b", begin);
            cmd.Parameters.Add(p);

            p = new SqlParameter("e", end);
            cmd.Parameters.Add(p);

            return ExecuteDataTable(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grdeviceID"></param>
        /// <returns></returns>
        public DataTable ExecuteGRDevicePlanHeatDataTable(int grdeviceID)
        {
            string s = "select * from tblPlanHeat where DeviceID = @id";
            SqlCommand cmd = new SqlCommand(s);
            SqlParameter p;

            p = new SqlParameter("id", grdeviceID);
            cmd.Parameters.Add(p);

            return ExecuteDataTable(cmd);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="planHeat"></param>
        public void InsertPlanHeat(int grdeviceID, int month, int planHeat)
        {
            string s = "insert into tblPlanHeat(deviceID, month, planHeat) values(@id, @m, @p)";
            SqlCommand cmd = new SqlCommand(s);
            AddSqlParameter(cmd, "id", grdeviceID);
            AddSqlParameter(cmd, "m", month);
            AddSqlParameter(cmd, "p", planHeat);
            ExecuteScalar(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grdeviceID"></param>
        /// <param name="month"></param>
        /// <param name="planHeat"></param>
        public void UpdatePlanHeat(int planHeatID, int month, int planHeat)
        {
            string s = "update tblPlanHeat set month=@m, planHeat=@p where planHeatID = @id";

            SqlCommand cmd = new SqlCommand(s);
            AddSqlParameter(cmd, "id", planHeatID);
            AddSqlParameter(cmd, "m", month);
            AddSqlParameter(cmd, "p", planHeat);
            ExecuteScalar(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grdevcieID"></param>
        /// <param name="month"></param>
        /// <param name="ingore"></param>
        /// <returns></returns>
        public bool ExistMonth(int grdevcieID, int month, int ignorePlanHeatID)
        {
            string s = "select count(*) from tblPlanHeat " + 
                "where deviceID = @id and month = @m and planHeatID <> @i";
            SqlCommand cmd = new SqlCommand(s);
            AddSqlParameter(cmd, "id", grdevcieID);
            AddSqlParameter(cmd, "m", month);
            AddSqlParameter(cmd, "i", ignorePlanHeatID);

            bool b = false;
            object obj = ExecuteScalar(cmd);
            int count = Convert.ToInt32(obj);
            b = count != 0;
            return b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="planHeatID"></param>
        public void DeletePlanHeat(int planHeatID)
        {
            string s = string.Format("delete from tblPlanHeat where planHeatID = {0}",
                planHeatID);
            ExecuteScalar(s);
        }

        ///// <summary>
        ///// 获取供热设备当月计划热量
        ///// </summary>
        ///// <param name="grdeviceID"></param>
        ///// <returns></returns>
        //public int GetGRDevicePlanHeat(int grdeviceID)
        //{
        //    int month = DateTime.Now.Month;
        //    return GetGRDevicePlanHeat(grdeviceID, month);
        //}

        /// <summary>
        /// 获取供热设备某个月的计划热量
        /// </summary>
        /// <param name="grDeviceID"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public int GetGRDevicePlanHeat(int grDeviceID, int month)
        {
            string s = "select planheat from tblPlanHeat where deviceid = @id and month = @m";
            SqlCommand cmd = new SqlCommand(s);
            AddSqlParameter(cmd, "id", grDeviceID);
            AddSqlParameter(cmd, "m", month);
            object obj = ExecuteScalar(cmd);
            if( obj == null )
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32 (obj);
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        static public void AddSqlParameter(SqlCommand cmd, string parameterName, object value)
        {
            SqlParameter p = new SqlParameter(parameterName, value);
            cmd.Parameters.Add(p);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public DataTable ExecuteEMData(DateTime b, DateTime e)
        {
            string s = "select * from vEMData where dt between @b and @e order by dt";
            SqlCommand cmd = new SqlCommand(s);
            DBIBase.AddSqlParameter(cmd, "b", b);
            DBIBase.AddSqlParameter(cmd, "e", e);
            return ExecuteDataTable(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public DataTable ExecuteEMData(string stationName, DateTime b, DateTime e)
        {
            string s = "select * from vEMData where (stationName = @stationName) and (dt between @b and @e) order by dt";
            SqlCommand cmd = new SqlCommand(s);

            DBIBase.AddSqlParameter(cmd, "stationName", stationName);
            DBIBase.AddSqlParameter(cmd, "b", b);
            DBIBase.AddSqlParameter(cmd, "e", e);

            return ExecuteDataTable(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public DataTable ExecuteRecruitData(DateTime b, DateTime e)
        {
            string s = "select * from vGRData where dt between @b and @e order by dt";
            SqlCommand cmd = new SqlCommand(s);
            DBIBase.AddSqlParameter(cmd, "b", b);
            DBIBase.AddSqlParameter(cmd, "e", e);
            return ExecuteDataTable(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public DataTable ExecuteRecruitData(string stationName, DateTime b, DateTime e)
        {
            string s = "select * from vgrdata where (StationName = @stationName) and (dt between @b and @e) order by dt";
            SqlCommand cmd = new SqlCommand(s);

            DBIBase.AddSqlParameter(cmd, "stationName", stationName);
            DBIBase.AddSqlParameter(cmd, "b", b);
            DBIBase.AddSqlParameter(cmd, "e", e);

            return ExecuteDataTable(cmd);   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DBCard[] ExecuteTmDBCard()
        {
            DataTable tbl = ExecuteTmCardDataTable();
            List<DBCard> list = new List<DBCard>();
            foreach (DataRow row in tbl.Rows)
            {
                DBCard c = new DBCard();
                c.CardID = Convert.ToInt32(row["CardID"]);
                c.SN = row["sn"].ToString();
                c.Person = row["person"].ToString();
                c.Remark = row["remark"].ToString();
                list.Add(c);
            }
            return list.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteTmCardDataTable()
        {
            string s = "select * from tblCard order by Person";
            return ExecuteDataTable(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="person"></param>
        /// <param name="remark"></param>
        public int InsertTmCard(string sn, string person, string remark)
        {
            string s = "insert into tblCard(sn, person, remark) values(@sn, @person, @remark); select @@identity";
            SqlCommand cmd = new SqlCommand(s);
            DBIBase.AddSqlParameter(cmd, "sn", sn);
            DBIBase.AddSqlParameter(cmd, "person", person );
            DBIBase.AddSqlParameter(cmd, "remark", remark );
            object obj = ExecuteScalar(cmd);
            return Convert.ToInt32(obj);
        }


        public void UpdateTmCard(int id, string sn, string person, string remark)
        {
            string s = "update tblCard Set sn = @sn, person = @person, remark = @remark where cardid = @id";
            SqlCommand cmd = new SqlCommand(s);

            DBIBase.AddSqlParameter(cmd, "sn", sn);
            DBIBase.AddSqlParameter(cmd, "person", person );
            DBIBase.AddSqlParameter(cmd, "remark", remark );
            DBIBase.AddSqlParameter(cmd, "id", id);

            this.ExecuteScalar(cmd);

        }

        public void DeleteTmCard(int id)
        {
            string s = string.Format("delete from tblCard where cardid = {0}",id);
            ExecuteScalar(s);
        }

        // exist tmcard (sn )
        //

        public bool ExistTmCard(string sn, int ignoreID)
        {
            string s = string.Format("select count(*) from tblCard where sn = '{0}' and cardid <> {1}",
                sn, ignoreID);

            object obj = ExecuteScalar(s);
            return Convert.ToInt32(obj) > 0;
        }

        public string GetDeviceExtend(int deviceID)
        {
            string s = string.Format("select DeviceExtend from tblDevice where deviceid = {0}", deviceID);
            return ExecuteScalar(s).ToString();
        }
    }

   public class DBCard     
    {
        #region Members
        private string _sN;
        private string _person;
        private string _remark;
        #endregion //Members


        /// <summary>
        /// 
        /// </summary>
        public DBCard()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="person"></param>
        /// <param name="remark"></param>
        public DBCard(string sn, string person, string remark)
        {
            this.SN = sn;
            Person = person;
            Remark = remark;
        }

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// 
        public int CardID
        {
            get { return _cardID; }
            set { _cardID = value; }
        } private int _cardID;

        #region SN
        /// <summary>
        /// 获取或设置
        /// </summary>
        public string SN
        {
            get { return _sN; }
            set { _sN = value; }
        }
        #endregion //SN

        #region Person
        /// <summary>
        /// 获取或设置
        /// </summary>
        public string Person
        {
            get { return _person; }
            set { _person = value; }
        }
        #endregion //Person

        #region Remark
        /// <summary>
        /// 获取或设置
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        #endregion //Remark

        #endregion //Properties

    }
}
