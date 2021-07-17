using System;
using JSONPlaceholder.Entities;

namespace JSONPlaceholder.ViewModels
{
    public class CompanyViewModel : BaseViewModel<Company>
    {
        public CompanyViewModel(Company item) : base(item)
        {
        }
    }
}
