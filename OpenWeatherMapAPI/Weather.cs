using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMapAPI
{
    public class Weather
    {
        private HttpClient _client;

        public Weather(HttpClient client)
        {
            _client = client;
        }

        public string CurrentWeather()
        {
            var weatherURL = "https://api.openweathermap.org/data/2.5/find?q=Chaska&units=imperial&appid=c6a5411956e8b651b9d50e35410b9b06";

            var weather = _client.GetStringAsync(weatherURL).Result;

            var weatherReturn = JObject.Parse(weather).GetValue("list[1]").ToString();

            return weatherReturn;
        }
    }
}
