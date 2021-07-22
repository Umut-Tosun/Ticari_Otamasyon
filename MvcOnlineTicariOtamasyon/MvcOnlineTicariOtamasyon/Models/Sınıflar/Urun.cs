using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.Sınıflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool durum { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string UrunGorsel { get; set; }
        public int Kategoriid { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}