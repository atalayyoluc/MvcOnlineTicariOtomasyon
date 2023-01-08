using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context context=new Context();
        public ActionResult Index()
        {
          var kategoriler=  context.Kategoris.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            context.Kategoris.Add(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = context.Kategoris.Find(id);
            context.Kategoris.Remove(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori=context.Kategoris.Find(id);
            return View(kategori);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var ktgr = context.Kategoris.Find(kategori.CategoryID);
            ktgr.KategoriAdi = kategori.KategoriAdi;
            context.SaveChanges();
            return RedirectToAction("Index");   
        }

    }
}