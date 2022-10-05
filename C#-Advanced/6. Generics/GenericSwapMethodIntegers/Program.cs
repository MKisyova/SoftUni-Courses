using System;

namespace GenericSwapMethodIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBoxes = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Add(input);
            }

            string[] elementsToSwap = Console.ReadLine().Split(" ");

            int firstElementToBeSwapped = int.Parse(elementsToSwap[0]);
            int secondElementToBeSwapped = int.Parse(elementsToSwap[1]);

            box.Swap(firstElementToBeSwapped, secondElementToBeSwapped);

            Console.WriteLine(box.ToString());
        }
    }
}
