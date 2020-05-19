using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using JSONPlaceholder.Database;
using JSONPlaceholder.Util;
using JSONPlaceholder.WebServices;
using Refit;
using SQLite;
using Xamarin.Essentials;

namespace JSONPlaceholder.Models
{
    public class JSONPlaceholder
    {
        private JSONPlaceholderSqlite JSONPlaceholderSqlite;
        private IJSONPlaceholder JSONPlaceholderWebService;

        public JSONPlaceholder(JSONPlaceholderSqlite JSONPlaceholderSqlite, IJSONPlaceholder JSONPlaceholderWebService)
        {
            //JSONPlaceholderSqlite = new JSONPlaceholderSqlite(dbPath);

            this.JSONPlaceholderSqlite = JSONPlaceholderSqlite;
            this.JSONPlaceholderWebService = JSONPlaceholderWebService;

        }
        public async Task<ObservableCollection<Post>> GetPostsAsync()
        {
            //var rangeObservableCollection = new RangeObservableCollection<Post>();

            //            var items = await JSONPlaceholderSqlite.GetPostsAsync();
            //            if ( items.Count > 0 )
            //            {
            //                rangeObservableCollection.AddRange(items);
            //#pragma warning disable CS4014
            //                Task.Run(async () => {
            //                    await Task.Delay(TimeSpan.FromSeconds(1));
            //                    items = await JSONPlaceholderWebService.GetPostsAsync();
            //                });
            //#pragma warning restore CS4014
            //            }
            //            else
            //            {
            //                items = await JSONPlaceholderWebService.GetPostsAsync();
            //                rangeObservableCollection.AddRange(items);
            //#pragma warning disable CS4014
            //                Task.Run(async () => {
            //                    await JSONPlaceholderSqlite.SQLiteAsyncConnection.RunInTransactionAsync(nonAsyncConnection =>
            //                    {
            //                        foreach (var item in items)
            //                        {
            //                            nonAsyncConnection.InsertOrReplace(item);
            //                        }
            //                    });
            //                });
            //#pragma warning restore CS4014
            //            }

            var rangeObservableCollection = await TClass<Post>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetPostsAsync(),
                async () => await JSONPlaceholderWebService.GetPostsAsync(),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }

        public async Task<ObservableCollection<Post>> GetPostAsync(User user)
        {
            var rangeObservableCollection = await TClass<Post>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetPostsAsync(user),
                async () => await JSONPlaceholderWebService.GetPostsAsync(user),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }
        

        public async Task<ObservableCollection<Comment>> GetCommentsAsync()
        {
            var rangeObservableCollection = await TClass<Comment>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetCommentsAsync(),
                async () => await JSONPlaceholderWebService.GetCommentsAsync(),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }


        public async Task<ObservableCollection<Comment>> GetCommentsAsync(Post post)
        {
            var rangeObservableCollection = await TClass<Comment>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetCommentsAsync(post),
                async () => await JSONPlaceholderWebService.GetCommentsAsync(post),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }




        public async Task<ObservableCollection<Album>> GetAlbumsAsync()
        {
            var rangeObservableCollection = await TClass<Album>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetAlbumsAsync(),
                async () => await JSONPlaceholderWebService.GetAlbumsAsync(),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }


        public async Task<ObservableCollection<Album>> GetAlbumsAsync(User user)
        {
            var rangeObservableCollection = await TClass<Album>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetAlbumsAsync(user),
                async () => await JSONPlaceholderWebService.GetAlbumsAsync(user),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }


        //Task<Album> GetAlbumAsync(int albumId);


        public async Task<ObservableCollection<Photo>> GetPhotosAsync()
        {
            var rangeObservableCollection = await TClass<Photo>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetPhotosAsync(),
                async () => await JSONPlaceholderWebService.GetPhotosAsync(),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }

        public async Task<ObservableCollection<Photo>> GetPhotosAsync(Album album)
        {
            var rangeObservableCollection = await TClass<Photo>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetPhotosAsync(album),
                async () => await JSONPlaceholderWebService.GetPhotosAsync(album),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }



        //Task<Photo> GetPhotoAsync(int photoId);


        public async Task<ObservableCollection<Todo>> GetTodosAsync()
        {
            var rangeObservableCollection = await TClass<Todo>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetTodosAsync(),
                async () => await JSONPlaceholderWebService.GetTodosAsync(),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }


        public async Task<ObservableCollection<Todo>> GetTodosAsync(User user)
        {
            var rangeObservableCollection = await TClass<Todo>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetTodosAsync(user),
                async () => await JSONPlaceholderWebService.GetTodosAsync(user),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }


        //Task<Todo> GetTodoAsync(int todoId);


