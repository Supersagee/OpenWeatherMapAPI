using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMapAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            while (true)
            {
                Console.WriteLine("What city would you like to know the weather in?");
                var userCity = Console.ReadLine();
                Console.Clear();

                var weatherURL = $"https://api.openweathermap.org/data/2.5/find?q={userCity}&units=imperial&appid=c6a5411956e8b651b9d50e35410b9b06";
                var weather = client.GetStringAsync(weatherURL).Result;
                var currentTemp = ((dynamic)JObject.Parse(weather)).list[0].main.temp;
                var highTemp = ((dynamic)JObject.Parse(weather)).list[0].main.temp_max;
                var lowTemp = ((dynamic)JObject.Parse(weather)).list[0].main.temp_min;
                var currentConditions = ((dynamic)JObject.Parse(weather)).list[0].weather[0].description;

                Console.WriteLine($"It is currently {currentTemp} degress in {userCity} with {currentConditions}.");
                Console.WriteLine($"You can expect a high of {highTemp}, and a low of {lowTemp} today.");
                Console.WriteLine($"-----------------------------------------------------------------------");
            }

        }
    }
}
