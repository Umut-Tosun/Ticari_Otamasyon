using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler p)
        {
            p.durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir",cari);
        }
        [HttpGet]
        public ActionResult CariGuncelle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariGuncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var deger = c.Carilers.Find(p.CariID);
            deger.CariAd = p.CariAd;
            deger.CariSoyad = p.CariSoyad;
            deger.CariSehir = p.CariSehir;
            deger.durum = p.durum;
            deger.CariMail = p.CariMail;
            c.SaveChanges();    
           return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis (int id)
        {
            
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var z = c.SatisHarekets.Where(x => x.Cariid == id).Select(y => y.Cariler.CariAd + " " + y.Cariler.CariSoyad).FirstOrDefault();
            ViewBag.deger1 = z;
            return View(degerler);
        }
    }
}