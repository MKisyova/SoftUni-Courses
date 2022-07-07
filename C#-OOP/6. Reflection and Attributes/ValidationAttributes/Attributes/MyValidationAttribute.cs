using System;

namespace ValidationAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);

    }
}
