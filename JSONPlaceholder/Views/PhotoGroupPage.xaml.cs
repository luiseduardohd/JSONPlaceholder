using System;
using System.Collections.Generic;
using System.ComponentModel;
using JSONPlaceholder.Models;
using JSONPlaceholder.ViewModels;
using Xamarin.Forms;

namespace JSONPlaceholder.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
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

        //async void AddPhoto_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new NavigationPage(new NewPhotoPage()));
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}