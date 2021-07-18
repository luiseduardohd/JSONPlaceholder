using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JSONPlaceholderApp.Entities;
using Refit;

namespace JSONPlaceholderApp.WebServices
{
    public interface IJSONPlaceholder
    {

        [Get("/posts/")]
        Task<List<Post>> GetPostsAsync();

        [Get("/users/{user.Id}/posts/")]
        Task<List<Post>> GetPostsAsync(User user);

        [Get("/posts/{postId}")]
        Task<Post> GetPostAsync(int postId);

        [Get("/comments/")]
        Task<List<Comment>> GetCommentsAsync();

        [Get("/posts/{post.Id}/comments/")]
        Task<List<Comment>> GetCommentsAsync(Post post);

        [Get("/users/{user.Id}/albums/")]
        Task<List<Album>> GetAlbumsAsync(User user);

        [Get("/albums/")]
        Task<List<Album>> GetAlbumsAsync();

        [Get("/albums/{albumId}")]
        Task<Album> GetAlbumAsync(int albumId);

        [Put("/albums/{albumId}")]
        Task UpdateAlbumAsync(int albumId,[Body] Album album);

        [Get("/albums/{album.Id}/photos/")]
        Task<List<Photo>> GetPhotosAsync(Album album);

        [Get("/photos/")]
        Task<List<Photo>> GetPhotosAsync();

        [Get("/photos/{photoId}")]
        Task<Photo> GetPhotoAsync(int photoId);

        [Get("/todos/")]
        Task<List<Todo>> GetTodosAsync();

        [Get("/users/{user.Id}/todos/")]
        Task<List<Todo>> GetTodosAsync(User user);

        [Get("/todos/{todoId}")]
        Task<Todo> GetTodoAsync(int todoId);

        [Get("/users/")]
        Task<List<User>> GetUsersAsync();
        [Get("/users/")]
        Task<List<User>> GetUsersAsync(CancellationToken cancellationToken);

        [Get("/user/{userId}")]
        Task<Photo> GetUserAsync(int userId);

    }
}
