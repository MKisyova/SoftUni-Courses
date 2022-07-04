using System;
using WildFarm.Food;

namespace WildFarm.Animal
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void CanEat(IFood food)
        {
            if (food.GetType().Name != "Meat")
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            else
            {
                Weight += 0.25 * food.Quantity;

                FoodEaten += food.Quantity;
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
