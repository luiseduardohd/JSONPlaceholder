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
using JSONPlaceholder.Models;
using FFImageLoading;
using JSONPlaceholder.Database;
using System.IO;
using System.Threading.Tasks;

namespace JSONPlaceholder
{
    public partial class App : Application
    {
        //public IJSONPlaceholder jsonPlaceholder;
        //public JSONPlaceholder.Models.JSONPlaceholder jsonPlaceholder;

        static JSONPlaceholder.Models.JSONPlaceholder _jsonPlaceholder;

        public static JSONPlaceholder.Models.JSONPlaceholder jsonPlaceholder
        {
            get
            {
                if (_jsonPlaceholder == null)
                {

                    var JSONPlaceholderSqlite = new JSONPlaceholderSqlite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "JSONPlaceholder.db3"));
                    //await JSONPlaceholderSqlite.InitializeAsync();
                    var IJSONPlaceholder = RestService.For<IJSONPlaceholder>(Globals.JSONPlaceHolderUrl);

                    _jsonPlaceholder = new Models.JSONPlaceholder(JSONPlaceholderSqlite, IJSONPlaceholder);
                }
                return _jsonPlaceholder;
            }
        }

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

            //var JSONPlaceholderSqlite = new JSONPlaceholderSqlite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "JSONPlaceholder.db3"));
            //JSONPlaceholderSqlite.Initialize();
            ////await JSONPlaceholderSqlite.InitializeAsync();
            //var IJSONPlaceholder = RestService.For<IJSONPlaceholder>(Globals.JSONPlaceHolderUrl);

            //_jsonPlaceholder = new Models.JSONPlaceholder(JSONPlaceholderSqlite, IJSONPlaceholder);
        }

        public async Task InitializeAsync ()
        {
            var JSONPlaceholderSqlite = new JSONPlaceholderSqlite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "JSONPlaceholder.db3"));
            await JSONPlaceholderSqlite.InitializeAsync();
            var IJSONPlaceholder = RestService.For<IJSONPlaceholder>(Globals.JSONPlaceHolderUrl);

            _jsonPlaceholder = new Models.JSONPlaceholder(JSONPlaceholderSqlite, IJSONPlaceholder);
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
