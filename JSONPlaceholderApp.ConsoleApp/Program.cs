using JSONPlaceholderApp.Entities;
using JSONPlaceholderApp.Util;
using JSONPlaceholderApp.WebServices;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JSONPlaceholderApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            try
            {
                var IJSONPlaceholder = RestService.For<IJSONPlaceholder>(Globals.JSONPlaceHolderUrl);
                Task<List<User>> task;
                using (var cts = new CancellationTokenSource(new TimeSpan(0, 0, 5)))
                {
                    task = IJSONPlaceholder.GetUsersAsync(cts.Token);
                }
                //task?.Start();
                task?.Wait();
                var users = task?.Result;
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
