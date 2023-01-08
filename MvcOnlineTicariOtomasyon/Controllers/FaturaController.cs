using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context context=new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var liste = context.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        public ActionResult FaturaEkle(Faturalar faturalar)
        {
            context.Faturalars.Add(faturalar);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura=context.Faturalars.Find(id);
            return View(fatura);
        }
        [HttpPost]
        public ActionResult FaturaGuncelle(Faturalar fatura)
        {
            var faturalar = context.Faturalars.Find(fatura.FaturaID);

            faturalar.FaturaSıraNo = fatura.FaturaSıraNo;
            faturalar.FaturaSeriNo= fatura.FaturaSeriNo;
            faturalar.TeslimAlan=fatura.TeslimAlan;
            faturalar.TeslimEden=fatura.TeslimEden;
            faturalar.VergiDairesi=fatura.VergiDairesi;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
        
            var deger = context.FaturaKalems.Where(x => x.FaturaID == id).ToList();
            
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniKalemGiris()
        {
            List<SelectListItem> deger1 = (from x in context.Faturalars.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.FaturaSıraNo,
                                               Value = x.FaturaID.ToString(),
                                           }).ToList();
            ViewBag.Deger1 = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult YeniKalemGiris(FaturaKalem faturaKalem)
        {
            faturaKalem.Tutar = faturaKalem.Miktar * faturaKalem.BirimFiyat;

            context.FaturaKalems.Add(faturaKalem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}