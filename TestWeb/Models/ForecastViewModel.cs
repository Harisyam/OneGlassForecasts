using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OneGlassForecasts.Models;

namespace OneGlassForecasts.Web.Models
{
    public class ForecastViewModel
    {
        [Display(Name ="Location")]
        public string Location { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public List<Forecast> Forecasts { get; set; }

        public List<Weather> Weather { get; set; }
    }
}
