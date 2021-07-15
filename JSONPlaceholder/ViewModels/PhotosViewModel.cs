using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using JSONPlaceholder.Entities;
using JSONPlaceholder.Util;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class PhotosViewModel :  CollectionViewModel<Photo>
    {
        private Func<Task<RangeObservableCollection<Photo>>> GetItems;

        public PhotosViewModel()
            : this(App.jsonPlaceholder.GetPhotosAsync)
        {
        }

        public PhotosViewModel(Func<Task<RangeObservableCollection<Photo>>> getItems) : base()
        {
            this.GetItems = getItems;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
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
