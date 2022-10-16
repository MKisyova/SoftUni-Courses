using System;
using System.Collections;
using System.Collections.Generic;

namespace ListyIterator
{
    public class ListyIterator <T> : IEnumerable
    {
        private List<T> collection;
        private int currentIndex;

        public ListyIterator(params T[] inputData)
        {
            collection = new List<T>(inputData);
        }

        public bool HasNext() => currentIndex < collection.Count - 1;

        public bool Move()
        {
            if (HasNext())
            {
                currentIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            else
            {
                Console.WriteLine(collection[currentIndex]);
            }

        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", collection));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < collection.Count; i++)
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
