using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JSONPlaceholder.Models;
using JSONPlaceholder.Util;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class PhotoGroupViewModel : CollectionViewModel<PhotoGroup>
    {
        public PhotoGroupViewModel(PhotoGroup photoGroup) : this()
        {
        }
        public PhotoGroupViewModel() : base()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        protected override async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                var albums = await App.jsonPlaceholder.GetAlbumsAsync();
                await Task.Delay(500);
                foreach (var album in albums)
                {
                    var photoGroup = new PhotoGroup(album.Title, album);
                    var photos = await App.jsonPlaceholder.GetPhotosAsync(photoGroup.Album);
                    photoGroup.AddRange(photos);
                    Items.Add(photoGroup);
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
