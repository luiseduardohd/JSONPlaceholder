using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholder.Entities;
using JSONPlaceholder.Views;
using JSONPlaceholder.ViewModels;

namespace JSONPlaceholder.Views
{
    [DesignTimeVisible(false)]
    public partial class PostsPage : ContentPage
    {
        PostsViewModel viewModel;
        //private PostsViewModel postsViewModel;

        public PostsPage():this(new PostsViewModel())
        {
        }

        public PostsPage(PostsViewModel postsViewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = postsViewModel;
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var Post = (Post)layout.BindingContext;
            await Navigation.PushAsync(new PostPage(new PostViewModel(Post)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items?.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}