using System.Collections.Generic;

namespace PokemonTrainer
{
    class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Pokemon = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int BadgesNumber { get; set; } = 0;
        public List<Pokemon> Pokemon { get; set; }


    }
}
