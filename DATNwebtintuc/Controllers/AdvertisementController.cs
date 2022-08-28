using DATNwebtintuc.Models.ModelEntity;
using DATNwebtintuc.Models.ModelRequest;
using DATNwebtintuc.Validator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNwebtintuc.Controllers
{
    public class AdvertisementController : Controller
    {
        private DATNwebtintucContext data = new DATNwebtintucContext();
        // GET: Advertisement
        public ActionResult Index(bool? create, bool? update,bool? delete)
        {
            if (create == true)
            {
                ViewBag.Messcreate = true;
            }

            if (update == true)
            {
                ViewBag.Messupdate = true;
            }


            if (delete == true)
            {
                ViewBag.Messdelete = true;
            }
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
                entityadvertisment.urlAdvertisment = item.urlAdvertisment;
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
            return RedirectToAction("Index", new { delete = true });
        }
        public ActionResult Viewupdate(string id) 
        {
            var update = data.Advertisements.Find(id);
            return View(update);
        }
        public ActionResult Update(AdvertisementRequest item) 
        {
            AdvertisementRequestValidator validator = new AdvertisementRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid)
            {
                {
                    ViewData["checkvalidateadvertismentupdate"] = (result.Errors);
                    return View("Viewcreate");
                }
            }
            else 
            {
                var entityadvertisment = new Advertisement();
                entityadvertisment.idAdvertisement = item.idAdvertisement;
                entityadvertisment.linkAdvertisement = item.linkAdvertisement;
                entityadvertisment.typeAdvertisement = item.typeAdvertisement;
                entityadvertisment.urlAdvertisment = item.urlAdvertisment;
                data.Entry(entityadvertisment).State = EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index", new { update = true });
            }
        }
        public ActionResult Search(string search) 
        {
            var result = data.Advertisements.Where(x => x.linkAdvertisement.Contains(search));
            return View(result);
        }
    }
}