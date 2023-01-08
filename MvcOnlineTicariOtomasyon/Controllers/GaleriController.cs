using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context context = new Context();
        public ActionResult Index()
        {
            var resim = context.Uruns.ToList();
            return View(resim);
        }
    }
}