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
    public partial class TodosPage : ContentPage
    {
        TodosViewModel viewModel;
        //private TodosViewModel todosViewModel;

        public TodosPage():this(new TodosViewModel())
        {
        }

        public TodosPage(TodosViewModel todosViewModel)
        {
            //InitializeComponent();

            //
            this.Title = "ToDos";

            var todosDataTemplate = new DataTemplate(() =>
            {
                var lblTitle = new Label()
                {
                    LineBreakMode = LineBreakMode.NoWrap,
                    FontSize = 16
                };
                lblTitle.SetBinding(Label.TextProperty, "Title");

                var lblCompleted = new Label()
                {
                    LineBreakMode = LineBreakMode.NoWrap,
                    FontSize = 16
                };
                lblCompleted.SetBinding(Label.TextProperty, "Completed");

                var stackLayout = new StackLayout()
                {
                    Children =
                    {
                        lblTitle,
                        lblCompleted,

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
                ItemTemplate = todosDataTemplate
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