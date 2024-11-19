using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bài_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Tạo thư mục
                string directoryPath = @"D:\example";
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine("Directory Created Successfully. Information of Directory:");

                // Thông tin về thư mục
                DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
                Console.WriteLine("\nDirectory Name : " + dirInfo.Name);
                Console.WriteLine("\nPath : " + dirInfo.FullName);
                Console.WriteLine("\nDirectory is created on : " + dirInfo.CreationTime);
                Console.WriteLine("\nDirectory is Last Accessed : " + dirInfo.LastAccessTime);

                // Tạo và ghi vào tệp
                string filePath = Path.Combine(directoryPath, "test.txt");
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Hello File Handling");
                    Console.WriteLine("\n\n\nFile 'test.txt' has been created and the content has been written to.");
                }

                // Thông tin về tệp
                FileInfo fileInfo = new FileInfo(filePath);
                Console.WriteLine("\n\n\n******Display File Info******");
                Console.WriteLine("\nFile Create on : " + fileInfo.CreationTime);
                Console.WriteLine("\nDirectory Name : " + fileInfo.DirectoryName);
                Console.WriteLine("\nFull Name of File : " + fileInfo.FullName);
                Console.WriteLine("\nFile is Last Accessed on : " + fileInfo.LastAccessTime);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nAn error has occurred: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
