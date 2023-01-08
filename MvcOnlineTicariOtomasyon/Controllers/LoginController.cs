using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context context=new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult KayıtOl()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult KayıtOl(Cariler cariler)
        {
            context.Carilers.Add(cariler);
            context.SaveChanges();
            return PartialView();
        }
    }
}