using System;

namespace DayDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayOne = Console.ReadLine();
            string dayTwo = Console.ReadLine();

            int days = DateModifier.CalculateDateDifference(dayOne, dayTwo);

            Console.WriteLine(days);
        }
    }
}
