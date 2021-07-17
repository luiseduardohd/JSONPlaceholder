using System;
using JSONPlaceholder.Entities;

namespace JSONPlaceholder.ViewModels
{
    public class TodoViewModel : BaseViewModel<Todo>
    {
        public TodoViewModel(Todo item) : base(item)
        {
        }
    }
}
