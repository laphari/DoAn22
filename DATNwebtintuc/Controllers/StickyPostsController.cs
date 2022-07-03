using DATNwebtintuc.Models.ModelEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNwebtintuc.Controllers
{
    public class StickyPostsController : Controller
    {
        private DATNwebtintucContext data = new DATNwebtintucContext();
        // GET: StickyPosts
        public ActionResult Index(bool? create, bool? update, bool? delete)
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
            var thongtin = data.StickyPostss.ToList();
            return View(thongtin);
        }
        public ActionResult Viewcreate() 
        {
            return View();
        }
        public ActionResult Create(StickyPosts item) 
        {
            var entitysticky = new StickyPosts();
            entitysticky.priority = item.priority;
            data.StickyPostss.Add(entitysticky);
            data.SaveChanges();
            return RedirectToAction("Index", new { create = true });
        }
        public ActionResult Delete(string id) 
        {
            var remove = data.StickyPostss.Find(id);
            data.StickyPostss.Remove(remove);
            data.SaveChanges();
            return RedirectToAction("Index", new { delete = true });
        }
        public ActionResult Viewupdate(string id) 
        {
            var update = data.StickyPostss.Find(id);
            return View(update);
        }
        public ActionResult Update(StickyPosts item) 
        {
            var entitysticky = new StickyPosts();
            entitysticky.idStickyPosts = item.idStickyPosts;
            entitysticky.priority = item.priority;
            data.Entry(entitysticky).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index", new { update = true });
        }
    }
}