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
    public partial class CommentsPage : ContentPage
    {
        CommentsViewModel viewModel;
        //private CommentsViewModel commentsViewModel;

        public CommentsPage()
            :this(new CommentsViewModel())
        {
        }

        public CommentsPage(CommentsViewModel commentsViewModel)
        {
            //InitializeComponent();

            // 

            this.Title = "Comments";

            var commentsDataTemplate = new DataTemplate(() =>
            {
                var lblName = new Label()
                {
                    LineBreakMode = LineBreakMode.NoWrap,
                    FontSize = 16
                };
                lblName.SetBinding(Label.TextProperty, "Name");


                var lblEmail = new Label()
                {
                    LineBreakMode = LineBreakMode.NoWrap,
                    FontSize = 16
                };
                lblEmail.SetBinding(Label.TextProperty, "Email");

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
                        lblName,
                        lblEmail,
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
                ItemTemplate = commentsDataTemplate
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

            BindingContext = this.viewModel = commentsViewModel;
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var Comment = (Comment)layout.BindingContext;
            await Navigation.PushAsync(new CommentPage(new CommentViewModel(Comment)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}