using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholderApp.Entities;
using JSONPlaceholderApp.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace JSONPlaceholderApp.Views
{
    [DesignTimeVisible(false)]
    public partial class UserPage : ContentPage
    {
        UserViewModel viewModel;

        public UserPage(UserViewModel viewModel)
        {
            //InitializeComponent();

            // Empiezo a editar

            var btnAlbums = new Button()
            {
                Text = "Albums",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            btnAlbums.Clicked += OnAlbumsButtonClicked;

            var btnPosts = new Button()
            {
                Text = "Posts",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            btnPosts.Clicked += OnPostsButtonClicked;

            var btnTodos = new Button()
            {
                Text = "Todos",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            btnTodos.Clicked += OnTodosButtonClicked;

            var lblName =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblName.SetBinding(Label.TextProperty, "Item.Name");

            var lblUsername =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblUsername.SetBinding(Label.TextProperty, "Item.Username");

            var lblEmail =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblEmail.SetBinding(Label.TextProperty, "Item.Email");

            var lblAddressStreet =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblAddressStreet.SetBinding(Label.TextProperty, "Item.Address.Street");

            var lblAddressSuite =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblAddressSuite.SetBinding(Label.TextProperty, "Item.Address.Suite");

            var lblAddressCity =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblAddressCity.SetBinding(Label.TextProperty, "Item.Address.City");

            var lblAddressZipcode =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblAddressZipcode.SetBinding(Label.TextProperty, "Item.Address.Zipcode");

            var lblAddressGeolocationLatitude =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblAddressGeolocationLatitude.SetBinding(Label.TextProperty, "Item.Address.Geolocation.Latitude");

            var lblAddressGeolocationLongitude =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblAddressGeolocationLongitude.SetBinding(Label.TextProperty, "Item.Address.Geolocation.Longitude");

            var lblPhone =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblPhone.SetBinding(Label.TextProperty, "Item.Phone");

            var lblWebsite =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblWebsite.SetBinding(Label.TextProperty, "Item.Website");

            var lblCompanyName =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblCompanyName.SetBinding(Label.TextProperty, "Item.Company.Name");

            var lblCompanyCatchPhrase =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblCompanyCatchPhrase.SetBinding(Label.TextProperty, "Item.Company.CatchPhrase");

            var lblCompanyBs =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblCompanyBs.SetBinding(Label.TextProperty, "Item.Company.Bs");



            this.Content = new ScrollView()
            {
                Content = new StackLayout()
                {
                    Spacing = 20,
                    Padding = 15,
                    Children = {
                        
                        new Label()
                        {
                            Text = "Name:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                       },
                        lblName,
                       
                        new Label()
                        {
                            Text = "Username:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblUsername,

                        new Label()
                        {
                            Text = "Email:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblEmail,

                        new Label()
                        {
                            Text = "Address Street:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblAddressStreet,

                        new Label()
                        {
                            Text = "Address Suite:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblAddressSuite,

                        new Label()
                        {
                            Text = "Address City:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblAddressCity,

                        new Label()
                        {
                            Text = "Address Zipcode:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblAddressZipcode,

                        new Label()
                        {
                            Text = "Address Geolocation Latitude:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblAddressGeolocationLatitude,

                        new Label()
                        {
                            Text = "Address Geolocation Longitude:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblAddressGeolocationLongitude,

                        new Label()
                        {
                            Text = "Phone:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblPhone,

                        new Label()
                        {
                            Text = "Website:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblWebsite,

                        new Label()
                        {
                            Text = "Company Name:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblCompanyName,

                        new Label()
                        {
                            Text = "Company CatchPhrase:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblCompanyCatchPhrase,

                        new Label()
                        {
                            Text = "Company bs:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblCompanyBs,

                        btnAlbums,
                        btnPosts,
                        btnTodos,
                    }
                }
            };


            // Termina

            BindingContext = this.viewModel = viewModel;
        }

        public UserPage()
        {
            //InitializeComponent();

            var item = new User
            {
                //Text = "Item 1",
                //Description = "This is an item description."
            };

            viewModel = new UserViewModel(item);
            BindingContext = viewModel;
        }

        async void OnAlbumsButtonClicked(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var User = viewModel.Item;
            Func<Task<ObservableCollection<Album>>> getItems = async () => await App.jsonPlaceholder.GetAlbumsAsync(User);
            await Navigation.PushAsync(new AlbumsPage(new AlbumsViewModel(getItems)));
        }

        async void OnPostsButtonClicked(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var User = viewModel.Item;
            Func<Task<ObservableCollection<Post>>> getItems = async () => await App.jsonPlaceholder.GetPostsAsync(User);
            await Navigation.PushAsync(new PostsPage(new PostsViewModel(getItems)));
        }

        async void OnTodosButtonClicked(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var User = viewModel.Item;
            Func<Task<ObservableCollection<Todo>>> getItems = async () => await App.jsonPlaceholder.GetTodosAsync(User);
            await Navigation.PushAsync(new TodosPage(new TodosViewModel(getItems)));
        }
    }
}