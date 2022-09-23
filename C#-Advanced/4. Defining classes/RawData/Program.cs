using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                float tire1Pressure = float.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);

                float tire2Pressure = float.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);

                float tire3Pressure = float.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);

                float tire4Pressure = float.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Engine engine = new Engine(engineSpeed, enginePower);

                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Tire tire1 = new Tire(tire1Age, tire1Pressure);
                Tire tire2 = new Tire(tire2Age, tire2Pressure);
                Tire tire3 = new Tire(tire3Age, tire3Pressure);
                Tire tire4 = new Tire(tire4Age, tire4Pressure);

                List<Tire> tires = new List<Tire> { tire1, tire2, tire3, tire4 };

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(x => x.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);

                }
            }

            else
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power >= 250))
                {
                    Console.WriteLine(car.Model);
                }

            }
        }
    }
}
