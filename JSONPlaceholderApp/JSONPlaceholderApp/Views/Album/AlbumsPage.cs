using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholderApp.Entities;
using JSONPlaceholderApp.Views;
using JSONPlaceholderApp.ViewModels;

namespace JSONPlaceholderApp.Views
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
            //InitializeComponent();

            // 

            this.Title = "Albums";

            var albumsDataTemplate = new DataTemplate(() =>
            {
                var label = new Label()
                {
                    LineBreakMode = LineBreakMode.NoWrap,
                    FontSize = 16
                };
                label.SetBinding(Label.TextProperty, "Title");
                
                var stackLayout = new StackLayout()
                {
                    Children =
                    {
                        label,
                    }
                };
                
                var tapGestureRecognizer = new TapGestureRecognizer()
                {
                    NumberOfTapsRequired = 1,
                };
                tapGestureRecognizer.Tapped += OnItemSelected;
                //tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "OnItemSelected");
                stackLayout.GestureRecognizers.Add(tapGestureRecognizer);
                return stackLayout ;
            });
            
            var collectionView = new CollectionView()
            {
                ItemTemplate = albumsDataTemplate
            };
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, "Items");

            var refreshView = new RefreshView()
            {
                Content = collectionView
            };
            Binding binding = new Binding();
            binding.Path = "IsBusy";
            binding.Mode = BindingMode.TwoWay;
            refreshView.SetBinding(RefreshView.IsRefreshingProperty, binding);
            refreshView.SetBinding(RefreshView.CommandProperty, "LoadItemsCommand");
            this.Content = refreshView;


            // 

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