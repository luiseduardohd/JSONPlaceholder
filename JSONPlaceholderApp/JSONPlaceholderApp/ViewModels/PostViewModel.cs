using System;
using JSONPlaceholderApp.Entities;

namespace JSONPlaceholderApp.ViewModels
{
    public class PostViewModel : BaseViewModel<Post>
    {
        public PostViewModel(Post item) : base(item)
        {
        }
    }
}
