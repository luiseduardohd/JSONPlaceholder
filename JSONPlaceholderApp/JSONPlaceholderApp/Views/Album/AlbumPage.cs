using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholderApp.Entities;
using JSONPlaceholderApp.ViewModels;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace JSONPlaceholderApp.Views
{
    [DesignTimeVisible(false)]
    public partial class AlbumPage : ContentPage
    {
        AlbumViewModel viewModel;

        public AlbumPage(AlbumViewModel viewModel)
        {
            //InitializeComponent();

            // 

            this.Title = "Album";

            BindingContext = this.viewModel = viewModel;

            var btnEdit = new Button()
            {
                Text = "Edit",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            btnEdit.Clicked += OnEditButtonClicked;

            var btnPhotos = new Button()
            {
                Text = "Photos",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            btnPhotos.Clicked += OnPhotosButtonClicked;

            var lblTitle =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblTitle.SetBinding(Label.TextProperty, "Item.Title");


            this.Content = new ScrollView()
            {
                Content = new StackLayout()
                {
                    Spacing = 20,
                    Padding = 15,
                    Children =
                    {
                        new Label()
                        {
                            Text = "Title:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblTitle,
                        btnEdit,
                        btnPhotos,
                    }
                }

             };

            // 

        }

        async void OnEditButtonClicked(object sender, EventArgs args)
        {
            AlbumViewModel viewModel = this.viewModel;
            var page = new AlbumEditPage(viewModel);
            await Navigation.PushAsync(page);
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