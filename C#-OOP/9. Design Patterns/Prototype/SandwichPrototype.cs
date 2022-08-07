namespace Prototype
{
    public abstract class SandwichPrototype
    {
        public abstract SandwichPrototype ShallowClone();

        public abstract SandwichPrototype DeepClone();
    }
}
