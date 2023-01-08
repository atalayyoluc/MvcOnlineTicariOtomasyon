using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        public PersonelController()
        {
            List<SelectListItem> deger1 = (from x in context.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString(),
                                           }).ToList();
            ViewBag.departman = deger1;
        }
        Context context= new Context(); 
        public ActionResult Index()
        {
            var degerler=context.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
          

            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var personel = context.Personels.Find(id);
            return View(personel);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personel person)
        {
            var personel = context.Personels.Find(person.PersonelID);
            personel.PersonelAd= person.PersonelAd;
            personel.PersonelSoyad=person.PersonelSoyad;
            personel.PersonelGorsel=person.PersonelGorsel;
            personel.DepartmanId=person.DepartmanId;
            personel.TelefonNumarası = person.TelefonNumarası;
            personel.Adress=person.Adress;
            personel.Hakkında = person.Hakkında;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}