using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        private Dictionary<string, double> flourTypeCalories = new Dictionary<string, double>
        {{"White", 1.5 }, {"Wholegrain", 1.0 }};

        private Dictionary<string, double> bakingTechniqueCalories = new Dictionary<string, double>
        {{"Crispy" , 0.9 }, {"Chewy", 1.1 }, {"Homemade", 1.0 }};

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                value = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();

                if (!flourTypeCalories.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }

        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                value = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();

                if (!bakingTechniqueCalories.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double Weight 
        { 
            get => weight;

            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }

        public double Calories
            => 2 * this.Weight * flourTypeCalories[FlourType] * bakingTechniqueCalories[BakingTechnique];

    }
}
