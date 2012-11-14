using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBusiness.CommonUtils.Database;
using WebBusiness.MetaInfo;
using System.Data.SqlClient;
using System.Data;
namespace WebBusiness.AccountBusiness
{
    public class AccountOperation
    {
        public static bool LoginCheck(string user_name, string user_password)
        {
            SqlParameter[] checkparm = {new SqlParameter("@user_name",user_name),
                                        new SqlParameter("@user_password",user_password)};
            
            int returnValue=(int)SQLDataAccess.ExecuteScalar(DBInfo.DBString, "CheckUser",checkparm);
            if (returnValue>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string GetUserID(string user_name, string user_password)
        {
            SqlParameter[] getidparm = {new SqlParameter("@user_name",user_name),
                                        new SqlParameter("@user_password",user_password)};

            SqlDataReader returnReader = SQLDataAccess.ExecuteReader(DBInfo.DBString,
                                        "GetUserID", getidparm);
            if (returnReader.Read())
            {
                return returnReader["SNS_User_ID"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        public static bool RegisterUser(string strguid,string user_name, string user_password, string user_email)
        {
           
            SqlParameter[] registerparm = { new SqlParameter("@user_id",strguid),
                                            new SqlParameter("@user_email",user_email),
                                            new SqlParameter("@user_name",user_name),
                                            new SqlParameter("@user_password",user_password)
                                            
                                          };
            int returnValue = (int)SQLDataAccess.ExecuteNonQuery(DBInfo.DBString, "RegisterUser", registerparm);
            if (returnValue > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string GetUserName(string struid)
        {
            SqlParameter uidparm = new SqlParameter("@user_id", struid);
            SqlDataReader returnReader = SQLDataAccess.ExecuteReader(DBInfo.DBString,
                                        "GetUserName", uidparm);
            if (returnReader.Read())
            {
                return returnReader["SNS_User_Name"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
