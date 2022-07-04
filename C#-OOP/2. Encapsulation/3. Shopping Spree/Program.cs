using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] inputPeople = Console.ReadLine().Split(new char[] { ';', '=' });

                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();

                for (int i = 0; i < inputPeople.Length; i += 2)
                {
                    string name = inputPeople[i];
                    double money = double.Parse(inputPeople[i + 1]);

                    Person person = new Person(name, money);
                    people.Add(person);
                }

                string[] inputProducts = Console.ReadLine().Split(new char[] { ';', '=' });

                for (int i = 0; i < inputProducts.Length; i += 2)
                {
                    string name = inputProducts[i];
                    double cost = double.Parse(inputProducts[i + 1]);

                    Product product = new Product(name, cost);
                    products.Add(product);
                }

                string commandInput = Console.ReadLine();


                while (commandInput != "END")
                {
                    string[] purchaseInfo = commandInput.Split(" ");

                    string personName = purchaseInfo[0];
                    string productName = purchaseInfo[1];

                    Person person = people.FirstOrDefault(x => x.Name == personName);
                    Product product = products.FirstOrDefault(x => x.Name == productName);

                    if (person.Money - product.Cost < 0)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                        commandInput = Console.ReadLine();
                        continue;
                    }

                    person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");

                    commandInput = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    string productMessage = person.Products.Count == 0 ? "Nothing bought"
                        : string.Join(", ", person.Products.Select(x => x.Name));

                    Console.WriteLine($"{person.Name} - {productMessage}");
                }
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
