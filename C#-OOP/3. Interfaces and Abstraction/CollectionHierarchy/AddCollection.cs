using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddCollection : ICollection
    {
        public AddCollection()
        {
            Collection = new List<string>();
        }

        public List<string> Collection { get; set; }

        public int Add(string element)
        {
            Collection.Add(element);

            return Collection.IndexOf(element);
        }
    }
}
