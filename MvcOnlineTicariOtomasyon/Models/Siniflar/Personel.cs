using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Compilation;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }
        public string  Hakkında { get; set; }
        public string  TelefonNumarası { get; set; }
        public string Adress { get; set; }

        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }
        public ICollection<SatisHaraket> SatisHarakets { get; set; }

    }
}   