using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_1_a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string file = @"D:\test\example.txt";
                FileStream fs = new FileStream(file, FileMode.Create);
                byte[] bdata = Encoding.Default.GetBytes(DateTime.Now.ToString());
                fs.Write(bdata, 0, bdata.Length);
                Console.WriteLine("Data Added");
                fs.Close();
                string data;
                FileStream fsread = new FileStream(file, FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(fsread))
                {
                    data = sr.ReadToEnd();
                }
                Console.WriteLine(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            Console.ReadLine();
        }
    }
}
