using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelEntity
{
    public class Tags
    {
        [Key]
        public int TagID { get; set; }
        public string TagName { get; set; }
        public int post_id { get; set; }
        public virtual Post Post { get; set; }
    }
}