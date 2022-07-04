using MilitaryElite.Interfaces;

namespace MilitaryElite.Members
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int iD, string firstName, string lastName)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
