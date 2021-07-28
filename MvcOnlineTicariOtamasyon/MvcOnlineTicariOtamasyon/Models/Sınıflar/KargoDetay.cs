using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.Sınıflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string Aciklama { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Personel { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }
    }
}