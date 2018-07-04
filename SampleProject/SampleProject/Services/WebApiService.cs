using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SampleProject.Models;

namespace SampleProject.Services
{
    public static class WebApiService
    {
        //Заменить строку подключения на ваш сервис https://ngrok.com/
        private static string _apiUri = "{Your URL}";

        public static async Task<bool> CheckRegister(UserItem userItem)
        {
            var result = false;
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    //http://127.0.0.1:5200/api/mongo/check
                    RequestUri = new Uri($"{_apiUri}/mongo/check/{userItem.Name}/{userItem.Password}"),
                    Method = HttpMethod.Post
                };
                string content = JsonConvert.SerializeObject(userItem);
                request.Content = new StringContent(content);
                request.Headers.Add("Accept", "application/json");
                var response = await client.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var myObj = JsonConvert.DeserializeObject<bool>(json);
                    if (!Equals(myObj, null))
                        result = myObj;
                }
            }
            return result;
        }
    }
}
