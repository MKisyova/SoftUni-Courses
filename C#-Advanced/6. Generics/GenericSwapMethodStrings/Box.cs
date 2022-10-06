using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box <T>
    {
        private List<T> elements;

        public Box()
        {
            elements = new List<T>();
        }

        public void Add(T item)
        {
            elements.Add(item);
        }

        public void Swap(int a, int b)
        {
            T tempSwappedElement = elements[a];
            elements[a] = elements[b];
            elements[b] = tempSwappedElement;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in elements)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
