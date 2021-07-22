using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.Sınıflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        
        public string PersonelGorsel { get; set; }
        public bool durum { get; set; }
        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}