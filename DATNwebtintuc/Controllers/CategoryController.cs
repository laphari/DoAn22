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
    public class CategoryController : Controller
    {
        private DATNwebtintucContext data = new DATNwebtintucContext();

        // GET: Category
        public ActionResult Index(bool? create, bool? update,bool? delete,int? page)
        {
            var thongtin = data.Categories.ToList();
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
            var pagesize = 4;
            if(page == null) 
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.OrderBy(x => x.IDcategory).Skip(paging ?? 1).Take(pagesize);//??
            var numberpage = 0;
            if (totall % pagesize == 0)
            {
                numberpage = totall / pagesize;
            }
            else
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpage"] = numberpage;

            return View(result.ToList());
        }
        public ActionResult Viewcreate() 
        {
            return View();
        }
        public ActionResult Create(CategoryRequest item)
        {
            CategoryRequestValidator validator = new CategoryRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid) 
            {
                {
                    ViewData["checkvalidatecategory"] = (result.Errors);
                    return View("Viewcreate");
                }
            }
            else 
            {
                var entitycategory = new Category();
                entitycategory.namecategory = item.namecategory;
                data.Categories.Add(entitycategory);
                data.SaveChanges();
                return RedirectToAction("Index", new { create = true });
            }
        }
        public ActionResult Viewupdate(string id)
        {
            var update = data.Categories.Find(id);
            return View(update);
        }
        public ActionResult Update(CategoryRequest item) 
        {
            CategoryRequestValidator validator = new CategoryRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid)
            {
                {
                    ViewData["checkvalidatecategory"] = (result.Errors);
                    return View("Viewcreate");
                }
            }
            else 
            {
                var entitycategory = new Category();
                entitycategory.IDcategory = item.IDcategory;
                entitycategory.namecategory = item.namecategory;
                data.Entry(entitycategory).State = EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index", new { update = true });
            }
        }
        public ActionResult Search(string search) 
        {
            var result = data.Categories.Where(x => x.namecategory.Contains(search)).Select(x => x).ToList();
            return View(result);
        }
        public ActionResult Delete(string id) 
        {
            var delete = data.Categories.Find(id);
            if(delete.TBL_Post.Count == 0) 
            {
                data.Categories.Remove(delete);
                data.SaveChanges();
                return RedirectToAction("Index", new { delete = true });
            }
            else 
            {
                ViewData["checkdelte"] = "danh muc da ton tai du lieu khong the xoa";
                var thongtin = data.Categories.ToList();
                return View("Index",thongtin);
            }
        }
    }
}