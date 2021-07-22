using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime Tarih { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string VergiDairesi { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(5)]
        public string Saat { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        public decimal ToplamTutar { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}