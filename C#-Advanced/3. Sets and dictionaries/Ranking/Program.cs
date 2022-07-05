using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var contests = new Dictionary<string, string>();

            var candidates = new Dictionary<string, Dictionary<string, int>>();

            while (input != "end of contests")
            {
                string[] inputContest = input.Split(":");

                string firstContest = inputContest[0];
                string password = inputContest[1];

                if (!contests.ContainsKey(firstContest))
                {
                    contests.Add(firstContest, password);
                }

                input = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "end of submissions")
            {
                string[] submission = secondInput.Split("=>");

                string secondContest = submission[0];
                string secondPassword = submission[1];
                string username = submission[2];
                int points = int.Parse(submission[3]);

                if (contests.ContainsKey(secondContest))
                {
                    if (contests[secondContest] == secondPassword)
                    {
                        if (!candidates.ContainsKey(username))
                        {
                            candidates.Add(username, new Dictionary<string, int>());
                        }
                        
                        if (candidates[username].ContainsKey(secondContest))
                        {
                            if (candidates[username][secondContest] < points)
                            {
                                candidates[username][secondContest] = points;
                            }
                            
                        }

                        else
                        {
                            candidates[username].Add(secondContest, points);
                        }

                    }

                }

                secondInput = Console.ReadLine();
            }

            int maxPoint = int.MinValue;

            string userMaxPoint = string.Empty;

            foreach (var candidate in candidates)
            {
                int totalPoint = 0;
                foreach (var competition in candidate.Value)
                {
                    totalPoint += competition.Value;
                }

                if (totalPoint > maxPoint)
                {
                    maxPoint = totalPoint;
                    userMaxPoint = candidate.Key;
                }
            }

            Console.WriteLine($"Best candidate is {userMaxPoint} with total {maxPoint} points.");

            Console.WriteLine("Ranking:");

            foreach (var user in candidates.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);

                foreach (var competition in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {competition.Key} -> {competition.Value}");
                }
            }
        }
    }
}
