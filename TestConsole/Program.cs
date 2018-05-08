using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using Sunc.Framework.Repository.Utility.Excel;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Person o = new Person();
            o.Name = "孙超";
            o.Age = 24;

            Person o1 = new Person();
            o1.Name = "孙超2";
            o1.Age = 23;
            NPOIExcel<Person> e = new NPOIExcel<Person>(new List<Person> { o,o1 }, "姓名", "年龄");
            e.CreateSheet("A");
            HSSFWorkbook work = e.GenerateExcel();
            MemoryStream ms = new MemoryStream();
            work.Write(ms);
            var buf = ms.ToArray();
            //保存为Excel文件  
            using (FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory+"a.xls", FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
            Console.ReadKey();
        }
        class Person
        {
            public string Name { set; get; }
            public int Age { set; get; }
        }
    }
}
