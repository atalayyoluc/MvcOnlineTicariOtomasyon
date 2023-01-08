using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30,ErrorMessage ="Ad en fazla 30 karakter olablir.")]
        public string CariAd { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(20)]
        public string Sifre { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30, ErrorMessage = "Soyad en fazla 30 karakter olablir.")]
        public string CariSoyad { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(15, ErrorMessage = "Sehir en fazla 15 karakter olablir.")]
        
        public string CariSehir { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(50, ErrorMessage = "Mail en fazla 30 karakter olablir.")]
        public string CariMail { get; set; }
        public bool Durum { get; set; } = false;
        public ICollection<SatisHaraket> SatisHarakets { get; set; }

    }
}