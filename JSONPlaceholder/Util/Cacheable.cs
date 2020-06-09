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

        public static async Task<ObservableCollection<T>> GetItemAsync(Func<Task<IEnumerable<T>>> databaseAction, Func<Task<IEnumerable<T>>> webServiceAction, SQLiteAsyncConnection SQLiteAsyncConnection)
        {
            var rangeObservableCollection = new RangeObservableCollection<T>();

            try
            {
                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    var items = await webServiceAction();
                    rangeObservableCollection.AddRange(items);

                    UpdateDatabaseInBackground(items, SQLiteAsyncConnection);
                }
                else
                {
                    var items = await databaseAction();
                    rangeObservableCollection.AddRange(items);
                }
            }
            catch (ApiException Exception)
            {
                Debug.WriteLine("Exception:" + Exception);
                var items = await databaseAction();
                rangeObservableCollection.AddRange(items);
                WebCallExceptionHandler?.HandleException(Exception);
            }
            catch (SocketException Exception)
            {
                Debug.WriteLine("Exception:" + Exception);
                var items = await databaseAction();
                rangeObservableCollection.AddRange(items);
                WebCallExceptionHandler?.HandleException(Exception);
            }
            catch (Exception Exception)
            {
                Debug.WriteLine("Exception:" + Exception);
                ExceptionHandler?.HandleException(Exception);
            }

            return rangeObservableCollection;

        }

        public static void UpdateInBackground(RangeObservableCollection<T> rangeObservableCollection, IEnumerable<T> items, Func<Task<IEnumerable<T>>> webServiceAction, SQLiteAsyncConnection SQLiteAsyncConnection)
        {
            _ = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromMilliseconds(1));
                await UpdateAsync(rangeObservableCollection, items, webServiceAction, SQLiteAsyncConnection);
            });
        }
        public static async Task UpdateAsync(RangeObservableCollection<T> rangeObservableCollection, IEnumerable<T> items, Func<Task<IEnumerable<T>>> webServiceAction, SQLiteAsyncConnection SQLiteAsyncConnection)
        {
            items = await webServiceAction();
            rangeObservableCollection.ClearRange();
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
                //nonAsyncConnection.Delete
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
