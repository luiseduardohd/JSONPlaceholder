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
            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
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

                var photoGroups = new List<PhotoGroup>();
                foreach(var album in albums)
                {
                    var photoGroup = new PhotoGroup(album.Title, album);

                    photoGroups.Add(photoGroup);
                }
                Items.AddRange(photoGroups);

                DownloadPhotosInBackground(Items);
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


        public void DownloadPhotosInBackground(RangeObservableCollection<PhotoGroup> photoGroups)
        {
            _ = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                await DownloadPhotosAsync(photoGroups);
            });
        }
        public static async Task DownloadPhotosAsync(RangeObservableCollection<PhotoGroup> photoGroups)
        {
            foreach (var photoGroup in photoGroups)
            {
                var photos = await App.jsonPlaceholder.GetPhotosAsync(photoGroup.Album);
                photoGroup.AddRange(photos);
                await Task.Delay(TimeSpan.FromMilliseconds(500));
            }
        }
    }
}
