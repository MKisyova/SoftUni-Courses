using System.Collections.Generic;

namespace CollectionHierarchy
{
    public interface ICollection 
    {
        public List<string> Collection { get; set; }

        int Add(string element);
    }
}
