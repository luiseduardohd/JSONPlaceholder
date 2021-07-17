using JSONPlaceholderApp.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONPlaceholderApp.WebApplication
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Test>().Wait();
        }

        public Task<List<Test>> GetTestsAsync()
        {
            return _database.Table<Test>().ToListAsync();
        }

        public Task<int> SaveTestAsync(Test newTest)
        {
            return _database.InsertAsync(newTest);
        }
    }
}
