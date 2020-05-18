﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using AsyncAwaitBestPractices.MVVM;
using JSONPlaceholder.Models;
using JSONPlaceholder.Util;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class CollectionViewModel <T>: BaseViewModel<T>
    {
        public RangeObservableCollection<T> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public AsyncCommand<T> AddItemCommand { get; set; }

        public CollectionViewModel()
        {
            Title = "Browse";
            Items = new RangeObservableCollection<T>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new AsyncCommand<T>(async (item) => await ExecuteAddItemCommand(item));

            /*
            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
            */
        }
        async Task ExecuteAddItemCommand(T item)
        {
            //var newItem = item as Item;
            var newItem = item ;
            Items.Add(item);
            await DataStore.AddItemAsync(newItem);
        }

        protected virtual async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
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
    }
}