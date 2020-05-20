using System;
using JSONPlaceholder.Models;

namespace JSONPlaceholder.ViewModels
{
    public class AlbumViewModel : BaseViewModel<Album>
    {
        public AlbumViewModel(Album item) : base(item)
        {
        }
    }
}
