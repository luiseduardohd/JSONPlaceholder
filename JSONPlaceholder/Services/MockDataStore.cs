using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSONPlaceholder.Models;

namespace JSONPlaceholder.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Title = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Title = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Title = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Title = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Title = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Title = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}