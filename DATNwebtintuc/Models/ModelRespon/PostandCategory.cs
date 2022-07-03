using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelRespon
{
    public class PostandCategory
    {
        public string post_id { get; set; }
        public string post_title { get; set; }
        public DateTime? create_date { get; set; }
        public string post_teaser { get; set; }
        public string IDcategory { get; set; }
        public string namecategory { get; set; }
    }
}