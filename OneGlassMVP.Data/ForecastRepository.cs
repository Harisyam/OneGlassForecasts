using OneGlassForecasts.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OneGlassForecasts.Data
{
    public class SalesForecastRepository : ISalesForecastRepository
    {
        private readonly PostgresContext _context;

        public SalesForecastRepository(PostgresContext context)
        {
            _context = context;
        }

        public IEnumerable<Forecast> GetForecasts(Location location, DateTime startDate, DateTime endDate)
        {
            return _context.forecasts
                .Where(f => f.location == location.ToString() && f.date >= startDate && f.date <= endDate)
                .OrderBy(f => f.date);
        }
    }


}
