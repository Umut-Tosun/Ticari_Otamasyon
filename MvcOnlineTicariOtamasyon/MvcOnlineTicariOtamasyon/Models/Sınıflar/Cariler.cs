using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.Sınıflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter Girebilirsiniz .")]
        [MinLength(2, ErrorMessage = "En az 3 Karakter Olmalıdır .")]
        [Required(ErrorMessage ="Bu Alan Boş Geçilemez !")]
        public string CariAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Girebilirsiniz .")]
        [MinLength(2, ErrorMessage = "En az 3 Karakter Olmalıdır .")]
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez !")]
        public string CariSoyad { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage = "En Fazla 13 Karakter Girebilirsiniz .")]
        [MinLength(2, ErrorMessage = "En az 4 Karakter Olmalıdır .")]
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez !")]
        public string CariSehir { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Girebilirsiniz .")]
        [MinLength(2, ErrorMessage = "En az 5 Karakter Olmalıdır .")]
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez !")]
        public string CariMail { get; set; }
       
        public bool durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}