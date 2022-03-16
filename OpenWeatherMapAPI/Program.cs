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

            var weather = new Weather(client);

            while (true)
            {
                Console.WriteLine("What city would you like to know the weather in?");
                weather.UserCity = Console.ReadLine();
                weather.WeatherURL = $"https://api.openweathermap.org/data/2.5/find?q={weather.UserCity}&units=imperial&appid=c6a5411956e8b651b9d50e35410b9b06";

                Console.WriteLine($"It is currently {weather.CurrentTemp()} degrees in {weather.UserCity} with {weather.CurrentConditions()}.");
                Console.WriteLine($"You can expect a high of {weather.HighTemp()}, and a low of {weather.LowTemp()} today.");
                Console.WriteLine($"-----------------------------------------------------------------------");
            }

        }
    }
}
