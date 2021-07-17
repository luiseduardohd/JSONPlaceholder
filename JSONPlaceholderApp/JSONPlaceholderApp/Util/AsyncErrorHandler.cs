using System;
using System.Diagnostics;

namespace JSONPlaceholder.Util
{
    //To be used on next commits
    public static class AsyncErrorHandler
    {
        public static void HandleException(Exception exception)
        {
            Debug.WriteLine(exception);
        }
    }
}
