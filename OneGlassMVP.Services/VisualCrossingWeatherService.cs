using Newtonsoft.Json;
using OneGlassForecasts.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace OneGlassForecasts.Services
{

    public class WeatherService : IWeatherService
    {
        private readonly string _apiKey;

        public WeatherService()
        {
            _apiKey = "3WWEVYKLNRDJ4DHHK7ASL5XFF";
        }

        public IEnumerable<Weather> GetWeatherForcasts(Location location, DateTime startDate, DateTime endDate)
        {
            var url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{location}/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}?key={_apiKey}&unitGroup=metric";
            RestClient restClient = new RestClient(url);
            
            var response = restClient.Get(new RestRequest());

            dynamic weatherData = JsonConvert.DeserializeObject(response.Content);
            var days = weatherData.days;

            var weather = new List<Weather>();
            foreach (var day in days)
            {
                weather.Add(new Weather
                {
                    Date = DateTime.Parse(day.datetime.ToString()),
                    AverageTemperature = (int)day.temp,
                    Precipitation = (int)day.precip
                });
            }

            return weather;
        }

    }
}
