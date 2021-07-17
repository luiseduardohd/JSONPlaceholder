using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using JSONPlaceholderApp.Entities;
using Nito.AsyncEx;
using Xamarin.Forms;

namespace JSONPlaceholderApp.ViewModels
{
    public class AlbumsViewModel : CollectionViewModel<Album>
    {
        //private AsyncLazy<ObservableCollection<Album>> asyncAlbums;

        private Func<Task<ObservableCollection<Album>>> GetItems;

        //No parameter load all.
        public AlbumsViewModel()
            :this(App.jsonPlaceholder.GetAlbumsAsync)
            /*
            : this(
                  new AsyncLazy<ObservableCollection<Album>>(
                    async () => await App.jsonPlaceholder.GetAlbumsAsync()
                    )
                  )
            */
        {
        }

        //public AlbumsViewModel(AsyncLazy<ObservableCollection<Album>> asyncAlbums):base()
        public AlbumsViewModel(Func<Task<ObservableCollection<Album>>> GetItems) : base()
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
