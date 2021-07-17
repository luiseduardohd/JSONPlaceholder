using System;
using JSONPlaceholderApp.Entities;

namespace JSONPlaceholderApp.ViewModels
{
    public class CompanyViewModel : BaseViewModel<Company>
    {
        public CompanyViewModel(Company item) : base(item)
        {
        }
    }
}
