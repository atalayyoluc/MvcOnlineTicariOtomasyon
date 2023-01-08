using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        public UrunController()
        {
            List<SelectListItem> deger1 = (from x in context.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAdi,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.Deger1 = deger1;
        }
        // GET: Urun
        Context context=new Context();
    
        public ActionResult Index()
        {
            var urunler = context.Uruns.Where(x=>x.Durum==true).ToList();
  
            return View(urunler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {



            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = context.Uruns.Find(id);
            deger.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UrunGetir(int id)
        {
           
            var urun=context.Uruns.Find(id);
            return View(urun);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urun u )
        {
            var urun = context.Uruns.Find(u.UrunID);
            urun.AlisFiyati=u.AlisFiyati;
            urun.Durum=u.Durum;
            urun.CategoryId= u.CategoryId;
            urun.UrunAdi=u.UrunAdi;
            urun.Marka=u.Marka;
            urun.UrunGorsel=u.UrunGorsel;
            urun.Stock=u.Stock;
            urun.SatisFiyati = u.SatisFiyati;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}