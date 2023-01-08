using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(50)]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; } = true;
        public ICollection<Personel> Personels { get; set; }

    }
}