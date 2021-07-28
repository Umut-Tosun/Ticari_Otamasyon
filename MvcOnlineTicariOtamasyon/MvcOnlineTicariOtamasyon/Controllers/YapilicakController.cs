using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class YapilicakController : Controller
    {
        // GET: Yapilicak
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.yapilicaklars.Count().ToString();          
            var deger2 = c.yapilicaklars.Where(x => x.Durum == false).Count().ToString();
            var deger3 = c.yapilicaklars.Where(x => x.Durum == true).Count().ToString();
            var deger4 = c.yapilicaklars.Max(x=>x.Baslik);

            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;

            var sart = c.yapilicaklars.Where(x=>x.Durum==true).ToList();
            return View(sart);
        }
    }
}