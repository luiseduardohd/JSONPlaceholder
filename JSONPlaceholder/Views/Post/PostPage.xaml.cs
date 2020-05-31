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
    public partial class PostPage : ContentPage
    {
        PostViewModel viewModel;

        public PostPage(PostViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void OnCommentsButtonClicked(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var post = viewModel.Item;
            Func<Task<ObservableCollection<Comment>>> getItems = async () => await App.jsonPlaceholder.GetCommentsAsync(post);
            await Navigation.PushAsync(new CommentsPage(new CommentsViewModel(getItems)));
        }
    }
}