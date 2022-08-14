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
            ViewData["PostandStickyslide"] = data.Posts.Where(x => x.stickypost == null).OrderBy(x => x.stickypost).OrderByDescending(x => x.create_date).Take(3).ToList();
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
        public ActionResult Categories(int? page) 
        {
            var thongtin = data.Posts.Where(x => x.Category.IDcategory == "0803772a-0cea-4245-b3b2-ab66eaa2a269").OrderByDescending(x => x.create_date).ToList();
            var pagesize = 9;
            if (page == null)
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.Skip(paging ?? 1).Take(pagesize).ToList();

            var numberpage = 0;
            if (totall % pagesize == 0)
            {
                numberpage = totall / pagesize;
            }
            else
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpagephapluat"] = numberpage;
            return View(result);
        }
        public ActionResult Categoriessociety(int? page)
        {
            var thongtin = data.Posts.Where(x => x.Category.IDcategory== "756f7244-b290-422a-84e9-59c3a92f6162").OrderByDescending(x => x.create_date).ToList();
            var pagesize = 9;
            if (page == null)
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.Skip(paging ?? 1).Take(pagesize).ToList();
            
            var numberpage = 0;
            if (totall % pagesize == 0)
            {
                numberpage = totall / pagesize;
            }
            else
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpagesociety"] = numberpage;
            return View(result);
        }
        public ActionResult Categoriesworld(int? page)
        {
            var thongtin = data.Posts.Where(x => x.Category.IDcategory == "58a2925d-0558-4810-bcbb-a777a8673fd9").OrderByDescending(x => x.create_date).ToList();
            var pagesize = 9;
            if (page == null)
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.Skip(paging ?? 1).Take(pagesize).ToList();

            var numberpage = 0;
            if (totall % pagesize == 0)
            {
                numberpage = totall / pagesize;
            }
            else
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpageworld"] = numberpage;
            return View(result);
           
        }
        public ActionResult Categoriesnews(int? page)
        {
            var thongtin = data.Posts.Where(x => x.Category.IDcategory == "4b313e76-b8e6-46e4-8c09-9832df224774").OrderByDescending(x => x.create_date).ToList();
            var pagesize = 9;
            if (page == null)
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.Skip(paging ?? 1).Take(pagesize).ToList();

            var numberpage = 0;
            if (totall % pagesize == 0)
            {
                numberpage = totall / pagesize;
            }
            else
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpagenews"] = numberpage;
            return View(result);
        }
        public ActionResult Categoriesbusiness(int? page)
        {
            var thongtin = data.Posts.Where(x => x.Category.IDcategory == "285fe985-8cd1-43d9-bf52-a23616c23111").OrderByDescending(x => x.create_date).ToList();
            var pagesize = 9;
            if (page == null)
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.Skip(paging ?? 1).Take(pagesize).ToList();

            var numberpage = 0;
            if (totall % pagesize == 0)
            {
                numberpage = totall / pagesize;
            }
            else
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpagebusiness"] = numberpage;
            return View(result);
        }
        public ActionResult Categorieslife(int? page)
        {
            var thongtin = data.Posts.Where(x => x.Category.IDcategory == "5b103212-abfd-4ba7-ae9c-18aa1da11a95").OrderByDescending(x => x.create_date).ToList();
            var pagesize = 9;
            if (page == null)
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.Skip(paging ?? 1).Take(pagesize).ToList();

            var numberpage = 0;
            if (totall % pagesize == 0)
            {
                numberpage = totall / pagesize;
            }
            else
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpagelife"] = numberpage;
            return View(result);
        }
        public ActionResult Categoriesentertainment(int? page)
        {
            var thongtin = data.Posts.Where(x => x.Category.IDcategory == "57b07297-5de7-41cd-b037-443a082fe77a").OrderByDescending(x => x.create_date).ToList();
            var pagesize = 9;
            if (page == null)
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.Skip(paging ?? 1).Take(pagesize).ToList();

            var numberpage = 0;
            if (totall % pagesize == 0)
            {
                numberpage = totall / pagesize;
            }
            else
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpageentertainment"] = numberpage;
            return View(result);
        }
        public ActionResult Categoriescar(int? page)
        {
            var thongtin = data.Posts.Where(x => x.Category.IDcategory == "01fd0a70-3ba6-4f4f-b301-9334cb87dd7d").OrderByDescending(x => x.create_date).ToList();
            var pagesize = 9;
            if (page == null)
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.Skip(paging ?? 1).Take(pagesize).ToList();

            var numberpage = 0;
            if (totall % pagesize == 0)
            {
                numberpage = totall / pagesize;
            }
            else
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpagecar"] = numberpage;
            return View(result);
        }
        public ActionResult Categoriestechnology(int? page) 
        {
            var thongtin = data.Posts.Where(x => x.Category.IDcategory == "0aaf8949-0d6a-454f-a301-79af10f1a319").OrderByDescending(x => x.create_date).ToList();
            var pagesize = 9;
            if (page == null)
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.Skip(paging ?? 1).Take(pagesize).ToList();

            var numberpage = 0;
            if (totall % pagesize == 0)
            {
                numberpage = totall / pagesize;
            }
            else
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpagetechnology"] = numberpage;
            return View(result);
        }
        public ActionResult Hastags() 
        {
            return View();
        }
    }
}