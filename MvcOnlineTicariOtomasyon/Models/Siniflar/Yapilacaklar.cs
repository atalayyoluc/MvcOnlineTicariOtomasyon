using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Yapilacaklar
    {
        [Key]
        public int YapilacakID { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(120)]
        public string Baslik { get; set; }
        public bool Durum { get; set; } = false;
    }
}