using System;
using System.Collections.Generic;
using WildFarm.Animal;
using WildFarm.Food;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<IAnimal> animals = new List<IAnimal>();

            while (input != "End")
            {
                string[] animalInfo = input.Split(" ");

                string animalType = animalInfo[0];

                IAnimal animal = null;

                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                if (animalType == "Owl")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = new Owl(name, weight, wingSize);
                }

                else if (animalType == "Hen")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = new Hen(name, weight, wingSize);
                }

                else if (animalType == "Mouse")
                {
                    string livingRegion = animalInfo[3];
                    animal = new Mouse(name, weight, livingRegion);
                }

                else if (animalType == "Dog")
                {
                    string livingRegion = animalInfo[3];
                    animal = new Dog(name, weight, livingRegion);
                }

                else if (animalType == "Cat")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];

                    animal = new Cat(name, weight, livingRegion, breed);
                }

                else if (animalType == "Tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];

                    animal = new Tiger(name, weight, livingRegion, breed);

                }

                input = Console.ReadLine();

                string[] foodInfo = input.Split(" ");

                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                IFood food = null;

                if (foodType == "Vegetable")
                {
                    food = new Vegetable(quantity);
                }

                else if (foodType == "Fruit")
                {
                    food = new Fruit(quantity);
                }

                else if (foodType == "Meat")
                {
                    food = new Meat(quantity);
                }

                else if (foodType == "Seeds")
                {
                    food = new Seeds(quantity);
                }

                Console.WriteLine(animal.ProduceSound());

                animal.CanEat(food);

                animals.Add(animal);

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
