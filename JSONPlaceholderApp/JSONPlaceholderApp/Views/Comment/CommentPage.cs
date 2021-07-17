using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholderApp.Entities;
using JSONPlaceholderApp.ViewModels;

namespace JSONPlaceholderApp.Views
{
    [DesignTimeVisible(false)]
    public partial class CommentPage : ContentPage
    {
        CommentViewModel viewModel;

        public CommentPage(CommentViewModel viewModel)
        {
            //InitializeComponent();

            // 

            this.Title = "Comment";

            var lblNameComment =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblNameComment.SetBinding(Label.TextProperty, "Item.Name");

            var lblEmailComment =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblEmailComment.SetBinding(Label.TextProperty, "Item.Email");

            var lblBodyComment =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            lblBodyComment.SetBinding(Label.TextProperty, "Item.Body");


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
                            Text = "Name:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblNameComment,

                        new Label()
                        {
                            Text = "Email:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblEmailComment,

                        new Label()
                        {
                            Text = "Body:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        lblBodyComment,

                    }
                }

            };


            BindingContext = this.viewModel = viewModel;
        }
    }
}