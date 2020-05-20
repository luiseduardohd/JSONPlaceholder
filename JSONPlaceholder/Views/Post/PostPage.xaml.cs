using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholder.Entities;
using JSONPlaceholder.ViewModels;

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
    }
}