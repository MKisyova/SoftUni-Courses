using MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Members
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int iD, string firstName, string lastName, decimal salary) : base(iD, firstName, lastName, salary)
        {
            Privates = new List<IPrivate>(); 
        }

        public List<IPrivate> Privates { get ; set ; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string baseInfo = base.ToString();

            sb.AppendLine(baseInfo);
            sb.AppendLine("Privates:");

            foreach (var person in Privates)
            {
                sb.AppendLine($"  {person.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
