using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("Samsung", 1000);
            phone.CalculateTotalPrice();
            Console.WriteLine(phone.Print());           

            var rootBox = new CompositeGift("RootBox", 0);
            var truckToy = new SingleGift("TruckToy", 199);
            var carToy = new SingleGift("CarToy", 149);

            rootBox.Add(truckToy);
            rootBox.Add(carToy);

            var childBox = new CompositeGift("ChildBox", 0);
            var soldierToy = new SingleGift("SoldierToy", 179);
            childBox.Add(soldierToy);

            rootBox.Add(childBox);
            Console.WriteLine(rootBox.Print());

            Console.WriteLine($"Total price of the composite present is {rootBox.CalculateTotalPrice()}");
        }
    }
}
