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

            // Comienza editar
            var btnPhotos = new Button()
            {
                Text = "Button",
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
                        btnPhotos,
                    }
                }

             };

                // Termina de editar

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