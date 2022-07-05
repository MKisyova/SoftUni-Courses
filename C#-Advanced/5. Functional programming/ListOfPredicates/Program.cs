using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] numbers = Enumerable.Range(1, num).ToArray();

            int[] divisibleNums = Console.ReadLine().Split(" ").Select(int.Parse).Distinct().ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var number in divisibleNums)
            {
                predicates.Add(x => x % number == 0);
            }

            foreach (var number in numbers)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
