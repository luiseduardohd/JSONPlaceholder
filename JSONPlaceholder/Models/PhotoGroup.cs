using System;
using System.Collections.Generic;

namespace JSONPlaceholder.Models
{
    public class PhotoGroup : List<Photo>
    {
        public string Name { get; private set; }

        public PhotoGroup(string name, List<Photo> items) : base(items)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
