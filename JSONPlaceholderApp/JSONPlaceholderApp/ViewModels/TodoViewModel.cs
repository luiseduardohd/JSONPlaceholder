using System;
using JSONPlaceholderApp.Entities;

namespace JSONPlaceholderApp.ViewModels
{
    public class TodoViewModel : BaseViewModel<Todo>
    {
        public TodoViewModel(Todo item) : base(item)
        {
        }
    }
}
