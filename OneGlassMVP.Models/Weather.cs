using System;

namespace OneGlassForecasts.Models
{
    public class Weather
    {
        public DateTime Date { get; set; }
        public int AverageTemperature { get; set; }
        public int Precipitation { get; set; }
    }
}
