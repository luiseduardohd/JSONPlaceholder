using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholder.Entities;
using JSONPlaceholder.ViewModels;

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
    }
}