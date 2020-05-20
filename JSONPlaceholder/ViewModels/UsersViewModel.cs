using System;
using System.Diagnostics;
using System.Threading.Tasks;
using JSONPlaceholder.Entities;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class UsersViewModel : CollectionViewModel<User>
    {
        public UsersViewModel() : base()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        protected override async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await App.jsonPlaceholder.GetUsersAsync();
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
