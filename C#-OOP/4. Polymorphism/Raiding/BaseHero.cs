
namespace Raiding
{
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public int Power { get; set; }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
