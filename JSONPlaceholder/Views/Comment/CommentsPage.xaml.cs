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
    public partial class CommentsPage : ContentPage
    {
        CommentsViewModel viewModel;

        public CommentsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CommentsViewModel();
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