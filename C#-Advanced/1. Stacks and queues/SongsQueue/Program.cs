using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            Queue<string> songs = new Queue<string>();

            foreach (var element in input)
            {
                songs.Enqueue(element);
            }

            while (songs.Count > 0)
            {
                string[] command = Console.ReadLine().Split(" ").ToArray();

                if (command[0] == "Play")
                {
                    songs.Dequeue();
                }

                if (command[0] == "Add")
                {
                    string songToAdd = "";

                    for (int i = 1; i < command.Length; i++)
                    {
                        songToAdd += command[i];

                        if (i < command.Length - 1)
                        {
                            songToAdd += " ";
                        }
                    }

                    if (!songs.Contains(songToAdd))
                    {
                        songs.Enqueue(songToAdd);
                    }

                    else
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                }

                if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
