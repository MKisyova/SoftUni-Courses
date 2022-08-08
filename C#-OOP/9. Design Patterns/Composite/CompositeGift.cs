using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;
        public CompositeGift(string name, decimal price) : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }

        public override decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (var gift in gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }

            return totalPrice;
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{name} contains the following products:");

            foreach (var gift in gifts)
            {
                sb.AppendLine(gift.Print());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
