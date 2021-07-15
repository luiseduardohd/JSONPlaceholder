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
    public class AlbumsViewModel : CollectionViewModel<Album>
    {
        //private AsyncLazy<ObservableCollection<Album>> asyncAlbums;

        private Func<Task<RangeObservableCollection<Album>>> GetItems;

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
        public AlbumsViewModel(Func<Task<RangeObservableCollection<Album>>> GetItems) : base()
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
