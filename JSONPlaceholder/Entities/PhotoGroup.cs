using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JSONPlaceholder.Util;

namespace JSONPlaceholder.Entities
{
    public class PhotoGroup
        : RangeObservableCollection<Photo>
    {
        public string Name { get; private set; }

        public Album Album { get; private set; }


        public PhotoGroup(string name, Album album) : base()
        {
            Name = name;
            Album = album;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
