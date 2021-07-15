using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JSONPlaceholder.Entities;
using JSONPlaceholder.Util;
using Xamarin.Forms;

namespace JSONPlaceholder.ViewModels
{
    public class PhotoGroupViewModel : CollectionViewModel<PhotoGroup>
    {
        public Command RemainingItemsThresholdReachedCommand { get; set; }
        public Command RefreshItemsCommand { get; set; }
        

        private RangeObservableCollection<Album> Groups =  new RangeObservableCollection<Album>();
        private int CurrentGroup = -1;// -1 no current group

        public int RemainingItemsThreshold
        {
            get { return (CurrentGroup != -1)? Groups.Count-CurrentGroup:-1; }
        }


        public PhotoGroupViewModel(PhotoGroup photoGroup) : this()
        {
        }
        public PhotoGroupViewModel() : base()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            RemainingItemsThresholdReachedCommand = new Command(async () => await RemainingItemsThresholdReached());
            RefreshItemsCommand = new Command(async () =>
            {
                await ExecuteLoadItemsCommand();
            });
        }

        async Task<RangeObservableCollection<Album>> GetGroups()
        {
            var albums = await App.jsonPlaceholder.GetAlbumsAsync();
            return albums;
        }
        bool CanLoadNextGroup(int currentGroup, RangeObservableCollection<Album> groups)
        {
            if (currentGroup + 1 < groups.Count)
                return true;
            else
                return false;
        }
        async Task TryLoadNextGroup(int currentGroup, RangeObservableCollection<Album> groups, RangeObservableCollection<PhotoGroup> Items)
        {
            if( CanLoadNextGroup( currentGroup,  groups) )
            {
                await LoadGroup( groups[currentGroup+1],Items);
                await Task.Delay(1000);
            }                
        }
        async Task LoadGroup(Album album, RangeObservableCollection<PhotoGroup> Items)
        {

            var photoGroup = new PhotoGroup(album.Title, album);
            var photos = await App.jsonPlaceholder.GetPhotosAsync(photoGroup.Album);
            photoGroup.ClearRange();
            photoGroup.AddRange(photos);
            Items.Add(photoGroup);
            //await Task.Delay(1000);
        }

        protected override async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                //takes too much time to load all.
                //await LoadAll();

                //Not working correctly Xamarin forms issue
                //https://github.com/xamarin/Xamarin.Forms/issues/8383
                await LoadFirstGroup();
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
        async Task LoadAll()
        {
            Items.Clear();
            await Task.Delay(100);
            var albums = await GetGroups();
            await Task.Delay(500);
            //foreach (var album in albums)
            //{
            //    var photoGroup = new PhotoGroup(album.Title, album);
            //    Items.Add(photoGroup);
            //}
            foreach (var album in albums)
            {
                var photoGroup = new PhotoGroup(album.Title, album);
                var photos = await App.jsonPlaceholder.GetPhotosAsync(photoGroup.Album);
                photoGroup.AddRange(photos);
                Items.Add(photoGroup);
                await Task.Delay(1000);
            }
        }
        async Task LoadFirstGroup()
        {
            //Items.Clear();

            //TryLoadNextGroup
            await Task.Delay(100);
            var albums = await GetGroups();
            Groups = albums;

            if (Groups.Count() == 0)
            {
                return;
            }
            //foreach (var album in albums)
            //{
            //    var photoGroup = new PhotoGroup(album.Title, album);
            //    Items.Add(photoGroup);
            //}
            await Task.Delay(1000);
            await TryLoadNextGroup(CurrentGroup, Groups, Items);
        }



        async Task RemainingItemsThresholdReached()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await TryLoadNextGroup(CurrentGroup, Groups,Items);
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
