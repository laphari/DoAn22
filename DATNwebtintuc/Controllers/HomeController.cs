using DATNwebtintuc.Models.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNwebtintuc.Controllers
{
    public class HomeController : Controller
    {
        private DATNwebtintucContext data = new DATNwebtintucContext();

        public ActionResult Index()
        {
            ViewData["advertismentimage"] = data.Advertisements.Where(x => x.typeAdvertisement == "Image").Take(5).ToList();
            ViewData["advertismentvideo"] = data.Advertisements.Where(x => x.typeAdvertisement == "Video").Take(3).ToList();
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
        public ActionResult Categories() 
        {
            return View();
        }
    }
}