using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_2
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayStudentDetails();

            Console.WriteLine();
            Student s1 = new Student();
            Student s2 = new Student();
            s1.SetStudentDetails("Thepv", "Phd");
            s2.SetStudentDetails("Nghiemn", "MBA");
            s1.DisplayStudentDetails();
            s2.DisplayStudentDetails();
            Console.Read();
        }
    }
}
