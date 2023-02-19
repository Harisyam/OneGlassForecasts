using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneGlassForecasts.Data;
using OneGlassForecasts.Models;
using OneGlassForecasts.Services;
using OneGlassForecasts.Web.Models;

namespace OneGlassForecasts.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISalesForecastRepository _salesForecastRepository;
        private readonly IWeatherService _weatherService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ISalesForecastRepository salesForecastRepository, IWeatherService weatherService, ILogger<HomeController> logger)
        {
            _salesForecastRepository = salesForecastRepository;
            _weatherService = weatherService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var location = Location.Hamburg;
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(13);

            var salesForecast = _salesForecastRepository.GetForecasts(location, startDate, endDate);
            var GetWeatherForcasts = _weatherService.GetWeatherForcasts(location, startDate, endDate);

            var viewModel = new ForecastViewModel
            {
                Location = location.ToString(),
                StartDate = startDate,
                EndDate = endDate,
                Forecasts = salesForecast.ToList(),
                Weather = GetWeatherForcasts.ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Index(Location location, DateTime startDate, DateTime endDate)
        {
            var salesForecast = _salesForecastRepository.GetForecasts(location, startDate, endDate);
            var GetWeatherForcasts = _weatherService.GetWeatherForcasts(location, startDate, endDate);

            var viewModel = new ForecastViewModel
            {
                Location = location.ToString(),
                StartDate = startDate,
                EndDate = endDate,
                Forecasts = salesForecast.ToList(),
                Weather = GetWeatherForcasts.ToList()
            };

            return View(viewModel);
        }



        [HttpPost]
        public IActionResult GetAlerts(Location location, DateTime startDate, DateTime endDate)
        {
            var salesForecast = _salesForecastRepository.GetForecasts(location, startDate, endDate).ToList();
            var weatherForcasts = _weatherService.GetWeatherForcasts(location, startDate, endDate).ToList();

            var possibleClosingDays = new List<Tuple<string, List<DateTime>>>();
            var salesSum = 0.00;
            var tempCount = 0;
            for (var i = 0; i < salesForecast.Count; i++)
            {
                salesSum += salesForecast[i].forecasted_sales_quantity;
                tempCount += weatherForcasts[i].AverageTemperature < 5 ? 1 : 0;

                if (i >= 2)
                {
                    if (salesSum < 1000)
                    {
                        possibleClosingDays.Add(new Tuple<string, List<DateTime>>("Sales is less than 1000 in these days!!! ", new List<DateTime>() { salesForecast[i - 2].date, salesForecast[i - 1].date, salesForecast[i].date }));
                    }
                    else if (salesSum < 1500 && tempCount == 3)
                    {
                        var remainingSales = salesForecast.Skip(i + 1).Take(12 - i).Sum(f => f.forecasted_sales_quantity);
                        if (remainingSales < 500)
                        {
                            possibleClosingDays.Add(new Tuple<string, List<DateTime>>("Temperature is less than 5 and sales is less than 1500 in these days!!! ", new List<DateTime>() { salesForecast[i - 2].date, salesForecast[i - 1].date, salesForecast[i].date }));
                        }
                    }

                    salesSum -= salesForecast[i - 2].forecasted_sales_quantity;
                    tempCount -= weatherForcasts[i - 2].AverageTemperature < 5 ? 1 : 0;
                }
            }

            return Json(possibleClosingDays);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
