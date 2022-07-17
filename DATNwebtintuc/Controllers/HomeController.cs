using DATNwebtintuc.Models.ModelEntity;
using DATNwebtintuc.Models.ModelRespon;
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
            var queryPostandCategory = from ps in data.Posts
                                       join ca in data.Categories
                                       on ps.IDcategory equals ca.IDcategory
                                       select new PostandCategory
                                       {
                                           IDcategory = ca.IDcategory,
                                           namecategory = ca.namecategory,
                                           post_id = ps.post_id,
                                           post_teaser = ps.post_teaser,
                                           post_title = ps.post_title,
                                           create_date = ps.create_date,
                                           ViewCount =ps.ViewCount,
                                       };
            var queryPostandCategory1 = from ps in data.Posts
                                       join ca in data.Categories
                                       on ps.IDcategory equals ca.IDcategory
                                       select new PostandCategory
                                       {
                                           IDcategory = ca.IDcategory,
                                           namecategory = ca.namecategory,
                                           post_id = ps.post_id,
                                           post_teaser = ps.post_teaser,
                                           post_title = ps.post_title,
                                           create_date = ps.create_date,
                                       };
            var queryPostandCategory2 = from ps in data.Posts
                                        join ca in data.Categories
                                        on ps.IDcategory equals ca.IDcategory
                                        select new PostandCategory
                                        {
                                            IDcategory = ca.IDcategory,
                                            namecategory = ca.namecategory,
                                            post_id = ps.post_id,
                                            post_teaser = ps.post_teaser,
                                            post_title = ps.post_title,
                                            create_date = ps.create_date,
                                        };
            var queryPostandCategory3 = from ps in data.Posts
                                        join ca in data.Categories
                                        on ps.IDcategory equals ca.IDcategory
                                        select new PostandCategory
                                        {
                                            IDcategory = ca.IDcategory,
                                            namecategory = ca.namecategory,
                                            post_id = ps.post_id,
                                            post_teaser = ps.post_teaser,
                                            post_title = ps.post_title,
                                            create_date = ps.create_date,
                                        };
            var queryPostandCategory4 = from ps in data.Posts
                                        join ca in data.Categories
                                        on ps.IDcategory equals ca.IDcategory
                                        select new PostandCategory
                                        {
                                            IDcategory = ca.IDcategory,
                                            namecategory = ca.namecategory,
                                            post_id = ps.post_id,
                                            post_teaser = ps.post_teaser,
                                            post_title = ps.post_title,
                                            create_date = ps.create_date,
                                        };
            var queryPostandCategory5 = from ps in data.Posts
                                        join ca in data.Categories
                                        on ps.IDcategory equals ca.IDcategory
                                        select new PostandCategory
                                        {
                                            IDcategory = ca.IDcategory,
                                            namecategory = ca.namecategory,
                                            post_id = ps.post_id,
                                            post_teaser = ps.post_teaser,
                                            post_title = ps.post_title,
                                            create_date = ps.create_date,
                                        };
            var queryPostandCategory6 = from ps in data.Posts
                                        join ca in data.Categories
                                        on ps.IDcategory equals ca.IDcategory
                                        select new PostandCategory
                                        {
                                            IDcategory = ca.IDcategory,
                                            namecategory = ca.namecategory,
                                            post_id = ps.post_id,
                                            post_teaser = ps.post_teaser,
                                            post_title = ps.post_title,
                                            create_date = ps.create_date,
                                        };
            var queryPostandCategory7 = from ps in data.Posts
                                        join ca in data.Categories
                                        on ps.IDcategory equals ca.IDcategory
                                        select new PostandCategory
                                        {
                                            IDcategory = ca.IDcategory,
                                            namecategory = ca.namecategory,
                                            post_id = ps.post_id,
                                            post_teaser = ps.post_teaser,
                                            post_title = ps.post_title,
                                            create_date = ps.create_date,
                                        };
            var queryPostandCategory8 = from ps in data.Posts
                                        join ca in data.Categories
                                        on ps.IDcategory equals ca.IDcategory
                                        select new PostandCategory
                                        {
                                            IDcategory = ca.IDcategory,
                                            namecategory = ca.namecategory,
                                            post_id = ps.post_id,
                                            post_teaser = ps.post_teaser,
                                            post_title = ps.post_title,
                                            create_date = ps.create_date,
                                        };
            var queryPostandCategory9 = from ps in data.Posts
                                        join ca in data.Categories
                                        on ps.IDcategory equals ca.IDcategory
                                        select new PostandCategory
                                        {
                                            IDcategory = ca.IDcategory,
                                            namecategory = ca.namecategory,
                                            post_id = ps.post_id,
                                            post_teaser = ps.post_teaser,
                                            post_title = ps.post_title,
                                            create_date = ps.create_date,
                                        };
            var queryPostandCategory10 = from ps in data.Posts
                                        join ca in data.Categories
                                        on ps.IDcategory equals ca.IDcategory
                                        select new PostandCategory
                                        {
                                            IDcategory = ca.IDcategory,
                                            namecategory = ca.namecategory,
                                            post_id = ps.post_id,
                                            post_teaser = ps.post_teaser,
                                            post_title = ps.post_title,
                                            create_date = ps.create_date,
                                        };
            
            ViewData["PostandSticky"] = data.Posts.Where(x => x.stickypost !=null).OrderBy(x => x.stickypost).OrderByDescending(x => x.create_date).Take(3).ToList();
            ViewData["PostandCategory "] = queryPostandCategory.Where(x => x.namecategory.Contains("XÃ HỘI")).OrderByDescending(x => x.create_date).Take(3).ToList();
            ViewData["PostandCategoryphapluat"] = queryPostandCategory1.Where(x => x.namecategory.Contains("PHÁP LUẬT")).OrderByDescending(x => x.create_date).Take(3).ToList();
            ViewData["PostandCategorykinhdoanh"] = queryPostandCategory2.Where(x => x.namecategory.Contains("KINH DOANH")).OrderByDescending(x => x.create_date).Take(1).ToList();
            ViewData["PostandCategorykinhdoanh1"] = queryPostandCategory3.Where(x => x.namecategory.Contains("KINH DOANH")).OrderBy(x => x.create_date).Take(3).ToList();
            ViewData["PostandCategorydoisong"] = queryPostandCategory4.Where(x => x.namecategory.Contains("ĐỜI SỐNG")).OrderByDescending(x => x.create_date).Take(1).ToList();
            ViewData["PostandCategorydoisong1"] = queryPostandCategory4.Where(x => x.namecategory.Contains("ĐỜI SỐNG")).OrderBy(x => x.create_date).Take(3).ToList();
            ViewData["PostandCategorythegioi"] = queryPostandCategory5.Where(x => x.namecategory.Contains("THẾ GIỚI")).OrderByDescending(x => x.create_date).Take(3).ToList();
            ViewData["PostandCategorythegioi1"] = queryPostandCategory5.Where(x => x.namecategory.Contains("THẾ GIỚI")).OrderBy(x => x.create_date).Take(3).ToList();
            ViewData["PostandCategorygiaitri"] = queryPostandCategory6.Where(x => x.namecategory.Contains("GIẢI TRÍ")).OrderByDescending(x => x.create_date).Take(4).ToList();
            ViewData["PostandCategoryxe"] = queryPostandCategory7.Where(x => x.namecategory.Contains("XE")).OrderByDescending(x => x.create_date).Take(3).ToList();
            ViewData["PostandCategoryxe1"] = queryPostandCategory7.Where(x => x.namecategory.Contains("XE")).OrderBy(x => x.create_date).Take(3).ToList();
            ViewData["PostandCategorycanbiet"] = queryPostandCategory8.Where(x => x.namecategory.Contains("CẦN BIẾT")).OrderByDescending(x => x.create_date).Take(4).ToList();
            ViewData["PostandCategorythoisu"] = queryPostandCategory9.Where(x => x.namecategory.Contains("THỜI SỰ")).OrderByDescending(x => x.create_date).Take(2).ToList();
            ViewData["PostandCategorythoisu1"] = queryPostandCategory9.Where(x => x.namecategory.Contains("THỜI SỰ")).OrderBy(x => x.create_date).Take(2).ToList();
            ViewData["PostandCategorycongnghe"] = queryPostandCategory10.Where(x => x.namecategory.Contains("CÔNG NGHỆ")).OrderByDescending(x => x.create_date).Take(2).ToList();
            ViewData["PostandCategorycongnghe1"] = queryPostandCategory10.Where(x => x.namecategory.Contains("CÔNG NGHỆ")).OrderBy(x => x.create_date).Take(2).ToList();
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
        public ActionResult Categoriessociety()
        {
            var queryPostandCategory1 = from ps in data.Posts
                                       join ca in data.Categories
                                       on ps.IDcategory equals ca.IDcategory
                                       select new PostandCategory
                                       {
                                           IDcategory = ca.IDcategory,
                                           namecategory = ca.namecategory,
                                           post_id = ps.post_id,
                                           post_teaser = ps.post_teaser,
                                           post_title = ps.post_title,
                                           create_date = ps.create_date,
                                       };
            var queryPostandCategory2 = from ps in data.Posts
                                        join ca in data.Categories
                                        on ps.IDcategory equals ca.IDcategory
                                        select new PostandCategory
                                        {
                                            IDcategory = ca.IDcategory,
                                            namecategory = ca.namecategory,
                                            post_id = ps.post_id,
                                            post_teaser = ps.post_teaser,
                                            post_title = ps.post_title,
                                            create_date = ps.create_date,
                                        };
            var queryPostandCategory3 = from ps in data.Posts
                                        join ca in data.Categories
                                        on ps.IDcategory equals ca.IDcategory
                                        select new PostandCategory
                                        {
                                            IDcategory = ca.IDcategory,
                                            namecategory = ca.namecategory,
                                            post_id = ps.post_id,
                                            post_teaser = ps.post_teaser,
                                            post_title = ps.post_title,
                                            create_date = ps.create_date,
                                        };
            ViewData["PostandCategorysociety"] = queryPostandCategory1.Where(x => x.namecategory.Contains("XÃ HỘI")).OrderByDescending(x => x.create_date).Take(1).ToList();
            ViewData["PostandCategorysociety2"] = queryPostandCategory2.Where(x => x.namecategory.Contains("XÃ HỘI")).OrderBy(x => x.create_date).Take(2).ToList();
            ViewData["PostandCategorysociety3"] = queryPostandCategory3.Where(x => x.namecategory.Contains("XÃ HỘI")).OrderBy(x => x.create_date).Take(2).ToList();

            return View();
        }
        public ActionResult Categoriesworld()
        {
            return View();
        }
        public ActionResult Categoriesnews()
        {
            return View();
        }
        public ActionResult Categoriesbusiness()
        {
            return View();
        }
        public ActionResult Categorieslife()
        {
            return View();
        }
        public ActionResult Categoriesentertainment()
        {
            return View();
        }
        public ActionResult Categoriescar()
        {
            return View();
        }
        public ActionResult Categoriestechnology() 
        {
            return View();
        }
        public ActionResult Hastags() 
        {
            return View();
        }
    }
}