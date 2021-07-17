using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using JSONPlaceholderApp.Entities;
using Xamarin.Forms;

namespace JSONPlaceholderApp.ViewModels
{
    public class PhotosViewModel :  CollectionViewModel<Photo>
    {
        private Func<Task<ObservableCollection<Photo>>> GetItems;

        public PhotosViewModel()
            : this(App.jsonPlaceholder.GetPhotosAsync)
        {
        }

        public PhotosViewModel(Func<Task<ObservableCollection<Photo>>> getItems) : base()
        {
            this.GetItems = getItems;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
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
