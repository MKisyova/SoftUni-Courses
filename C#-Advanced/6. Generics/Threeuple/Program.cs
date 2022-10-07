using System;
using System.Linq;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInputData = Console.ReadLine().Split();

            string firstName = personInputData[0];
            string lastName = personInputData[1];
            string address = personInputData[2];
            string town = string.Join(" ", personInputData.Skip(3));

            string fullName = $"{firstName} {lastName}";

            Threeuple<string, string, string> person = new Threeuple<string, string, string>(fullName, address, town);

            string[] beerInputData = Console.ReadLine().Split();

            string name = beerInputData[0];
            int amountOfBeer = int.Parse(beerInputData[1]);
            bool isDrunk = beerInputData[2] == "drunk";

            Threeuple<string, int, bool> amountOfBeerPerPerson = new Threeuple<string, int, bool>(name, amountOfBeer, isDrunk);

            string[] bankInputData = Console.ReadLine().Split();

            string accountName = bankInputData[0];
            double accountBalance = double.Parse(bankInputData[1]);
            string bankName = bankInputData[3];

            Threeuple<string, double, string> bankDetails = new Threeuple<string, double, string>(accountName, accountBalance, bankName);

            Console.WriteLine(person.ToString());
            Console.WriteLine(amountOfBeerPerPerson.ToString());
            Console.WriteLine(bankDetails.ToString());
        }
    }
}
