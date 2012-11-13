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
        public static bool RegisterUser(string user_name, string user_password, string user_email)
        {
            SqlParameter[] registerparm = { new SqlParameter("@user_name",user_name),
                                            new SqlParameter("@user_password",user_password),
                                            new SqlParameter("@user_email",user_email)
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

    }
}
