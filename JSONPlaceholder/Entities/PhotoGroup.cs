using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JSONPlaceholder.Util;

namespace JSONPlaceholder.Entities
{
    public class PhotoGroup
        : RangeObservableCollection<Photo>
    {

        public Album Album { get; private set; }


        public PhotoGroup(string name, Album album) : base()
        {
            Album = album;
        }

        public override string ToString()
        {
            return Album.Title;
        }
    }
}
