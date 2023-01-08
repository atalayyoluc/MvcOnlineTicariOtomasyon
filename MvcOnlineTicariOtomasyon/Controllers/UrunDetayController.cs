using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context context = new Context();
        // GET: UrunDetay
        public ActionResult Index()
        {
            Class1 cs= new Class1();
            cs.Uruns= context.Uruns.Where(x => x.UrunID == 1).ToList();
            cs.Detays = context.Detays.Where(y => y.DetayId == 1).ToList();
            //var degerler=context.Uruns.Where(x=>x.UrunID==1).ToList();
            return View(cs);
        }
    }
}