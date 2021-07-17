using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using JSONPlaceholderApp.Entities;
using Nito.AsyncEx;
using Xamarin.Forms;

namespace JSONPlaceholderApp.ViewModels
{
    public class PostsViewModel : CollectionViewModel<Post>
    {
        //private AsyncLazy<ObservableCollection<Post>> asyncPosts;

        private Func<Task<ObservableCollection<Post>>> GetItems;

        public PostsViewModel()
            : this(App.jsonPlaceholder.GetPostsAsync)
        /*
        : this(
              new AsyncLazy<ObservableCollection<Post>>(
                App.jsonPlaceholder.GetPostsAsync
                )
              )
        */
        {
        }

        //public PostsViewModel(AsyncLazy<ObservableCollection<Post>> asyncPosts):base()
        public PostsViewModel(Func<Task<ObservableCollection<Post>>> GetItems) : base()
        {
            this.GetItems = GetItems;
            LoadItemsCommand = new Command(
                async () => await ExecuteLoadItemsCommand()
                );
        }

        protected override async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await GetItems();
                Items.AddRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
