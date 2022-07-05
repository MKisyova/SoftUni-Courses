using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> text = new Stack<string>();
            Stack<int> counter = new Stack<int>();

            int pushingTimes = 0;
            int popingTimes = 0;

            Stack<string> popping = new Stack<string>();

            for ( int j = 0; j < n; j ++)
            {
                string[] command = Console.ReadLine().Split(" ");

                if (command[0] == "1")
                {
                    pushingTimes = 0;

                    for (int i = 1; i < command.Length; i++)
                    {
                        text.Push(command[i]);
                        pushingTimes++;
                    }

                    counter.Push(1);
                }

                if (command[0] == "2")
                {
                    popingTimes = 0;

                    for (int i = 0; i < int.Parse(command[1]); i++)
                    {
                        popping.Push(text.Peek());
                        text.Pop();
                        popingTimes++;
                    }

                    counter.Push(2);
                }

                if (command[0] == "3")
                {
                    string[] stackToArray = text.ToArray();

                    int position = int.Parse(command[1]);

                    Console.WriteLine(stackToArray[position]);
                
                }

                if (command[0] == "4")
                {
                    if (counter.Pop() == 1)
                    {
                        for (int i = 0; i < pushingTimes; i++)
                        {
                            text.Pop();
                        }
                    }

                    if (counter.Pop() == 2)
                    {
                        for (int i = 0; i < popingTimes; i++)
                        {
                            foreach (var symbol in popping)
                            {
                                text.Push(symbol);
                            }
                        }
                    }
                }

            }
        }
    }
}
