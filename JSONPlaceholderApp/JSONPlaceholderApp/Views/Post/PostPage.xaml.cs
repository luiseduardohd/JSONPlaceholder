using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholderApp.Entities;
using JSONPlaceholderApp.ViewModels;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace JSONPlaceholderApp.Views
{
    [DesignTimeVisible(false)]
    public partial class PostPage : ContentPage
    {
        PostViewModel viewModel;

        public PostPage(PostViewModel viewModel)
        {
            Debug.WriteLine("Time:" + DateTime.Now);
            //InitializeComponent();
            
            var button = new Button()
            {
                Text = "Comments",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            button.Clicked += OnCommentsButtonClicked;

            var labelTitle =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            labelTitle.SetBinding(Label.TextProperty, "Item.Title");

            var labelBody =
                new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            labelBody.SetBinding(Label.TextProperty, "Item.Body");

            this.Content = new ScrollView()
            {
                Content = new StackLayout()
                {
                    Spacing = 20,
                    Padding = 15,
                    Children = {
                        new Label()
                        {
                            Text = "Title:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        labelTitle,
                        new Label()
                        {
                            Text = "Body:",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        },
                        labelBody,
                        button,
                    }
                }
            };
            
            Debug.WriteLine("Time:" + DateTime.Now);
            BindingContext = this.viewModel = viewModel;
        }

        async void OnCommentsButtonClicked(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var post = viewModel.Item;
            Func<Task<ObservableCollection<Comment>>> getItems = async () => await App.jsonPlaceholder.GetCommentsAsync(post);
            await Navigation.PushAsync(new CommentsPage(new CommentsViewModel(getItems)));
        }
    }
}