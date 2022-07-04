using System;

namespace VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInputInfo = Console.ReadLine().Split(" ");

            double carFuelQuantity = double.Parse(carInputInfo[1]);
            double carFuelConsumption = double.Parse(carInputInfo[2]);
            double carTankCapacity = double.Parse(carInputInfo[3]);

            Vehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            string[] truckInputInfo = Console.ReadLine().Split(" ");

            double truckFuelQuantity = double.Parse(truckInputInfo[1]);
            double truckFuelConsumption = double.Parse(truckInputInfo[2]);
            double truckTankCapacity = double.Parse(truckInputInfo[3]);

            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busInputInfo = Console.ReadLine().Split(" ");

            double busFuelQuantity = double.Parse(busInputInfo[1]);
            double busFuelConsumption = double.Parse(busInputInfo[2]);
            double busTankCapacity = double.Parse(busInputInfo[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] commands = Console.ReadLine().Split(" ");

                string action = commands[0];
                string vehicleType = commands[1];

                if (action == "Drive")
                {
                    double distance = double.Parse(commands[2]);

                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }

                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance)); 
                    }

                    else
                    {
                        Console.WriteLine(bus.Drive(distance)); 
                    }

                }

                else if (action == "DriveEmpty")
                {
                    double distance = double.Parse(commands[2]);
                    Console.WriteLine(bus.DriveEmpty(distance));
                }

                else if (action == "Refuel")
                {
                    double liters = double.Parse(commands[2]);

                    if (vehicleType == "Car")
                    {
                        car.Refuel(liters);
                    }

                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(liters);
                    }

                    else
                    {
                        bus.Refuel(liters);
                    }

                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
