using System;

namespace EqualityLogic
{
    class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person otherPerson)
        {
            int result = name.CompareTo(otherPerson.name);

            if (result == 0)
            {
                result = age.CompareTo(otherPerson.age);
            }

            return result;
        }

        public override int GetHashCode()
            => name.GetHashCode() ^ age.GetHashCode();
        //{
        //    return HashCode.Combine(name, age);
        //}

        public override bool Equals(object obj)
        {
            var otherPerson = obj as Person;

            if (otherPerson == null)
            {
                return false;
            }

            return age == otherPerson.age && name == otherPerson.name;
        }
    }
}
