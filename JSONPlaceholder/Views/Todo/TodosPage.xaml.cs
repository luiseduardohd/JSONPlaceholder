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
    public partial class TodosPage : ContentPage
    {
        TodosViewModel viewModel;
        //private TodosViewModel todosViewModel;

        public TodosPage():this(new TodosViewModel())
        {
        }

        public TodosPage(TodosViewModel todosViewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = todosViewModel;
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var Todo = (Todo)layout.BindingContext;
            await Navigation.PushAsync(new TodoPage(new TodoViewModel(Todo)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items?.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}