        public async Task<ObservableCollection<User>> GetUsersAsync()
        {
            //var rangeObservableCollection = await TClass<User>.GetItemAsync(
            //    async () => await JSONPlaceholderSqlite.GetUsersAsync(),
            //    async () => await JSONPlaceholderWebService.GetUsersAsync(),
            //    JSONPlaceholderSqlite.SQLiteAsyncConnection);

            //return rangeObservableCollection;


//            var rangeObservableCollection = new RangeObservableCollection<User>();

//            var items = await JSONPlaceholderSqlite.GetUsersAsync();
//            if (items.Count > 0)
//            {
//                rangeObservableCollection.AddRange(items);

//                _ = Task.Run(async () =>
//                  {
//                      await Task.Delay(TimeSpan.FromSeconds(1));
//                      items = await JSONPlaceholderWebService.GetUsersAsync();
//                      rangeObservableCollection.ClearRange();
//                      rangeObservableCollection.AddRange(items);
//                      _ = Task.Run(async () =>
//                        {
//                            await Task.Delay(TimeSpan.FromMilliseconds(1));
//                            await JSONPlaceholderSqlite.SQLiteAsyncConnection.DeleteAllAsync<User>();
//                            await JSONPlaceholderSqlite.SQLiteAsyncConnection.RunInTransactionAsync(nonAsyncConnection =>
//                            {
//                                foreach (var item in items)
//                                {
//                                    nonAsyncConnection.InsertOrReplace(item);
//                                }
//                            });
//                        });
//                  });

//            }
//            else
//            {
//                items = await JSONPlaceholderWebService.GetUsersAsync();
//                rangeObservableCollection.AddRange(items);
//#pragma warning disable CS4014
//                Task.Run(async () =>
//                {
//                    await Task.Delay(TimeSpan.FromMilliseconds(1));
//                    await JSONPlaceholderSqlite.SQLiteAsyncConnection.DeleteAllAsync<User>();
//                    await JSONPlaceholderSqlite.SQLiteAsyncConnection.RunInTransactionAsync(nonAsyncConnection =>
//                    {
//                        foreach (var item in items)
//                        {
//                            nonAsyncConnection.InsertOrReplace(item);
//                        }
//                    });
//                });
//#pragma warning restore CS4014
//            }

            var rangeObservableCollection = await TClass<User>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetUsersAsync(),
                async () => await JSONPlaceholderWebService.GetUsersAsync(),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }


        //Task<Photo> GetUserAsync(int userId);



        private static class TClass<T>
        {

            public static async Task<ObservableCollection<T>> GetItemAsync(Func<Task<IEnumerable<T>>> databaseAction, Func<Task<IEnumerable<T>>> webServiceAction, SQLiteAsyncConnection SQLiteAsyncConnection)
            {
                var rangeObservableCollection = new RangeObservableCollection<T>();


                //var items = await databaseAction();

                //if (items.Count() > 0)
                //{
                //    rangeObservableCollection.AddRange(items);

                //    UpdateInBackground(rangeObservableCollection, items, webServiceAction, SQLiteAsyncConnection);
                //}
                //else
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
                catch (ApiException )
                {
                    var items = await databaseAction();
                    rangeObservableCollection.AddRange(items);
                }
                catch (SocketException)
                {
                    var items = await databaseAction();
                    rangeObservableCollection.AddRange(items);
                }
                catch (Exception Exception)
                {
                    Debug.WriteLine("Exception:"+ Exception);
                }

                return rangeObservableCollection;

            }

            public static void UpdateInBackground(RangeObservableCollection<T> rangeObservableCollection, IEnumerable<T> items, Func<Task<IEnumerable<T>>> webServiceAction, SQLiteAsyncConnection SQLiteAsyncConnection)
            {
                _ = Task.Run(async () =>
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(1));
                    await UpdateAsync( rangeObservableCollection, items, webServiceAction, SQLiteAsyncConnection);
                });
            }
            public static async Task UpdateAsync(RangeObservableCollection<T> rangeObservableCollection,IEnumerable<T> items, Func<Task<IEnumerable<T>>> webServiceAction, SQLiteAsyncConnection SQLiteAsyncConnection)
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
                    await Task.Delay(TimeSpan.FromMilliseconds(1));
                    await UpdateDatabaseAsync(items, SQLiteAsyncConnection);
                });
            }
            public static async Task UpdateDatabaseAsync(IEnumerable<T> items,SQLiteAsyncConnection SQLiteAsyncConnection)
            {
                await SQLiteAsyncConnection.DeleteAllAsync<User>();
                await SQLiteAsyncConnection.RunInTransactionAsync(nonAsyncConnection =>
                {
                    foreach (var item in items)
                    {
                        nonAsyncConnection.InsertOrReplace(item);
                    }
                });
            }

            //            public static async Task<ObservableCollection<T>> GetItemAsync(Func<Task<IEnumerable<T>>> databaseAction, Func<Task<IEnumerable<T>>> webServiceAction, SQLiteAsyncConnection SQLiteAsyncConnection)
            //            {
            //                var rangeObservableCollection = new RangeObservableCollection<T>();

            //                //var items = await JSONPlaceholderSqlite.GetPostsAsync();

            //                //var items = await databaseAction(); // Mono Bug
            //                /*
            //                if (items.Count() > 0)
            //                {
            //                    rangeObservableCollection.AddRange(items);
            //#pragma warning disable CS4014
            //                    Task.Run(async () => {
            //                        await Task.Delay(TimeSpan.FromSeconds(1));
            //                        items = await webServiceAction();
            //                    });
            //#pragma warning restore CS4014
            //                }
            //                else*/
            //                try
            //                {
            //                    var items = await webServiceAction();
            //                    rangeObservableCollection.AddRange(items);
            //#pragma warning disable CS4014
            //                    Task.Run(async () => {
            //                        await SQLiteAsyncConnection.RunInTransactionAsync(nonAsyncConnection =>
            //                        {
            //                            foreach (var item in items)
            //                            {
            //                                nonAsyncConnection.InsertOrReplace(item);
            //                            }
            //                        });
            //                    });
            //#pragma warning restore CS4014
            //                }
            //                catch(Exception Exception)
            //                {
            //                    Debug.WriteLine("Exception:" + Exception);
            //                }

            //                return rangeObservableCollection;

            //            }
        }
    }
}
