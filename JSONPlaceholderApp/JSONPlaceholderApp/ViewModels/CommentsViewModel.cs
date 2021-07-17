using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using JSONPlaceholder.Entities;
using JSONPlaceholder.Util;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class CommentsViewModel : CollectionViewModel<Comment>
    {
        private Func<Task<RangeObservableCollection<Comment>>> GetItems;

        public CommentsViewModel()
            :this(
                 App.jsonPlaceholder.GetCommentsAsync
            )
        {
        }

        public CommentsViewModel(Func<Task<RangeObservableCollection<Comment>>> getItems) : base()
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
