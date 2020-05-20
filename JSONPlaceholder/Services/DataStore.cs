using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSONPlaceholder.Entities;


namespace JSONPlaceholder.Services
{
    public class DataStore<T,I> : IDataStore<T,I> where T : Entity<I> 
    {
        readonly List<T> items;

        public DataStore()
        {
            items = new List<T>()
            {
                //new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
                //new T(){ Id = new I()  }


            };
        }

        public async Task<bool> AddItemAsync(T item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            var oldItem = items.Where((T arg) => arg.Id.Equals( item.Id)).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(I id)
        {
            var oldItem = items.Where((T arg) => arg.Id.Equals(id)).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(I id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id.Equals( id) ));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}