using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module5_HW1_15082023
{
    internal class REST
    {
        private const string URL = @"https://reqres.in/api/";

        public static async Task Get(string urlParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var res = await httpClient.GetAsync($"{URL}{urlParameters}");

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var context = await res.Content.ReadAsStringAsync();
                }
            }
        }

        public static async Task Post(List<Worker> worker, string urlParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var context = new StringContent(
                    JsonConvert.SerializeObject(worker),
                    Encoding.UTF8,
                    "application/json");

                var res = await httpClient.PostAsync(
                    $"{URL}{urlParameters}", context);

                if (res.StatusCode == HttpStatusCode.Created)
                {
                    var contextRes = await res.Content.ReadAsStringAsync();
                }
            }
        }

        public static async Task Post(List<NewUser> worker, string urlParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var context = new StringContent(
                    JsonConvert.SerializeObject(worker),
                    Encoding.UTF8,
                    "application/json");

                var res = await httpClient.PostAsync(
                    $"{URL}{urlParameters}", context);

                if (res.StatusCode == HttpStatusCode.Created)
                {
                    var contextRes = await res.Content.ReadAsStringAsync();
                }
            }
        }

        public static async Task Post(string email, string urlParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var context = new StringContent(
                    JsonConvert.SerializeObject(email),
                    Encoding.UTF8,
                    "application/json");

                var res = await httpClient.PostAsync(
                    $"{URL}{urlParameters}", context);

                if (res.StatusCode == HttpStatusCode.Created)
                {
                    var contextRes = await res.Content.ReadAsStringAsync();
                }
            }
        }

        public static async Task Put(List<Worker> worker, string urlParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var context = new StringContent(
                    JsonConvert.SerializeObject(worker),
                    Encoding.UTF8,
                    "application/json");

                var res = await httpClient.PutAsync(
                    $"{URL}{urlParameters}", context);

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var contextRes = await res.Content.ReadAsStringAsync();
                }
            }
        }

        public static async Task Patch(List<Worker> worker, string urlParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var context = new StringContent(
                    JsonConvert.SerializeObject(worker),
                    Encoding.UTF8,
                    "application/json");

                var res = await httpClient.PatchAsync(
                    $"{URL}{urlParameters}", context);

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var contextRes = await res.Content.ReadAsStringAsync();
                }
            }
        }

        public static async Task Delete(string urlParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var res = await httpClient.DeleteAsync($"{URL}{urlParameters}");

                if (res.StatusCode != HttpStatusCode.NoContent)
                {
                    var contextRes = await res.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
