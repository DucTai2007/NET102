using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_2_c
{
    internal class Program
    {
        delegate void MathOps(int a);
        static void Main(string[] args)
        {
            int y = 10;

            // Khởi tạo delegate bằng Anonymous method
            MathOps ops = delegate (int x)
            {
                Console.WriteLine("Add Result: {0}", x + y);
                Console.WriteLine("Subtract Result: {0}", x - y);
            };

            // Gọi Anonymous method
            ops(90);

            Console.ReadLine();
        }
    }
}
