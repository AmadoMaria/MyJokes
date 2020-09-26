using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyJokes
{
    class Program
    {
        static void Main(string[] args)
        {
            GetData();
            Console.ReadKey();
        }

        public static async void GetData()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new
            HttpRequestMessage(HttpMethod.Get,
           "http://jsonplaceholder.typicode.com/posts/1");
            HttpResponseMessage response = await
            httpClient.SendAsync(request);
            string dados = await
            response.Content.ReadAsStringAsync();

            //Post p = JsonConvert.DeserializeObject<Post>(dados);
            //Console.WriteLine($"Titulo: {p.Title}");
           // Console.WriteLine($"Body: {p.Body}");

        }
    }
}
