using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using JSONPlaceholder.Models;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class PhotosViewModel :  CollectionViewModel<Photo>
    {
        public PhotosViewModel():base()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        protected override async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                //var items = await DataStore.GetItemsAsync(true);
                //var items = GetItemsAsync();
                //var items = await ((App)App.Current).jsonPlaceholder.GetPhotos(new Album() { Id=1});
                var items = await ((App)App.Current).jsonPlaceholder.GetPhotos();
                items[0].ThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b7/Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG/180px-Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG";
                items[1].ThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b7/Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG/180px-Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG";
                items[2].ThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b7/Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG/180px-Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG";
                items[3].ThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b7/Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG/180px-Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG";
                items[4].ThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b7/Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG/180px-Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG";

                Items.AddRange(items);
                //foreach (var item in items)
                //{
                //    Items.Add(item);
                //}
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
        List<Photo> GetItemsAsync()
        {
            return new List<Photo>()
            {
                new Photo { Id = Guid.NewGuid().ToString(), Title = "First Photo"},
                new Photo { Id = Guid.NewGuid().ToString(), Title = "Second Photo"},
                new Photo { Id = Guid.NewGuid().ToString(), Title = "Third Photo"},
                new Photo { Id = Guid.NewGuid().ToString(), Title = "Fourth Photo"},
                new Photo { Id = Guid.NewGuid().ToString(), Title = "Fifth Photo"},
                new Photo { Id = Guid.NewGuid().ToString(), Title = "Sixth Photo"}

            };
        }
    }
}
