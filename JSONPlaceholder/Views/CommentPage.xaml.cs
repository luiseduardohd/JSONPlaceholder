using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholder.Models;
using JSONPlaceholder.ViewModels;

namespace JSONPlaceholder.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CommentPage : ContentPage
    {
        CommentViewModel viewModel;

        public CommentPage(CommentViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public CommentPage()
        {
            InitializeComponent();

            var Comment = new Comment
            {
                //Text = "Comment 1",
                Name = "Comment 1",
                //Description = "This is an Comment description."
                Body = "This is an Comment description."
            };

            viewModel = new CommentViewModel(Comment);
            BindingContext = viewModel;
        }
    }
}