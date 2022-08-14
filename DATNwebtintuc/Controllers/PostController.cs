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
        [Authorize(Roles ="Admin")]
        public ActionResult Viewcreate() 
        {
            ViewData["selectcategory"] = data.Categories.ToList();
            ViewData["selectstickpost"] = data.StickyPostss.Where(x => x.post_id == null).ToList();
            ViewData["selectseries"] = data.Seriess.Where(x => x.post_id == null).ToList();
            return View();// khi ma giao dien load len can du lieu tra ve
        }
        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(PostRequest item , string seriesID) 
        {
            ViewData["selectcategory"] = data.Categories.ToList();
            ViewData["selectseries"] = data.Seriess.Where(x => x.post_id == null).ToList();
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
                var entitypost = new Post();
                entitypost.post_review = item.post_review;
                entitypost.post_content = item.post_content;
                entitypost.post_slug = item.post_slug;
                entitypost.post_tag =  string.Join("", item.post_tag.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                entitypost.IDcategory = item.IDcategory;
                entitypost.stickypost = item.stickypost;
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
                if(seriesID == "") //mk k chon cai gi
                {
                    data.SaveChanges();
                    return RedirectToAction("Index", new { create = true });
                }
                else 
                {
                    if(seriesID != "") // co gia tri
                    {
                        var Findseriesid = data.Seriess.Find(seriesID);//tim series
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
                    data.SaveChanges();
                    return RedirectToAction("Index", new { create = true });
                }
            }
        }
        [ValidateInput(false)]
        public ActionResult Viewupdate(string id, string seriesID) //dau vao la id 
        {
            var update = data.Posts.Find(id);// find thong tin bai post thong qua id
            ViewData["selectcategory"] = data.Categories.ToList();
            var updateseries = data.Seriess.Where(x => x.post_id==id).FirstOrDefault();//lay ra danh sach ma series dc phep gan cho bai post 
            ViewData["selectseriesed"] = data.Seriess.Where(x => x.post_id == null).ToList();
            
            {
                ViewData["selectseries"] = updateseries;// no gan vao update series de ti nua lay ra hien thi ra ben ngoai
            }
            return View(update);// dau ra la mot object
        }
        [ValidateInput(false)]
        public ActionResult Update(string post_teaser,PostRequest item, string seriesID,string idStickyPosts)
        {
            ViewData["selectcategory"] = data.Categories.ToList(); // not null 
            ViewData["selectseriesed"] = data.Seriess.Where(x => x.post_id == null).ToList(); // allow null 
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
                entitypost.stickypost = item.stickypost;
              if (seriesID != "") 
                {
                    // tim no
                    var findSeries = data.Seriess.Where(x => x.post_id == item.post_id).FirstOrDefault();// tim doi tuong
                    if (findSeries != null)// neu ma nguoi dung chon series
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
        public ActionResult Detail(string id,int morecmt=1) 
        {
            ViewData["advertismentimage"] = data.Advertisements.Where(x => x.typeAdvertisement == "Image").Take(6).ToList();
            var detail = data.Posts.Find(id);//tim id chi tiet cua bai viet
            var stringhastags = "#";//cat hastags thanh mot mang keyword
            var hastags = stringhastags.ToCharArray();// cai list hastags ra thanh mot mang keyword
            var listTag = detail.post_tag.Trim().Split(hastags);//loai khoang trang
            ViewData["nameseries"] = data.Seriess.Where(x => x.post_id == detail.post_id).FirstOrDefault();
            ViewData["gethastags"] = listTag;
            detail.ViewCount = detail.ViewCount + 1;
            data.Entry(detail).State = EntityState.Modified;
            data.SaveChanges();
            ViewData["selectpostanddetail"] = data.Posts.OrderByDescending(x => x.create_date).Take(3).ToList();
            ViewData["FindIdPostcomment"] = data.Comments.Where(x => x.post_id == id).OrderByDescending(x => x.dateComment).ToList();
            return View(detail);
        }
        public ActionResult FindHastag(string keyWord)
        {
            ViewBag.keyword = keyWord;//gan cai keyword nguoi ta tim ra ngoai
            var listFindHastag = data.Posts.Where(x => x.post_title.ToUpper().Contains(keyWord.ToUpper())).Select((x) => new HastagRespon//contains dung de so sanh gan dung
            {
                post_id = x.post_id,
                post_teaser = x.post_teaser ,
                post_title = x.post_title , 
                create_date = x.create_date , 
                name_category = x.Category.namecategory
            }).ToList();
            return View(listFindHastag);//vi muon tra ve cai listfindhastags
        }
    }
}