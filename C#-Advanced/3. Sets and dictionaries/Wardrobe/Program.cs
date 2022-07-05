using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < number; i++)
            {
                string[] inputClothes = Console.ReadLine().Split(" -> ");

                string color = inputClothes[0];

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                string[] clothPerColor = inputClothes[1].Split(",");

                for (int j = 0; j < clothPerColor.Length; j++)
                {
                    string cloth = clothPerColor[j];

                    if (!clothes[color].ContainsKey(cloth))
                    {
                        clothes[color].Add(cloth, 0);
                    }

                    clothes[color][cloth]++;
                }
            }

            string[] command = Console.ReadLine().Split();

            string existingColor = command[0];
            string existingCloth = command[1];

            foreach (var item in clothes)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var element in item.Value)
                {
                    if (item.Key == existingColor && element.Key == existingCloth)
                    {
                        Console.WriteLine($"* {element.Key} - {element.Value} (found!)");
                    }

                    else
                    {
                        Console.WriteLine($"* {element.Key} - {element.Value}");
                    }

                }
            }
        }
    }
}
