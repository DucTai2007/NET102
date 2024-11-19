using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_1_c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = @"D:\test\example.txt";
            //Writing File
            using (TextWriter writer = File.CreateText(file))
            {
                writer.WriteLine(DateTime.Now.ToString());
                Console.WriteLine("Successfully Added Current Date and Time");
            }
            //Reading File
            using (TextReader reader = File.OpenText(file))
            {
                Console.Write("Reading Current Time : ");
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
