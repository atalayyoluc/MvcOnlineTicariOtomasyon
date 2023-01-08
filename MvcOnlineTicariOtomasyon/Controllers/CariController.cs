using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Carilers.Where(x=>x.Durum).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler cariler)
        {
            context.Carilers.Add(cariler);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cari = context.Carilers.Find(id);
            cari.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = context.Carilers.Find(id);
          
            return View(cari);
        }
        [HttpPost]
        public ActionResult CariGuncelle(Cariler cariler)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = context.Carilers.Find(cariler.CariID);
            cari.CariAd=cariler.CariAd;
            cari.CariSoyad=cariler.CariSoyad;
            cari.CariMail=cariler.CariMail;
            cari.CariSehir=cariler.CariSehir;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            ViewBag.cariId = id;    
            var cr = context.Carilers.Where(x => x.CariID == id).Select(x => x.CariAd + " " + x.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            var degerler=context.SatisHarakets.Where(x=>x.CariId==id).ToList();
            return View(degerler);
        }
    }
}