using System;
using JSONPlaceholder.Models;

namespace JSONPlaceholder.ViewModels
{
    public class TodoViewModel : BaseViewModel<Todo>
    {
        public TodoViewModel(Todo item) : base(item)
        {
        }
    }
}
