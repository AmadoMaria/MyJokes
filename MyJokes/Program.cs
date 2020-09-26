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
            JokeObj joke = new JokeObj();
            Console.WriteLine("Please, select a category:");
            Console.WriteLine("[0] Any category");
            Console.WriteLine("[1] Programming");
            Console.WriteLine("[2] Miscellaneous");
            Console.WriteLine("[3] Dark");
            Console.WriteLine("[4] Pun");

            string category = Console.ReadLine();

            switch (category)
            {
                case "0":
                    joke.category = "Any";
                    break;
                case "1":
                    joke.category = "Programming";
                    break;
                case "2":
                    joke.category = "Miscellaneous";
                    break;
                case "3":
                    joke.category = "Dark";
                    break;
                case "4":
                    joke.category = "Pun";
                    break;
                default:
                    Console.WriteLine("Código inválido");
                    break;
            }

            GetData(joke);
            Console.ReadKey();
        }

        public static void PrintJoke(JokeObj joke)
        {
            if (joke.type == "single")
            {
                Console.WriteLine($"Category: {joke.category}");
                Console.WriteLine($"joke: {joke.joke}");
            }
            else
            {
                Console.WriteLine($"Category: {joke.category}");
                Console.WriteLine($"Setup: {joke.setup}");
                Console.WriteLine($"Delivery: {joke.delivery}");
            }
      
        }

        public static async void GetData(JokeObj joke)
        {
            HttpClient httpClient = new HttpClient();
            string url = 
               $"https://sv443.net/jokeapi/v2/joke/{joke.category}?blacklistFlags=nsfw,religious,political,racist,sexist";
            HttpRequestMessage request = new
            HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await
            httpClient.SendAsync(request);
            string data = await
            response.Content.ReadAsStringAsync();

            joke = JsonConvert.DeserializeObject<JokeObj>(data);
            PrintJoke(joke);
        }
    }
}
