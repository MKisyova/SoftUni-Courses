namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["Peanut Butter"] = new Sandwich("White", "", "", "Peanut butter, Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");
            sandwichMenu["Three Meat Combo"] = new Sandwich("Wheat", "Turkey, Ham, Bacon", "Cheddar", "Lettuce, Tomato");
            sandwichMenu["Vegetarian"] = new Sandwich("Whole grain", "", "Emental", "Lettuce, Tomato, Olives, Onion");

            Sandwich sandwich1 = sandwichMenu["BLT"].ShallowClone() as Sandwich;
            Sandwich sandwich2 = sandwichMenu["Three Meat Combo"].DeepClone() as Sandwich;
            Sandwich sandwich3 = sandwichMenu["Vegetarian"].DeepClone() as Sandwich;
        }
    }
}
