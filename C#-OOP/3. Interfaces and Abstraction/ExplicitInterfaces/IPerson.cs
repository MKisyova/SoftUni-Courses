﻿
namespace ExplicitInterfaces
{
    public interface IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        string GetName(string name);
    }
}
