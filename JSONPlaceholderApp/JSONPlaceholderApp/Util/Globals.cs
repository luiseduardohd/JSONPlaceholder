using System;
namespace JSONPlaceholderApp.Util
{
    public static  class Globals
    {
        public static string JSONPlaceHolderUrl = "https://jsonplaceholder.typicode.com/";
        //public static string JSONPlaceHolderUrl = "http://10.0.2.2:8053/";
        public static string DBFileName = "JSONPlaceholder";
        public static string DBFileExtension = "db3";
        public static string DBCompleteFileExtension { get => $"{DBFileName}.{DBFileExtension}"; }
    }
}
