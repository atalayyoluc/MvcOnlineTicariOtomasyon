using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }
        [Column(TypeName=("Varchar"))]
        [StringLength(100)]
        public string UrunAdi { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30)]
        public string Marka { get; set;}
        public short Stock { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; } = true;
        [Column(TypeName = ("Varchar"))]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public int CategoryId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHaraket> SatisHarakets { get; set; }

    }
}