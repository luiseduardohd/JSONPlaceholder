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
using JSONPlaceholder.Entities;
using FFImageLoading;
using JSONPlaceholder.Database;
using System.IO;
using System.Threading.Tasks;

namespace JSONPlaceholder
{
    public partial class App : Application
    {

        static JSONPlaceholder.Entities.JSONPlaceholder _jsonPlaceholder;

        public static JSONPlaceholder.Entities.JSONPlaceholder jsonPlaceholder
        {
            get
            {
                if (_jsonPlaceholder == null)
                {
                    var dbFileName = Globals.DBCompleteFileExtension;
                    var JSONPlaceholderSqlite = new JSONPlaceholderSqlite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbFileName));
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
