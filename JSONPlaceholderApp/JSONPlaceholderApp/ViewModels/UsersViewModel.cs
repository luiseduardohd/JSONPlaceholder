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
                Items = await App.jsonPlaceholder.GetUsersAsync();
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
