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

        public object CurrentTemp()
        {
            var weatherURL = "https://api.openweathermap.org/data/2.5/find?q=Chaska&units=imperial&appid=c6a5411956e8b651b9d50e35410b9b06";

            var weather = _client.GetStringAsync(weatherURL).Result;

            var currentTemp = ((dynamic)JObject.Parse(weather)).list[0].main.temp;

            return currentTemp;
        }

        public object HighTemp()
        {
            var weatherURL = "https://api.openweathermap.org/data/2.5/find?q=Chaska&units=imperial&appid=c6a5411956e8b651b9d50e35410b9b06";

            var weather = _client.GetStringAsync(weatherURL).Result;

            var highTemp = ((dynamic)JObject.Parse(weather)).list[0].main.temp_max;

            return highTemp;
        }

        public object LowTemp()
        {
            var weatherURL = "https://api.openweathermap.org/data/2.5/find?q=Chaska&units=imperial&appid=c6a5411956e8b651b9d50e35410b9b06";

            var weather = _client.GetStringAsync(weatherURL).Result;

            var lowTemp = ((dynamic)JObject.Parse(weather)).list[0].main.temp_min;

            return lowTemp;
        }

        public object CurrentConditions()
        {
            var weatherURL = "https://api.openweathermap.org/data/2.5/find?q=Chaska&units=imperial&appid=c6a5411956e8b651b9d50e35410b9b06";

            var weather = _client.GetStringAsync(weatherURL).Result;

            var currentConditions = ((dynamic)JObject.Parse(weather)).list[0].weather[0].description;

            return currentConditions;
        }
    }
}
