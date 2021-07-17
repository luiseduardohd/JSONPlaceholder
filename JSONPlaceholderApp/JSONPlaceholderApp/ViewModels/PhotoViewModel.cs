using System;
using JSONPlaceholder.Entities;

namespace JSONPlaceholder.ViewModels
{
    public class PhotoViewModel : BaseViewModel<Photo>
    {
        public PhotoViewModel(Photo item) : base(item)
        {
        }
    }
}
