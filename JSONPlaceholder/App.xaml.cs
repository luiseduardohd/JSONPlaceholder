using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JSONPlaceholder.Services;
using JSONPlaceholder.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Refit;
using JSONPlaceholder.WebServices;
using JSONPlaceholder.Util;
using FFImageLoading;

namespace JSONPlaceholder
{
    public partial class App : Application
    {
        public IJSONPlaceholder jsonPlaceholder;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
            JsonConvert.DefaultSettings =
                () => new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = { new StringEnumConverter() }
                };
            jsonPlaceholder = RestService.For<IJSONPlaceholder>(Globals.JSONPlaceHolderUrl);
            //FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            //FFImageLoading.Forms.
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
