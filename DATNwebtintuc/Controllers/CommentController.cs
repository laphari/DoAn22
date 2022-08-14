using DATNwebtintuc.Models.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNwebtintuc.Controllers
{
    public class CommentController : Controller
    {
        private DATNwebtintucContext data = new DATNwebtintucContext();
        // GET: Comment
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var thongtin = data.Comments.OrderByDescending(x => x.dateComment).ToList();
            return View(thongtin);
        }
        public ActionResult Savecomment(string IDpost,string nameuser, string nameusercomment,string usergender) 
        {
            var entitycomment = new Comment();
            entitycomment.post_id = IDpost;
            entitycomment.dateComment = DateTime.Now;
            entitycomment.commentName = nameuser;
            entitycomment.commentContent = nameusercomment;
            if (usergender == "Man") 
            {
                entitycomment.gender = "0";
            }
            else 
            {
                entitycomment.gender = "1";
            }
            data.Comments.Add(entitycomment);
            data.SaveChanges();
            return RedirectToAction("Detail","Post",new { id=IDpost});
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Remove(string id)
        {
            var delete = data.Comments.Find(id);
            data.Comments.Remove(delete);
            data.SaveChanges();
            return RedirectToAction("Index", new { delete = true });
        }
    }
}