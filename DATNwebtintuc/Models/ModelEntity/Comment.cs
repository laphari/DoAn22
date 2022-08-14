using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelEntity
{
    public class Comment
    {
        public Comment()
        {
            this.commentID = Guid.NewGuid().ToString();
        }
        [Key]
        public string commentID { get; set; }
        public string commentName { get; set; }
        public string commentContent { get; set; }
        public DateTime dateComment { get; set;}
        public string post_id { get; set; }
        public string gender { get; set;}
        public virtual Post Post { get; set; }
    }
}