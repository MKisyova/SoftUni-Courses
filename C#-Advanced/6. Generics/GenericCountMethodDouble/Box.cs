using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    class Box<T> where T : IComparable
    {
        private List<T> items { get; set; }

        public Box()
        {
            items = new List<T>();
        }

        public void Add(T element)
        {
            items.Add(element);
        }

        public int CompareElements(T itemToCompare)
        {
            int count = 0;

            foreach (var currentElement in items)
            {
                if (currentElement.CompareTo(itemToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }

    }
}
