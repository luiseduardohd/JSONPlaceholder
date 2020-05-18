using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSONPlaceholder.Services
{
    public interface IDataStore<T,I>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(I id);
        Task<T> GetItemAsync(I id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
