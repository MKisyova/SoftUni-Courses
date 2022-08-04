namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [TestCase("Toyota", "Corolla", 5.5, 55.5)]
        [TestCase("Audi", "A7", 7, 80)]
        [TestCase("BMW", "Z4", 10, 100)]
        public void ConstructorShouldSetEverythingIfDataIsValid
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [TestCase("")]
        [TestCase(null)]
        public void ConstructorShouldThrowExceptionWhenMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "Some model", 5.5, 55.5));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ConstructorShouldThrowExceptionWhenModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("Toyota", model, 5.5, 55.5));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-123456.78)]
        public void ConstructorShouldThrowExceptionWhenFuelConsumptionIsZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Toyota", "Corolla", fuelConsumption, 55.5));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-123456.78)]
        public void ConstructorShouldThrowExceptionWhenFuelCapacityIsZeroOrNegative(double fuelCapacity)
        {           
            Assert.Throws<ArgumentException>(() => new Car("Toyota", "Corolla", 5.5 , fuelCapacity));
        }

        [TestCase(1, 5)]
        [TestCase(5.5, 10)]
        [TestCase(55.5, 1)]
        public void RefuelShouldAddFuelAmount(double fuelToRefuel, int timesToRefuel)
        {
            Car car = new Car("Toyota", "Corolla", 5.5, 55.5);

            for (int i = 0; i < timesToRefuel; i++)
            {
                car.Refuel(fuelToRefuel);
            }

            double expectedResult = fuelToRefuel * timesToRefuel;

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [TestCase(10, 6)]
        [TestCase(5.5, 100)]
        [TestCase(55.5, 10)]
        public void RefuelShouldЕqualizedToFuelCapacityIfFuelGivenIsMoreThanFuelCapacity
            (double fuelToRefuel, int timesToRefuel)
        {
            Car car = new Car("Toyota", "Corolla", 5.5, 55.5);

            for (int i = 0; i < timesToRefuel; i++)
            {
                car.Refuel(fuelToRefuel);
            }

            double expectedResult = car.FuelCapacity;

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-123456.78)]
        public void RefuelShouldThrowExceptionForZeroOrNegativeValue(double fuelToRefuel)
        {
            Car car = new Car("Toyota", "Corolla", 5.5, 55.5);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [TestCase(100, 50)]
        [TestCase(1000, 100)]
        [TestCase(0, 70)]
        public void DriveShouldDriveDistanceIfFuelAmountIsEnough(double distance, double fuelToRefuel)
        {
            Car car = new Car("Toyota", "Corolla", 10 , 100);
            car.Refuel(fuelToRefuel);

            double expectedResult = car.FuelAmount - distance / 100 * car.FuelConsumption;
            car.Drive(distance);

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [TestCase(101, 10)]
        [TestCase(10000, 100)]
        [TestCase(7876, 123)]
        public void DriveShouldThrowExceptionIfFuelAmountIsNotEnoughForTheDistance(double distance, double fuelToRefuel)
        {
            Car car = new Car("Toyota", "Corolla", 10, 100);
            car.Refuel(fuelToRefuel);

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }
    }
}