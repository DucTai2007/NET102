using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_2_b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = new
            {
                Id = 1,
                Name = "Suresh Dasari",
                IsActive = true,
                JobInfo = new { Designation = "Lead", Location = "Hyderabad" }
            };
            Console.WriteLine("Id: " + user.Id);
            Console.WriteLine("Name: " + user.Name);
            Console.WriteLine("IsActive: " + user.IsActive);
            Console.WriteLine("Designation: {0}, Location: {1}", user.JobInfo.Designation, user.JobInfo.Location);
        }
    }
}
