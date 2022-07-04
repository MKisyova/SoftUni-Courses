using MilitaryElite.Interfaces;
using System.Text;

namespace MilitaryElite.Members
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int iD, string firstName, string lastName, int codeNumber) : base(iD, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set ; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {ID}");
            sb.AppendLine($"Code Number: {CodeNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}
