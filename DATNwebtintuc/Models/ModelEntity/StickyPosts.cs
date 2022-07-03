using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelEntity
{
    public class StickyPosts
    {
        public StickyPosts()
        {
            idStickyPosts = Guid.NewGuid().ToString();
        }
        [Key]
        public string idStickyPosts { get; set; }
        public int priority { get; set; } // do uu tien
        public string post_id { get; set;}
        public virtual Post Post { get; set;}
    }
}