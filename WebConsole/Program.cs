using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBusiness.AccountBusiness;

namespace WebConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           bool a= AccountOperation.LoginCheck("chu888chu888", "123456");
        }
    }
}
