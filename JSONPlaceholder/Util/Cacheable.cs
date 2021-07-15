using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;
using Refit;
using SQLite;
using Xamarin.Essentials;

namespace JSONPlaceholder.Util
{
    public static class Cacheable<T>
    {
        //static dinamic ?
        public static ExceptionHandler ExceptionHandler;
        public static ExceptionHandler WebCallExceptionHandler;
        public static ExceptionHandler DatabaseExceptionHandler;
        public static ExceptionHandler NoInternetConnectionExceptionHandler;

        public static async Task<RangeObservableCollection<T>> GetItemAsync(Func<Task<IEnumerable<T>>> databaseAction, Func<Task<IEnumerable<T>>> webServiceAction, SQLiteAsyncConnection SQLiteAsyncConnection)
        {
            var rangeObservableCollection = new RangeObservableCollection<T>();

            try
            {
                await RetrieveFromDatabase(rangeObservableCollection, databaseAction, SQLiteAsyncConnection);
                UpdateInBackground(rangeObservableCollection, webServiceAction, SQLiteAsyncConnection);
            }
            catch (Exception Exception)
            {
                Debug.WriteLine("Exception:" + Exception);
                ExceptionHandler?.HandleException(Exception);
            }

            return rangeObservableCollection;

        }

        public static async Task RetrieveFromDatabase(RangeObservableCollection<T> rangeObservableCollection, Func<Task<IEnumerable<T>>> databaseAction, SQLiteAsyncConnection SQLiteAsyncConnection)
        {
            var items = await databaseAction();
            rangeObservableCollection.AddRange(items);
        }

        public static void UpdateInBackground(RangeObservableCollection<T> rangeObservableCollection, Func<Task<IEnumerable<T>>> webServiceAction, SQLiteAsyncConnection SQLiteAsyncConnection)
        {
            _ = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromMilliseconds(100));
                await TryUpdateAsync(rangeObservableCollection, webServiceAction, SQLiteAsyncConnection);
            });
        }
        public static async Task TryUpdateAsync(RangeObservableCollection<T> rangeObservableCollection, Func<Task<IEnumerable<T>>> webServiceAction, SQLiteAsyncConnection SQLiteAsyncConnection)
        {
            try
            {
                await UpdateAsync(rangeObservableCollection, webServiceAction,  SQLiteAsyncConnection);
            }
            catch (ApiException Exception)
            {
                Debug.WriteLine("Exception:" + Exception);
                WebCallExceptionHandler?.HandleException(Exception);
            }
            catch (SocketException Exception)
            {
                Debug.WriteLine("Exception:" + Exception);
                WebCallExceptionHandler?.HandleException(Exception);
            }
        }
        public static async Task UpdateAsync(RangeObservableCollection<T> rangeObservableCollection, Func<Task<IEnumerable<T>>> webServiceAction, SQLiteAsyncConnection SQLiteAsyncConnection)
        {
            var items = await webServiceAction();
            //await Task.Delay(TimeSpan.FromMilliseconds(100));
            rangeObservableCollection.ClearRange();
            //await Task.Delay(TimeSpan.FromMilliseconds(100));
            rangeObservableCollection.AddRange(items);
            UpdateDatabaseInBackground(items, SQLiteAsyncConnection);
        }
        public static void UpdateDatabaseInBackground(IEnumerable<T> items, SQLiteAsyncConnection SQLiteAsyncConnection)
        {
            _ = Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(1));
                    await UpdateDatabaseAsync(items, SQLiteAsyncConnection);
                }
                catch (Exception Exception)
                {
                    Debug.WriteLine("Exception:" + Exception);
                }
            });
        }
        public static async Task UpdateDatabaseAsync(IEnumerable<T> items, SQLiteAsyncConnection SQLiteAsyncConnection)
        {
            await SQLiteAsyncConnection.RunInTransactionAsync(nonAsyncConnection =>
            {
                nonAsyncConnection.DeleteAll<T>();
                foreach (var item in items)
                {
                    nonAsyncConnection.InsertOrReplace(item);
                }
                //SortedList<T> incomingElements;
                //SortedList<T> DatabaseElements;
            });
        }


    }
}
