using System;

namespace GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<double> elements = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double inputElement = double.Parse(Console.ReadLine());
                elements.Add(inputElement);
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            int resultOfCompare = elements.CompareElements(elementToCompare);

            Console.WriteLine(resultOfCompare);
        }
    }
}
