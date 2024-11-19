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
            List<Dog> dogs = new List<Dog>()
            {
            new Dog { Name = "Rex", Age = 4 },
            new Dog { Name = "Sean", Age = 0 },
            new Dog { Name = "Stacy", Age = 3 }
            };

            var dogInfo = dogs.Select(d => new { d.Name, d.Age });

            foreach (var dog in dogInfo)
            {
                Console.WriteLine($"Name: {dog.Name}, Age: {dog.Age}");

            }
            Console.ReadKey();
        }
    }
}
