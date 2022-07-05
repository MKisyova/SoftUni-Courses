using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Func<int[], int> func = numbers =>
            {
                int minNum = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number <= minNum)
                    {
                        minNum = number;
                    }
                }

                return minNum;
            };

            Console.WriteLine(func(numbers));
        }

        //static int SmallestNumber (int[] arrayOfNumbers)
        //{
        //    int minNum = int.MaxValue;

        //    foreach (var number in arrayOfNumbers)
        //    {
        //        if (number <= minNum)
        //        {
        //            minNum = number;
        //        }
        //    }

        //    return minNum;
        //}
    }
}
