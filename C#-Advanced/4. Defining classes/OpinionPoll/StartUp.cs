using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] people = Console.ReadLine().Split();
                string name = people[0];
                int age = int.Parse(people[1]);

                Person person = new Person(name, age);

                if (person.OlderThanThirty())
                {
                    family.AddMember(person);
                }
                
            }

            family.AlphabeticallyOrdered();

        }
    }
}
