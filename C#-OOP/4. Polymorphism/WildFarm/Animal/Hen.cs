using WildFarm.Food;

namespace WildFarm.Animal
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void CanEat(IFood food)
        {
            Weight += 0.35 * food.Quantity;
            FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
