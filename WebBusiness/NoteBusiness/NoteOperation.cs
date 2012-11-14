using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBusiness.CommonUtils.Database;
using WebBusiness.MetaInfo;

namespace WebBusiness.NoteBusiness
{
    public class NoteOperation
    {
        public static bool PostNote(string strPosterTitle, string strContent,string strPosterID )
        {

            SqlParameter[] PostNoteparm = { new SqlParameter("@strNoteID",Guid.NewGuid().ToString()),
                                            new SqlParameter("@strPosterID",strPosterID),
                                            new SqlParameter("@strContent",strContent),
                                            new SqlParameter("@PosterTitle",strPosterTitle)
                                          };
            int returnValue = (int)SQLDataAccess.ExecuteNonQuery(DBInfo.DBString, "PostNote", PostNoteparm);
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
