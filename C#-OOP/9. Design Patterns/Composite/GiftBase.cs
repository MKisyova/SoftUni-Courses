﻿namespace Composite
{
    public abstract class GiftBase
    {
        protected string name;
        protected decimal price;

        protected GiftBase(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract decimal CalculateTotalPrice();

        public abstract string Print();
    }
}
