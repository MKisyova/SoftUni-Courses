using System;

namespace Prototype
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichPrototype ShallowClone()
        {
            Console.WriteLine($"Cloning sandwich with ingredients: {GetIngredientsList()}");

            return MemberwiseClone() as SandwichPrototype; 
        }

        public override SandwichPrototype DeepClone()
        {
            string newBread = new string(this.bread);
            string newMeat = new string(this.meat);
            string newCheese = new string(this.cheese);
            string newVeggies = new string(this.veggies);

            Sandwich sandwich = new Sandwich(newBread, newMeat, newCheese, newVeggies);

            return sandwich;
        }

        private string GetIngredientsList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}
