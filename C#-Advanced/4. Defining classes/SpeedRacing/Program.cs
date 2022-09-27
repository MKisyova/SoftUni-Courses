using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < number; i++)
            {
                string[] inputInfo = Console.ReadLine().Split(" ");

                string model = inputInfo[0];
                double fuelAmount = double.Parse(inputInfo[1]);
                double fuelConsumptionFor1km = double.Parse(inputInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] driveInfo = command.Split(" ");
                string carModel = driveInfo[1];
                double amountOfKm = double.Parse(driveInfo[2]);

                foreach (var car in cars)
                {
                    if (car.Model == carModel)
                    {
                        car.CarMoving(amountOfKm);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
