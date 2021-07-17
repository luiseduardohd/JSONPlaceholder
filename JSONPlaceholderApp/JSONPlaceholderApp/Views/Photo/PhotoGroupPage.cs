using System;
using System.Collections.Generic;
using System.ComponentModel;
using FFImageLoading.Forms;
using JSONPlaceholderApp.Entities;
using JSONPlaceholderApp.ViewModels;
using Xamarin.Forms;

namespace JSONPlaceholderApp.Views
{
    [DesignTimeVisible(false)]
    public partial class PhotoGroupPage : ContentPage
    {
        PhotoGroupViewModel viewModel;

        public PhotoGroupPage()
        {
            //InitializeComponent();

            //

            var photoGroupDataTemplate = new DataTemplate(() =>
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
                ItemTemplate = photoGroupDataTemplate
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