using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> toppingTypeCalories = new Dictionary<string, double>
        { {"Meat", 1.2 }, {"Veggies", 0.8 }, {"Cheese", 1.1 }, {"Sauce", 0.9 }};

        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public string ToppingType
        {
            get => toppingType; 

            private set 
            {
                value = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();

                if (!toppingTypeCalories.ContainsKey(value))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value; 
            }
        }

        public double Weight 
        { 
            get => weight;

            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }

        public double Calories => 2 * this.toppingTypeCalories[toppingType] * this.Weight;

    }
}
