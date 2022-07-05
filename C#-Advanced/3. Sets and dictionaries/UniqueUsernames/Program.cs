using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string inputName = Console.ReadLine();
                names.Add(inputName);
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
