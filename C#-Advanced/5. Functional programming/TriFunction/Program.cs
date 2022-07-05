using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(" ");

            Func<string, int, bool> isLarger = (name, asciiSum) => name.Sum(x => x) >= asciiSum;


            Func<string[], Func<string, int, bool>, string> firstName = (allNames, function) => allNames.FirstOrDefault(x => function(x, num));


            string winnerName = firstName(names, isLarger);

            Console.WriteLine(winnerName);

        }
    }
}
