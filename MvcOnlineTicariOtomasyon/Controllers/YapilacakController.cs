using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context context=new Context();
        public ActionResult Index()
        {

            var Yapilacaklar = context.Yapilacaklars.Where(x => !x.Durum).ToList();
            return View(Yapilacaklar);
        }
    }
}