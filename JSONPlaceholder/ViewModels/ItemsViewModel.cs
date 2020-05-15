using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using JSONPlaceholder.Models;
using JSONPlaceholder.Views;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace JSONPlaceholder.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                //var items = await GetPhotos(true);
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
        //async Task<List<Photo>> GetItemsAsync(bool forceRefresh)
        //{
        //    var topHeadlines = await GetTopHeadlines();

        //    var articles = topHeadlines.Articles;
        //    return articles;
        //}


        async Task<List<Photo>> GetPhotos()
        {
            var url = "https://jsonplaceholder.typicode.com/photos";
            var uri = new Uri(url);
            var webClient = new WebClient();
            var json = await webClient.DownloadStringTaskAsync(uri);

            var result = JsonConvert.DeserializeObject<List<Photo>>(json);

            return result;
        }
    }
}