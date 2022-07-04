using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : ICollection
    {
        public AddRemoveCollection()
        {
            Collection = new List<string>();
        }
        public List<string> Collection { get; set; }

        public int Add(string element)
        {
            Collection.Insert(0, element);
            return Collection.IndexOf(element);
        }

        public string Remove()
        {
            string element = Collection[Collection.Count - 1];
            Collection.RemoveAt(Collection.Count - 1);

            return element;
        }
    }
}
