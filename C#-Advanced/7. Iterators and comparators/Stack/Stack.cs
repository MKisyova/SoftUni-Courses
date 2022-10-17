using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> collection;
        public Stack()
        {
            collection = new List<T>();
        }

        public void Push(params T[] input)
        {
            foreach (var item in input)
            {
                collection.Add(item);
            }
        }
        public void Pop()
        {
            if (collection.Count > 0)
            {
                collection.RemoveAt(collection.Count - 1);
            }

            else
            {
                Console.WriteLine("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
