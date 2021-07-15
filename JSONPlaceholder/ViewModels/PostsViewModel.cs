using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using JSONPlaceholder.Entities;
using JSONPlaceholder.Util;
using Nito.AsyncEx;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class PostsViewModel : CollectionViewModel<Post>
    {
        //private AsyncLazy<ObservableCollection<Post>> asyncPosts;

        private Func<Task<RangeObservableCollection<Post>>> GetItems;

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
        public PostsViewModel(Func<Task<RangeObservableCollection<Post>>> GetItems) : base()
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
                Items = await GetItems();
                BindingBase.EnableCollectionSynchronization(Items, null, ObservableCollectionCallback);
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
