using System;
using System.Collections.Generic;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<IHero> heroes = new List<IHero>();

            for (int i = 0; i < number; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                IHero hero = null;

                if (heroType == "Druid")
                {
                    hero = new Druid(heroName);
                }

                else if (heroType == "Paladin")
                {
                    hero = new Paladin(heroName);
                }

                else if (heroType == "Rogue")
                {
                    hero = new Rogue(heroName);
                }

                else if (heroType == "Warrior")
                {
                    hero = new Warrior(heroName);
                }

                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;

                }

                heroes.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());
            int sumPowers = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                sumPowers += hero.Power;
            }

            if (sumPowers >= bossPower)
            {
                Console.WriteLine("Victory!");
            }

            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
