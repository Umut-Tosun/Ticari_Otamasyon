using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.Sınıflar
{
    public class Yapilicaklar
    {
        [Key]
        public int YapilicakID { get; set; }
        public string Baslik { get; set; }
        public bool Durum { get; set; }

    }
}