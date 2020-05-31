using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using JSONPlaceholder.Entities;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class CommentsViewModel : CollectionViewModel<Comment>
    {
        private Func<Task<ObservableCollection<Comment>>> GetItems;

        public CommentsViewModel()
            :this(
                 App.jsonPlaceholder.GetCommentsAsync
            )
        {
        }

        public CommentsViewModel(Func<Task<ObservableCollection<Comment>>> getItems) : base()
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
