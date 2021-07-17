using System;
using System.Threading.Tasks;
using JSONPlaceholder.Entities;

namespace JSONPlaceholder.ViewModels
{
    public class UserViewModel : BaseViewModel<User>
    {
        public UserViewModel(User item) : base(item)
        {
        }
        protected async Task InitializeAsync()
        {
            
        }

    }
}
