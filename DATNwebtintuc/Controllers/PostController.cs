using DATNwebtintuc.Models.ModelEntity;
using DATNwebtintuc.Models.ModelRequest;
using DATNwebtintuc.Models.ModelRespon;
using DATNwebtintuc.Validator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNwebtintuc.Controllers
{
    public class PostController : Controller
    {
        private DATNwebtintucContext data = new DATNwebtintucContext();

        // GET: Post
        public ActionResult Index(bool? create,bool? update,bool? delete,int? page)
        {

            var thongtin = data.Posts.ToList();
            if (update == true) 
            {
                ViewBag.Messupdate = true;
            }
            if (create == true)
            {
                ViewBag.Messcreate = true;
            }
            if (delete == true)
            {
                ViewBag.Messdelete = true;
            }
            var pagesize = 70;
            if(page == null) 
            {
                page = 1;
            }
            var totall = thongtin.Count();
            var paging = (page - 1) * pagesize;
            var result = thongtin.OrderBy(x => x.post_id).Skip(paging ?? 1).Take(pagesize);
            var numberpage = 0;
            if(totall % pagesize == 0) 
            {
                numberpage = totall / pagesize;
            }
            else 
            {
                numberpage = totall / pagesize + 1;
            }
            ViewData["totallpage"] = numberpage;

            return View(result.OrderByDescending(x => x.create_date).ToList());
        }
        [ValidateInput(false)]
        public ActionResult Viewcreate() 
        {
            ViewData["selectcategory"] = data.Categories.ToList();
            ViewData["selectstickpost"] = data.StickyPostss.Where(x => x.post_id == null).ToList();
            ViewData["selectseries"] = data.Seriess.Where(x => x.post_id == null).ToList();
            return View();
        }
        [ValidateInput(false)]
        public ActionResult Create(PostRequest item , string seriesID,string idStickyPosts) 
        {
            ViewData["selectcategory"] = data.Categories.ToList();
            ViewData["selectseries"] = data.Seriess.Where(x => x.post_id == null).ToList();
            ViewData["selectstickpost"] = data.StickyPostss.Where(x => x.post_id == null).ToList(); ;
            PostRequestValidator validator = new PostRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid)
            {
                {
                    ViewData["checkvalidatepost"] = (result.Errors);
                    return View("Viewcreate");//chua fix
                }
            }
            else
            {
                var entitypost = new Post();
                entitypost.post_review = item.post_review;
                entitypost.post_content = item.post_content;
                entitypost.post_slug = item.post_slug;
                entitypost.post_tag = item.post_tag;
                entitypost.IDcategory = item.IDcategory;
                if (item.post_teaser == null)
                {
                    entitypost.post_teaser = "../UploadPost/logoweb.jpg";
                }
                else
                {
                    entitypost.post_teaser = UploadPosttester(item.post_teaser);
                }
               // entitypost.post_teaser = UploadPosttester(item.post_teaser);
                entitypost.post_title = item.post_title;
                entitypost.create_date = item.create_date;
                data.Posts.Add(entitypost);
                if(seriesID == "" && idStickyPosts == "") //mk k chon cai gi
                {
                    data.SaveChanges();
                    return RedirectToAction("Index", new { create = true });
                }
                else 
                {

                    if(seriesID != "") // co gia tri
                    {
                        var Findseriesid = data.Seriess.Find(seriesID);
                        if(Findseriesid.post_id != null) 
                        {
                            ViewData["sentmessseries"] = "The post already exists";
                            return View("Viewcreate");
                        }
                        else 
                        {
                            Findseriesid.post_id = entitypost.post_id;
                            data.Entry(Findseriesid).State = EntityState.Modified;
                        }
                    }

                    if(idStickyPosts != "") 
                    {
                        var Stickypostid = data.StickyPostss.Find(idStickyPosts);
                        if(Stickypostid.post_id != null) 
                        {
                            ViewData["sentmessstick"] = "The post already exists";
                            return View("Viewcreate");
                        }
                        else 
                        {
                            Stickypostid.post_id = entitypost.post_id;
                            data.Entry(Stickypostid).State = EntityState.Modified;
                        }
                    }
                    data.SaveChanges();
                    return RedirectToAction("Index", new { create = true });
                }
            }
        }
        [ValidateInput(false)]
        public ActionResult Viewupdate(string id, string seriesID, string idStickyPosts) //dau vao la id 
        {
            var update = data.Posts.Find(id);// dau du lieu o trong bang post
            ViewData["selectcategory"] = data.Categories.ToList();
            var updatestickypost = data.StickyPostss.Where(x => x.post_id == id).FirstOrDefault();
            var updateseries = data.Seriess.Where(x => x.post_id==id).FirstOrDefault();//lay ra danh sach ma series dc phep gan cho bai post 
            ViewData["selectseriesed"] = data.Seriess.Where(x => x.post_id == null).ToList();
            ViewData["selectstickyposted"] = data.StickyPostss.Where(x => x.post_id == null).ToList();
            if (updateseries != null) 
            {
                ViewData["selectseries"] = updateseries;
            }
            if(updatestickypost != null)
            {
                ViewData["selectstickypost"] = updatestickypost;
            }
            return View(update);// dau ra la mot object
        }
        [ValidateInput(false)]
        public ActionResult Update(string post_teaser,PostRequest item, string seriesID,string idStickyPosts)
        {
            ViewData["selectcategory"] = data.Categories.ToList(); // not null 
            ViewData["selectseriesed"] = data.Seriess.Where(x => x.post_id == null).ToList(); // allow null 
            ViewData["selectstickyposted"] = data.StickyPostss.Where(x => x.post_id == null).ToList(); // allow null 
                var entitypost = new Post();
                entitypost.post_id = item.post_id;
                entitypost.post_review = item.post_review;
                entitypost.post_content = item.post_content;
                entitypost.post_slug = item.post_slug;
                entitypost.post_tag = item.post_tag;
                entitypost.IDcategory = item.IDcategory;
                if (item.post_teaser == null)
                {
                entitypost.post_teaser = post_teaser;
                }
                else
                {
                entitypost.post_teaser = UploadPosttester(item.post_teaser);
                }
                entitypost.post_title = item.post_title;
                entitypost.create_date = item.create_date;
                entitypost.edit_date = item.edit_date;
                if (seriesID != "") 
                {
                    // tim no
                    var findSeries = data.Seriess.Where(x => x.post_id == item.post_id).FirstOrDefault();// tim doi tuong
                    if (findSeries != null)
                    {
                        // xoa no
                        data.Seriess.Remove(findSeries);
                        // cap nhap lai series ma nguoi dung muon sua
                        var updateSeries = data.Seriess.Find(seriesID);
                        if(updateSeries.post_id == null)
                        {
                            updateSeries.post_id = item.post_id;
                            data.Entry(updateSeries).State = EntityState.Modified;
                        }
                    }
                    else
                    {
                        var updateSeries = data.Seriess.Find(seriesID);
                        if (updateSeries.post_id == null)
                        {
                            updateSeries.post_id = item.post_id;
                            data.Entry(updateSeries).State = EntityState.Modified;
                        }
                    }
                }
                if(idStickyPosts != "") 
                {
                    var findidstickypost = data.StickyPostss.Where(x => x.post_id == item.post_id).FirstOrDefault();
                    if(findidstickypost != null) 
                    {
                        data.StickyPostss.Remove(findidstickypost);
                        var updatestickypost = data.StickyPostss.Find(idStickyPosts);
                        if(updatestickypost.post_id == null) 
                        {
                            updatestickypost.post_id = item.post_id;
                            data.Entry(updatestickypost).State = EntityState.Modified;
                        }
                    }
                    else 
                    {
                        var updateStickyPost = data.StickyPostss.Find(idStickyPosts);
                        if (updateStickyPost.post_id == null)
                        {
                            updateStickyPost.post_id = item.post_id;
                            data.Entry(updateStickyPost).State = EntityState.Modified;
                        }
                    }
                }
            else
            {
                var isExistStickyPost = data.StickyPostss.Where(x => x.post_id == item.post_id).FirstOrDefault();
                if(isExistStickyPost != null)
                {
                    data.StickyPostss.Remove(isExistStickyPost);
                }
            }
                data.Entry(entitypost).State = EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index", new { update = true });
            
        }
        public ActionResult Delete(string idPost)
        {
            // find idSeri qua idPost 
            var postResult = data.Posts.Find(idPost); // => return 1 object post 

            // post object contain id_seri
            if(postResult != null)
            {
                
                var seriResult = data.Seriess.Where(x=> x.post_id == postResult.post_id).FirstOrDefault();
                var stickyResult = data.StickyPostss.Where(x => x.post_id == postResult.post_id).FirstOrDefault();
                // nếu seriResult có giá trị => xóa bthg
                // nếu ko có giá trị => lấy gì mà xóa 
                if(seriResult != null) 
                {
                    data.Seriess.Remove(seriResult);
                    data.SaveChanges();
                }
                if(stickyResult != null) 
                {
                    data.StickyPostss.Remove(stickyResult);
                    data.SaveChanges();
                }
            }
            data.Posts.Remove(postResult);
            data.SaveChanges();
            return RedirectToAction("Index", new { delete = true });
        }
        public ActionResult Search(string search) 
        {
            var searchlower = search.ToLower();
            var result = data.Posts.Where(x => x.post_title.ToLower().Contains(searchlower)).ToList();
            return View(result);
        }
        public string UploadPosttester(HttpPostedFileBase file)
        {
            var filename = file.FileName;
            var getfile = "../UploadPost/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
        public string UploadAvatarimg(HttpPostedFileBase file)
        {
            var filename = file.FileName;
            var getfile = "../UploadPostava/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
        public ActionResult Detail(string id) 
        {
            ViewData["advertismentimage"] = data.Advertisements.Where(x => x.typeAdvertisement == "Image").Take(6).ToList();
            var detail = data.Posts.Find(id);
            ViewData["selectpostanddetail"] = data.Posts.OrderByDescending(x => x.create_date).Take(3).ToList();
            return View(detail);
        }
    }
}