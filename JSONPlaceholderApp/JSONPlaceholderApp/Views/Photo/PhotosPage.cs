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
using FFImageLoading.Forms;

namespace JSONPlaceholderApp.Views
{
    [DesignTimeVisible(false)]
    public partial class PhotosPage : ContentPage
    {
        PhotosViewModel viewModel;
        private PhotosViewModel photosViewModel;

        public PhotosPage()
            :this(new PhotosViewModel())
        {
        }

        public PhotosPage(PhotosViewModel photosViewModel):base()
        {
            //InitializeComponent();

            //

            this.Title = "Photos";

            var photosDataTemplate = new DataTemplate(() =>
            {
                var lblPhotos = new Label()
                {
                    LineBreakMode = LineBreakMode.NoWrap,
                    FontSize = 16
                };
                lblPhotos.SetBinding(Label.TextProperty, "Title");

              

                var cachedImage =
                        new CachedImage()
                        {
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            WidthRequest = 100,
                            HeightRequest = 100,
                            DownsampleToViewSize = true,
                        };
                cachedImage.SetBinding(CachedImage.SourceProperty, "ThumbnailUrl");

                var stackLayout = new StackLayout()
                {
                    Children =
                    {
                        cachedImage,
                        lblPhotos,

                    }
                };

                var tapGestureRecognizer = new TapGestureRecognizer()
                {
                    NumberOfTapsRequired = 1,
                };
                tapGestureRecognizer.Tapped += OnItemSelected;
                //tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "OnItemSelected");
                stackLayout.GestureRecognizers.Add(tapGestureRecognizer);
                return stackLayout;
            });

            var collectionView = new CollectionView()
            {
                ItemTemplate = photosDataTemplate
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

            BindingContext = viewModel = photosViewModel;
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