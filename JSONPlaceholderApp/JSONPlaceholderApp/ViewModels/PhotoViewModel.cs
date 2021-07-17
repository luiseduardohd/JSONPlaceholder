using System;
using JSONPlaceholderApp.Entities;

namespace JSONPlaceholderApp.ViewModels
{
    public class PhotoViewModel : BaseViewModel<Photo>
    {
        public PhotoViewModel(Photo item) : base(item)
        {
        }
    }
}
