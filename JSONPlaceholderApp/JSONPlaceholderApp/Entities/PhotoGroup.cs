using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JSONPlaceholderApp.Util;

namespace JSONPlaceholderApp.Entities
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
