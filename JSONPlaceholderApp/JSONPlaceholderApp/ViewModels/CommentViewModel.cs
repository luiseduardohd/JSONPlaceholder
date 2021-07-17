using System;
using JSONPlaceholder.Entities;

namespace JSONPlaceholder.ViewModels
{
    public class CommentViewModel : BaseViewModel<Comment>
    {
        public CommentViewModel(Comment item) : base(item)
        {
        }
    }
}
