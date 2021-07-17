using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JSONPlaceholderApp.Views
{
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            //InitializeComponent();

            //NavigationPage commentsNavigationPage = new NavigationPage(new CommentsPage());
            //commentsNavigationPage.Title = "Comments";
            //Children.Add(commentsNavigationPage);
            Children.Add(new UsersPage());
            Children.Add(new CommentsPage());
            Children.Add(new PostsPage());
            Children.Add(new PhotosPage());
            Children.Add(new AlbumsPage());

        }
    }
}