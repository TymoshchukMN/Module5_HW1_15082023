using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Module5_HW1_15082023
{
    public class Starter
    {
        

        public static void Run()
        {
            SendAsync().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        private static async Task SendAsync()
        {
            string urlParameters = string.Empty;

            // GET LIST USERS
            urlParameters = @"users?page=2";
            await REST.Get(urlParameters);

            // SINGLE USER
            urlParameters = @"users/2";
            await REST.Get(urlParameters);

            // SINGLE USER NOT FOUND
            urlParameters = @"users/23";
            await REST.Get(urlParameters);

            // LIST <RESOURCE>
            urlParameters = @"unknown";
            await REST.Get(urlParameters);

            // SINGLE <RESOURCE>
            urlParameters = @"unknown/2";
            await REST.Get(urlParameters);

            // SINGLE <RESOURCE> NOT FOUND
            urlParameters = @"unknown/23";
            await REST.Get(urlParameters);

            // SINGLE <RESOURCE> NOT FOUND
            urlParameters = @"unknown/23";
            await REST.Get(urlParameters);

            // CREATE
            urlParameters = @"users";
            await REST.Create(urlParameters);
        }
    }
}
