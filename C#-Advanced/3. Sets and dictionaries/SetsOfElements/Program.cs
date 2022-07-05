using System;
using System.Collections.Generic;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            HashSet<int> firstHashSet = new HashSet<int>();
            HashSet<int> secondHashSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstHashSet.Add(num);
            }

            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondHashSet.Add(num);
            }

            foreach (var number in firstHashSet)
            {
                if (secondHashSet.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
