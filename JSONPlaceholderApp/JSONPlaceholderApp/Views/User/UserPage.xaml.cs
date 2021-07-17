using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholder.Entities;
using JSONPlaceholder.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JSONPlaceholder.Util;

namespace JSONPlaceholder.Views
{
    [DesignTimeVisible(false)]
    public partial class UserPage : ContentPage
    {
        UserViewModel viewModel;

        public UserPage(UserViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public UserPage()
        {
            InitializeComponent();

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
            Func<Task<RangeObservableCollection<Album>>> getItems = async () => await App.jsonPlaceholder.GetAlbumsAsync(User);
            await Navigation.PushAsync(new AlbumsPage(new AlbumsViewModel(getItems)));
        }

        async void OnPostsButtonClicked(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var User = viewModel.Item;
            Func<Task<RangeObservableCollection<Post>>> getItems = async () => await App.jsonPlaceholder.GetPostsAsync(User);
            await Navigation.PushAsync(new PostsPage(new PostsViewModel(getItems)));
        }

        async void OnTodosButtonClicked(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var User = viewModel.Item;
            Func<Task<RangeObservableCollection<Todo>>> getItems = async () => await App.jsonPlaceholder.GetTodosAsync(User);
            await Navigation.PushAsync(new TodosPage(new TodosViewModel(getItems)));
        }
    }
}