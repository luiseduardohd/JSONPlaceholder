using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholder.Models;
using JSONPlaceholder.ViewModels;

namespace JSONPlaceholder.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class PhotoPage : ContentPage
    {
        PhotoViewModel viewModel;

        public PhotoPage(PhotoViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public PhotoPage()
        {
            InitializeComponent();

            var item = new Photo
            {
                //Text = "Item 1",
                Title = "Item 1",
                //Description = "This is an item description."
            };

            viewModel = new PhotoViewModel(item);
            BindingContext = viewModel;
        }
    }
}