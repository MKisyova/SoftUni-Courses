using System;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commandInfo = input.Split(" ");

                string name = commandInfo[0];
                string country = commandInfo[1];
                int age = int.Parse(commandInfo[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson personName = citizen;
                IResident residentName = citizen;

                Console.WriteLine(personName.GetName(citizen.Name));
                Console.WriteLine(residentName.GetName(citizen.Name));

                input = Console.ReadLine();
            }

        }
    }
}
