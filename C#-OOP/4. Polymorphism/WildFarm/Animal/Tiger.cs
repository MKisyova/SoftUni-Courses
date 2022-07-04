using System;
using WildFarm.Food;

namespace WildFarm.Animal
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
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
                Weight += 1 * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
