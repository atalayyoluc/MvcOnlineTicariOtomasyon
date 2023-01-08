using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
           Context context = new Context();
        
        // GET: Departman   
        public ActionResult Index()
        {
           
            var degerler = context.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            context.Departmans.Add(departman);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var departman = context.Departmans.Find(id);
            departman.Durum=false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DepartmanGetir(int id)
        {
            var departman = context.Departmans.Find(id);
            return View(departman);
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman depart) 
        {
            var departman = context.Departmans.Find(depart.DepartmanID);
            departman.DepartmanAd = depart.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index"); 
        }
        public ActionResult DepartmanDetay(int id)
        {
            var deger = context.Personels.Where(x => x.DepartmanId == id).ToList();
            var departman=context.Departmans.Where(x=>x.DepartmanID==id).Select(x=>x.DepartmanAd).FirstOrDefault();
            ViewBag.dpt = departman;
            return View(deger);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
           ViewBag.personelId=id;
            var degerler = context.SatisHarakets.Where(x => x.PersonelId == id).ToList();
            var personel=context.Personels.Where(x=>x.PersonelID==id).Select(x=>x.PersonelAd + " " + x.PersonelSoyad).FirstOrDefault();
            ViewBag.person = personel;
            return View(degerler);
        }

    }
}