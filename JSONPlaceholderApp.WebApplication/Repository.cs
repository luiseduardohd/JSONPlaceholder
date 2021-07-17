
using JSONPlaceholderApp.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONPlaceholderApp.WebApplication
{
    public class Repository
    {
        public SQLiteAsyncConnection AsyncConnection;

        public Repository(string dbPath)
        {
            AsyncConnection = new SQLiteAsyncConnection(dbPath);
            AsyncConnection.CreateTableAsync<Test>().Wait();
            AsyncConnection.CreateTableAsync<Post>().Wait();
            AsyncConnection.CreateTableAsync<Photo>().Wait();
            AsyncConnection.CreateTableAsync<Address>().Wait();
        }

        public Task<List<Test>> GetTestsAsync()
        {
            return AsyncConnection.Table<Test>().ToListAsync();
        }

        public Task<List<Post>> GetPostAsync()
        {
            return AsyncConnection.Table<Post>().ToListAsync();
        }

        public Task<List<Photo>> GetPhotoAsync()
        {
            return AsyncConnection.Table<Photo>().ToListAsync();
        }

        public Task<List<Address>> GetAddressAsync()
        {
            return AsyncConnection.Table<Address>().ToListAsync();
        }

        public Task<int> SaveTestAsync(Test newTest)
        {
            return AsyncConnection.InsertAsync(newTest);
        }

        public Task<int> SavePostAsync(Post newPost)
        {
            return AsyncConnection.InsertAsync(newPost);
        }

        public Task<int> SavePhotoAsync(Photo newPhoto)
        {
            return AsyncConnection.InsertAsync(newPhoto);
        }

        public Task<int> SaveAsync(Photo newPhoto)
        {
            return AsyncConnection.InsertAsync(newPhoto);
        }

        public Task<int> SaveAsync(Address newAddress)
        {
            return AsyncConnection.InsertAsync(newAddress);
        }
    }
}
