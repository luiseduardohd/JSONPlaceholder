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
    public partial class AlbumsPage : ContentPage
    {
        AlbumsViewModel viewModel;
        //private AlbumsViewModel albumsViewModel;

        public AlbumsPage()
            :this(new AlbumsViewModel())
        {
        }

        public AlbumsPage(AlbumsViewModel albumsViewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = albumsViewModel;
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var Album = (Album)layout.BindingContext;
            await Navigation.PushAsync(new AlbumPage(new AlbumViewModel(Album)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items?.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}