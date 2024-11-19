using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ass
{
    internal class Program
    {
        static List<Class> classes = new List<Class>();
        static List<Student> students = new List<Student>();
        private static string connectionString = @"Data Source=localhost;Initial Catalog=ASM_C#2;Integrated Security=True;";
        
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Write("---------------------------MENU---------------------------\n");
                Console.Write("1.Nhap danh sach hoc vien.\n");
                Console.Write("2.Xuat danh sach hoc vien.\n");
                Console.Write("3.Tim kiem hoc vien theo diem.\n");
                Console.Write("4.Tim kiem hoc vien theo StId va cap nhap thong tin.\n");
                Console.Write("5.Sap xep hoc vien.\n");
                Console.Write("6.Xuat 5 hoc vien co diem cao nhat.\n");
                Console.Write("7.Tinh diem trung binh theo tung lop.\n");
                Console.Write("0.Thoat\n");
                Console.Write("-----------------------------------------------------------\n");
                Console.Write("Hay chon: ");
                string tmpS = Console.ReadLine();
                choice = int.Parse(tmpS);

                switch (choice)
                {
                    case 1:
                        Nhap();
                        break;
                    case 2:
                        Xuat();
                        break;
                    case 3:
                        timkiemTheoDiem();
                        break;
                    case 4:
                        TimVaCapNhap();
                        break;
                    case 5:
                        SapXep();
                        break;
                    case 6:
                        HienThiTop5();
                        break;
                    case 7:
                        TinhDiemTB();
                        break;
                    case 0:
                        Console.WriteLine("Thoat truong chinh");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le");
                        break;
                }
            } while (choice != 0);

        }
        static void Nhap()
        {
            List<Class> classes = new List<Class>();
            List<Student> students = new List<Student>();

            Console.Write("Nhap so luong lop: ");
            int numClasses = int.Parse(Console.ReadLine());
            for (int i = 0; i < numClasses; i++)
            {
                Class newClass = new Class();
                Console.Write("Nhap ten lop: ");
                newClass.NameClass = Console.ReadLine();
                classes.Add(newClass);
            }

            Console.Write("\nNhap so luong sinh vien: ");
            int numStudents = int.Parse(Console.ReadLine());
            for (int i = 0; i < numStudents; i++)
            {
                Student newStudent = new Student();
                Console.Write("\nNhap ten sinh vien: ");
                newStudent.Name = Console.ReadLine();
                Console.Write("Nhap ID sinh vien: ");
                newStudent.StId = Console.ReadLine();
                Console.Write("Nhap diem: ");
                newStudent.Mark = double.Parse(Console.ReadLine());
                Console.Write("Nhap email: ");
                newStudent.Email = Console.ReadLine();
                Console.Write("Nhap IdClass: ");
                newStudent.IdClass = int.Parse(Console.ReadLine());
                students.Add(newStudent);
            }

            using (dbASMDataContext db = new dbASMDataContext())
            {
                db.Classes.InsertAllOnSubmit(classes);
                db.Students.InsertAllOnSubmit(students);

                db.SubmitChanges();
            }
        }

        static void Xuat()
        {
            dbASMDataContext dbASMDataContext = new dbASMDataContext(connectionString);
            var studentList = dbASMDataContext.Students.Select(s => new
            {
                s.Name,
                s.Mark,
                s.Email,
                s.IdClass,
                HocLuc = s.Mark < 3 ? "Yeu" :
                         s.Mark < 5 ? "Yeu" :
                         s.Mark < 6.5 ? "Trung Binh" :
                         s.Mark < 7.5 ? "Kha" :
                         s.Mark < 9 ? "Gioi" :
                         "Xuat Sac"
            });

            foreach (var student in studentList)
            {
                Console.WriteLine($"\nTen: {student.Name}\nDiem: {student.Mark}\nEmail: {student.Email}\nHoc luc: {student.HocLuc}");
            }
        }

        static void timkiemTheoDiem()
        {
            Console.Write("Nhap diem thap nhat: ");
            double minMark = double.Parse(Console.ReadLine());
            Console.Write("Nhap diem cao nhat: ");
            double maxMark = double.Parse(Console.ReadLine());

            var searchedStudents = students.Where(s => s.Mark >= minMark && s.Mark <= maxMark);

            foreach (var student in searchedStudents)
            {
                Console.WriteLine($"\nTen: {student.Name}\nDiem: {student.Mark}\nEmail: {student.Email}");
            }
        }

        static void TimVaCapNhap()
        {
            Console.Write("Nhap Id sinh vien: ");
            string searchId = Console.ReadLine();
            var studentToUpdate = students.FirstOrDefault(s => s.StId == searchId);

            if (studentToUpdate != null)
            {
                Console.Write("\nNhap ten moi: ");
                studentToUpdate.Name = Console.ReadLine();
                Console.Write("Nhap diem moi: ");
                studentToUpdate.Mark = double.Parse(Console.ReadLine());
                Console.Write("Nhap email moi: ");
                studentToUpdate.Email = Console.ReadLine();
                Console.Write("Nhap IdClass moi: ");
                studentToUpdate.IdClass = int.Parse(Console.ReadLine());

                Console.WriteLine("Cap nhap thong tin sinh vien thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien voi Id nay.");
            }
        }

        static void SapXep()
        {
            var sortedStudents = students.OrderByDescending(s => s.Mark);

            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"\nTen: {student.Name}\nDiem: {student.Mark}\nEmail: {student.Email}");
            }
        }

        static void HienThiTop5()
        {
            var top5Students = students.OrderByDescending(s => s.Mark).Take(5);

            foreach (var student in top5Students)
            {
                Console.WriteLine($"\nTen: {student.Name}\nDiem: {student.Mark}\nEmail: {student.Email}");
            }
        }

        static void TinhDiemTB()
        {
            Thread dtbThread = new Thread(() =>
            {
                Console.WriteLine("Thread DTB đang chạy...");
                using (dbASMDataContext db = new dbASMDataContext(connectionString))
                {
                    var classes = db.Classes.ToList();
                    using (StreamWriter writer = new StreamWriter(@"D:\ASM_C#2.txt", false))
                    {
                        writer.WriteLine("Điểm trung bình của từng lớp:");
                        foreach (var classInfo in classes)
                        {
                            var students = db.Students
                                    .Where(s => s.IdClass == classInfo.IdClass)
                                    .ToList();

                            if (students.Any())
                            {
                                var avg = students.Average(s => s.Mark);
                                writer.WriteLine($"Lớp ID: {classInfo.IdClass}, Tên lớp: {classInfo.NameClass}, Điểm trung bình: {avg}");
                            }
                            else
                            {
                                writer.WriteLine($"Lớp ID: {classInfo.IdClass}, Tên lớp: {classInfo.NameClass}, không có sinh viên");
                            }

                        }

                    }
                }
                Console.WriteLine("Thread DTB đã hoàn thành và ghi kết quả vào file.");
            })
            {
                Name = "DTB"
            };

            dtbThread.Start();
            dtbThread.Join();
        }
    }
}