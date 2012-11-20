using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebConsole
{
    class Program
    {
        public static SNSDBEntities db = new SNSDBEntities();
        static void Main(string[] args)
        {

            //TestFirstOrDefault();
            //TestAdd();
            //TestUpdate();
            //TestRemove();
            //TestExecuteSqlCommand();
            //TestExecuteSqlCommandWithoutParm();


        }

        private static void TestExecuteSqlCommandWithoutParm()
        {
            int intReturnValue =
                db.Database.ExecuteSqlCommand("update SNS_User_Info set SNS_User_PassWord='123456' where SNS_User_Name='chu999chu999'");
            if (intReturnValue > 0)
            {
                Console.WriteLine("更新成功！");
            }
            else
            {
                Console.WriteLine("更新失败！");
            }
        }

        private static void TestExecuteSqlCommand()
        {
            int intReturnValue = db.Database.ExecuteSqlCommand("update SNS_User_Info set SNS_User_PassWord={0} where SNS_User_Name={1}",
                "654321", "chu999chu999");
            if (intReturnValue > 0)
            {
                Console.WriteLine("更新成功！");
            }
            else
            {
                Console.WriteLine("更新失败！");
            }
        }

        private static void TestRemove()
        {
            SNS_User_Info user =
                db.SNS_User_Info.FirstOrDefault(o => o.SNS_User_Name == "楚广明");
            db.SNS_User_Info.Remove(user);
            if (db.SaveChanges() > 0)
            {
                Console.WriteLine("删除成功！");
            }
            else
            {
                Console.WriteLine("删除失败！");
            }
        }

        private static void TestUpdate()
        {
            SNS_User_Info users =
                db.SNS_User_Info.FirstOrDefault(o => o.SNS_User_Name == "chu888chu888");
            users.SNS_User_Name = "楚广明";
            if (db.SaveChanges() > 0)
            {
                Console.WriteLine("保存成功！");
            }
            else
            {
                Console.WriteLine("保存失败");
            }
            SNS_User_Info users2 =
                db.SNS_User_Info.FirstOrDefault(o => o.SNS_User_Email == "chu888chu888@gmail.com");
            Console.WriteLine("修改之后查询到的用户名为：{0}", users2.SNS_User_Name);
        }

        private static void TestAdd()
        {
            SNS_User_Info users = new SNS_User_Info();
            users.SNS_User_ID = Guid.NewGuid().ToString();
            users.SNS_User_Email = "chu888chu888@gmail.com";
            users.SNS_User_Name = "chu888chu888";
            users.SNS_User_PassWord = "123456";
            db.SNS_User_Info.Add(users);
            db.SaveChanges();
            SNS_User_Info users2 =
                db.SNS_User_Info.FirstOrDefault(o => o.SNS_User_Name == "chu888chu888");
            Console.WriteLine("查询出来的用户邮件为：{0}", users2.SNS_User_Email);
        }

        private static void TestFirstOrDefault()
        {

            SNS_User_Info users =
                db.SNS_User_Info.FirstOrDefault(o => o.SNS_User_Name == "chu999chu999");
            Console.WriteLine("用户名为：{0}", users.SNS_User_Name);
            Console.WriteLine();
        }

    }
}
