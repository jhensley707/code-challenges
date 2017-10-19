using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var serializer = new JavaScriptSerializer();

            using (var client = new WebClient())
            {
                string json = client.DownloadString("http://dev1-sample.azurewebsites.net/properties.json");
                var propertyModels = serializer.Deserialize<PropertiesModel>(json);
                var properties = propertyModels.Properties.Select(p => new PropertyViewModel
                {
                    Address = (p.Address != null) ? string.Format("{0} {1} {2} {3}", p.Address.Address1, p.Address.City, p.Address.State, p.Address.Zip) : "",
                    ListPrice = (p.Financial != null) ?  p.Financial.ListPrice : 0M,
                    MonthlyRent = (p.Financial != null) ? p.Financial.MonthlyRent : 0M,
                    YearBuilt = (p.Physical != null) ? p.Physical.YearBuilt.ToString() : ""

                });
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}