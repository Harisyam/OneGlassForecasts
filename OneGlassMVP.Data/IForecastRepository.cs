using OneGlassForecasts.Models;
using System;
using System.Collections.Generic;

namespace OneGlassForecasts.Data
{
    public interface ISalesForecastRepository
    {
        IEnumerable<Forecast> GetForecasts(Location location, DateTime startDate, DateTime endDate);
    }
}
