using MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Members
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int iD, string firstName, string lastName, decimal salary, Corps corp) : base(iD, firstName, lastName, salary, corp)
        {
            Missions = new List<IMission>();
        }

        public List<IMission> Missions { get; set; }

        public void CompleteMission(string codeName)
        {
            var mission = Missions.FirstOrDefault(x => x.CodeName == codeName);
            mission.Status = Status.Finished;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string baseInfo = base.ToString();

            sb.AppendLine(baseInfo);
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
