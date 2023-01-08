using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YazdirController : Controller
    {
        Context context = new Context();
        // GET: Yazdır
        public ActionResult PersonelSatis(int id)
        {
            var degerler = context.SatisHarakets.Where(x => x.PersonelId == id).ToList();
            var person = context.Personels.Where(x => x.PersonelID == id).Select(x => x.PersonelAd + " " + x.PersonelSoyad).FirstOrDefault();
            ViewBag.personel = person;
            return View(degerler);            
        }
        public ActionResult CariAlis(int id) {
            var degerler = context.SatisHarakets.Where(x => x.CariId == id).ToList();
            var cari = context.Carilers.Where(x => x.CariID == id).Select(x => x.CariAd + " " + x.CariSoyad).FirstOrDefault();
            ViewBag.cariler = cari;
            return View(degerler);
        }
        public ActionResult SatisDetaylari(int id)
        {
            var degerler = context.SatisHarakets.Where(x => x.SatisID == id).ToList();
            ViewBag.satisId = id;
            return View(degerler);
        }
    }
}