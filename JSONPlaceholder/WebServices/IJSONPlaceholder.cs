using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JSONPlaceholder.Models;
using Refit;

namespace JSONPlaceholder.WebServices
{
    public interface IJSONPlaceholder
    {
        //[Get("/posts/{user}")]
        //Task<User> GetPosts(string user);

        //[Get("/posts/{user}")]
        //Task<User> GetPosts(string user);

        [Get("/posts/")]
        Task<List<Post>> GetPosts();

        [Get("/users/{user.Id}/posts/")]
        Task<Post> GetPost(User user);

        [Get("/posts/{postId}")]
        Task<Post> GetPost(int postId);

        [Get("/comments/")]
        Task<List<Comment>> GetComments();

        [Get("/posts/{post.Id}/comments/")]
        Task<List<Comment>> GetComments(Post post);

        [Get("/users/{user.Id}/albums/")]
        Task<List<Album>> GetAlbums(User user);

        [Get("/albums/")]
        Task<List<Album>> GetAlbums();

        [Get("/albums/{albumId}")]
        Task<Album> GetAlbum(int albumId);

        [Get("/albums/{album.Id}/photos/")]
        Task<List<Photo>> GetPhotos(Album album);

        [Get("/photos/")]
        Task<List<Photo>> GetPhotos();

        [Get("/photos/{photoId}")]
        Task<Photo> GetPhoto(int photoId);

        [Get("/todos/")]
        Task<List<Todo>> GetTodos();

        [Get("/users/{user.Id}/todos/")]
        Task<List<Todo>> GetTodos(User user);

        [Get("/todos/{todoId}")]
        Task<Todo> GetTodo(int todoId);

        [Get("/users/")]
        Task<List<User>> GetUsers();

        [Get("/user/{userId}")]
        Task<Photo> GetUser(int userId);

    }
}
