using System;
using System.Collections.Generic;
using OneGlassForecasts.Models;

namespace OneGlassForecasts.Services
{
    public interface IWeatherService
    {
        IEnumerable<Weather> GetWeatherForcasts(Location location, DateTime startDate, DateTime endDate);
    }
}
