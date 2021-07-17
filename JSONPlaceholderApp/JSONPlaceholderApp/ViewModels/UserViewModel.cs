using System;
using JSONPlaceholderApp.Entities;

namespace JSONPlaceholderApp.ViewModels
{
    public class UserViewModel : BaseViewModel<User>
    {
        public UserViewModel(User item) : base(item)
        {
        }
    }
}
