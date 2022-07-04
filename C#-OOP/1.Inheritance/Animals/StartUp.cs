using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string animalType = Console.ReadLine();
                if (animalType == "Beast!")
                {
                    break;
                }

                string[] dataForAnimal = Console.ReadLine().Split(" ");

                string name = dataForAnimal[0];
                int age = int.Parse(dataForAnimal[1]);
                string gender = dataForAnimal[2];

                if (age < 0 || age >= 200)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }


                if (gender != "Male" && gender != "Female")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                Animal animal = new Animal(name, age, gender);
                if (animalType == "Frog")
                {
                    animal = new Frog(name, age, gender);
                }

                else if (animalType == "Dog")
                {
                    animal = new Dog(name, age, gender);
                }

                else if (animalType == "Cat")
                {

                    animal = new Cat(name, age, gender);
                }

                else if (animalType == "Tomcat")
                {
                    animal = new Tomcat(name, age);
                }

                else if (animalType == "Kitten")
                {
                    animal = new Kitten(name, age);
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                Console.Write(animal.ToString());
            }


        }
    }
}
