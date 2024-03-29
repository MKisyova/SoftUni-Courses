﻿
namespace Vehicles
{
    public class Truck : Vehicle
    {

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption = fuelConsumption + 1.6;
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * 0.95);
        }

    }
}
