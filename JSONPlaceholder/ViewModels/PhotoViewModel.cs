using System;
using JSONPlaceholder.Models;

namespace JSONPlaceholder.ViewModels
{
    public class PhotoViewModel : BaseViewModel<Photo>
    {
        public PhotoViewModel(Models.Photo photo)
        {
        }
    }
}
