using System;
using JSONPlaceholderApp.Entities;

namespace JSONPlaceholderApp.ViewModels
{
    public class AddressViewModel : BaseViewModel<Address>
    {
        public AddressViewModel(Address item) : base(item)
        {
        }
    }
}
