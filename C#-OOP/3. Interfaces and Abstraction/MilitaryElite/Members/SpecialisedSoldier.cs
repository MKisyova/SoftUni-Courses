using MilitaryElite.Interfaces;

namespace MilitaryElite.Members
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int iD, string firstName, string lastName, decimal salary, Corps corp) : base(iD, firstName, lastName, salary)
        {
            this.Corps = corp;
        }

        public Corps Corps { get; set; }
    }
}
