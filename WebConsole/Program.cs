using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBusiness.AccountBusiness;
using WebBusiness.NoteBusiness;

namespace WebConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 1000; i++)
            {
                NoteOperation.PostNote(string.Format("测试标题{0}", i.ToString()),
                    string.Format("测试内容{0}", i.ToString()),
                    Guid.NewGuid().ToString());
                
            }
            Console.Write("OK");
        }
    }
}
