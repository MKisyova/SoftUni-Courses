﻿using System;

namespace ValidationAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if ((int)obj < minValue || (int)obj > maxValue)
            {
                return false;
            }

            return true;
        }
    }
}
