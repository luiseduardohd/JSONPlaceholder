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
    public partial class AlbumPage : ContentPage
    {
        AlbumViewModel viewModel;

        public AlbumPage(AlbumViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public AlbumPage()
        {
            InitializeComponent();

            var item = new Album
            {
                //Text = "Item 1",
                //Description = "This is an item description."
            };

            viewModel = new AlbumViewModel(item);
            BindingContext = viewModel;
        }
    }
}