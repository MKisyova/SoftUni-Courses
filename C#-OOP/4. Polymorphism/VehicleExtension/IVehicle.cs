
namespace VehiclesExtension
{
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        void Refuel(double liters);

        string Drive(double distance);

    }
}
