using DATNwebtintuc.Models.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNwebtintuc.Controllers
{
 
    public class ListController : Controller
    {
        private DATNwebtintucContext data = new DATNwebtintucContext();
        // GET: List
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listforview() 
        {
            var result = data.Posts.OrderByDescending(x => x.create_date).ToList();
            return View(result);
        }
    }
}