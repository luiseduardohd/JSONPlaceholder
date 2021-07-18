using System;
using JSONPlaceholderApp.Entities;
using System.Threading.Tasks;
namespace JSONPlaceholderApp.ViewModels
{
    public class AlbumViewModel : BaseViewModel<Album>
    {
        public AlbumViewModel(Album item) : base(item)
        {
        }

        public async Task Save()
        {
            //await App.jsonPlaceholder.JSONPlaceholderWebService.UpdateAlbumAsync(Item.Id, Item);
            await App.jsonPlaceholder.JSONPlaceholderSqlite.SaveAlbumAsync(Item);
            //SaveAlbumAsync(Album Album)
        }
    }
}
