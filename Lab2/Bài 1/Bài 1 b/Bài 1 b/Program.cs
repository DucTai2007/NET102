using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_1_b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, int>();
            data.Add("cat", 2);
            data.Add("dog", 1);
            Console.WriteLine("cat - dog = {0}",
                data["cat"] - data["dog"]);
        }
    }
}
