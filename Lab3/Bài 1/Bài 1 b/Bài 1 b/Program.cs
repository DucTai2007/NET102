using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_1_b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                string file = @"D:\test\example.txt";
                //Creating and Writting
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.Write(DateTime.Now.ToString());
                    Console.WriteLine("Successfully Added Current Date and Time");
                }
                //Reading File
                using (StreamReader reader = new StreamReader(file))
                {
                    Console.Write("Reading Current Time : ");
                    Console.WriteLine(reader.ReadToEnd());
                }

            }
        }
    }
}

