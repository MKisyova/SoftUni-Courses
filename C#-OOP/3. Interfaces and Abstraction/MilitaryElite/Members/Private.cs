using MilitaryElite.Interfaces;

namespace MilitaryElite.Members
{
    public class Private : Soldier, IPrivate 
    {
        public Private(int iD, string firstName, string lastName, decimal salary) : base(iD, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary:f2}";
        }
    }
}
