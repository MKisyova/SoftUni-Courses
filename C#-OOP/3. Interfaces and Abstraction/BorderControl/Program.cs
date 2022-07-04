using BorderControl.Interfaces;
using BorderControl.Members;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> buyersOfFood = new Dictionary<string, IBuyer>();

            for (int i = 0; i < number; i++)
            {
                string[] commandInput = Console.ReadLine().Split(" ");

                if (commandInput.Length == 4)
                {
                    string name = commandInput[0];
                    int age = int.Parse(commandInput[1]);
                    string identityNumber = commandInput[2];
                    string birthdate = commandInput[3];

                    IBuyer citizen = new Citizen(name, age, identityNumber, birthdate);

                    buyersOfFood.Add(name, citizen);
                }

                else if (commandInput.Length == 3)
                {
                    string name = commandInput[0];
                    int age = int.Parse(commandInput[1]);
                    string group = commandInput[2];

                    IBuyer rebel = new Rebel(name, age, group);

                    buyersOfFood.Add(name, rebel);
                }
            }

            while (true)
            {
                string inputName = Console.ReadLine();

                if (inputName == "End")
                {
                    break;
                }

                else if (!buyersOfFood.ContainsKey(inputName))
                {
                    continue;
                }

                else
                {
                    buyersOfFood[inputName].BuyFood();
                }

            }

            int totalFoodBought = buyersOfFood.Sum(x => x.Value.Food);

            Console.WriteLine(totalFoodBought);
        }
    }
}
