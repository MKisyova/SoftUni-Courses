using MilitaryElite.Interfaces;
using MilitaryElite.Members;
using MilitaryElite.MissionsAndRepairs;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<int, ISoldier> soldiers = new Dictionary<int, ISoldier>();

            while (input != "End")
            {
                string[] commandInfo = input.Split(" ");

                string action = commandInfo[0];

                int id = int.Parse(commandInfo[1]);
                string firstName = commandInfo[2];
                string lastName = commandInfo[3];

                if (action == "Private")
                {
                    decimal salary = decimal.Parse(commandInfo[4]);
                    IPrivate privateSoldier = new Private(id, firstName, lastName, salary);
                    soldiers.Add(id, privateSoldier);
                }

                else if (action == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(commandInfo[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < commandInfo.Length; i++)
                    {
                        int idPrivate = int.Parse(commandInfo[i]);

                        IPrivate privateSoldier = soldiers[idPrivate] as IPrivate;

                        lieutenantGeneral.Privates.Add(privateSoldier);
                    }

                    soldiers.Add(id, lieutenantGeneral);
                }

                else if (action == "Engineer")
                {
                    decimal salary = decimal.Parse(commandInfo[4]);
                    string corp = commandInfo[5];

                    bool isValidEnum = Enum.TryParse(corp, out Corps result);

                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, result);

                    for (int i = 6; i < commandInfo.Length; i+= 2)
                    {
                        string partName = commandInfo[i];
                        int workingHours = int.Parse(commandInfo[i + 1]);

                        IRepair repair = new Repair(partName, workingHours);

                        engineer.Repairs.Add(repair);
                    }

                    soldiers.Add(id, engineer);
                }

                else if (action == "Commando")
                {
                    decimal salary = decimal.Parse(commandInfo[4]);
                    string corp = commandInfo[5];

                    bool isValidEnum = Enum.TryParse(corp, out Corps result);

                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, result);

                    for (int i = 6; i < commandInfo.Length; i += 2)
                    {
                        string codeName = commandInfo[i];
                        string status = commandInfo[i + 1];

                        bool isValidEnumMission = Enum.TryParse(status, out Status resultStatus);

                        if (!isValidEnumMission)
                        {
                            continue;
                        }

                        IMission mission = new Mission(codeName, resultStatus);

                        commando.Missions.Add(mission);
                    }

                    soldiers.Add(id, commando);
                }

                else if (action == "Spy")
                {
                    int codeNumber = int.Parse(commandInfo[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(id, spy);
                }

                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    }
}
