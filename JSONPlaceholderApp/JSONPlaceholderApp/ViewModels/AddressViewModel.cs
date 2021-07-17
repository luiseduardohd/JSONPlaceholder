using System;
using JSONPlaceholder.Entities;

namespace JSONPlaceholder.ViewModels
{
    public class AddressViewModel : BaseViewModel<Address>
    {
        public AddressViewModel(Address item) : base(item)
        {
        }
    }
}
