using System;
using WildFarm.Food;

namespace WildFarm.Animal
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void CanEat(IFood food)
        {
            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            else
            {
                Weight += 0.3 * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
