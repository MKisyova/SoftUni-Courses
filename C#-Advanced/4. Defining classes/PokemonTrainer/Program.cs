using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (command != "Tournament")
            {
                string[] inputInfo = command.Split(" ");

                string trainerName = inputInfo[0];
                string pokemonName = inputInfo[1];
                string pokemonElement = inputInfo[2];
                int pokemonHealth = int.Parse(inputInfo[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    trainers.Add(trainerName, newTrainer);
                }

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                Trainer trainer = trainers[trainerName];

                trainer.Pokemon.Add(pokemon);

                command = Console.ReadLine();
            }

            string inputCommand = Console.ReadLine();

            while (inputCommand != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemon.Any(x => x.Element == inputCommand))
                    {
                        trainer.Value.BadgesNumber++;
                    }

                    else
                    {

                        foreach (var pokemon in trainer.Value.Pokemon)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Value.Pokemon.RemoveAll(x => x.Health <= 0);
                    }
                }

                inputCommand = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Value.BadgesNumber))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.BadgesNumber} {trainer.Value.Pokemon.Count}");
            }

        }
    }
}
