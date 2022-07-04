using WildFarm.Food;

namespace WildFarm.Animal
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public abstract string ProduceSound();

        public abstract void CanEat(IFood food);

    }
}
