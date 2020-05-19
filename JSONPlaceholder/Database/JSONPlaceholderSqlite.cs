using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JSONPlaceholder.Models;
using SQLite;

namespace JSONPlaceholder.Database
{
    public class JSONPlaceholderSqlite //: IJSONPlaceholder, IInitialize, IInitializeAsync
    {
        public readonly SQLiteAsyncConnection SQLiteAsyncConnection;
        //public readonly SQLiteConnection SQLiteConnection;
        private bool isInitialized = false;

        public JSONPlaceholderSqlite(string dbPath)
        {
            SQLiteAsyncConnection = new SQLiteAsyncConnection(dbPath);
            //SQLiteConnection = new SQLiteConnection(dbPath);
        }

        public void Initialize()
        {
            InitializeAsync().Wait();
        }

        public async Task InitializeAsync()
        {
            if( ! isInitialized )
            {
                await SQLiteAsyncConnection.CreateTableAsync<Post>();
                await SQLiteAsyncConnection.CreateTableAsync<Comment>();
                await SQLiteAsyncConnection.CreateTableAsync<Album>();
                await SQLiteAsyncConnection.CreateTableAsync<Photo>();
                await SQLiteAsyncConnection.CreateTableAsync<Todo>();
                await SQLiteAsyncConnection.CreateTableAsync<User>();
                isInitialized = true;
            }
        }

        #region Post

        public async Task<List<Post>> GetPostsAsync()
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Post>().ToListAsync();
        }
        public async Task<List<Post>> GetPostsAsync(User user)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Post>().Where( x => x.UserId == user.Id).ToListAsync();
        }

        public async Task<Post> GetPostAsync(int id)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Post>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SavePostAsync(Post Post)
        {
            await InitializeAsync();
            if (Post.Id != 0)
            {
                return await SQLiteAsyncConnection.UpdateAsync(Post);
            }
            else
            {
                //if not exists ?
                return await SQLiteAsyncConnection.InsertAsync(Post);
            }
        }

        public async Task<int> DeletePostAsync(Post Post)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.DeleteAsync(Post);
        }

        #endregion Post

        #region Comment

        public async Task<List<Comment>> GetCommentsAsync()
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Comment>().ToListAsync();
        }
        public async Task<List<Comment>> GetCommentsAsync(Post post)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Comment>().Where(x => x.PostId == post.Id).ToListAsync();
        }

        public async Task<Comment> GetCommentAsync(int id)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Comment>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SaveCommentAsync(Comment Comment)
        {
            await InitializeAsync();
            if (Comment.Id != 0)
            {
                return await SQLiteAsyncConnection.UpdateAsync(Comment);
            }
            else
            {
                //if not exists ?
                return await SQLiteAsyncConnection.InsertAsync(Comment);
            }
        }

        public async Task<int> DeleteCommentAsync(Comment Comment)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.DeleteAsync(Comment);
        }

        #endregion Comment

        #region Album

        public async Task<List<Album>> GetAlbumsAsync()
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Album>().ToListAsync();
        }
        public async Task<List<Album>> GetAlbumsAsync(User user)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Album>().Where(x => x.UserId == user.Id).ToListAsync();
        }

        public async Task<Album> GetAlbumAsync(int id)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Album>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SaveAlbumAsync(Album Album)
        {
            await InitializeAsync();
            if (Album.Id != 0)
            {
                return await SQLiteAsyncConnection.UpdateAsync(Album);
            }
            else
            {
                //if not exists ?
                return await SQLiteAsyncConnection.InsertAsync(Album);
            }
        }

        public async Task<int> DeleteAlbumAsync(Album Album)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.DeleteAsync(Album);
        }

        #endregion Album

        #region Photo

        public async Task<List<Photo>> GetPhotosAsync()
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Photo>().ToListAsync();
        }
        public async Task<List<Photo>> GetPhotosAsync(Album album)
        {
            return await SQLiteAsyncConnection.Table<Photo>().Where(x => x.AlbumId == album.Id).ToListAsync();
        }

        public async Task<Photo> GetPhotoAsync(int id)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Photo>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SavePhotoAsync(Photo Photo)
        {
            await InitializeAsync();
            if (Photo.Id != 0)
            {
                return await SQLiteAsyncConnection.UpdateAsync(Photo);
            }
            else
            {
                //if not exists ?
                return await SQLiteAsyncConnection.InsertAsync(Photo);
            }
        }

        public async Task<int> DeletePhotoAsync(Photo Photo)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.DeleteAsync(Photo);
        }

        #endregion Photo

        #region Todo

        public async Task<List<Todo>> GetTodosAsync()
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Todo>().ToListAsync();
        }
        public async Task<List<Todo>> GetTodosAsync(User user)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Todo>().Where(x => x.UserId == user.Id).ToListAsync();
        }

        public async Task<Todo> GetTodoAsync(int id)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<Todo>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SaveTodoAsync(Todo Todo)
        {
            await InitializeAsync();
            if (Todo.Id != 0)
            {
                return await SQLiteAsyncConnection.UpdateAsync(Todo);
            }
            else
            {
                //if not exists ?
                return await SQLiteAsyncConnection.InsertAsync(Todo);
            }
        }

        public async Task<int> DeleteTodoAsync(Todo Todo)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.DeleteAsync(Todo);
        }

        #endregion Todo

        #region User

        public async Task<List<User>> GetUsersAsync()
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<User>().ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.Table<User>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SaveUserAsync(User User)
        {
            await InitializeAsync();
            if (User.Id != 0)
            {
                return await SQLiteAsyncConnection.UpdateAsync(User);
            }
            else
            {
                //if not exists ?
                return await SQLiteAsyncConnection.InsertAsync(User);
            }
        }

        public async Task<int> DeleteUserAsync(User User)
        {
            await InitializeAsync();
            return await SQLiteAsyncConnection.DeleteAsync(User);
        }

        #endregion User


    }
}
