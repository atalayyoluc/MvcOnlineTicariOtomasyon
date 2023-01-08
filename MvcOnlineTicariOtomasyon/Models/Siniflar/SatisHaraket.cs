using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHaraket
    {
        [Key]
        public int SatisID { get; set; }
        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }
        public int CariId { get; set; }
        public virtual Cariler Cariler { get; set; }
        public int PersonelId { get; set; }
        public virtual Personel Personel { get; set; }
        public DateTime Tarih { get; set; } =DateTime.Parse(DateTime.Now.ToShortDateString());
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
         
    }
}