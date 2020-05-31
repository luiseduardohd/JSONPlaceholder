using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholder.Entities;
using JSONPlaceholder.ViewModels;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace JSONPlaceholder.Views
{
    [DesignTimeVisible(false)]
    public partial class AlbumPage : ContentPage
    {
        AlbumViewModel viewModel;

        public AlbumPage(AlbumViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void OnPhotosButtonClicked(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var album= viewModel.Item;
            Func<Task<ObservableCollection<Photo>>> getItems = async () => await App.jsonPlaceholder.GetPhotosAsync(album);
            await Navigation.PushAsync(new PhotosPage(new PhotosViewModel(getItems)));
        }
    }
}