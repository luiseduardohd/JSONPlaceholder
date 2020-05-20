using System;
using JSONPlaceholder.Models;

namespace JSONPlaceholder.ViewModels
{
    public class CommentViewModel : BaseViewModel<Comment>
    {
        public CommentViewModel(Comment item) : base(item)
        {
        }
    }
}
