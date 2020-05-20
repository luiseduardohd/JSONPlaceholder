using System;
using System.Collections.Generic;
using System.ComponentModel;
using JSONPlaceholder.Models;
using JSONPlaceholder.ViewModels;
using Xamarin.Forms;

namespace JSONPlaceholder.Views
{
    [DesignTimeVisible(false)]
    public partial class PhotoGroupPage : ContentPage
    {
        PhotoGroupViewModel viewModel;

        public PhotoGroupPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PhotoGroupViewModel();
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