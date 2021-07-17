using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JSONPlaceholderApp.Services;
using JSONPlaceholderApp.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Refit;
using JSONPlaceholderApp.WebServices;
using JSONPlaceholderApp.Util;
using JSONPlaceholderApp.Entities;
using FFImageLoading;
using JSONPlaceholderApp;
using JSONPlaceholderApp.Database;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using System.Diagnostics;

namespace JSONPlaceholderApp
{
    public partial class App : Application
    {

        static JSONPlaceholderApp.Model.JSONPlaceholder _jsonPlaceholder;

        public static JSONPlaceholderApp.Model.JSONPlaceholder jsonPlaceholder
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
            Xamarin.Forms.Internals.Log.Listeners.Add(new DelegateLogListener((arg1, arg2) => Debug.WriteLine(arg2)));

            //InitializeComponent();
            var style1 = new Style(typeof(NavigationPage)) 
            { 
                Setters = {
                    new Setter()
                    {
                        Property =  BindableProperty.Create( "BarBackgroundColor",typeof(string), typeof(NavigationPage),"#2196F3"),
                    },
                    new Setter()
                    {
                        Property =  BindableProperty.Create( "BarTextColor",typeof(string), typeof(NavigationPage),"White"),
                    }
                } 
            };
            var style2 = new Style(typeof(Button))
            {
                Setters = {
                    new Setter()
                    {
                        //Property =  BindableProperty.Create( "TextColor",typeof(string), typeof(NavigationPage),"White"),
                        Property =  Button.TextColorProperty,
                        Value = "White"
                    },
                    /*
                    new Setter()
                    {
                        Property = Button.Prop  BindableProperty.Create( "VisualStateManager.VisualStateGroups",typeof(string), typeof(NavigationPage),
                        Value = new VisualStateGroupList(){ 
                            new VisualStateGroup()
                            {
                                Name = "CommonStates",
                                States =
                                {
                                    ButtonStyle.NormalState,
                                    ButtonStyle.DisabledState,
                                }
                            }
                        },
                    }
                    */
                }
            };
            //style1.
            this.Resources = new ResourceDictionary()
            {
                { "Primary" , Color.FromHex("2196F3")},
                { "NavigationPrimary" , Color.FromHex("2196F3")},
                { "1" , style1 },
            };

            //Cacheable<Comment>.WebCallExceptionHandler = new 
            MainPage = new NavigationPage( new MainPage());
            //Seems like there is a bug that dont let me avoid to use attributes
            JsonConvert.DefaultSettings =
                () => new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = { new StringEnumConverter() }
                };

        }
        static class ButtonStyle
        {
            public static VisualState NormalState { get; } =
            new VisualState
            {
                Name = "Normal",
                Setters =
                {
                    new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex("2196F3") },
                }
            };
            public static VisualState DisabledState { get; } =
            new VisualState
            {
                Name = "Disabled",
                Setters =
                {
                    new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex("332196F3") },
                }
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
