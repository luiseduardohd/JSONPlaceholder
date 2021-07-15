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
using JSONPlaceholder.Entities;
using Refit;
using SQLite;
using Xamarin.Essentials;

namespace JSONPlaceholder.Model
{
    public class JSONPlaceholder 
    {
        private JSONPlaceholderSqlite JSONPlaceholderSqlite;
        private IJSONPlaceholder JSONPlaceholderWebService;

        public JSONPlaceholder(JSONPlaceholderSqlite JSONPlaceholderSqlite, IJSONPlaceholder JSONPlaceholderWebService)
        {
            this.JSONPlaceholderSqlite = JSONPlaceholderSqlite;
            this.JSONPlaceholderWebService = JSONPlaceholderWebService;
        }
        public async Task<RangeObservableCollection<Post>> GetPostsAsync()
        {
            var rangeObservableCollection = await Cacheable<Post>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetPostsAsync(),
                async () => await JSONPlaceholderWebService.GetPostsAsync(),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }

        public async Task<RangeObservableCollection<Post>> GetPostsAsync(User user)
        {
            var rangeObservableCollection = await Cacheable<Post>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetPostsAsync(user),
                async () => await JSONPlaceholderWebService.GetPostsAsync(user),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }
        

        public async Task<RangeObservableCollection<Comment>> GetCommentsAsync()
        {
            var rangeObservableCollection = await Cacheable<Comment>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetCommentsAsync(),
                async () => await JSONPlaceholderWebService.GetCommentsAsync(),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }


        public async Task<RangeObservableCollection<Comment>> GetCommentsAsync(Post post)
        {
            var rangeObservableCollection = await Cacheable<Comment>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetCommentsAsync(post),
                async () => await JSONPlaceholderWebService.GetCommentsAsync(post),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }




        public async Task<RangeObservableCollection<Album>> GetAlbumsAsync()
        {
            var rangeObservableCollection = await Cacheable<Album>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetAlbumsAsync(),
                async () => await JSONPlaceholderWebService.GetAlbumsAsync(),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }


        public async Task<RangeObservableCollection<Album>> GetAlbumsAsync(User user)
        {
            var rangeObservableCollection = await Cacheable<Album>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetAlbumsAsync(user),
                async () => await JSONPlaceholderWebService.GetAlbumsAsync(user),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }


        //Task<Album> GetAlbumAsync(int albumId);


        public async Task<RangeObservableCollection<Photo>> GetPhotosAsync()
        {
            var rangeObservableCollection = await Cacheable<Photo>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetPhotosAsync(),
                async () => await JSONPlaceholderWebService.GetPhotosAsync(),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }

        public async Task<RangeObservableCollection<Photo>> GetPhotosAsync(Album album)
        {
            var rangeObservableCollection = await Cacheable<Photo>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetPhotosAsync(album),
                async () => await JSONPlaceholderWebService.GetPhotosAsync(album),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }



        //Task<Photo> GetPhotoAsync(int photoId);


        public async Task<RangeObservableCollection<Todo>> GetTodosAsync()
        {
            var rangeObservableCollection = await Cacheable<Todo>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetTodosAsync(),
                async () => await JSONPlaceholderWebService.GetTodosAsync(),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }


        public async Task<RangeObservableCollection<Todo>> GetTodosAsync(User user)
        {
            var rangeObservableCollection = await Cacheable<Todo>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetTodosAsync(user),
                async () => await JSONPlaceholderWebService.GetTodosAsync(user),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }


        //Task<Todo> GetTodoAsync(int todoId);


        public async Task<RangeObservableCollection<User>> GetUsersAsync()
        {

            var rangeObservableCollection = await Cacheable<User>.GetItemAsync(
                async () => await JSONPlaceholderSqlite.GetUsersAsync(),
                async () => await JSONPlaceholderWebService.GetUsersAsync(),
                JSONPlaceholderSqlite.SQLiteAsyncConnection);

            return rangeObservableCollection;
        }

    }
}
