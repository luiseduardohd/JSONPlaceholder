using System;
using JSONPlaceholderApp.Entities;

namespace JSONPlaceholderApp.ViewModels
{
    public class AlbumViewModel : BaseViewModel<Album>
    {
        public AlbumViewModel(Album item) : base(item)
        {
        }
    }
}
