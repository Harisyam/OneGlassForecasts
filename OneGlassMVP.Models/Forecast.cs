using System;

namespace OneGlassForecasts.Models
{
    public class Forecast
    {
        public DateTime date { get; set; }
        public string location { get; set; }
        public double forecasted_sales_quantity { get; set; }
    }
}
