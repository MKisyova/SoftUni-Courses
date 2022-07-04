using WildFarm.Food;

namespace WildFarm.Animal
{
    public interface IAnimal
    {
        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        string ProduceSound();

        public abstract void CanEat(IFood food);
    }
}
