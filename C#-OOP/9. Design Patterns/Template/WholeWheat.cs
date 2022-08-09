using System;

namespace Template
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheat bread (15 minutes).");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Whole Wheat bread.");
        }
    }
}
