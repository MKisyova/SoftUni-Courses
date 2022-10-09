using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] personsData = Console.ReadLine().Split();

            string firstName = personsData[0];
            string lastName = personsData[1];
            string address = personsData[2];
            string fullName = $"{firstName} {lastName}";

            Tuple<string, string> person = new Tuple<string, string>(fullName, address);

            string[] beerData = Console.ReadLine().Split();

            string name = beerData[0];
            int amountOfBeer = int.Parse(beerData[1]);

            Tuple<string, int> amountOfBeerPerPerson = new Tuple<string, int>(name, amountOfBeer);

            string[] numbersData = Console.ReadLine().Split();

            int integerNumber = int.Parse(numbersData[0]);
            double doubleNumber = double.Parse(numbersData[1]);

            Tuple<int, double> numbers = new Tuple<int, double>(integerNumber, doubleNumber);

            Console.WriteLine(person.ToString());
            Console.WriteLine(amountOfBeerPerPerson.ToString());
            Console.WriteLine(numbers.ToString());

        }
    }
}
