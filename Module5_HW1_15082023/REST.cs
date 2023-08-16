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

        public static async Task Create(string urlParameters)
        {
            var jobParam = new
            {
                name = "morpheus",
                job = "leader",
            };

            using (var httpClient = new HttpClient())
            {
                var context = new StringContent(
                    JsonConvert.SerializeObject(jobParam),
                    Encoding.UTF8,
                    "application/json");

                var res = await httpClient.PostAsync($"{URL}{urlParameters}", context);
            }
        }
    }
}
