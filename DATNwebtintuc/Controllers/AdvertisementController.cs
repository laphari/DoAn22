using DATNwebtintuc.Models.ModelEntity;
using DATNwebtintuc.Models.ModelRequest;
using DATNwebtintuc.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNwebtintuc.Controllers
{
    public class AdvertisementController : Controller
    {
        private DATNwebtintucContext data = new DATNwebtintucContext();
        // GET: Advertisement
        public ActionResult Index()
        {
            var thongtin = data.Advertisements.ToList();
            return View(thongtin);
        }
        public ActionResult Viewcreate() 
        {
            return View();
        }
        public ActionResult Create(AdvertisementRequest item)
        {
            AdvertisementRequestValidator validator = new AdvertisementRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid)
            {
                {
                    ViewData["checkvalidateadvertisment"] = (result.Errors);
                    return View("Viewcreate");
                }
            }
            else 
            {
                var entityadvertisment = new Advertisement();
                entityadvertisment.linkAdvertisement = item.linkAdvertisement;
                entityadvertisment.typeAdvertisement = item.typeAdvertisement;
                data.Advertisements.Add(entityadvertisment);
                data.SaveChanges();
                return RedirectToAction("Index", new { create = true });
            }
        }
        public ActionResult Remove(string id) 
        {
            var delete = data.Advertisements.Find(id);
            data.Advertisements.Remove(delete);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}