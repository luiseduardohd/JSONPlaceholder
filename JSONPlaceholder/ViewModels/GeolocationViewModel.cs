using System;
using JSONPlaceholder.Entities;

namespace JSONPlaceholder.ViewModels
{
    public class GeolocationViewModel : BaseViewModel<Geolocation>
    {
        public GeolocationViewModel(Geolocation item) : base(item)
        {
        }
    }
}
