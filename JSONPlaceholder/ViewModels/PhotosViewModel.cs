using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using JSONPlaceholder.Models;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class PhotosViewModel :  CollectionViewModel<Photo>
    {
        public PhotosViewModel():base()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        protected override async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await App.jsonPlaceholder.GetPhotosAsync();
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
