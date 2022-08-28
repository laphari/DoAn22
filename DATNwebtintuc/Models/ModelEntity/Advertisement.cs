using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Models.ModelEntity
{
    public class Advertisement
    {
        public Advertisement() 
        {
            this.idAdvertisement = Guid.NewGuid().ToString();
        }
        [Key]
        public string idAdvertisement { get; set;}
        public string linkAdvertisement { get; set;}
        public string typeAdvertisement { get; set;}
        public string urlAdvertisment { get; set;}
    }
}