using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Stack<string> stackCollection = new Stack<string>();

            while (command != "END")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = input[0];

                if (action == "Push")
                {
                    string[] elementsToAdd = input.Skip(1).Select(x => x.Split(",").First()).ToArray();

                    stackCollection.Push(elementsToAdd);
                }

                else if (action == "Pop")
                {
                    stackCollection.Pop();
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stackCollection)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
