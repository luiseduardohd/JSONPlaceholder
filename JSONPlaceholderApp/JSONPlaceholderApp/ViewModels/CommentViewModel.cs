using System;
using JSONPlaceholderApp.Entities;

namespace JSONPlaceholderApp.ViewModels
{
    public class CommentViewModel : BaseViewModel<Comment>
    {
        public CommentViewModel(Comment item) : base(item)
        {
        }
    }
}
