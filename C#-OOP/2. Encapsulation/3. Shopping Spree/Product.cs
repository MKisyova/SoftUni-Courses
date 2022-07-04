using System;

namespace ShoppingSpree
{
    class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name 
        { 
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public double Cost 
        { 
            get => cost; 

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cost cannot be negative");
                }

                cost = value;
            }               
        }
    }
}
