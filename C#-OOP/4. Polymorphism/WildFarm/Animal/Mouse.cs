using System;
using WildFarm.Food;

namespace WildFarm.Animal
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void CanEat(IFood food)
        {
            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Fruit")
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            else
            {
                Weight += 0.1 * food.Quantity;

                FoodEaten += food.Quantity;
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
