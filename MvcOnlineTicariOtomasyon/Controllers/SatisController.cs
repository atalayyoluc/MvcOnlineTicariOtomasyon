using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context context = new Context();
        public SatisController()
        {
            List<SelectListItem> urunler = (from u in context.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = u.UrunAdi,
                                                Value=u.UrunID.ToString()
                                            }).ToList();

            List<SelectListItem> cariler = (from c in context.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = c.CariAd + " " + c.CariSoyad,
                                                Value = c.CariID.ToString()
                                            }).ToList();
            List<SelectListItem> personeller=(from p in context.Personels.ToList()
                                              select new SelectListItem
                                              {
                                                  Text=p.PersonelAd +" " +p.PersonelSoyad,
                                                  Value= p.PersonelID.ToString()
                                              }).ToList() ;
            ViewBag.Urun=urunler;
            ViewBag.Cariler=cariler;
            ViewBag.Personeller=personeller;


        }
        // GET: Satis
        public ActionResult Index()
        {
            var degerler = context.SatisHarakets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHaraket satisHaraket)
        {
            context.SatisHarakets.Add(satisHaraket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id) 
        {
            var deger = context.SatisHarakets.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult SatisGuncelle(SatisHaraket satisHaraket)
        {
            var satis = context.SatisHarakets.Find(satisHaraket.SatisID);
            satis.CariId=satisHaraket.CariId;
            satis.UrunId= satisHaraket.UrunId;
            satis.PersonelId=satisHaraket.PersonelId;
            satis.Adet=satisHaraket.Adet;
            satis.Fiyat=satisHaraket.Fiyat;
            satis.ToplamTutar = satisHaraket.ToplamTutar;
            satis.Tarih=satisHaraket.Tarih;
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            ViewBag.satisId = id;
            var degerler=context.SatisHarakets.Where(x=>x.SatisID==id).ToList();
            return View(degerler);
        }
    }
}