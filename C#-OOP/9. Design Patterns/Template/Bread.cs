﻿using System;

namespace Template
{
    public abstract class Bread
    {
        public abstract void MixIngredients();

        public abstract void Bake();

        public virtual void Slice()
        {
            Console.WriteLine($"Slicing the {GetType().Name} bread.");
        }

        //template method
        public void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }
    }
}