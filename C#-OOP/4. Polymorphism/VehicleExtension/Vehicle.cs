using System;

namespace VehiclesExtension
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;

            if (fuelQuantity > tankCapacity)
            {
                FuelQuantity = 0;
            }
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }

            else
            {
                if (FuelQuantity + liters > TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }

                else
                {
                    FuelQuantity += liters;
                }
            }

        }

        public virtual string Drive(double distance)
        {
            double fuelNeeded = FuelConsumption * distance;
            if (FuelQuantity >= fuelNeeded)
            {
                FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled { distance} km";
            }

            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
