using System;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = input => Console.WriteLine(string.Join(Environment.NewLine, input));

            string[] names = Console.ReadLine().Split(" ");

            print(names);

        }
    }
}
