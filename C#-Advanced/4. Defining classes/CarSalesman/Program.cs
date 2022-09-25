using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < numberEngines; i++)
            {
                string[] inputData = Console.ReadLine().Split(" ");

                string model = inputData[0];
                int power = int.Parse(inputData[1]);

                Engine engine = new Engine(model, power);

                if (inputData.Length == 3)
                {
                    int displacement = 0;

                    if (int.TryParse(inputData[2], out displacement))
                    {
                        engine = new Engine(model, power, displacement);
                    }

                    else
                    {
                        string efficiency = inputData[2];
                        engine = new Engine(model, power, efficiency);
                    }
                    
                }

                else if (inputData.Length == 4)
                {
                    int displacement = int.Parse(inputData[2]);
                    string efficiency = inputData[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }

                engines.Add(engine);
            }

            int numberCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberCars; i++)
            {
                string[] inputData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = inputData[0];

                Engine engine = engines.FirstOrDefault(x => x.Model == inputData[1]);

                Car car = new Car(model, engine);

                if (inputData.Length == 3)
                {
                    int weight = 0;

                    if (int.TryParse(inputData[2], out weight))
                    {
                        car = new Car(model, engine, weight);
                    }

                    else
                    {
                        string color = inputData[2];
                        car = new Car(model, engine, color);
                    }
                    
                }

                else if (inputData.Length == 4)
                {
                    int weight = int.Parse(inputData[2]);
                    string color = inputData[3];

                    car = new Car(model, engine, weight, color);
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
