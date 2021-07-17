using System;
using JSONPlaceholderApp.Entities;

namespace JSONPlaceholderApp.ViewModels
{
    public class GeolocationViewModel : BaseViewModel<Geolocation>
    {
        public GeolocationViewModel(Geolocation item) : base(item)
        {
        }
    }
}
