using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_2
{
    class Student
    {
        public static string StudentName;
        public static string Course;
        public void SetStudentDetails(string StuName, string Cou)
        {
            StudentName = StuName;
            Course = Cou;
        }
        public void DisplayStudentDetails()
        {
            Console.WriteLine(StudentName + " - " + Course);
        }

        public static string CollegeName = "FPT Polytechnic";
        public static string CollegeAddress = "391A Nam Kỳ Khởi Nghĩa, Phường 8, Quận 3, Hồ Chí Minh";

        public static void DisplayCollegeDetails()
        {
            Console.WriteLine(CollegeName);
            Console.WriteLine(CollegeAddress);
        }
    }
}
