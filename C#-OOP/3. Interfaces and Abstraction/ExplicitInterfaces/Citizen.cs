﻿
namespace ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        string IPerson.GetName(string name)
        {
            return Name;
        }

        string IResident.GetName(string name)
        {
            return $"Mr/Ms/Mrs {Name}";
        }
    }
}
