using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] input = Console.ReadLine().Split(" ");

            List<int> resultFromAddCollection = new List<int>();
            List<int> resultFromAddRemoveCollection = new List<int>();
            List<int> resultFromMyList = new List<int>();

            foreach (var element in input)
            {
                int a = addCollection.Add(element);
                int b = addRemoveCollection.Add(element);
                int c = myList.Add(element);

                resultFromAddCollection.Add(a);
                resultFromAddRemoveCollection.Add(b);
                resultFromMyList.Add(c);
            }

            int elementsToRemove = int.Parse(Console.ReadLine());

            List<string> resultFromRemoveAddRemoveCollection = new List<string>();
            List<string> resultFromRemoveMyList = new List<string>();

            for (int i = 0; i < elementsToRemove; i++)
            {
                string elementAddRemove = addRemoveCollection.Remove();
                string elementMyList = myList.Remove();

                resultFromRemoveAddRemoveCollection.Add(elementAddRemove);
                resultFromRemoveMyList.Add(elementMyList);
            }

            PrintResultFromAdd(resultFromAddCollection);
            PrintResultFromAdd(resultFromAddRemoveCollection);
            PrintResultFromAdd(resultFromMyList);

            PrintResultFromRemove(resultFromRemoveAddRemoveCollection);
            PrintResultFromRemove(resultFromRemoveMyList);

        }

        public static void PrintResultFromAdd(List<int> resultFromAddCollection)
        {
            Console.WriteLine(string.Join(" ", resultFromAddCollection));
        }

        public static void PrintResultFromRemove(List<string> resultFromAddCollection)
        {
            Console.WriteLine(string.Join(" ", resultFromAddCollection));
        }
    }
}
