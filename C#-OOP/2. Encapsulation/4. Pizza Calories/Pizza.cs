using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name 
        { 
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }
        public Dough Dough { get; set; }

        public IReadOnlyCollection<Topping> Toppings
            => this.toppings;

        public void AddTopping(Topping topping)
        {
            if (toppings.Count > 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }

        public double CalculateCalories()
        {
            double result = this.Dough.Calories + toppings.Sum(x => x.Calories);
            return result;
        }
    }
}
