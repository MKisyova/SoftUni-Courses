using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] inputPizza = Console.ReadLine().Split(" ");
                string pizzaName = inputPizza[1];

                string[] inputDough = Console.ReadLine().Split(" ");

                string flourType = inputDough[1];
                string bakingTechnique = inputDough[2];
                double doughWeight = double.Parse(inputDough[3]);

                Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string inputTopping = Console.ReadLine();

                while (inputTopping != "END")
                {
                    string[] toppingInfo = inputTopping.Split(" ");

                    string toppingType = toppingInfo[1];
                    double toppingWeight = double.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    inputTopping = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.CalculateCalories():f2} Calories.");
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
