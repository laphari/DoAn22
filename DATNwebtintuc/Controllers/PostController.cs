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
            var pagesize = 5;
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
            return View(result.ToList());
        }
        [ValidateInput(false)]
        public ActionResult Viewcreate() 
        {
            ViewData["selectcategory"] = data.Categories.ToList();
            ViewData["selectseries"] = data.Seriess.Where(x => x.post_id == null).ToList();
            return View();
        }
        [ValidateInput(false)]
        public ActionResult Create(PostRequest item , string seriesID) 
        {
            ViewData["selectcategory"] = data.Categories.ToList();
            ViewData["selectseries"] = data.Seriess.ToList();
            PostRequestValidator validator = new PostRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid)
            {
                {
                    ViewData["checkvalidatepost"] = (result.Errors);
                    return View("Viewcreate");
                }
            }
            else
            {
                var entitypost = new Post();// -> tạo ra đối tượng -> có 1 id => guid 
                if(seriesID != "") // th này có chọn seri  
                {
                    // check xem post_id có tồng tại seri chư
                    var FindIdSeries = data.Seriess.Find(seriesID);//gui cai seriesid len de tim kie
                    // nếu đã có rồi 
                    if (FindIdSeries.post_id != null)
                    {
                        // thì ko tạo bài và trả ra message 
                        ViewData["sentmessseries"] = "The post already exists";
                        return View("Viewcreate");
                    }
                    else // th chưa có  
                    {
                        //
                        entitypost.post_review = item.post_review;
                        entitypost.post_content = item.post_content;
                        entitypost.post_slug = item.post_slug;
                        entitypost.post_tag = item.post_tag;
                        entitypost.IDcategory = item.IDcategory;
                        entitypost.post_teaser = UploadPosttester(item.post_teaser);
                        entitypost.post_title = item.post_title;
                        entitypost.create_date = item.create_date;
                        data.Posts.Add(entitypost);
                        FindIdSeries.post_id = entitypost.post_id;// gan lai
                        data.Entry(FindIdSeries).State = EntityState.Modified;
                        data.SaveChanges(); //xử lý 2 vvd ( gán giá trị lại cho nhau và update cái serri)
                    }
                }
                else // th ng ta ko chọn seri 
                {
                    entitypost.post_review = item.post_review;
                    entitypost.post_content = item.post_content;
                    entitypost.post_slug = item.post_slug;
                    entitypost.post_tag = item.post_tag;
                    entitypost.IDcategory = item.IDcategory;
                    entitypost.post_teaser = UploadPosttester(item.post_teaser);
                    entitypost.post_title = item.post_title;
                    entitypost.create_date = item.create_date;
                    data.Posts.Add(entitypost);
                    data.SaveChanges();
                    // chỉ cho ng ta tạo bài viết 
                }
                return RedirectToAction("Index", new { create = true });
            }
        }
        [ValidateInput(false)]
        public ActionResult Viewupdate(string id) //dau vao la id 
        {
            var update = data.Posts.Find(id);// dau du lieu o trong bang post
            ViewData["selectcategory"] = data.Categories.ToList();
           
            ViewData["selectseries"] = data.Seriess.Where(x => x.post_id == null).ToList();//lay ra danh sach ma series dc phep gan cho bai post 
            var resultidseries = data.Seriess.Where(x => x.post_id == id).FirstOrDefault();// lay ra series ma chua id cua bai post can update
            if(resultidseries != null) 
            {
                ViewData["selectseriesid"] = resultidseries;
            }
            return View(update);// dau ra la mot object
        }
        [ValidateInput(false)]
        public ActionResult Update(PostRequest item, string seriesID) 
        {
            ViewData["selectcategory"] = data.Categories.ToList();
            ViewData["selectseries"] = data.Seriess.ToList();
            PostRequestValidator validator = new PostRequestValidator();
            var result = validator.Validate(item);
            if (!result.IsValid)
            {
                {
                    ViewData["checkvalidatepostupdate"] = (result.Errors);
                    return View("Viewupdate");
                }
            }
            else 
            {
                var entitypost = new Post();
                if(seriesID != "") 
                {
                    entitypost.post_id = item.post_id;
                    entitypost.post_review = item.post_review;
                    entitypost.post_content = item.post_content;
                    entitypost.post_slug = item.post_slug;
                    entitypost.post_tag = item.post_tag;
                    entitypost.IDcategory = item.IDcategory;
                    entitypost.post_teaser = UploadPosttester(item.post_teaser);
                    entitypost.post_title = item.post_title;
                    entitypost.create_date = item.create_date;
                    entitypost.edit_date = item.edit_date;
                    data.Entry(entitypost).State = EntityState.Modified;
                    var Findseries = data.Seriess.Where(x => x.post_id == item.post_id).FirstOrDefault();// đối cũ => id post 
                    data.Seriess.Remove(Findseries);
                    var seriUpdate = data.Seriess.Where(x => x.seriesID == seriesID).FirstOrDefault();
                    if (seriUpdate != null)
                    {
                        seriUpdate.post_id = entitypost.post_id;
                        data.Entry(seriUpdate).State = EntityState.Modified;
                    }
                    data.SaveChanges();
                    
                }
                else 
                {
                    entitypost.post_id = item.post_id;
                    entitypost.post_review = item.post_review;
                    entitypost.post_content = item.post_content;
                    entitypost.post_slug = item.post_slug;
                    entitypost.post_tag = item.post_tag;
                    entitypost.IDcategory = item.IDcategory;
                    entitypost.post_teaser = UploadPosttester(item.post_teaser);
                    entitypost.post_title = item.post_title;
                    entitypost.create_date = item.create_date;
                    entitypost.edit_date = item.edit_date;
                    data.Entry(entitypost).State = EntityState.Modified;
                    data.SaveChanges();
                }
                return RedirectToAction("Index", new { update = true });
            }
        }
        public ActionResult Delete(string idPost)
        {
            // find idSeri qua idPost 
            var postResult = data.Posts.Find(idPost); // => return 1 object post 

            // post object contain id_seri
            if(postResult != null)
            {
                
                var seriResult = data.Seriess.Where(x=> x.post_id == postResult.post_id).FirstOrDefault();
                // nếu seriResult có giá trị => xóa bthg
                // nếu ko có giá trị => lấy gì mà xóa 
                if(seriResult != null) 
                {
                    data.Seriess.Remove(seriResult);
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
            var detail = data.Posts.Find(id);
            return View(detail);
        }
    }
}