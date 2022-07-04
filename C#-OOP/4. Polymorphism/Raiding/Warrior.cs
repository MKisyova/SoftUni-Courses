﻿
namespace Raiding
{
    class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            Power = 100;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
