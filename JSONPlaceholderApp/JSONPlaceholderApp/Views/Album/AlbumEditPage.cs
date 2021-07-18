using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JSONPlaceholderApp.Entities;
using JSONPlaceholderApp.ViewModels;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace JSONPlaceholderApp.Views
{
    public class AlbumEditPage : ContentPage
    {
        AlbumViewModel viewModel;

        public AlbumEditPage(AlbumViewModel viewModel)
        {
            //InitializeComponent();

            // 
            BindingContext = this.viewModel = viewModel;

            this.Title = "Album";

            var btnSave = new Button()
            {
                Text = "Save",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            btnSave.Clicked += OnSaveButtonClicked;

            var entryTitle =
                new Entry()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
            entryTitle.SetBinding(Entry.TextProperty, "Item.Title");


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
                        entryTitle,
                        btnSave,
                    }
                }

            };

            // 

        }

        async void OnSaveButtonClicked(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var viewModel = this.viewModel;

            await viewModel.Save();
        }
    }
}