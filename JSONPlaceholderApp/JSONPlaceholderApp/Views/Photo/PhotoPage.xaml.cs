using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholderApp.Entities;
using JSONPlaceholderApp.ViewModels;
using FFImageLoading.Forms;

namespace JSONPlaceholderApp.Views
{
    [DesignTimeVisible(false)]
    public partial class PhotoPage : ContentPage
    {
        PhotoViewModel viewModel;

        public PhotoPage(PhotoViewModel viewModel)
        {
            //InitializeComponent();

            // 

            this.Title = "Photo";

            var lblTitlePhoto =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblTitlePhoto.SetBinding(Label.TextProperty, "Item.Title");

            var cachedImage =
                        new CachedImage()
                        {
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            WidthRequest = 200,
                            HeightRequest = 200,
                            DownsampleToViewSize = true,
                        };
            cachedImage.SetBinding(CachedImage.SourceProperty, "Item.Url");

            this.Content = new ScrollView()
            {
                Content = new StackLayout()
                {
                    Spacing = 20,
                    Padding = 15,
                    Children =
                    {
                        lblTitlePhoto,
                        cachedImage
                    }
                }

            };



            // 

            BindingContext = this.viewModel = viewModel;
        }

        //public PhotoPage()
        //{
        //    InitializeComponent();

        //    var item = new Photo
        //    {
        //        //Text = "Item 1",
        //        Title = "Item 1",
        //        //Description = "This is an item description."
        //    };

        //    viewModel = new PhotoViewModel(item);
           
        //    BindingContext = viewModel;
        //}
    }
}