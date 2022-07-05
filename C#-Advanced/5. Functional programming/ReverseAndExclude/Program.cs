using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int num = int.Parse(Console.ReadLine());

            Func<int, int, bool> divisibleNumbers = (x, y) => x % y == 0;

            int[] result = numbers.Where(x => !divisibleNumbers(x, num)).Reverse().ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
