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
    public partial class TodoPage : ContentPage
    {
        TodoViewModel viewModel;

        public TodoPage(TodoViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public TodoPage()
        {
            InitializeComponent();

            var Todo = new Todo
            {
                //Text = "Todo 1",
                //Description = "This is an Todo description."
            };

            viewModel = new TodoViewModel(Todo);
            BindingContext = viewModel;
        }
    }
}