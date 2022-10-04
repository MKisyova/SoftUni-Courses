using System;

namespace GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<string> elements = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string inputElement = Console.ReadLine();
                elements.Add(inputElement);
            }

            string elementToCompare = Console.ReadLine();

            int resultOfCompare = elements.CompareElements(elementToCompare);

            Console.WriteLine(resultOfCompare);
        }
    }
}
