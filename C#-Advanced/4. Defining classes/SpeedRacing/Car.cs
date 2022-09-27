using System;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; } = 0;

        public void CarMoving(double amountOfKm)
        {
            if (FuelAmount / FuelConsumptionPerKilometer >= amountOfKm)
            {
                FuelAmount -= amountOfKm * FuelConsumptionPerKilometer;
                TravelledDistance += amountOfKm;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }
    }
}
