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
        public string UserCity { get; set; }
        public string WeatherURL { get; set; }
        
        private HttpClient _client;

        public Weather(HttpClient client)
        {
            _client = client;
        }

        public object CurrentTemp()
        {
            var weather = _client.GetStringAsync(WeatherURL).Result;

            var currentTemp = ((dynamic)JObject.Parse(weather)).list[0].main.temp;

            return Math.Round(Convert.ToDouble(currentTemp));
        }

        public object HighTemp()
        {
            var weather = _client.GetStringAsync(WeatherURL).Result;

            var highTemp = ((dynamic)JObject.Parse(weather)).list[0].main.temp_max;

            return Math.Round(Convert.ToDouble(highTemp));
        }

        public object LowTemp()
        {
            var weather = _client.GetStringAsync(WeatherURL).Result;

            var lowTemp = ((dynamic)JObject.Parse(weather)).list[0].main.temp_min;

            return Math.Round(Convert.ToDouble(lowTemp));
        }

        public object CurrentConditions()
        {
            var weather = _client.GetStringAsync(WeatherURL).Result;

            var currentConditions = ((dynamic)JObject.Parse(weather)).list[0].weather[0].description;

            return currentConditions;
        }
    }
}
