using System;
using JSONPlaceholder.Entities;

namespace JSONPlaceholder.ViewModels
{
    public class PostViewModel : BaseViewModel<Post>
    {
        public PostViewModel(Post item) : base(item)
        {
        }
    }
}
