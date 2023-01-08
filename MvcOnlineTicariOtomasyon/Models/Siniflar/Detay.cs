using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayId { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(100)]
        public string UrunAdi { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(5000)]
        public string UrunBilgi { get; set; }

    }
}