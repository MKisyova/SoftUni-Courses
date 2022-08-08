using System;

namespace Composite
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price) : base(name, price)
        {
        }

        public override decimal CalculateTotalPrice()
            => price;

        public override string Print()
            => $"{name} is with price {price}.";

    }
}
