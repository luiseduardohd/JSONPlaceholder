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
using System.Windows.Input;

namespace JSONPlaceholderApp.Views
{
    [DesignTimeVisible(false)]
    public partial class UsersPage : ContentPage
    {
        UsersViewModel viewModel;

        public UsersPage()
        {
            //InitializeComponent();

            // 

            this.Title = "Users";

            var usersDataTemplate = new DataTemplate(() =>
            {
                var labelName = new Label()
                {
                    LineBreakMode = LineBreakMode.NoWrap,
                    FontSize = 16
                };
                labelName.SetBinding(Label.TextProperty, "Name");

                var labelUserName = new Label()
                {
                    LineBreakMode = LineBreakMode.NoWrap,
                    FontSize = 16
                };
                labelUserName.SetBinding(Label.TextProperty, "Username");

                var labelEmail = new Label()
                {
                    LineBreakMode = LineBreakMode.NoWrap,
                    FontSize = 16
                };
                labelEmail.SetBinding(Label.TextProperty, "Email");

                var stackLayout = new StackLayout()
                {
                    Children =
                    {
                        labelName,
                        labelUserName,
                        labelEmail,
 
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
                ItemTemplate = usersDataTemplate
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

            BindingContext = viewModel = new UsersViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var User = (User)layout.BindingContext;
            await Navigation.PushAsync(new UserPage(new UserViewModel(User)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}