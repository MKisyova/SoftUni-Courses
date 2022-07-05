using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string following = "following";
            string follower = "follower";

            while (input != "Statistics")
            {
                string[] inputCommand = input.Split();

                string user = inputCommand[0];
                string command = inputCommand[1];
                string starUser = inputCommand[2];
                                
                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(user))
                    {
                        vloggers.Add(user, new Dictionary<string, HashSet<string>>());

                        vloggers[user].Add(following, new HashSet<string>());
                        vloggers[user].Add(follower, new HashSet<string>());
                    }
                }

                else if (command == "followed" && vloggers.ContainsKey(user) 
                    && vloggers.ContainsKey(starUser) 
                    && !vloggers[starUser][follower].Contains(user) && user != starUser)
                {
                    vloggers[user][following].Add(starUser);
                    vloggers[starUser][follower].Add(user);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int count = 1;

            foreach (var vlogger in vloggers.OrderByDescending(x => x.Value[follower].Count)
                .ThenBy(x => x.Value[following].Count))
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value[follower].Count} followers, {vlogger.Value[following].Count} following");

                if (count == 1)
                {
                    foreach (var person in vlogger.Value[follower].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {person}");
                    }
                }

                count++;
            }
        }
    }
}
