using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBusiness.MetaInfo
{
    public class DBInfo
    {
        public static string DBString=ConfigurationManager.AppSettings["DB"];
    }
}
