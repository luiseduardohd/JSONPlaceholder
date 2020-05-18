using System;
using JSONPlaceholder.Models;

namespace JSONPlaceholder.ViewModels
{
    public class CommentViewModel : BaseViewModel<Comment>
    {
        public CommentViewModel(Models.Comment comment)
        {
        }
    }
}
