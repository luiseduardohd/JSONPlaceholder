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
    public partial class PostsPage : ContentPage
    {
        PostsViewModel viewModel;
        //private PostsViewModel postsViewModel;

        public PostsPage():this(new PostsViewModel())
        {
        }

        public PostsPage(PostsViewModel postsViewModel)
        {
            //InitializeComponent();

            // 

            this.Title = "Posts";

            var postsDataTemplate = new DataTemplate(() =>
            {
                var lblTitle = new Label()
                {
                    LineBreakMode = LineBreakMode.NoWrap,
                    FontSize = 16
                };
                lblTitle.SetBinding(Label.TextProperty, "Title");

                var lblBody = new Label()
                {
                    LineBreakMode = LineBreakMode.NoWrap,
                    FontSize = 16
                };
                lblBody.SetBinding(Label.TextProperty, "Body");

                var stackLayout = new StackLayout()
                {
                    Children =
                    {
                        lblTitle,
                        lblBody,

                    }
                };

                var tapGestureRecognizer = new TapGestureRecognizer()
                {
                    NumberOfTapsRequired = 1,
                };
                tapGestureRecognizer.Tapped += OnItemSelected;
                stackLayout.GestureRecognizers.Add(tapGestureRecognizer);
                return stackLayout;
            });

            var collectionView = new CollectionView()
            {
                ItemTemplate = postsDataTemplate
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