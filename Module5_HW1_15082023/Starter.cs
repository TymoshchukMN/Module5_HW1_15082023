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
            List<Worker> worker = new List<Worker>()
            {
                new Worker
                {
                    Name = "morpheus",
                    Job = "leader",
                },
            };
            await REST.Post(worker, urlParameters);

            // UPDATE
            urlParameters = @"users/2";
            worker[0].Job = "zion resident";
            await REST.Put(worker, urlParameters);

            // PATCH
            urlParameters = @"users/2";
            await REST.Patch(worker, urlParameters);

            // DELETE
            urlParameters = @"users/2";
            await REST.Delete(urlParameters);

            // REGISTER - SUCCESSFUL
            urlParameters = @"register";
            List<NewUser> user = new List<NewUser>()
            {
                new NewUser
                {
                    Email = "eve.holt@reqres.in",
                    Password = "pistol",
                },
            };

            await REST.Post(user, urlParameters);

            // REGISTER - UNSUCCESSFUL
            urlParameters = @"register";
            user[0].Email = "sydney@fife";
            await REST.Post(user[0].Email, urlParameters);

            // LOGIN - SUCCESSFUL
            urlParameters = @"login";
            user[0].Email = "eve.holt@reqres.in";
            user[0].Password = "cityslicka";
            await REST.Post(user, urlParameters);

            // LOGIN - SUCCESSFUL
            urlParameters = @"login";
            user[0].Email = "peter@klaven";
            await REST.Post(user[0].Email, urlParameters);

            // DELAYED RESPONSE
            urlParameters = @"users?delay=3";
            await REST.Get(urlParameters);
        }
    }
}
