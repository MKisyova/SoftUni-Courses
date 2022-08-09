using System;

namespace Template
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough bread (20 minutes).");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Sourdough bread.");
        }
    }
}
