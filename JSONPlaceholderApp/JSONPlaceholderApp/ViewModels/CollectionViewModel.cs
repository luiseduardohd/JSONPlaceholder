using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices.MVVM;
using JSONPlaceholder.Entities;
using JSONPlaceholder.Util;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class CollectionViewModel <T>: BaseViewModel<T,int>
    {
        RangeObservableCollection<T> items = new RangeObservableCollection<T>();
        public RangeObservableCollection<T> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }
        public Command LoadItemsCommand { get; set; }
        public AsyncCommand<T> AddItemCommand { get; set; }
        

        public CollectionViewModel()
        {
            Title = "Browse";
            //Items = new RangeObservableCollection<T>();
            //BindingBase.EnableCollectionSynchronization(Items, null, ObservableCollectionCallback);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new AsyncCommand<T>(async (item) => await ExecuteAddItemCommand(item));
            
        }

        protected void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
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

        protected bool SetProperty(ref IEnumerable<T> backingStore, IEnumerable<T> value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            //if (EqualityComparer<T>.Default.Equals(backingStore, value))
            //    return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}