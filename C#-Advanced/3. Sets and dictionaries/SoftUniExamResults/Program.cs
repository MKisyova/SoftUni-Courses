using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var participants = new Dictionary<string, Dictionary<string, int>>();

            var submissions = new Dictionary<string, int>();

            while (input != "exam finished")
            {
                string[] splittedInput = input.Split("-");

                string username = splittedInput[0];

                if (splittedInput.Length == 2)
                {
                    if (participants.ContainsKey(username))
                    {
                        participants.Remove(username);
                    }
                }

                else
                {
                    string language = splittedInput[1];

                    int points = int.Parse(splittedInput[2]);

                    if (!participants.ContainsKey(username))
                    {
                        participants.Add(username, new Dictionary<string, int>());
                    }

                    if (!participants[username].ContainsKey(language))
                    {
                        participants[username].Add(language, points);
                    }

                    else if (participants[username][language] < points)
                    {
                        participants[username][language] = points;
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }

                    submissions[language]++;

                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var participant in participants.OrderByDescending(x => x.Value.Values.First()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{participant.Key} | {participant.Value.Values.First()}");
            }

            Console.WriteLine("Submissions:");

            foreach (var language in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
