using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholder.Entities;
using JSONPlaceholder.Views;
using JSONPlaceholder.ViewModels;

namespace JSONPlaceholder.Views
{
    [DesignTimeVisible(false)]
    public partial class PhotosPage : ContentPage
    {
        PhotosViewModel viewModel;

        public PhotosPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PhotosViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var Photo = (Photo)layout.BindingContext;
            await Navigation.PushAsync(new PhotoPage(new PhotoViewModel(Photo)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}