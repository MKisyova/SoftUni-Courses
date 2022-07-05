using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> symbolOccurences = new SortedDictionary<char, int>();

            foreach (var symbol in text)
            {
                if (!symbolOccurences.ContainsKey(symbol))
                {
                    symbolOccurences.Add(symbol, 0);
                }

                symbolOccurences[symbol]++;
            }

            foreach (var item in symbolOccurences)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
