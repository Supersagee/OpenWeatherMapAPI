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

            Console.WriteLine(weather.CurrentWeather());

        }
    }
}
