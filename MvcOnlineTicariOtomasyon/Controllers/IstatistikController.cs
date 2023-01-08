using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();
        // GET: İstatistik
        public ActionResult Index()
        {
            DateTime bugun = DateTime.Today;

            var ToplamCari=context.Carilers.Count().ToString();
            ViewBag.ToplamCari=ToplamCari;
            var UrunSayisi=context.Uruns.Count().ToString();
            ViewBag.UrunSayisi=UrunSayisi;
            var PersonelSayisi=context.Personels.Count().ToString();
            ViewBag.PersonelSayisi=PersonelSayisi;
            var KategoriSayisi=context.Kategoris.Count().ToString();
            ViewBag.KategoriSayisi=KategoriSayisi;
            var ToplamStok=context.Uruns.Sum(x=>x.Stock).ToString();
            ViewBag.ToplamStok=ToplamStok;
            var KritikSayi=context.Uruns.Count(x=>x.Stock<=30).ToString();
            ViewBag.KritikSayi=KritikSayi;
            var MarkaSayisi = (from x in context.Uruns
                               select x.Marka).Distinct().Count().ToString();
            ViewBag.MarkaSayisi=MarkaSayisi;
            var MaxFiyatliUrun = (from x in context.Uruns
                                  orderby x.SatisFiyati descending select x.UrunAdi).FirstOrDefault();
            ViewBag.MaxFiyatliUrun=MaxFiyatliUrun;
            var MinFiyatliUrun= (from x in context.Uruns
                                 orderby x.SatisFiyati select x.UrunAdi).FirstOrDefault();
            ViewBag.MinFiyatliUrun=MinFiyatliUrun;
            var BuzdolabiSayisi=context.Uruns.Count(x=>x.UrunAdi=="Buzdolabi").ToString();
            var LaptopSayisi = context.Uruns.Count(x => x.UrunAdi == "Laptop").ToString();
            ViewBag.BuzdolabiSayisi=BuzdolabiSayisi;
            ViewBag.LaptopSayisi = LaptopSayisi;
            var KasadakiToplam=context.SatisHarakets.Sum(x=>x.ToplamTutar).ToString();
            ViewBag.KasadakiToplam=KasadakiToplam;
            var BuGunkiSatisler=context.SatisHarakets.Count(x=>x.Tarih==bugun).ToString();
            ViewBag.BuGunkiSatisler=BuGunkiSatisler;
            try
            {   var BuGunKasa = context.SatisHarakets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar).ToString();
                ViewBag.BuGunKasa = BuGunKasa;
            }
            catch (Exception ex)
            {
                 var BuGunKasa = 0;
                 ViewBag.BuGunKasa = BuGunKasa;
            }

            var EnFazlaBulunanMarka = context.Uruns.GroupBy(x=>x.Marka).OrderByDescending(x=>x.Count()).Select(x=>x.Key).FirstOrDefault();
            ViewBag.EnFazlaBulunanMarka = EnFazlaBulunanMarka;
            var EnCokSatanUrun =context.Uruns.Where(u=>u.UrunID==(context.SatisHarakets.GroupBy(x => x.UrunId).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault())).Select(x=>x.UrunAdi).FirstOrDefault();
            ViewBag.EnCokSatanUrun= EnCokSatanUrun;

            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = (from x in context.Carilers
                         group x by x.CariSehir into g
                         select new SinifGrup
                         {
                             Sehir = g.Key,
                             Sayi=g.Count(),
                         }).ToList();
            return View(sorgu);
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = (from p in context.Personels
                          join x in context.Departmans
                          on p.DepartmanId equals x.DepartmanID
                          group p by new { p.DepartmanId,x.DepartmanAd } into g
                          select new SinifGrup2
                          {
                              DepartmanAdi=g.Key.DepartmanAd,   
                              Sayi=g.Count(),

                          }).ToList();
         
            return PartialView(sorgu2);
        }
        public PartialViewResult Partial2()
        {
            var sorgu2 = (from p in context.Uruns
                          join x in context.Kategoris
                          on p.CategoryId equals x.CategoryID
                          group p by new { p.CategoryId, x.KategoriAdi } into g
                          select new UrunKategoriDTO
                          {
                              Kategori = g.Key.KategoriAdi,
                              Sayi = g.Count(),

                          }).ToList();
            return PartialView(sorgu2);
        }
        public PartialViewResult Partia3()
        {
            var sorgu=context.Carilers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = context.Uruns.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial5()
        {
            var sorgu2 = (from p in context.Uruns
                           group p by p.Marka into g
                          select new MarkaSayi
                          {
                              Marka = g.Key,
                              Sayi = g.Count(),

                          }).ToList();
            return PartialView(sorgu2);
        }
    }
}