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

        static JSONPlaceholder.Model.JSONPlaceholder _jsonPlaceholder;

        public static JSONPlaceholder.Model.JSONPlaceholder jsonPlaceholder
        {
            get
            {
                if (_jsonPlaceholder == null)
                {
                    var dbFileName = Globals.DBCompleteFileExtension;
                    var JSONPlaceholderSqlite = new JSONPlaceholderSqlite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbFileName));
                    var IJSONPlaceholder = RestService.For<IJSONPlaceholder>(Globals.JSONPlaceHolderUrl);

                    _jsonPlaceholder = new Model.JSONPlaceholder(JSONPlaceholderSqlite, IJSONPlaceholder);
                }
                return _jsonPlaceholder;
            }
        }

        public App()
        {
            InitializeComponent();

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
