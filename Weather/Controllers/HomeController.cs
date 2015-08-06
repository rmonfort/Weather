using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Weather.ViewModels;
using Newtonsoft.Json;
using Weather.Helpers;

namespace Weather.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var PostCode = new PostalCodeViewModel();
            return View(PostCode);
        }

        [HttpPost]
        public PartialViewResult FetchWeather(string PostalCode)
        {
            var url = "http://api.wunderground.com/api/b0f1b6600ed6fb14/conditions/q/" + PostalCode + ".json";
            var weather = JsonUtility.DownloadAndDeserializeJson<Rootobject>(url);

            ViewData["Location"] = weather.current_observation.display_location.full;
            ViewData["Weather"] = weather.current_observation.weather;
            ViewData["WeatherIconUrl"] = weather.current_observation.icon_url;
            ViewData["Temperature"] = weather.current_observation.temperature_string;
            ViewData["Wind"] = weather.current_observation.wind_mph;
            ViewData["Humidity"] = weather.current_observation.relative_humidity;
            ViewData["ForecastUrl"] = weather.current_observation.forecast_url;
            return PartialView("_Weather", weather);
        }
    }
}