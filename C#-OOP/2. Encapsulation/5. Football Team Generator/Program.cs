using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            while (input != "END")
            {

                string[] splittedInputData = input.Split(";");
                string action = splittedInputData[0];

                try
                {

                    if (action == "Team")
                    {
                        string teamName = splittedInputData[1];
                        Team team = new Team(teamName);

                        teams.Add(teamName, team);
                    }

                    else if (action == "Add")
                    {
                        string teamName = splittedInputData[1];

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            input = Console.ReadLine();
                            continue;
                        }

                        string playerName = splittedInputData[2];

                        int endurance = int.Parse(splittedInputData[3]);
                        int sprint = int.Parse(splittedInputData[4]);
                        int dribble = int.Parse(splittedInputData[5]);
                        int passing = int.Parse(splittedInputData[6]);
                        int shooting = int.Parse(splittedInputData[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        teams[teamName].AddPlayer(player);

                    }

                    else if (action == "Remove")
                    {
                        string teamName = splittedInputData[1];
                        string playerName = splittedInputData[2];

                        teams[teamName].RemovePlayer(playerName);
                    }

                    else if (action == "Rating")
                    {
                        string teamName = splittedInputData[1];

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            input = Console.ReadLine();
                            continue;
                        }

                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
