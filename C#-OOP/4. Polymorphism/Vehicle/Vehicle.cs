
namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }

        public string Drive(double distance)
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
