using System;
using System.Linq;

namespace ListyIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            ListyIterator<string> listy = null;

            while (input != "END")
            {
                string[] inputData = input.Split(" ");
                string action = inputData[0];

                if (action == "Create")
                {
                    listy = new ListyIterator<string>(inputData.Skip(1).ToArray());
                }

                else if (action == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }

                else if (action == "Move")
                {
                    Console.WriteLine(listy.Move());
                }

                else if (action == "Print")
                {
                    listy.Print();
                }

                else if (action == "PrintAll")
                {
                    listy.PrintAll();
                }

                input = Console.ReadLine();
            }
        }
    }
}
