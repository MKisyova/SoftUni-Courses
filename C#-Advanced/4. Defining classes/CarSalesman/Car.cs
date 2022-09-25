using System;

namespace CarSalesman
{
    class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }
        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }
        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            Color = color;
        }
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; } = 0;

        public string Color { get; set; } = "n/a";

        public string isNull(int param)
        {
            if (param == 0)
            {
                return "n/a";
            }

            else
            {
                return param.ToString();
            }
        }

        public override string ToString()
        {
            return $"{Model}: \n {Engine.Model}: {Environment.NewLine}  Power: {Engine.Power} \n  Displacement: {isNull(Engine.Displacement)} \n  Efficiency: {Engine.Efficiency} \n Weight: {isNull(Weight)} \n Color: {Color}";
        }

    }
}
