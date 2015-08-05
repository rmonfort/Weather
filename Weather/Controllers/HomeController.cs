using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Weather.ViewModels;
using Newtonsoft.Json;

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

            return PartialView("_Weather");
        }
    }
}