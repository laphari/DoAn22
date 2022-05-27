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

        }
        [Key]
        public int id { get; set; }
        public int priority { get; set; }
        public string post_id { get; set; }
        public virtual Post Post { get; set; }
    }
}