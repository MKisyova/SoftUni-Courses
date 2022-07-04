using System;
using WildFarm.Food;

namespace WildFarm.Animal
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
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
                Weight += 0.4 * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
