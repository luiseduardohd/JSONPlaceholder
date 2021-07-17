using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholderApp.Entities;
using JSONPlaceholderApp.ViewModels;

namespace JSONPlaceholderApp.Views
{
    [DesignTimeVisible(false)]
    public partial class TodoPage : ContentPage
    {
        TodoViewModel viewModel;

        public TodoPage(TodoViewModel viewModel)
        {
            //InitializeComponent();

            // Empiezo a editar

            var lblTitleTodo =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblTitleTodo.SetBinding(Label.TextProperty, "Item.Title");

            var lblCompleted =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblCompleted.SetBinding(Label.TextProperty, "Item.Completed");

            this.Content = new ScrollView()
            {
                Content = new StackLayout()
                {
                    Spacing = 20,
                    Padding = 15,
                    Children =
                    {
                        new Label()
                        {
                            Text = "Title:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblTitleTodo,

                        new Label()
                        {
                            Text = "Completed:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblCompleted,

                    }
                }

            };

            // Termina de editar

            BindingContext = this.viewModel = viewModel;
        }
    }
}