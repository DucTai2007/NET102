using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_1_d
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void GetDetails()
        {
            var d = "khong co gi dau out di";
            Console.WriteLine(d);
        }
    }
}
