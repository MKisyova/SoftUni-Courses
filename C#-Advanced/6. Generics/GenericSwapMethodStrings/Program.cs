using System;

namespace GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBoxes = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                string input = Console.ReadLine();
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
