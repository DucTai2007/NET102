using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_1_c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetDetails(100);
            GetDetails("Welcome to FPoly");
            GetDetails(true);
            GetDetails(20.50);
            Console.ReadLine();
        }
        static void GetDetails(dynamic d)
        {
            Console.WriteLine(d);
        }
    }
}
