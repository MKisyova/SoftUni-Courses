using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInputInfo = Console.ReadLine().Split(" ");

            double carFuelQuantity = double.Parse(carInputInfo[1]);
            double carFuelConsumption = double.Parse(carInputInfo[2]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumption);

            string[] truckInputInfo = Console.ReadLine().Split(" ");

            double truckFuelQuantity = double.Parse(truckInputInfo[1]);
            double truckFuelConsumption = double.Parse(truckInputInfo[2]);

            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] commands = Console.ReadLine().Split(" ");

                string action = commands[0];
                string vehicleType = commands[1];


                if (action == "Drive")
                {
                    double distance = double.Parse(commands[2]);

                    string result = vehicleType == "Car" ? car.Drive(distance) : truck.Drive(distance);
                    Console.WriteLine(result);
                }

                else if (action == "Refuel")
                {
                    double refuel = double.Parse(commands[2]);

                    if (vehicleType == "Car")
                    {
                        car.Refuel(refuel);
                    }

                    else
                    {
                        truck.Refuel(refuel);
                    }

                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
