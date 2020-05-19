using System;
using System.Diagnostics;
using System.Threading.Tasks;
using JSONPlaceholder.Models;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class AlbumsViewModel : CollectionViewModel<Album>
    {
        public AlbumsViewModel() : base()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        protected override async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await App.jsonPlaceholder.GetAlbumsAsync();
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
