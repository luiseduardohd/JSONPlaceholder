using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using JSONPlaceholderApp.Entities;
using Nito.AsyncEx;
using Xamarin.Forms;

namespace JSONPlaceholderApp.ViewModels
{
    public class TodosViewModel : CollectionViewModel<Todo>
    {
        //private AsyncLazy<ObservableCollection<Todo>> asyncTodos;

        private Func<Task<ObservableCollection<Todo>>> GetItems;

        public TodosViewModel()
            : this(App.jsonPlaceholder.GetTodosAsync)
        /*
        : this(
              new AsyncLazy<ObservableCollection<Todo>>(
                App.jsonPlaceholder.GetTodosAsync
                )
              )
        */
        {
        }

        //public TodosViewModel(AsyncLazy<ObservableCollection<Todo>> asyncTodos):base()
        public TodosViewModel(Func<Task<ObservableCollection<Todo>>> GetItems) : base()
        {
            this.GetItems = GetItems;
            LoadItemsCommand = new Command(
                async () => await ExecuteLoadItemsCommand()
                );
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
