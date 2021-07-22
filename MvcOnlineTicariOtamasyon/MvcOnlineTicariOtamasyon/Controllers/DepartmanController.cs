using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.ToList();
            return View(degerler);

        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman p)
        {
            p.Durum = true;
            c.Departmans.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var deger = c.Departmans.Find(id);
            if (deger.Durum == true)
            {
                deger.Durum = false;
            }
            else
            {
                deger.Durum = true;
            }
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var deger = c.Departmans.Find(id);
            return View("DepartmanGetir",deger);
        }
        [HttpGet]
        public ActionResult DepartmanGuncelle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman p)
        {
            var deger = c.Departmans.Find(p.DepartmanID);
            deger.DepartmanAd = p.DepartmanAd;
            deger.Durum = p.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x=>x.Departmanid==id).ToList();
            var y = c.Departmans.Find(id);
            ViewBag.deger1 = y.DepartmanAd;

            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var z = c.SatisHarekets.Where(x => x.Personelid == id).Select(y => y.Personel.PersonelAd +" "+y.Personel.PersonelSoyad).FirstOrDefault();
            ViewBag.deger1 = z;
            return View(degerler);
        }
    }
}