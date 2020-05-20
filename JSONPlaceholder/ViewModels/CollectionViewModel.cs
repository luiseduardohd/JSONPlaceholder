using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using AsyncAwaitBestPractices.MVVM;
using JSONPlaceholder.Entities;
using JSONPlaceholder.Util;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class CollectionViewModel <T>: BaseViewModel<T,int>
    {
        public RangeObservableCollection<T> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public AsyncCommand<T> AddItemCommand { get; set; }

        public CollectionViewModel()
        {
            Title = "Browse";
            Items = new RangeObservableCollection<T>();
            BindingBase.EnableCollectionSynchronization(Items, null, ObservableCollectionCallback);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new AsyncCommand<T>(async (item) => await ExecuteAddItemCommand(item));

        }
        void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
        {
            lock (collection)
            {
                accessMethod?.Invoke();
            }
        }
        async Task ExecuteAddItemCommand(T item)
        {
            var newItem = item ;
            Items.Add(item);
            await DataStore.AddItemAsync(newItem);
        }

        protected virtual async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
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