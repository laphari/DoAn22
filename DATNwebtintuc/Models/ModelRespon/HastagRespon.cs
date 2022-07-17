using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelRespon
{
    public class HastagRespon
    {
        public string post_id { get; set; }
        public string post_title { get; set; }
        public string post_teaser { get; set; }
        public string name_category { get; set; }
        public DateTime? create_date { get; set; }
    }
}