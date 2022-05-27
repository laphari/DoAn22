using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelEntity
{
    public class Series
    {
        public Series() 
        {

        }
        [Key]
        public int seriesID { get; set; }
        public string seriesName { get; set; }
        public int post_id { get; set; }
        public virtual Post Post { get; set; }
    }
}