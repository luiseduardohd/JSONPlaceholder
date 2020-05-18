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
                //var items = await DataStore.GetItemsAsync(true);
                var items = GetItemsAsync();
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
        List<Photo> GetItemsAsync()
        {
            return new List<Photo>()
            {
                new Photo { Id = Guid.NewGuid().ToString(), Title = "First Photo"},
                new Photo { Id = Guid.NewGuid().ToString(), Title = "Second Photo"},
                new Photo { Id = Guid.NewGuid().ToString(), Title = "Third Photo"},
                new Photo { Id = Guid.NewGuid().ToString(), Title = "Fourth Photo"},
                new Photo { Id = Guid.NewGuid().ToString(), Title = "Fifth Photo"},
                new Photo { Id = Guid.NewGuid().ToString(), Title = "Sixth Photo"}

            };
        }
    }
}
