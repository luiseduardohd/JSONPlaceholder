using System;
using JSONPlaceholder.Entities;

namespace JSONPlaceholder.ViewModels
{
    public class AlbumViewModel : BaseViewModel<Album>
    {
        public AlbumViewModel(Album item) : base(item)
        {
        }
    }
}
