using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(" ").ToList();

            Func<string, int, bool> sortedNames = (name, num) => name.Length <= num;

            foreach (var name in names.Where(x => sortedNames(x, n)))
            {
                Console.WriteLine(name);
            }

        }
    }
}
