﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholder.Models;
using JSONPlaceholder.Views;
using JSONPlaceholder.ViewModels;

namespace JSONPlaceholder.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TodosPage : ContentPage
    {
        TodosViewModel viewModel;

        public TodosPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TodosViewModel();
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

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}