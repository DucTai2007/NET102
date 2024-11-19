using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_2_a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInfo = new 
            {
                Id = 1,
                Name = "Suresh Dasari",
                IsActive = true
            };
            Console.WriteLine("Id: " + userInfo.Id);
            Console.WriteLine("Name: " + userInfo.Name);
            Console.WriteLine("IsActive: " + userInfo.IsActive);
            Console.ReadLine();
        }
    }
}
