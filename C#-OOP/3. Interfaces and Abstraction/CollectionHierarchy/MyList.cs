using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class MyList : ICollection
    {
        private int used;

        public MyList()
        {
            Collection = new List<string>();
        }
        public List<string> Collection { get; set; }

        public int Used 
        { 
            get => used;

            private set
            {
                value = Collection.Count;
                used = value; 
            } 
        }

        public int Add(string element)
        {
            Collection.Insert(0, element);

            return Collection.IndexOf(element);
        }

        public string Remove()
        {
            string element = Collection[0];
            Collection.RemoveAt(0);

            return element;
        }
    }
}
